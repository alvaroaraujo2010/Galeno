//- MARMOTA-GENCODE: VERSION 2.0 - 25/07/2015 09:54:29 PM
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
using Hospitalizacion.Modelo;

namespace Hospitalizacion.VistaModelo
{
    /// <summary>
    /// <para>TABLA: hosconfigmodulo</para>
    /// <para>DESCRIPCION:
    ///  Configuración parametros generales de funcionamiento modulo
    ///  hospitalización
    /// </para>
    /// </summary>
    public class VistaModeloHosconfigmoduloBase : ViewModelBase, IDataErrorInfo
    {
        //------------------------------------------------
        //-Identificador unico de esta Clase
        //------------------------------------------------
        public String gcrIdVistaModeloForm = "HOS008";
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
        //HOSCONFIGMODULO : Configuración modulo hospitalización
        //------------------------------------------------
        #region Notificacion campos: HOSCONFIGMODULO
        #region G1Hos_codsys_hoxx: Codigo configuración
        public const string gcrNomProp_G1Hos_codsys_hoxx = "G1Hos_codsys_hoxx";
        private string _g1hos_codsys_hoxx = string.Empty;
        /// <summary>
        /// <para>TABLA: hosconfigmodulo</para>
        /// <para>TABLA NATIVA: hosconfigmodulo</para>
        /// <para>CAMPO: Codigo configuración</para>
        /// <para>NOMBRE: g1hos_codsys_hoxx (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        ///Codigo unico del registro configuración del modulo
        /// </para>
        /// </summary>
        public string G1Hos_codsys_hoxx
        {
            get { return _g1hos_codsys_hoxx; }
            set
            {
                if (_g1hos_codsys_hoxx == value) return;
                _g1hos_codsys_hoxx = value;
                RaisePropertyChanged(gcrNomProp_G1Hos_codsys_hoxx);
            }
        }
        #endregion
        #region G1Hos_epicri_hoxx: Gestión epicrisis
        public const string gcrNomProp_G1Hos_epicri_hoxx = "G1Hos_epicri_hoxx";
        private string _g1hos_epicri_hoxx = string.Empty;
        /// <summary>
        /// <para>TABLA: hosconfigmodulo</para>
        /// <para>TABLA NATIVA: hosconfigmodulo</para>
        /// <para>CAMPO: Gestión epicrisis</para>
        /// <para>NOMBRE: g1hos_epicri_hoxx (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Configuracion obligatoriedad gestion de la epicrisis: 1 = Obligatoria
        /// 2=Opcional (no es obligatria) 3= Obligatoria según horas Minimas
        /// campo (HOS_EPICRH_HOXX)
        /// </para>
        /// </summary>
        public string G1Hos_epicri_hoxx
        {
            get { return _g1hos_epicri_hoxx; }
            set
            {
                if (_g1hos_epicri_hoxx == value) return;
                _g1hos_epicri_hoxx = value;
                RaisePropertyChanged(gcrNomProp_G1Hos_epicri_hoxx);
            }
        }
        #endregion
        #region G1Hos_epicrh_hoxx: Horas estancia epicrisis
        public const string gcrNomProp_G1Hos_epicrh_hoxx = "G1Hos_epicrh_hoxx";
        private int _g1hos_epicrh_hoxx = 0;
        /// <summary>
        /// <para>TABLA: hosconfigmodulo</para>
        /// <para>TABLA NATIVA: hosconfigmodulo</para>
        /// <para>CAMPO: Horas estancia epicrisis</para>
        /// <para>NOMBRE: g1hos_epicrh_hoxx (int:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        /// Numero de horas minimas en estancia para que la epicrisis se
        /// haga obligatoria
        /// </para>
        /// </summary>
        public int G1Hos_epicrh_hoxx
        {
            get { return _g1hos_epicrh_hoxx; }
            set
            {
                if (_g1hos_epicrh_hoxx == value) return;
                _g1hos_epicrh_hoxx = value;
                RaisePropertyChanged(gcrNomProp_G1Hos_epicrh_hoxx);
            }
        }
        #endregion
        #region G1Hos_autegr_hoxx: Autorización egreso
        public const string gcrNomProp_G1Hos_autegr_hoxx = "G1Hos_autegr_hoxx";
        private string _g1hos_autegr_hoxx = string.Empty;
        /// <summary>
        /// <para>TABLA: hosconfigmodulo</para>
        /// <para>TABLA NATIVA: hosconfigmodulo</para>
        /// <para>CAMPO: Autorización egreso</para>
        /// <para>NOMBRE: g1hos_autegr_hoxx (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        /// Gestion de autorizacion de egreso hospitalario: 1=No permitir
        /// antes de registro egreso urgencias/hospitalización 2=Permitir
        /// despues de registro egreso urgencias/Hospitalización
        /// </para>
        /// </summary>
        public string G1Hos_autegr_hoxx
        {
            get { return _g1hos_autegr_hoxx; }
            set
            {
                if (_g1hos_autegr_hoxx == value) return;
                _g1hos_autegr_hoxx = value;
                RaisePropertyChanged(gcrNomProp_G1Hos_autegr_hoxx);
            }
        }
        #endregion
        #region G1Hos_format_hoxx: Gestion formatos
        public const string gcrNomProp_G1Hos_format_hoxx = "G1Hos_format_hoxx";
        private string _g1hos_format_hoxx = string.Empty;
        /// <summary>
        /// <para>TABLA: hosconfigmodulo</para>
        /// <para>TABLA NATIVA: hosconfigmodulo</para>
        /// <para>CAMPO: Gestion formatos</para>
        /// <para>NOMBRE: g1hos_format_hoxx (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        /// Gestion formatos al finalizar atención medica 1= Confirmar
        /// formatos abiertos al finalizar atención 2= No finalizar atencion
        /// cuando hay formatos abiertos
        /// </para>
        /// </summary>
        public string G1Hos_format_hoxx
        {
            get { return _g1hos_format_hoxx; }
            set
            {
                if (_g1hos_format_hoxx == value) return;
                _g1hos_format_hoxx = value;
                RaisePropertyChanged(gcrNomProp_G1Hos_format_hoxx);
            }
        }
        #endregion
        #endregion
        //------------------------------------------------
        //HOSCONFIGMODULO COMBOBOX: Configuración modulo hospitalización
        //------------------------------------------------
        #region Campos ComboBox: HOSCONFIGMODULO
        #region  G1CbHos_epicri_hoxx: Gestión epicrisis
        public const string gcrNomProp_G1CbHos_epicri_hoxx = "G1CbHos_epicri_hoxx";
        private List<CrtForms.ListaComboBox> _g1cbhos_epicri_hoxx;
        /// <summary>
        /// <para>TABLA: hosconfigmodulo</para>
        /// <para>TABLA NATIVA: hosconfigmodulo</para>
        /// <para>CAMPO: Gestión epicrisis</para>
        /// <para>NOMBRE: g1cbhos_epicri_hoxx (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Configuracion obligatoriedad gestion de la epicrisis: 1 = Obligatoria
        /// 2=Opcional (no es obligatria) 3= Obligatoria según horas Minimas
        /// campo (HOS_EPICRH_HOXX)
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbHos_epicri_hoxx
        {
            get { return _g1cbhos_epicri_hoxx; }
            set
            {
                if (_g1cbhos_epicri_hoxx == value) return;
                _g1cbhos_epicri_hoxx = value;
                RaisePropertyChanged(gcrNomProp_G1CbHos_epicri_hoxx);
            }
        }
        #endregion
        #region  G1CbHos_autegr_hoxx: Autorización egreso
        public const string gcrNomProp_G1CbHos_autegr_hoxx = "G1CbHos_autegr_hoxx";
        private List<CrtForms.ListaComboBox> _g1cbhos_autegr_hoxx;
        /// <summary>
        /// <para>TABLA: hosconfigmodulo</para>
        /// <para>TABLA NATIVA: hosconfigmodulo</para>
        /// <para>CAMPO: Autorización egreso</para>
        /// <para>NOMBRE: g1cbhos_autegr_hoxx (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        /// Gestion de autorizacion de egreso hospitalario: 1=No permitir
        /// antes de registro egreso urgencias/hospitalización 2=Permitir
        /// despues de registro egreso urgencias/Hospitalización
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbHos_autegr_hoxx
        {
            get { return _g1cbhos_autegr_hoxx; }
            set
            {
                if (_g1cbhos_autegr_hoxx == value) return;
                _g1cbhos_autegr_hoxx = value;
                RaisePropertyChanged(gcrNomProp_G1CbHos_autegr_hoxx);
            }
        }
        #endregion
        #region  G1CbHos_format_hoxx: Gestion formatos
        public const string gcrNomProp_G1CbHos_format_hoxx = "G1CbHos_format_hoxx";
        private List<CrtForms.ListaComboBox> _g1cbhos_format_hoxx;
        /// <summary>
        /// <para>TABLA: hosconfigmodulo</para>
        /// <para>TABLA NATIVA: hosconfigmodulo</para>
        /// <para>CAMPO: Gestion formatos</para>
        /// <para>NOMBRE: g1cbhos_format_hoxx (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        /// Gestion formatos al finalizar atención medica 1= Confirmar
        /// formatos abiertos al finalizar atención 2= No finalizar atencion
        /// cuando hay formatos abiertos
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbHos_format_hoxx
        {
            get { return _g1cbhos_format_hoxx; }
            set
            {
                if (_g1cbhos_format_hoxx == value) return;
                _g1cbhos_format_hoxx = value;
                RaisePropertyChanged(gcrNomProp_G1CbHos_format_hoxx);
            }
        }
        #endregion
        #endregion
        //------------------------------------------------
        //HOSCONFIGMODULO: Registro Activo y Lista Browser
        //------------------------------------------------
        #region Propiedades de Registro Activo y Lista Browser
        #region propiedad registro activo: TmpG1RegActivo
        public const string gcrNomProp_TmpG1RegActivo = "TmpG1RegActivo";
        private ModeloHosconfigmodulo _tmpg1regactivo;
        /// <summary>
        ///  Registro activo de la tabla: hosconfigmodulo
        /// </summary>
        public ModeloHosconfigmodulo TmpG1RegActivo
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
        public VistaModeloHosconfigmoduloBase()
        {
            fcvIniciarComboBox();
            fcvReiniVariables();
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
                    TmpG1RegActivo.Hos_codsys_hoxx = ModeloHosconfigmodulo.flgAddRegistro(TmpG1RegActivo);
                    G1Hos_codsys_hoxx = TmpG1RegActivo.Hos_codsys_hoxx;
                }
                else
                {
                    fcvCargarRegActivoDesdeVariables();
                    ModeloHosconfigmodulo.fcvActualizar(TmpG1RegActivo);
                }
                if (string.IsNullOrEmpty(G1Hos_codsys_hoxx))
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
            G1Hos_codsys_hoxx = GcrFiltroDatos;
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
                    ModeloHosconfigmodulo.fcvEliminar(TmpG1RegActivo.Hos_codsys_hoxx);
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
                List<ModeloHosconfigmodulo> TmpG1ListaBrow = ModeloHosconfigmodulo.flsListaHosconfigmodulo(GcrFiltroDatos);
                if (TmpG1ListaBrow.Count > 0)
                {
                    TmpG1RegActivo = (ModeloHosconfigmodulo)TmpG1ListaBrow[0];
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
                G1Hos_codsys_hoxx = string.Empty;
                G1Hos_epicri_hoxx = string.Empty;
                G1Hos_epicrh_hoxx = 0;
                G1Hos_autegr_hoxx = string.Empty;
                G1Hos_format_hoxx = string.Empty;
                #endregion
                TmpG1RegActivo = new ModeloHosconfigmodulo();
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
                TmpG1RegActivo.Hos_codsys_hoxx = G1Hos_codsys_hoxx;
                TmpG1RegActivo.Hos_epicri_hoxx = G1Hos_epicri_hoxx;
                TmpG1RegActivo.Hos_epicrh_hoxx = G1Hos_epicrh_hoxx;
                TmpG1RegActivo.Hos_autegr_hoxx = G1Hos_autegr_hoxx;
                TmpG1RegActivo.Hos_format_hoxx = G1Hos_format_hoxx;
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
                G1Hos_codsys_hoxx = TmpG1RegActivo.Hos_codsys_hoxx;
                G1Hos_epicri_hoxx = TmpG1RegActivo.Hos_epicri_hoxx;
                G1Hos_epicrh_hoxx = TmpG1RegActivo.Hos_epicrh_hoxx;
                G1Hos_autegr_hoxx = TmpG1RegActivo.Hos_autegr_hoxx;
                G1Hos_format_hoxx = TmpG1RegActivo.Hos_format_hoxx;
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
                if (!string.IsNullOrEmpty(TmpG1RegActivo.Hos_codsys_hoxx) && GlgSIS_ModoEdicion == false)
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
                    llgReturn = string.IsNullOrEmpty(fcrValidacion("G1Hos_codsys_hoxx")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Hos_epicri_hoxx")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Hos_epicrh_hoxx")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Hos_autegr_hoxx")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Hos_format_hoxx"));
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
                if (!string.IsNullOrEmpty(TmpG1RegActivo.Hos_codsys_hoxx) && GlgSIS_ModoEdicion == false)
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
                if (!string.IsNullOrEmpty(G1Hos_codsys_hoxx))
                {
                    GcrFiltroDatos = G1Hos_codsys_hoxx;
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
                //HOS_EPICRI_HOXX: Gestión epicrisis
                //-------------------------------------------------
                #region HOS_EPICRI_HOXX: Gestión epicrisis
                string lcrG11Seleccion = "1,2,3";
                string lcrG11Descripcion = "Diligenciar epicrisis de manera obligatoria,Epicrisis es opción (no es obligatoria),Epicrisis hobligatoria segun horas de estancia";
                G1CbHos_epicri_hoxx = new List<CrtForms.ListaComboBox>();
                G1CbHos_epicri_hoxx = CrtForms.flsCargarLista(lcrG11Seleccion, lcrG11Descripcion);
                #endregion
                //-------------------------------------------------
                //HOS_AUTEGR_HOXX: Autorización egreso
                //-------------------------------------------------
                #region HOS_AUTEGR_HOXX: Autorización egreso
                string lcrG12Seleccion = "1,2";
                string lcrG12Descripcion = "No autorizar antes de registro egreso urgencias/Hospitalización,Permitir autorizar antes de egreso urgencias/Hospitalización";
                G1CbHos_autegr_hoxx = new List<CrtForms.ListaComboBox>();
                G1CbHos_autegr_hoxx = CrtForms.flsCargarLista(lcrG12Seleccion, lcrG12Descripcion);
                #endregion
                //-------------------------------------------------
                //HOS_FORMAT_HOXX: Gestion formatos
                //-------------------------------------------------
                #region HOS_FORMAT_HOXX: Gestion formatos
                string lcrG13Seleccion = "1,2";
                string lcrG13Descripcion = "Confirmar formatos abiertos al finalizar atención,No finalizar atención cuando hay formatos abiertos";
                G1CbHos_format_hoxx = new List<CrtForms.ListaComboBox>();
                G1CbHos_format_hoxx = CrtForms.flsCargarLista(lcrG13Seleccion, lcrG13Descripcion);
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
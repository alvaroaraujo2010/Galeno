using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Hospitalizacion.Modelo;
using System.ComponentModel;
using System.Windows;
using System;

namespace Hospitalizacion.VistaModelo
{
    public class HoscamasareasVistaModelo : ViewModelBase, IDataErrorInfo
    {
        /// <summary>
        /// HOSCAMASAREAS:
        /// Lista de camas creadas en el sistema, según las camas existentes 
        /// en cada area funcional de la IPS ejm: Cama Hospitalizacion Mujeres,
        /// Cama Hospitalizacion Niños y otras
        /// </summary>
        #region Variables de control perfil y Edicion en vistas

        //-----------------------------------
        //-Identificador unico de esta Clase
        //-----------------------------------
        public const string gcrSIS_CodigoVistaModelo = "FRM001"; 
        //-----------------------------------
        //-Variables Permiso para edicion  ------------------->  OJO pendiente implementacion
        //-----------------------------------
        #region Variables de control Perfil

        public string gcrSIS_PerfilCmdADD = string.Empty;
        public string gcrSIS_PerfilCmdEDT = string.Empty;
        public string gcrSIS_PerfilCmdSAV = string.Empty;
        public string gcrSIS_PerfilCmdDEL = string.Empty;
        public string gcrSIS_PerfilCmdPRN = string.Empty;
        #endregion
        //-----------------------------------
        //-Variables Control Edicion 
        //-----------------------------------
        #region Variables de control Edicion

        #region Vista Modelo Propiedad: glgSIS_ModoAdicion
        ///--------------------------------------------------------
        /// <summary>
        /// glgSIS_ModoAdicion: Variable para el control del modo 
        /// adicion del Vista Modelo.
        /// </summary>
        ///--------------------------------------------------------
        public string glgNomProp_SIS_ModoAdicion = "GlgSIS_ModoAdicion";
        private bool _glgSIS_ModoAdicion = false;
        public bool GlgSIS_ModoAdicion
        {
            get {  return _glgSIS_ModoAdicion;}
            set  
            {
                if (_glgSIS_ModoAdicion == value){return;}
                _glgSIS_ModoAdicion = value;
                RaisePropertyChanged(glgNomProp_SIS_ModoAdicion);
            }
        }
        #endregion

        #region Vista Modelo Propiedad: glgSIS_ModoEdicion
        ///--------------------------------------------------------
        /// <summary>
        /// glgSIS_ModoEdicion: Variable para el control del modo 
        /// Edicion del Vista Modelo.
        /// </summary>
        ///--------------------------------------------------------
        public string glgNomProp_SIS_ModoEdicion = "GlgSIS_ModoEdicion";
        private bool _glgSIS_ModoEdicion = false;
        public bool GlgSIS_ModoEdicion
        {
            get {return _glgSIS_ModoEdicion;}
            set
            {
                if (_glgSIS_ModoEdicion == value){return;}
                _glgSIS_ModoEdicion = value;
                RaisePropertyChanged(glgNomProp_SIS_ModoEdicion);
            }
        }
        #endregion
        #endregion
        //-----------------------------------
        //-Variables Filtro activo de datos
        //-----------------------------------
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

        #region Propiedades de la tabla

        #region Vista Modelo Propiedad: Hos_codcam_caho
        ///--------------------------------------------------------
        /// <summary>
        /// hos_codcam_caho: Codigo Cama generado por el sistema (Id unico)
        /// </summary>
        ///--------------------------------------------------------
        public const string gcrNomProp_Hos_codcam_caho = "Hos_codcam_caho";
        private string _hos_codcam_caho = string.Empty;
        public string Hos_codcam_caho
        {
            get {return _hos_codcam_caho;}
            set
            {
                if (_hos_codcam_caho == value){ return;}
                _hos_codcam_caho = value;
                RaisePropertyChanged(gcrNomProp_Hos_codcam_caho);
            }
        }
        #endregion

        #region Vista Modelo Propiedad: Hos_nrohab_habi
        ///--------------------------------------------------------
        /// <summary>
        /// hos_nrohab_habi: Codigo o numero de habitacion en area de 
        /// servicios donde se encuentra la cama: N201= Segundo piso Neonatos habitacion 201 
        /// </summary>
        ///--------------------------------------------------------
        public const string gcrNomProp_Hos_nrohab_habi = "Hos_nrohab_habi";

        private string _hos_nrohab_habi = string.Empty;

        public string Hos_nrohab_habi
        {
            get
            {
                return _hos_nrohab_habi;
            }

            set
            {
                if (_hos_nrohab_habi == value)
                {
                    return;
                }
                _hos_nrohab_habi = value;
                // Actualiza el bindings, no broadcast (sin emision)
                RaisePropertyChanged(gcrNomProp_Hos_nrohab_habi);
            }

        }
        #endregion

        #region Vista Modelo Propiedad: Hos_descam_caho
        ///--------------------------------------------------------
        /// <summary>
        /// hos_descam_caho: Descripcion cama según area funcional
        /// </summary>
        ///--------------------------------------------------------
        public const string gcrNomProp_Hos_descam_caho = "Hos_descam_caho";

        private string _hos_descam_caho = string.Empty;

        public string Hos_descam_caho
        {
            get
            {
                return _hos_descam_caho;
            }

            set
            {
                if (_hos_descam_caho == value)
                {
                    return;
                }
                _hos_descam_caho = value;
                // Actualiza el bindings, no broadcast (sin emision)
                RaisePropertyChanged(gcrNomProp_Hos_descam_caho);
            }
        }
        #endregion

        #region Vista Modelo Propiedad: Hos_tipcam_tcam
        ///--------------------------------------------------------
        /// <summary>
        /// hos_tipcam_tcam: Codigo Tipo cama: 01=Reclinable electronica 
        /// 2=Reclinable Mecanica
        /// </summary>
        ///--------------------------------------------------------
        public const string gcrNomProp_Hos_tipcam_tcam = "Hos_tipcam_tcam";

        private string _hos_tipcam_tcam = string.Empty;

        public string Hos_tipcam_tcam
        {
            get
            {
                return _hos_tipcam_tcam;
            }
            set
            {
                if (_hos_tipcam_tcam == value)
                {
                    return;
                }
                _hos_tipcam_tcam = value;
                // Actualiza el bindings, no broadcast (sin emision)
                RaisePropertyChanged(gcrNomProp_Hos_tipcam_tcam);
            }

        }
        #endregion

        #region Vista Modelo Propiedad: Hos_camaux_caho
        ///--------------------------------------------------------
        /// <summary>
        /// hos_camaux_caho: Cama adecuada o auxiliar imporvisada, cuando   
        /// no hay camas disponibles (en casos de urgencia), se utilizan camas 
        /// no adecuadas: 1=Cama Adecuada 2=Cama Auxiliar 
        /// </summary>
        ///--------------------------------------------------------
        public const string gcrNomProp_Hos_camaux_caho = "Hos_camaux_caho";

        private string _hos_camaux_caho = string.Empty;

        public string Hos_camaux_caho
        {
            get
            {
                return _hos_camaux_caho;
            }

            set
            {
                if (_hos_camaux_caho == value)
                {
                    return;
                }
                _hos_camaux_caho = value;
                // Actualiza el bindings, no broadcast (sin emision)
                RaisePropertyChanged(gcrNomProp_Hos_camaux_caho);
            }
        }
        #endregion

        #region Vista Modelo Propiedad: Fcm_idesec_sips
        ///--------------------------------------------------------
        /// <summary>
        /// fcm_idesec_sips: Codigo unico secuencial del Servicio IPS 
        /// con el cual se realiza el cobro de la estancia en cama
        /// </summary>
        ///--------------------------------------------------------
        public const string gcrNomProp_Fcm_idesec_sips = "Fcm_idesec_sips";

        private string _fcm_idesec_sips = string.Empty;

        public string Fcm_idesec_sips
        {
            get
            {
                return _fcm_idesec_sips;
            }

            set
            {
                if (_fcm_idesec_sips == value)
                {
                    return;
                }
                _fcm_idesec_sips = value;
                // Actualiza el bindings, no broadcast (sin emision)
                RaisePropertyChanged(gcrNomProp_Fcm_idesec_sips);
            }
        }
        #endregion

        #region Vista Modelo Propiedad: Hos_codsec_hsec
        ///--------------------------------------------------------
        /// <summary>
        /// hos_codsec_hsec: Codigo seccion para las subdiviciones de Hopitalización 
        /// y Urgencias con observación EJM:S001= Hospitalizacion Mujeres, 
        /// S002 =Hospitalizacion Niños y otras.
        /// </summary>
        ///--------------------------------------------------------
        public const string gcrNomProp_Hos_codsec_hsec = "Hos_codsec_hsec";

        private string _hos_codsec_hsec = string.Empty;

        public string Hos_codsec_hsec
        {
            get
            {
                return _hos_codsec_hsec;
            }
            set
            {
                if (_hos_codsec_hsec == value)
                {
                    return;
                }
                _hos_codsec_hsec = value;
                // Actualiza el bindings, no broadcast (sin emision)
                RaisePropertyChanged(gcrNomProp_Hos_codsec_hsec);
            }
        }
        #endregion

        #region Vista Modelo Propiedad: Hos_estcam_ecam
        ///--------------------------------------------------------
        /// <summary>
        /// hos_estcam_ecam: Codigo estado cama 1-Libre 2-Ocupada 3-Reserva 4-Reparacion 5-Inactiva 
        /// </summary>
        ///--------------------------------------------------------
        public const string gcrNomProp_Hos_estcam_ecam = "Hos_estcam_ecam";

        private string _hos_estcam_ecam = string.Empty;

        public string Hos_estcam_ecam
        {
            get
            {
                return _hos_estcam_ecam;
            }
            set
            {
                if (_hos_estcam_ecam == value)
                {
                    return;
                }
                _hos_estcam_ecam = value;
                // Actualiza el bindings, no broadcast (sin emision)
                RaisePropertyChanged(gcrNomProp_Hos_estcam_ecam);
            }
        }
        #endregion

        #region Vista Modelo Propiedad: Hos_destip_tcam
        ///--------------------------------------------------------
        /// <summary>
        /// hos_destip_tcam: Descripcion del tipo cama
        /// </summary>
        ///--------------------------------------------------------
        public const string gcrNomProp_Hos_destip_tcam = "Hos_destip_tcam";
        private string _hos_destip_tcam = string.Empty;
        public string Hos_destip_tcam
        {
            get { return _hos_destip_tcam; }
            set
            {
                if (_hos_destip_tcam == value) { return; }
                _hos_destip_tcam = value;
                RaisePropertyChanged(gcrNomProp_Hos_destip_tcam);
            }
        }
        #endregion

        #region Vista Modelo Propiedad: RegActivoHoscamasareas (registro actual)
        ///--------------------------------------------------------
        /// <summary>
        /// Para el registro activo de la tabla: Hoscamasareas
        /// </summary>
        ///--------------------------------------------------------
        public const string gcrNomProp_RegActivoHoscamasareas = "RegActivoHoscamasareas";

        private HoscamasareasModelo _regactivoHoscamasareas;

        public HoscamasareasModelo RegActivoHoscamasareas
        {
            get
            {
                return _regactivoHoscamasareas;
            }
            set
            {
                if (_regactivoHoscamasareas == value) return;
                _regactivoHoscamasareas = value;
                RaisePropertyChanged(gcrNomProp_RegActivoHoscamasareas);
            }
        }
        #endregion

        #region Vista Modelo Propiedad: ListaHoscamasareas
        ///--------------------------------------------------------
        /// <summary>
        /// listado para objetos o grillas de la tabla: Hoscamasareas
        /// </summary>
        ///--------------------------------------------------------
        public const string gcrNomProp_ListaHoscamasareas = "ListaHoscamasareas";

        private ObservableCollection <HoscamasareasModelo> _listaHoscamasareas;

        public ObservableCollection <HoscamasareasModelo> ListaHoscamasareas
        {
            get
            {
                return _listaHoscamasareas;
            }
            set
            {
                if (_listaHoscamasareas == value) return;
                _listaHoscamasareas = value;
                RaisePropertyChanged(gcrNomProp_ListaHoscamasareas);
            }
        }
        #endregion

        #endregion

        #region Comandos para gestion de registros
        ///--------------------------------------------------------
        /// <summary>
        /// Comandos para la gestion de registros
        /// </summary>
        ///--------------------------------------------------------
        public RelayCommand CmdADD { get; set; }
        public RelayCommand CmdEDT { get; set; }
        public RelayCommand CmdSAV { get; set; }
        public RelayCommand CmdCAN { get; set; }
        public RelayCommand CmdDEL { get; set; }
        public RelayCommand CmdPRN { get; set; }
        public RelayCommand CmdFIL { get; set; }
        public RelayCommand<HoscamasareasModelo> SelectionChangedCommand { get; set; }

        /// <summary>
        /// Registrar comandos del modelo vista
        /// </summary>
        private void fcvRegistrarComandos()
        {
            CmdADD = new RelayCommand(Adicionar,CanADD);//Adicionar registro
            CmdEDT = new RelayCommand(Modificar,CanEDT);//Modificar registro
            CmdSAV = new RelayCommand(Guardar,  CanSAV);//Guardar un registro
            CmdCAN = new RelayCommand(Cancelar, CanCAN);//Para activar el boton cancelar
            CmdDEL = new RelayCommand(Eliminar, CanDEL);//Eliminar registro
            CmdPRN = new RelayCommand(Imprimir, CanPRN);//Activar Boton Imprimir 
            CmdFIL = new RelayCommand(Filtro, CanFIL);//Activar Boton Filtro
            SelectionChangedCommand = new RelayCommand<HoscamasareasModelo>(lobjRegistro =>
            {
                if (lobjRegistro == null) return;
                RegActivoHoscamasareas = lobjRegistro;
                Hos_codcam_caho = lobjRegistro.Hos_codcam_caho;
                Hos_nrohab_habi = lobjRegistro.Hos_nrohab_habi;
                Hos_descam_caho = lobjRegistro.Hos_descam_caho;
                Hos_tipcam_tcam = lobjRegistro.Hos_tipcam_tcam;
                Hos_camaux_caho = lobjRegistro.Hos_camaux_caho;
                Fcm_idesec_sips = lobjRegistro.Fcm_idesec_sips;
                Hos_codsec_hsec = lobjRegistro.Hos_codsec_hsec;
                Hos_estcam_ecam = lobjRegistro.Hos_estcam_ecam;
                Hos_destip_tcam = lobjRegistro.Hos_destip_tcam;
            });
        }
        #endregion

        #region Metodo instancia Publica
        //--------------------------------------------------
        /// <summary>
        /// Metodo instancia publica de la clase
        /// </summary>
        //--------------------------------------------------
        //- 
        public HoscamasareasVistaModelo()
        {
            ListaHoscamasareas = new ObservableCollection<HoscamasareasModelo>(HoscamasareasModelo.farListaArrayHoscamasareas(""));
            fcvRegistrarComandos();
        }

        #endregion

        //--------------------------------------------------
        /// <summary>
        /// Region Para los Metodos que realizan la funcion
        /// de gestion de datos en la tabla
        /// </summary>
        //--------------------------------------------------
        #region Metodos para Gestion de Edicion Registros

        /// <summary>
        /// Adicionar Registro 
        /// </summary>
        public void Adicionar()
        {
            try 
            {
                Hos_codcam_caho = string.Empty;
                Hos_nrohab_habi = string.Empty;
                Hos_descam_caho = string.Empty;
                Hos_tipcam_tcam = string.Empty;
                Hos_camaux_caho = string.Empty;
                Fcm_idesec_sips = string.Empty;
                Hos_codsec_hsec = string.Empty;
                Hos_estcam_ecam = string.Empty;
                Hos_destip_tcam = string.Empty;
                RegActivoHoscamasareas = null;
                GlgSIS_ModoAdicion = true;
                GlgSIS_ModoEdicion = true;
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: Adicionar");
            } 

        }

        /// <summary>
        /// Modificar Registro
        /// </summary>
        public void Modificar()
        {
            try
            {
                GlgSIS_ModoAdicion = false;
                GlgSIS_ModoEdicion = true;
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: Modificar");
            } 
        }

        /// <summary>
        /// Guardar registro activo
        /// </summary>
        public void Guardar()
        {
            try
            {
                if (RegActivoHoscamasareas == null)
                {
                    var lobjRegistro = new HoscamasareasModelo
                    {
                        Hos_codcam_caho = Hos_codcam_caho,// aqui va la funcion que genera el nuevo codigo
                        Hos_nrohab_habi = Hos_nrohab_habi,
                        Hos_descam_caho = Hos_descam_caho,
                        Hos_tipcam_tcam = Hos_tipcam_tcam,
                        Hos_camaux_caho = Hos_camaux_caho,
                        Fcm_idesec_sips = Fcm_idesec_sips,
                        Hos_codsec_hsec = Hos_codsec_hsec,
                        Hos_estcam_ecam = Hos_estcam_ecam,
                        Hos_destip_tcam = Hos_destip_tcam
                    };

                    lobjRegistro.Hos_codcam_caho = HoscamasareasModelo.flgAddRegistro(lobjRegistro);
                    ListaHoscamasareas.Add(lobjRegistro);
                }
                else
                {
                    RegActivoHoscamasareas.Hos_codcam_caho = Hos_codcam_caho;
                    RegActivoHoscamasareas.Hos_nrohab_habi = Hos_nrohab_habi;
                    RegActivoHoscamasareas.Hos_descam_caho = Hos_descam_caho;
                    RegActivoHoscamasareas.Hos_tipcam_tcam = Hos_tipcam_tcam;
                    RegActivoHoscamasareas.Hos_camaux_caho = Hos_camaux_caho;
                    RegActivoHoscamasareas.Fcm_idesec_sips = Fcm_idesec_sips;
                    RegActivoHoscamasareas.Hos_codsec_hsec = Hos_codsec_hsec;
                    RegActivoHoscamasareas.Hos_estcam_ecam = Hos_estcam_ecam;
                    RegActivoHoscamasareas.Hos_destip_tcam = Hos_destip_tcam;
                    HoscamasareasModelo.fcvActualizar(RegActivoHoscamasareas);
                }
                GlgSIS_ModoAdicion = false;
                GlgSIS_ModoEdicion = false;
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: Guardar");
            } 
        }

        /// <summary>
        /// Cancelar o salir del modo edicion
        /// </summary>
        public void Cancelar()
        {
            Restaurar();
        }

        /// <summary>
        /// Eliminar el registro activo
        /// </summary>
        public void Eliminar()
        {
            if (MessageBox.Show("Desea Eliminar el regisro?", "Confirmación", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                HoscamasareasModelo.fcvEliminar(RegActivoHoscamasareas.Hos_codcam_caho);
                ListaHoscamasareas.Remove(RegActivoHoscamasareas);
                Restaurar();
            }
        }

        /// <summary>
        /// Restaurar los controles para edición
        /// al modo normal
        /// </summary>
        public void Restaurar()
        {
            try
            {
                GlgSIS_ModoAdicion = false;
                GlgSIS_ModoEdicion = false;
                Hos_codcam_caho = string.Empty;
                Hos_nrohab_habi = string.Empty;
                Hos_descam_caho = string.Empty;
                Hos_tipcam_tcam = string.Empty;
                Hos_camaux_caho = string.Empty;
                Fcm_idesec_sips = string.Empty;
                Hos_codsec_hsec = string.Empty;
                Hos_estcam_ecam = string.Empty;
                Hos_destip_tcam = string.Empty;
                RegActivoHoscamasareas = null;
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: Restaurar");
            }
        }

        /// <summary>
        /// Imprimir registro 
        /// </summary>
        public void Imprimir()
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

        /// <summary>
        /// Filtro Activa el filtro de datos
        /// </summary>
        public void Filtro()
        {
            try
            {
                if (GcrFiltroDatos != gcrFiltroAplicado && GlgSIS_ModoEdicion == false)
                {
                    Restaurar();
                    ListaHoscamasareas = new ObservableCollection<HoscamasareasModelo>(HoscamasareasModelo.farListaArrayHoscamasareas(GcrFiltroDatos));
                    gcrFiltroAplicado = GcrFiltroDatos;
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: Filtro");
            }
        }

        #endregion

        //--------------------------------------------------
        /// <summary>
        /// Region para Metodos que realizan la funcion
        /// de validacion de comandos para gestion de datos
        /// </summary>
        //--------------------------------------------------
        #region Validacion para habilitar comandos 

        /// <summary>
        /// Vaidacion para saber si se permite
        /// ejecutar comando Adicionar 
        /// </summary>
        private bool CanADD()
        {
            bool llgReturn = false;
            try
            {
                if (GlgSIS_ModoEdicion == false)
                {
                    // verificar si el perfil tiene permiso 
                    if (string.IsNullOrEmpty(gcrSIS_PerfilCmdADD))
                    {
                        gcrSIS_PerfilCmdADD = "OK"; // aqui va la funcion que verifica el perfil
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
        
        /// <summary>
        /// Vaidacion para saber si se permite
        /// ejecutar comando Modificar
        /// </summary>
        private bool CanEDT()
        {
            bool llgReturn = false;
            try
            {
                if (GlgSIS_ModoEdicion == false && RegActivoHoscamasareas != null)
                {
                    // verificar si el perfil tiene permiso 
                    if (string.IsNullOrEmpty(gcrSIS_PerfilCmdEDT))
                    {
                        gcrSIS_PerfilCmdEDT = "OK"; // aqui va la funcion que verifica el perfil
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

        /// <summary>
        /// Vaidacion para saber si se permite
        /// ejecutar comando Guardar 
        /// </summary>
        public bool CanSAV()
        {
            bool llgReturn = false;
            gcrSIS_PerfilCmdSAV = "NO";
            try
            {
                if (GlgSIS_ModoEdicion == true)
                {
                    llgReturn = string.IsNullOrEmpty(fcrValidacion("Hos_codcam_caho")) &&
                                string.IsNullOrEmpty(fcrValidacion("Hos_nrohab_habi")) &&
                                string.IsNullOrEmpty(fcrValidacion("Hos_descam_caho")) &&
                                string.IsNullOrEmpty(fcrValidacion("Hos_tipcam_tcam")) &&
                                string.IsNullOrEmpty(fcrValidacion("Hos_camaux_caho")) &&
                                string.IsNullOrEmpty(fcrValidacion("Fcm_idesec_sips")) &&
                                string.IsNullOrEmpty(fcrValidacion("Hos_codsec_hsec")) &&
                                string.IsNullOrEmpty(fcrValidacion("Hos_estcam_ecam"));


                    if (llgReturn == true) { gcrSIS_PerfilCmdSAV = "OK"; }
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: CanSAV");
            } 
            return llgReturn;
        }

        /// <summary>
        /// Vaidacion para saber si se permite
        /// ejecutar comando Cancelar
        /// </summary>
        public bool CanCAN()
        {
            return GlgSIS_ModoEdicion;
        }

        /// <summary>
        /// Vaidacion para saber si se permite
        /// ejecutar comando Eliminar
        /// </summary>
        public bool CanDEL()
        {
            bool llgReturn = false;
            try
            {
                if (RegActivoHoscamasareas != null && GlgSIS_ModoEdicion == false)
                {
                    // verificar si el perfil tiene permiso 
                    if (string.IsNullOrEmpty(gcrSIS_PerfilCmdDEL))
                    {
                        gcrSIS_PerfilCmdDEL = "OK"; // aqui va la funcion que verifica el perfil
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

        /// <summary>
        /// Vaidacion para saber si se permite
        /// ejecutar comando Imprimir
        /// </summary>
        public bool CanPRN()
        {
            bool llgReturn = false;
            try
            {
                if (RegActivoHoscamasareas != null && GlgSIS_ModoEdicion == false)
                {
                    // verificar si el perfil tiene permiso 
                    if (string.IsNullOrEmpty(gcrSIS_PerfilCmdPRN))
                    {
                        gcrSIS_PerfilCmdPRN = "OK"; // aqui va la funcion que verifica el perfil
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

        /// <summary>
        /// Vaidacion para saber si se permite
        /// ejecutar Filtro en formularios tipo uno
        /// se ejecuta el filtro automatico (por ser pocos registros)
        /// </summary>
        public bool CanFIL()
        {
            bool llgReturn = false;
            try
            {
                if (GcrFiltroDatos != gcrFiltroAplicado && GlgSIS_ModoEdicion == false)
                {
                    Restaurar();
                    ListaHoscamasareas = new ObservableCollection<HoscamasareasModelo>(HoscamasareasModelo.farListaArrayHoscamasareas(GcrFiltroDatos));
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

        /// <summary>
        /// Funcion para validar los datos cargados en el registro 
        /// que se esta editando
        /// </summary>
        /// <param name="tcrNombrePropiedad"></param>
        /// <returns>Retorna vacio o una cadena que describe el error</returns>
        private string fcrValidacion(string tcrNombrePropiedad)
        {
            string lcrValorReturn = string.Empty;
            try
            {
                switch (tcrNombrePropiedad)
                {
                    case "Hos_codcam_caho":
                        if (string.IsNullOrWhiteSpace(Hos_codcam_caho))
                        {
                            lcrValorReturn = "El codigo cama es requerido";
                        }
                        else if (Hos_codcam_caho.Length > 6)
                        {
                            lcrValorReturn = "El codigo de la cama no debe contener más de 6 caracteres";
                        }
                        else
                        {
                            if (GlgSIS_ModoAdicion == true && HoscamasareasModelo.flgBuscarRegistro(Hos_codcam_caho))
                            {
                                lcrValorReturn = "Nuevo codigo ya existe en Base de Datos";
                            }

                        }
                        break;

                    case "Hos_nrohab_habi":
                        if (string.IsNullOrWhiteSpace(Hos_nrohab_habi))
                        {
                            lcrValorReturn = "El numero de habitacion es requerido";
                        }
                        else if (Hos_nrohab_habi.Length < 3 && Hos_nrohab_habi.Length > 5)
                        {
                            lcrValorReturn = "El numero de habitacion debe contener de 3 a 5 caracteres";
                        }
                        break;

                    case "Hos_descam_caho":
                        if (string.IsNullOrWhiteSpace(Hos_descam_caho))
                        {
                            lcrValorReturn = "Descripcion o nombre cama es requerido";
                        }
                        else if (Hos_descam_caho.Length < 10 && Hos_descam_caho.Length > 50)
                        {
                            lcrValorReturn = "Descripcion o nombre cama debe contener de 10 a 50 caracteres";
                        }
                        break;

                    case "Hos_tipcam_tcam":
                        if (string.IsNullOrWhiteSpace(Hos_tipcam_tcam))
                        {
                            lcrValorReturn = "Tipo cama es requerido";
                        }
                        else if (Hos_tipcam_tcam.Length != 1)
                        {
                            lcrValorReturn = "Tipo cama debe contener un caracter";
                        }
                        else
                        {
                            Hos_destip_tcam = HoscamasareasModelo.fcrBuscarHostipocamas(Hos_tipcam_tcam);
                            if (string.IsNullOrWhiteSpace(Hos_destip_tcam))
                            {
                                lcrValorReturn = "Codigo tipo cama no existe";
                            }
                        }
                        break;

                    case "Hos_camaux_caho":
                        if (string.IsNullOrWhiteSpace(Hos_camaux_caho))
                        {
                            lcrValorReturn = "El Codigo cama adecuada es requerido 1=SI/2=NO";
                        }
                        else if (Hos_camaux_caho.Length < 3 && Hos_camaux_caho.Length > 5)
                        {
                            lcrValorReturn = "El numero de habitacion debe contener de 3 a 5 caracteres";
                        }
                        break;

                    case "Fcm_idesec_sips":
                        if (string.IsNullOrWhiteSpace(Fcm_idesec_sips))
                        {
                            lcrValorReturn = "El Codigo del Servicio IPS relacionado para cobro es obligatorio ";
                        }
                        else if (Fcm_idesec_sips.Length < 5 && Fcm_idesec_sips.Length > 8)
                        {
                            lcrValorReturn = "El Codigo del Servicio IPS debe contener de 5 a 8 caracteres";
                        }
                        break;

                    case "Hos_codsec_hsec":
                        if (string.IsNullOrWhiteSpace(Hos_codsec_hsec))
                        {
                            lcrValorReturn = "El Codigo Seccion relacionada es obligatorio ";
                        }
                        else if (Hos_codsec_hsec.Length < 3 && Hos_codsec_hsec.Length > 6)
                        {
                            lcrValorReturn = "El Codigo Seccion debe contener de 3 a 6 caracteres";
                        }
                        break;

                    case "Hos_estcam_ecam":
                        if (string.IsNullOrWhiteSpace(Hos_estcam_ecam))
                        {
                            lcrValorReturn = "El Codigo estado cama es obligatorio ";
                        }
                        else if (Hos_estcam_ecam != "1" && Hos_estcam_ecam != "2")
                        {
                            lcrValorReturn = "El Codigo estado cama no es valido";
                        }
                        break;
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: fcrValidacion");
            }
            return lcrValorReturn;
        }

        //- Implementacion para validacion
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
    }
}
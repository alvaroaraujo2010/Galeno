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
using Datos.Modelos;
using CitasMedicas.Modelo;

namespace CitasMedicas.VistaModelo
{
    public class NotificGestionCitas : ViewModelBase
    {
        //-------------------------------------------------
        // Metodo instancia publica de la clase
        //-------------------------------------------------
        #region Metodo instancia Publica
        public NotificGestionCitas()
        {
            fcvRegistrarComandos();
        }
        #endregion
        //--------------------------------------------------------
        // Variables de notificación
        //--------------------------------------------------------
        #region NOTIFICACIONES GRUPOS
        #region GcrNotificGrupos: Notifica el cambio en grupos
        public const string gcrNomProp_GcrNotificGrupos = "GcrNotificGrupos";
        private string _gcrNotificGrupos = string.Empty;
        /// <summary>
        /// <para>DESCRIPCION: Notifica el cambio en grupos</para>
        /// </summary>
        public string GcrNotificGrupos
        {
            get { return _gcrNotificGrupos; }
            set
            {
                if (_gcrNotificGrupos == value) return;
                _gcrNotificGrupos = value;
                RaisePropertyChanged(gcrNomProp_GcrNotificGrupos);
            }
        }
        #endregion
        #region GcrListaGrupos: Lista de grupos (turnos) cargados en vista
        public const string gcrNomProp_GcrListaGrupos = "GcrListaGrupos";
        private string _gcrListaGrupos = string.Empty;
        /// <summary>
        /// <para>DESCRIPCION: Lista de grupos cargados en vista </para>
        /// </summary>
        public string GcrListaGrupos
        {
            get { return _gcrListaGrupos; }
            set
            {
                if (_gcrListaGrupos == value) return;
                _gcrListaGrupos = value;
                RaisePropertyChanged(gcrNomProp_GcrListaGrupos);
            }
        }
        #endregion
        #endregion
        //-------------------------------------------------
        // Comandos para la gestion de registros
        //-------------------------------------------------
        #region Comandos para gestion de registros
        public RelayCommand cmdCambioVista { get; set; }
        /// <summary>
        /// Registrar comandos del modelo vista
        /// </summary>
        public void fcvRegistrarComandos()
        {
            cmdCambioVista = new RelayCommand(fcvValidCambiosVistas, flgValidacion);
        }
        #endregion
        //-------------------------------------------------
        // Region Metodos que Validan activacion de opciones
        // en gestion de datos
        //-------------------------------------------------
        #region Metodos Validacion de cambios
        #region flgValidacion
        /// <summary>
        ///Validación para saber si se permite
        ///ejecutar Filtro en formularios tipo uno
        ///se ejecuta el filtro automatico (por ser pocos registros)
        /// </summary>
        public bool flgValidacion()
        {
            bool llgReturn = false;
            try
            {
                if (!string.IsNullOrEmpty(GcrNotificGrupos))
                {
                    // cargar listas 
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: CanFILX");
            }
            return llgReturn;
        }
        #endregion
        #endregion
        //-------------------------------------------------
        // Region Para los Metodos que realizan la funcion
        // de gestion de datos en la tabla
        //-------------------------------------------------
        #region Metodos para Gestion de Edicion Registros
        #region fcvValidCambiosVistas: Validar cambios vista
        /// <summary>
        /// Filtro Auxiliar
        /// </summary>
        public void fcvValidCambiosVistas()
        {
        }
        #endregion
        #endregion
    }
}

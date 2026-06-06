using System;
using System.Windows;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Datos.Modelos;
using Sistema.Utilidades;
using Sistema.Modelo;

namespace GestorReportes.Modelo
{
    /// <summary>
    /// Descripcion para la Vista de  la tabla: odnmaestdientes Maestro Dientes
    /// </summary>
    public class HclOdontMaestroDientes : clBaseInpc
    {
        #region Modelo Attributos
        private static DbAplicacion _context;
        #region Modelo Propiedades Notificacion
        #region Odn_coddie_oddi: Código diente
        private String _odn_coddie_oddi;
        /// <summary>
        /// <para>TABLA: odnmaestdientes</para>
        /// <para>TABLA NATIVA: odnmaestdientes</para>
        /// <para>CAMPO: Código diente</para>
        /// <para>NOMBRE: odn_coddie_oddi (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        ///Codigo del Diente segun el Odontograma
        /// </para>
        /// </summary>
        public String Odn_coddie_oddi
        {
            get { return _odn_coddie_oddi; }
            set
            {
                if (_odn_coddie_oddi == value) return;
                _odn_coddie_oddi = value;
                OnPropertyChanged("Odn_coddie_oddi");
            }
        }
        #endregion
        #region Odn_desdie_oddi: Descripcion  diente
        private String _odn_desdie_oddi;
        /// <summary>
        /// <para>TABLA: odnmaestdientes</para>
        /// <para>TABLA NATIVA: odnmaestdientes</para>
        /// <para>CAMPO: Descripcion  diente</para>
        /// <para>NOMBRE: odn_desdie_oddi (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripcion Diente
        /// </para>
        /// </summary>
        public String Odn_desdie_oddi
        {
            get { return _odn_desdie_oddi; }
            set
            {
                if (_odn_desdie_oddi == value) return;
                _odn_desdie_oddi = value;
                OnPropertyChanged("Odn_desdie_oddi");
            }
        }
        #endregion
        #region Odn_codcte_odcd: Código cuadrante
        private String _odn_codcte_odcd;
        /// <summary>
        /// <para>TABLA: odnmaestdientes</para>
        /// <para>TABLA NATIVA: odnmscuadrantes</para>
        /// <para>CAMPO: Código cuadrante</para>
        /// <para>NOMBRE: odn_codcte_odcd (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        ///1=Cuadrante 1, 2=Cuadrante 2, 3=Cuadrante 3, 4=Cuadrante 4
        /// </para>
        /// </summary>
        public String Odn_codcte_odcd
        {
            get { return _odn_codcte_odcd; }
            set
            {
                if (_odn_codcte_odcd == value) return;
                _odn_codcte_odcd = value;
                OnPropertyChanged("Odn_codcte_odcd");
            }
        }
        #endregion
        #region Odn_codtdi_odtd: Tipo diente
        private String _odn_codtdi_odtd;
        /// <summary>
        /// <para>TABLA: odnmaestdientes</para>
        /// <para>TABLA NATIVA: odntiposdientes</para>
        /// <para>CAMPO: Tipo diente</para>
        /// <para>NOMBRE: odn_codtdi_odtd (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        /// Codigo Digitado del  tipo diente ejm:  1=Incisivo, 2=Incisivo
        /// lateral …
        /// </para>
        /// </summary>
        public String Odn_codtdi_odtd
        {
            get { return _odn_codtdi_odtd; }
            set
            {
                if (_odn_codtdi_odtd == value) return;
                _odn_codtdi_odtd = value;
                OnPropertyChanged("Odn_codtdi_odtd");
            }
        }
        #endregion
        #region Odn_imagen_oddi: Nombre Imagen
        private String _odn_imagen_oddi;
        /// <summary>
        /// <para>TABLA: odnmaestdientes</para>
        /// <para>TABLA NATIVA: odnmaestdientes</para>
        /// <para>CAMPO: Nombre Imagen</para>
        /// <para>NOMBRE: odn_imagen_oddi (char:60)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        /// nombre de la imagen en formato jpg o png, para vista preliminar
        /// del diente
        /// </para>
        /// </summary>
        public String Odn_imagen_oddi
        {
            get { return _odn_imagen_oddi; }
            set
            {
                if (_odn_imagen_oddi == value) return;
                _odn_imagen_oddi = value;
                OnPropertyChanged("Odn_imagen_oddi");
            }
        }
        #endregion
        #region Odn_estreg_oddi: Código Estado Registro
        private String _odn_estreg_oddi;
        /// <summary>
        /// <para>TABLA: odnmaestdientes</para>
        /// <para>TABLA NATIVA: odnmaestdientes</para>
        /// <para>CAMPO: Código Estado Registro</para>
        /// <para>NOMBRE: odn_estreg_oddi (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        ///Estado de registros  : 1= Activo 2= Inactivo
        /// </para>
        /// </summary>
        public String Odn_estreg_oddi
        {
            get { return _odn_estreg_oddi; }
            set
            {
                if (_odn_estreg_oddi == value) return;
                _odn_estreg_oddi = value;
                OnPropertyChanged("Odn_estreg_oddi");
            }
        }
        #endregion
        #region Odn_descte_odcd: Descripcion cuadrante
        private String _odn_descte_odcd;
        /// <summary>
        /// <para>TABLA: odnmaestdientes</para>
        /// <para>TABLA NATIVA: odnmscuadrantes</para>
        /// <para>CAMPO: Descripcion cuadrante</para>
        /// <para>NOMBRE: odn_descte_odcd (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripcion Cuadrante de la Boca o cara
        /// </para>
        /// </summary>
        public String Odn_descte_odcd
        {
            get { return _odn_descte_odcd; }
            set
            {
                if (_odn_descte_odcd == value) return;
                _odn_descte_odcd = value;
                OnPropertyChanged("Odn_descte_odcd");
            }
        }
        #endregion
        #region Odn_destdi_odtd: Descripcion tipo diente
        private String _odn_destdi_odtd;
        /// <summary>
        /// <para>TABLA: odnmaestdientes</para>
        /// <para>TABLA NATIVA: odntiposdientes</para>
        /// <para>CAMPO: Descripcion tipo diente</para>
        /// <para>NOMBRE: odn_destdi_odtd (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripcion Tipo Diente
        /// </para>
        /// </summary>
        public String Odn_destdi_odtd
        {
            get { return _odn_destdi_odtd; }
            set
            {
                if (_odn_destdi_odtd == value) return;
                _odn_destdi_odtd = value;
                OnPropertyChanged("Odn_destdi_odtd");
            }
        }
        #endregion
        #region Odn_cardnt_odcd: Configuracion caras
        private String _odn_cardnt_odcd;
        /// <summary>
        /// <para>TABLA: odnmscuadrantes</para>
        /// <para>TABLA NATIVA: odnmscuadrantes</para>
        /// <para>CAMPO: Configuracion caras</para>
        /// <para>NOMBRE: odn_cardnt_odcd (char:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        /// Lista caras de los diente segun Anatomia (Tabla ODNANATOMDIENTE)
        /// dependiendo del cuadrante ejm: para el cudarante 2 es : 14325
        /// </para>
        /// </summary>
        public String Odn_cardnt_odcd
        {
            get { return _odn_cardnt_odcd; }
            set
            {
                if (_odn_cardnt_odcd == value) return;
                _odn_cardnt_odcd = value;
                OnPropertyChanged("Odn_cardnt_odcd");
            }
        }
        #endregion
        #endregion
        #region Listar Registros
        public static List<HclOdontMaestroDientes> flsListaOdnmaestdientes(string tcrBuscar)
        {
            using (_context = new DbAplicacion())
            {
                if (string.IsNullOrEmpty(tcrBuscar))
                {
                    #region consulta
                    var lobConsulta = from odnmaestdientes in _context.Odnmaestdientes
                                      join odnmscuadrantes in _context.Odnmscuadrantes on odnmaestdientes.odn_codcte_odcd equals odnmscuadrantes.odn_codcte_odcd into tmodnmscuadrantes
                                      join odntiposdientes in _context.Odntiposdientes on odnmaestdientes.odn_codtdi_odtd equals odntiposdientes.odn_codtdi_odtd into tmodntiposdientes
                                      from odcd in tmodnmscuadrantes.DefaultIfEmpty()
                                      from odtd in tmodntiposdientes.DefaultIfEmpty()
                                      select new HclOdontMaestroDientes
                                      {
                                          Odn_coddie_oddi = odnmaestdientes.odn_coddie_oddi,
                                          Odn_desdie_oddi = odnmaestdientes.odn_desdie_oddi,
                                          Odn_codcte_odcd = odnmaestdientes.odn_codcte_odcd,
                                          Odn_codtdi_odtd = odnmaestdientes.odn_codtdi_odtd,
                                          Odn_imagen_oddi = odnmaestdientes.odn_imagen_oddi,
                                          Odn_estreg_oddi = odnmaestdientes.odn_estreg_oddi,
                                          Odn_descte_odcd = odcd.odn_descte_odcd,
                                          Odn_cardnt_odcd = odcd.odn_cardnt_odcd,
                                          Odn_destdi_odtd = odtd.odn_destdi_odtd,
                                      };
                    return lobConsulta.ToList();
                    #endregion
                }
                else
                {
                    #region consulta
                    var lobConsulta = from odnmaestdientes in _context.Odnmaestdientes
                                      join odnmscuadrantes in _context.Odnmscuadrantes on odnmaestdientes.odn_codcte_odcd equals odnmscuadrantes.odn_codcte_odcd into tmodnmscuadrantes
                                      join odntiposdientes in _context.Odntiposdientes on odnmaestdientes.odn_codtdi_odtd equals odntiposdientes.odn_codtdi_odtd into tmodntiposdientes
                                      from odcd in tmodnmscuadrantes.DefaultIfEmpty()
                                      from odtd in tmodntiposdientes.DefaultIfEmpty()
                                      where odnmaestdientes.odn_coddie_oddi == tcrBuscar
                                      select new HclOdontMaestroDientes
                                      {
                                          Odn_coddie_oddi = odnmaestdientes.odn_coddie_oddi,
                                          Odn_desdie_oddi = odnmaestdientes.odn_desdie_oddi,
                                          Odn_codcte_odcd = odnmaestdientes.odn_codcte_odcd,
                                          Odn_codtdi_odtd = odnmaestdientes.odn_codtdi_odtd,
                                          Odn_imagen_oddi = odnmaestdientes.odn_imagen_oddi,
                                          Odn_estreg_oddi = odnmaestdientes.odn_estreg_oddi,
                                          Odn_descte_odcd = odcd.odn_descte_odcd,
                                          Odn_cardnt_odcd = odcd.odn_cardnt_odcd,
                                          Odn_destdi_odtd = odtd.odn_destdi_odtd,
                                      };
                    return lobConsulta.ToList();
                    #endregion
                }
            }
        }
        #endregion
        #endregion
    }
}

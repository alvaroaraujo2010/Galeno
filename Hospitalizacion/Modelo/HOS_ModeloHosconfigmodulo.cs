//- MARMOTA-GENCODE: VERSION 2.0 - 25/07/2015 09:54:30 PM
using System;
using System.Windows;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.Generic;
using Datos.Modelos;
using Sistema.Utilidades;
using Sistema.Modelo;

namespace Hospitalizacion.Modelo
{
    /// <summary>
    /// Descripcion para la Vista de  la tabla: hosconfigmodulo
    /// </summary>
    public class ModeloHosconfigmodulo : clBaseInpc
    {
        #region Modelo Attributos
        private static DbAplicacion _context;
        #region Modelo Propiedades Notificacion
        #region Hos_codsys_hoxx: Codigo configuración
        private String _hos_codsys_hoxx;
        /// <summary>
        /// <para>TABLA: hosconfigmodulo</para>
        /// <para>TABLA NATIVA: hosconfigmodulo</para>
        /// <para>CAMPO: Codigo configuración</para>
        /// <para>NOMBRE: hos_codsys_hoxx (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        ///Codigo unico del registro configuración del modulo
        /// </para>
        /// </summary>
        public String Hos_codsys_hoxx
        {
            get { return _hos_codsys_hoxx; }
            set
            {
                if (_hos_codsys_hoxx == value) return;
                _hos_codsys_hoxx = value;
                OnPropertyChanged("Hos_codsys_hoxx");
            }
        }
        #endregion
        #region Hos_epicri_hoxx: Gestión epicrisis
        private String _hos_epicri_hoxx;
        /// <summary>
        /// <para>TABLA: hosconfigmodulo</para>
        /// <para>TABLA NATIVA: hosconfigmodulo</para>
        /// <para>CAMPO: Gestión epicrisis</para>
        /// <para>NOMBRE: hos_epicri_hoxx (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Configuracion obligatoriedad gestion de la epicrisis: 1 = Obligatoria
        /// 2=Opcional (no es obligatria) 3= Obligatoria según horas Minimas
        /// campo (HOS_EPICRH_HOXX)
        /// </para>
        /// </summary>
        public String Hos_epicri_hoxx
        {
            get { return _hos_epicri_hoxx; }
            set
            {
                if (_hos_epicri_hoxx == value) return;
                _hos_epicri_hoxx = value;
                OnPropertyChanged("Hos_epicri_hoxx");
            }
        }
        #endregion
        #region Hos_epicrh_hoxx: Horas estancia epicrisis
        private int _hos_epicrh_hoxx;
        /// <summary>
        /// <para>TABLA: hosconfigmodulo</para>
        /// <para>TABLA NATIVA: hosconfigmodulo</para>
        /// <para>CAMPO: Horas estancia epicrisis</para>
        /// <para>NOMBRE: hos_epicrh_hoxx (int:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        /// Numero de horas minimas en estancia para que la epicrisis se
        /// haga obligatoria
        /// </para>
        /// </summary>
        public int Hos_epicrh_hoxx
        {
            get { return _hos_epicrh_hoxx; }
            set
            {
                if (_hos_epicrh_hoxx == value) return;
                _hos_epicrh_hoxx = value;
                OnPropertyChanged("Hos_epicrh_hoxx");
            }
        }
        #endregion
        #region Hos_autegr_hoxx: Autorización egreso
        private String _hos_autegr_hoxx;
        /// <summary>
        /// <para>TABLA: hosconfigmodulo</para>
        /// <para>TABLA NATIVA: hosconfigmodulo</para>
        /// <para>CAMPO: Autorización egreso</para>
        /// <para>NOMBRE: hos_autegr_hoxx (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        /// Gestion de autorizacion de egreso hospitalario: 1=No permitir
        /// antes de registro egreso urgencias/hospitalización 2=Permitir
        /// despues de registro egreso urgencias/Hospitalización
        /// </para>
        /// </summary>
        public String Hos_autegr_hoxx
        {
            get { return _hos_autegr_hoxx; }
            set
            {
                if (_hos_autegr_hoxx == value) return;
                _hos_autegr_hoxx = value;
                OnPropertyChanged("Hos_autegr_hoxx");
            }
        }
        #endregion
        #region Hos_format_hoxx: Gestion formatos
        private String _hos_format_hoxx;
        /// <summary>
        /// <para>TABLA: hosconfigmodulo</para>
        /// <para>TABLA NATIVA: hosconfigmodulo</para>
        /// <para>CAMPO: Gestion formatos</para>
        /// <para>NOMBRE: hos_format_hoxx (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        /// Gestion formatos al finalizar atención medica 1= Confirmar
        /// formatos abiertos al finalizar atención 2= No finalizar atencion
        /// cuando hay formatos abiertos
        /// </para>
        /// </summary>
        public String Hos_format_hoxx
        {
            get { return _hos_format_hoxx; }
            set
            {
                if (_hos_format_hoxx == value) return;
                _hos_format_hoxx = value;
                OnPropertyChanged("Hos_format_hoxx");
            }
        }
        #endregion
        #endregion
        #endregion

        #region Metodos para edicion de registros
        #region Adicionar Registro
        public static string flgAddRegistro(ModeloHosconfigmodulo tobjModelo)
        {
            var lcrCodigoGen = string.Empty;
            try
            {
                using (_context = new DbAplicacion())
                {
                    var lobjRegistro = new EFhosconfigmodulo
                    {
                        #region cargar Registro
                        hos_codsys_hoxx = tobjModelo.Hos_codsys_hoxx,
                        hos_epicri_hoxx = tobjModelo.Hos_epicri_hoxx,
                        hos_epicrh_hoxx = tobjModelo.Hos_epicrh_hoxx,
                        hos_autegr_hoxx = tobjModelo.Hos_autegr_hoxx,
                        hos_format_hoxx = tobjModelo.Hos_format_hoxx,
                        #endregion
                    };
                    lcrCodigoGen = lobjRegistro.hos_codsys_hoxx;
                    _context.AddToHosconfigmodulo(lobjRegistro);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Modelo Error Metodo: flgAddRegistro");
            }
            return lcrCodigoGen;
        }
        #endregion
        #region Modificar Registro
        public static void fcvActualizar(ModeloHosconfigmodulo tobjModelo)
        {
            try
            {
                using (_context = new DbAplicacion())
                {
                    var lobjRegistro = _context.Hosconfigmodulo.FirstOrDefault(p => p.hos_codsys_hoxx == tobjModelo.Hos_codsys_hoxx);
                    if (lobjRegistro != null)
                    {
                        lobjRegistro.hos_codsys_hoxx = tobjModelo.Hos_codsys_hoxx;
                        lobjRegistro.hos_epicri_hoxx = tobjModelo.Hos_epicri_hoxx;
                        lobjRegistro.hos_epicrh_hoxx = (int)tobjModelo.Hos_epicrh_hoxx;
                        lobjRegistro.hos_autegr_hoxx = tobjModelo.Hos_autegr_hoxx;
                        lobjRegistro.hos_format_hoxx = tobjModelo.Hos_format_hoxx;
                        _context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Modelo Error Metodo: fcvActualizar");
            }
        }
        #endregion
        #region Eliminar registro
        public static void fcvEliminar(string tcrCodigo)
        {
            try
            {
                using (_context = new DbAplicacion())
                {
                    var lobjRegistro = _context.Hosconfigmodulo.FirstOrDefault(p => p.hos_codsys_hoxx == tcrCodigo);
                    if (lobjRegistro != null)
                    {
                        _context.DeleteObject(lobjRegistro);
                        _context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Modelo Error Metodo: fcvEliminar");
            }
        }
        #endregion
        #region Buscar HOSCONFIGMODULO: Logica
        /// <summary>
        /// <para>TABLA: hosconfigmodulo</para>
        /// <para>TITULO: Configuración modulo hospitalización</para>
        /// <para>MODULO: HOS</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Configuración parametros generales de funcionamiento modulo
        /// hospitalización
        /// </para>
        /// </summary>
        public static bool flgBuscarHosconfigmodulo(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Hosconfigmodulo.FirstOrDefault(p => p.hos_codsys_hoxx == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Listar Registros
        public static List<ModeloHosconfigmodulo> flsListaHosconfigmodulo(string tcrBuscar)
        {
            using (_context = new DbAplicacion())
            {
                if (string.IsNullOrEmpty(tcrBuscar))
                {
                    var lobConsulta = from hosconfigmodulo in _context.Hosconfigmodulo
                                      select new ModeloHosconfigmodulo
                                      {
                                          Hos_codsys_hoxx = hosconfigmodulo.hos_codsys_hoxx,
                                          Hos_epicri_hoxx = hosconfigmodulo.hos_epicri_hoxx,
                                          Hos_epicrh_hoxx = (int)hosconfigmodulo.hos_epicrh_hoxx,
                                          Hos_autegr_hoxx = hosconfigmodulo.hos_autegr_hoxx,
                                          Hos_format_hoxx = hosconfigmodulo.hos_format_hoxx,
                                      };
                    return lobConsulta.ToList();
                }
                else
                {
                    var lobConsulta = from hosconfigmodulo in _context.Hosconfigmodulo
                                      where hosconfigmodulo.hos_codsys_hoxx == tcrBuscar
                                      select new ModeloHosconfigmodulo
                                      {
                                          Hos_codsys_hoxx = hosconfigmodulo.hos_codsys_hoxx,
                                          Hos_epicri_hoxx = hosconfigmodulo.hos_epicri_hoxx,
                                          Hos_epicrh_hoxx = (int)hosconfigmodulo.hos_epicrh_hoxx,
                                          Hos_autegr_hoxx = hosconfigmodulo.hos_autegr_hoxx,
                                          Hos_format_hoxx = hosconfigmodulo.hos_format_hoxx,
                                      };
                    return lobConsulta.ToList();
                }
            }
        }
        #endregion
        #endregion
    }
}
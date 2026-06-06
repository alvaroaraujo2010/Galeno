//- MARMOTA-GENCODE: VERSION 2.0 - 09/08/2015 10:58:48 AM
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

namespace ConfigAsistencial.Modelo
{
    /// <summary>
    /// Descripcion para la Vista de  la tabla: siatablaeps
    /// </summary>
    public class ModeloSiatablaeps : clBaseInpc
    {
        #region Modelo Attributos
        private static DbAplicacion _context;
        #region Modelo Propiedades Notificacion
        #region Sia_codeps_teps: Código EPS
        private String _sia_codeps_teps;
        /// <summary>
        /// <para>TABLA: siatablaeps</para>
        /// <para>TABLA NATIVA: siatablaeps</para>
        /// <para>CAMPO: Código EPS</para>
        /// <para>NOMBRE: sia_codeps_teps (char:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        /// Código de Eps o Asegurador según códigos asignados por la supersalud
        /// </para>
        /// </summary>
        public String Sia_codeps_teps
        {
            get { return _sia_codeps_teps; }
            set
            {
                if (_sia_codeps_teps == value) return;
                _sia_codeps_teps = value;
                OnPropertyChanged("Sia_codeps_teps");
            }
        }
        #endregion
        #region Sia_codnit_teps: Numero Nit EPS
        private String _sia_codnit_teps;
        /// <summary>
        /// <para>TABLA: siatablaeps</para>
        /// <para>TABLA NATIVA: siatablaeps</para>
        /// <para>CAMPO: Numero Nit EPS</para>
        /// <para>NOMBRE: sia_codnit_teps (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Numero del Nit de la EPS o Asegurador
        /// </para>
        /// </summary>
        public String Sia_codnit_teps
        {
            get { return _sia_codnit_teps; }
            set
            {
                if (_sia_codnit_teps == value) return;
                _sia_codnit_teps = value;
                OnPropertyChanged("Sia_codnit_teps");
            }
        }
        #endregion
        #region Sia_deseps_teps: Nombre EPS
        private String _sia_deseps_teps;
        /// <summary>
        /// <para>TABLA: siatablaeps</para>
        /// <para>TABLA NATIVA: siatablaeps</para>
        /// <para>CAMPO: Nombre EPS</para>
        /// <para>NOMBRE: sia_deseps_teps (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        /// Descripción Eps o Asegurador según códigos asignados por la
        /// supersalud
        /// </para>
        /// </summary>
        public String Sia_deseps_teps
        {
            get { return _sia_deseps_teps; }
            set
            {
                if (_sia_deseps_teps == value) return;
                _sia_deseps_teps = value;
                OnPropertyChanged("Sia_deseps_teps");
            }
        }
        #endregion
        #region Sia_tipase_sita: Código tipo asegurador
        private String _sia_tipase_sita;
        /// <summary>
        /// <para>TABLA: siatablaeps</para>
        /// <para>TABLA NATIVA: siatipoasegurad</para>
        /// <para>CAMPO: Código tipo asegurador</para>
        /// <para>NOMBRE: sia_tipase_sita (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        /// Código tipo asegurador de salud:  01=Adminstradora  de Riesgos
        /// laborales 02=Entidades aseguradoras regimen subsidiado … otros
        /// </para>
        /// </summary>
        public String Sia_tipase_sita
        {
            get { return _sia_tipase_sita; }
            set
            {
                if (_sia_tipase_sita == value) return;
                _sia_tipase_sita = value;
                OnPropertyChanged("Sia_tipase_sita");
            }
        }
        #endregion
        #region Sia_desase_sita: Descripcion tipo
        private String _sia_desase_sita;
        /// <summary>
        /// <para>TABLA: siatablaeps</para>
        /// <para>TABLA NATIVA: siatipoasegurad</para>
        /// <para>CAMPO: Descripcion tipo</para>
        /// <para>NOMBRE: sia_desase_sita (char:50)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripcion tipo asegurador servicios de salud
        /// </para>
        /// </summary>
        public String Sia_desase_sita
        {
            get { return _sia_desase_sita; }
            set
            {
                if (_sia_desase_sita == value) return;
                _sia_desase_sita = value;
                OnPropertyChanged("Sia_desase_sita");
            }
        }
        #endregion
        #endregion
        #endregion
        #region Metodos para edicion de registros
        #region Adicionar Registro
        public static string flgAddRegistro(ModeloSiatablaeps tobjModelo)
        {
            var lcrCodigoGen = string.Empty;
            try
            {
                using (_context = new DbAplicacion())
                {
                    var lobjRegistro = new EFsiatablaeps
                    {
                        #region cargar Registro
                        sia_codeps_teps = tobjModelo.Sia_codeps_teps,
                        sia_codnit_teps = tobjModelo.Sia_codnit_teps,
                        sia_deseps_teps = tobjModelo.Sia_deseps_teps,
                        sia_tipase_sita = tobjModelo.Sia_tipase_sita,
                        #endregion
                    };
                    lcrCodigoGen = lobjRegistro.sia_codeps_teps;
                    _context.AddToSiatablaeps(lobjRegistro);
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
        public static void fcvActualizar(ModeloSiatablaeps tobjModelo)
        {
            try
            {
                using (_context = new DbAplicacion())
                {
                    var lobjRegistro = _context.Siatablaeps.FirstOrDefault(p => p.sia_codeps_teps == tobjModelo.Sia_codeps_teps);
                    if (lobjRegistro != null)
                    {
                        lobjRegistro.sia_codeps_teps = tobjModelo.Sia_codeps_teps;
                        lobjRegistro.sia_codnit_teps = tobjModelo.Sia_codnit_teps;
                        lobjRegistro.sia_deseps_teps = tobjModelo.Sia_deseps_teps;
                        lobjRegistro.sia_tipase_sita = tobjModelo.Sia_tipase_sita;
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
                    var lobjRegistro = _context.Siatablaeps.FirstOrDefault(p => p.sia_codeps_teps == tcrCodigo);
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
        #region Buscar SIATABLAEPS: Logica
        /// <summary>
        /// <para>TABLA: siatablaeps</para>
        /// <para>TITULO: Lista de EPS o seguradores</para>
        /// <para>MODULO: SIA</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Lista Codigos y nombres  de EPS contributivo, subsidiado y
        /// Aseguradores, direcciones departamentales de salud  según
        /// la supersalud
        /// </para>
        /// </summary>
        public static bool flgBuscarSiatablaeps(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Siatablaeps.FirstOrDefault(p => p.sia_codeps_teps == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Listar Registros
        public static List<ModeloSiatablaeps> flsListaSiatablaeps(string tcrBuscar)
        {
            using (_context = new DbAplicacion())
            {
                if (string.IsNullOrEmpty(tcrBuscar))
                {
                    var lobConsulta = from siatablaeps in _context.Siatablaeps
                                      join siatipoasegurad in _context.Siatipoasegurad on siatablaeps.sia_tipase_sita equals siatipoasegurad.sia_tipase_sita into tmsiatipoasegurad
                                      from sita in tmsiatipoasegurad.DefaultIfEmpty()
                                      select new ModeloSiatablaeps
                                      {
                                          Sia_codeps_teps = siatablaeps.sia_codeps_teps,
                                          Sia_codnit_teps = siatablaeps.sia_codnit_teps,
                                          Sia_deseps_teps = siatablaeps.sia_deseps_teps,
                                          Sia_tipase_sita = siatablaeps.sia_tipase_sita,
                                          Sia_desase_sita = sita.sia_desase_sita,
                                      };
                    return lobConsulta.ToList();
                }
                else
                {
                    var lobConsulta = from siatablaeps in _context.Siatablaeps
                                      join siatipoasegurad in _context.Siatipoasegurad on siatablaeps.sia_tipase_sita equals siatipoasegurad.sia_tipase_sita into tmsiatipoasegurad
                                      from sita in tmsiatipoasegurad.DefaultIfEmpty()
                                      where siatablaeps.sia_codeps_teps.Contains(tcrBuscar) || siatablaeps.sia_deseps_teps.Contains(tcrBuscar)
                                      select new ModeloSiatablaeps
                                      {
                                          Sia_codeps_teps = siatablaeps.sia_codeps_teps,
                                          Sia_codnit_teps = siatablaeps.sia_codnit_teps,
                                          Sia_deseps_teps = siatablaeps.sia_deseps_teps,
                                          Sia_tipase_sita = siatablaeps.sia_tipase_sita,
                                          Sia_desase_sita = sita.sia_desase_sita,
                                      };
                    return lobConsulta.ToList();
                }
            }
        }
        #endregion
        #endregion
    }
}
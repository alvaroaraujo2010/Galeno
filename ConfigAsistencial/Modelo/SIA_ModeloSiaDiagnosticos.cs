//- MARMOTA-GENCODE: VERSION 2.0 - 10/01/2018 06:16:06 PM
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
    /// Descripcion para la Vista de  la tabla: siadiagnosticos
    /// </summary>
    public class ModeloSiaDiagnosticos : clBaseInpc
    {
        #region Modelo Attributos
        private static DbAplicacion _context;
        #region Modelo Propiedades Notificacion
        #region Sia_coddia_tdia: Codgo Diagnostico
        private String _sia_coddia_tdia;
        /// <summary>
        /// <para>TABLA: siadiagnosticos</para>
        /// <para>TABLA NATIVA: siadiagnosticos</para>
        /// <para>CAMPO: Codgo Diagnostico</para>
        /// <para>NOMBRE: sia_coddia_tdia (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        ///Codgo del diagnostico según la tabla CIE-10
        /// </para>
        /// </summary>
        public String Sia_coddia_tdia
        {
            get { return _sia_coddia_tdia; }
            set
            {
                if (_sia_coddia_tdia == value) return;
                _sia_coddia_tdia = value;
                OnPropertyChanged("Sia_coddia_tdia");
            }
        }
        #endregion
        #region Sia_indice_tdia: Indice tamaño texto
        private int _sia_indice_tdia;
        /// <summary>
        /// <para>TABLA: siadiagnosticos</para>
        /// <para>TABLA NATIVA: siadiagnosticos</para>
        /// <para>CAMPO: Indice tamaño texto</para>
        /// <para>NOMBRE: sia_indice_tdia (numerico:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Indice según tamaño del string texto, para mejorar la busqueda
        /// </para>
        /// </summary>
        public int Sia_indice_tdia
        {
            get { return _sia_indice_tdia; }
            set
            {
                if (_sia_indice_tdia == value) return;
                _sia_indice_tdia = value;
                OnPropertyChanged("Sia_indice_tdia");
            }
        }
        #endregion
        #region Sia_desdia_tdia: Descripcion diagnostico
        private String _sia_desdia_tdia;
        /// <summary>
        /// <para>TABLA: siadiagnosticos</para>
        /// <para>TABLA NATIVA: siadiagnosticos</para>
        /// <para>CAMPO: Descripcion diagnostico</para>
        /// <para>NOMBRE: sia_desdia_tdia (char:240)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        ///Descripcion del diagnostico
        /// </para>
        /// </summary>
        public String Sia_desdia_tdia
        {
            get { return _sia_desdia_tdia; }
            set
            {
                if (_sia_desdia_tdia == value) return;
                _sia_desdia_tdia = value;
                OnPropertyChanged("Sia_desdia_tdia");
            }
        }
        #endregion
        #region Sia_desaux_tdia: Descripcion auxiliar
        private String _sia_desaux_tdia;
        /// <summary>
        /// <para>TABLA: siadiagnosticos</para>
        /// <para>TABLA NATIVA: siadiagnosticos</para>
        /// <para>CAMPO: Descripcion auxiliar</para>
        /// <para>NOMBRE: sia_desaux_tdia (char:240)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        ///Descripcion del diagnostico auxiliar, nombre popular
        /// </para>
        /// </summary>
        public String Sia_desaux_tdia
        {
            get { return _sia_desaux_tdia; }
            set
            {
                if (_sia_desaux_tdia == value) return;
                _sia_desaux_tdia = value;
                OnPropertyChanged("Sia_desaux_tdia");
            }
        }
        #endregion
        #region Sia_altcos_tdia: Alto Costo SI/No
        private String _sia_altcos_tdia;
        /// <summary>
        /// <para>TABLA: siadiagnosticos</para>
        /// <para>TABLA NATIVA: siadiagnosticos</para>
        /// <para>CAMPO: Alto Costo SI/No</para>
        /// <para>NOMBRE: sia_altcos_tdia (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        /// Marca para saber si es diagnostico de alto costo:1=SI, 2=No
        /// </para>
        /// </summary>
        public String Sia_altcos_tdia
        {
            get { return _sia_altcos_tdia; }
            set
            {
                if (_sia_altcos_tdia == value) return;
                _sia_altcos_tdia = value;
                OnPropertyChanged("Sia_altcos_tdia");
            }
        }
        #endregion
        #region Sia_notifc_tdia: Notificacion obligatoria
        private String _sia_notifc_tdia;
        /// <summary>
        /// <para>TABLA: siadiagnosticos</para>
        /// <para>TABLA NATIVA: siadiagnosticos</para>
        /// <para>CAMPO: Notificacion obligatoria</para>
        /// <para>NOMBRE: sia_notifc_tdia (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        /// Marca para saber si es diagnostico de notificacion obligatoria:
        /// 1=SI, 2 = No
        /// </para>
        /// </summary>
        public String Sia_notifc_tdia
        {
            get { return _sia_notifc_tdia; }
            set
            {
                if (_sia_notifc_tdia == value) return;
                _sia_notifc_tdia = value;
                OnPropertyChanged("Sia_notifc_tdia");
            }
        }
        #endregion
        #region Sia_sexapl_tdia: Sexo al que aplica
        private String _sia_sexapl_tdia;
        /// <summary>
        /// <para>TABLA: siadiagnosticos</para>
        /// <para>TABLA NATIVA: siadiagnosticos</para>
        /// <para>CAMPO: Sexo al que aplica</para>
        /// <para>NOMBRE: sia_sexapl_tdia (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        /// Sexo al que aplica el diagnostico: A=Ambos, M=Masculino F=Femenino
        /// </para>
        /// </summary>
        public String Sia_sexapl_tdia
        {
            get { return _sia_sexapl_tdia; }
            set
            {
                if (_sia_sexapl_tdia == value) return;
                _sia_sexapl_tdia = value;
                OnPropertyChanged("Sia_sexapl_tdia");
            }
        }
        #endregion
        #region Sia_edaini_tdia: Edad inicial
        private int _sia_edaini_tdia;
        /// <summary>
        /// <para>TABLA: siadiagnosticos</para>
        /// <para>TABLA NATIVA: siadiagnosticos</para>
        /// <para>CAMPO: Edad inicial</para>
        /// <para>NOMBRE: sia_edaini_tdia (numerico:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        ///Edad incial para la cual aplica el diagnostico
        /// </para>
        /// </summary>
        public int Sia_edaini_tdia
        {
            get { return _sia_edaini_tdia; }
            set
            {
                if (_sia_edaini_tdia == value) return;
                _sia_edaini_tdia = value;
                OnPropertyChanged("Sia_edaini_tdia");
            }
        }
        #endregion
        #region Sia_medini_tdia: Medida edad inicial
        private String _sia_medini_tdia;
        /// <summary>
        /// <para>TABLA: siadiagnosticos</para>
        /// <para>TABLA NATIVA: siadiagnosticos</para>
        /// <para>CAMPO: Medida edad inicial</para>
        /// <para>NOMBRE: sia_medini_tdia (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION:
        ///Medida edad inical: 1=Año, 2=Meses, 3=Dias
        /// </para>
        /// </summary>
        public String Sia_medini_tdia
        {
            get { return _sia_medini_tdia; }
            set
            {
                if (_sia_medini_tdia == value) return;
                _sia_medini_tdia = value;
                OnPropertyChanged("Sia_medini_tdia");
            }
        }
        #endregion
        #region Sia_edafin_tdia: Edad final
        private int _sia_edafin_tdia;
        /// <summary>
        /// <para>TABLA: siadiagnosticos</para>
        /// <para>TABLA NATIVA: siadiagnosticos</para>
        /// <para>CAMPO: Edad final</para>
        /// <para>NOMBRE: sia_edafin_tdia (numerico:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
        /// <para>DESCRIPCION:
        ///Edad final para la cual aplica el diagnostico
        /// </para>
        /// </summary>
        public int Sia_edafin_tdia
        {
            get { return _sia_edafin_tdia; }
            set
            {
                if (_sia_edafin_tdia == value) return;
                _sia_edafin_tdia = value;
                OnPropertyChanged("Sia_edafin_tdia");
            }
        }
        #endregion
        #region Sia_medfin_tdia: Medida endad final
        private String _sia_medfin_tdia;
        /// <summary>
        /// <para>TABLA: siadiagnosticos</para>
        /// <para>TABLA NATIVA: siadiagnosticos</para>
        /// <para>CAMPO: Medida endad final</para>
        /// <para>NOMBRE: sia_medfin_tdia (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 11</para>
        /// <para>DESCRIPCION:
        ///Medida edad final: 1=Año, 2=Meses, 3=Dias
        /// </para>
        /// </summary>
        public String Sia_medfin_tdia
        {
            get { return _sia_medfin_tdia; }
            set
            {
                if (_sia_medfin_tdia == value) return;
                _sia_medfin_tdia = value;
                OnPropertyChanged("Sia_medfin_tdia");
            }
        }
        #endregion
        #endregion
        #endregion
        #region Metodos para edicion de registros
        #region Adicionar Registro
        public static String flgAddRegistro(ModeloSiaDiagnosticos tobjModelo)
        {
            var lcrCodigoGen = String.Empty;
            try
            {
                using (_context = new DbAplicacion())
                {
                    var lobjRegistro = new EFsiadiagnosticos
                    {
                        #region cargar Registro
                        sia_coddia_tdia = tobjModelo.Sia_coddia_tdia,
                        sia_indice_tdia = tobjModelo.Sia_indice_tdia,
                        sia_desdia_tdia = tobjModelo.Sia_desdia_tdia,
                        sia_desaux_tdia = tobjModelo.Sia_desaux_tdia,
                        sia_altcos_tdia = tobjModelo.Sia_altcos_tdia,
                        sia_notifc_tdia = tobjModelo.Sia_notifc_tdia,
                        sia_sexapl_tdia = tobjModelo.Sia_sexapl_tdia,
                        sia_edaini_tdia = tobjModelo.Sia_edaini_tdia,
                        sia_medini_tdia = tobjModelo.Sia_medini_tdia,
                        sia_edafin_tdia = tobjModelo.Sia_edafin_tdia,
                        sia_medfin_tdia = tobjModelo.Sia_medfin_tdia,
                        #endregion
                    };
                    lcrCodigoGen = lobjRegistro.sia_coddia_tdia;
                    _context.AddToSiadiagnosticos(lobjRegistro);
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
        public static void fcvActualizar(ModeloSiaDiagnosticos tobjModelo)
        {
            try
            {
                using (_context = new DbAplicacion())
                {
                    var lobjRegistro = _context.Siadiagnosticos.FirstOrDefault(p => p.sia_coddia_tdia == tobjModelo.Sia_coddia_tdia);
                    if (lobjRegistro != null)
                    {
                        #region cargar Registro
                        lobjRegistro.sia_coddia_tdia = tobjModelo.Sia_coddia_tdia;
                        lobjRegistro.sia_indice_tdia = (int)tobjModelo.Sia_indice_tdia;
                        lobjRegistro.sia_desdia_tdia = tobjModelo.Sia_desdia_tdia;
                        lobjRegistro.sia_desaux_tdia = tobjModelo.Sia_desaux_tdia;
                        lobjRegistro.sia_altcos_tdia = tobjModelo.Sia_altcos_tdia;
                        lobjRegistro.sia_notifc_tdia = tobjModelo.Sia_notifc_tdia;
                        lobjRegistro.sia_sexapl_tdia = tobjModelo.Sia_sexapl_tdia;
                        lobjRegistro.sia_edaini_tdia = (int)tobjModelo.Sia_edaini_tdia;
                        lobjRegistro.sia_medini_tdia = tobjModelo.Sia_medini_tdia;
                        lobjRegistro.sia_edafin_tdia = (int)tobjModelo.Sia_edafin_tdia;
                        lobjRegistro.sia_medfin_tdia = tobjModelo.Sia_medfin_tdia;
                        #endregion
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
        public static void fcvEliminar(String tcrCodigo)
        {
            try
            {
                using (_context = new DbAplicacion())
                {
                    var lobjRegistro = _context.Siadiagnosticos.FirstOrDefault(p => p.sia_coddia_tdia == tcrCodigo);
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
        #region Buscar SIADIAGNOSTICOS: Logica
        /// <summary>
        /// <para>TABLA: siadiagnosticos</para>
        /// <para>TITULO: Tabla de diagnosticos CIE - 10</para>
        /// <para>MODULO: SIA</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        ///Talba de diagnositicos CIE-10
        /// </para>
        /// </summary>
        public static bool flgBuscarSiadiagnosticos(String tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Siadiagnosticos.FirstOrDefault(p => p.sia_coddia_tdia == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Listar Registros
        public static List<ModeloSiaDiagnosticos> flsListaSiadiagnosticos(String tcrBuscar)
        {
            using (_context = new DbAplicacion())
            {
                if (String.IsNullOrEmpty(tcrBuscar))
                {
                    var lobConsulta = from siadiagnosticos in _context.Siadiagnosticos
                                      select new ModeloSiaDiagnosticos
                                      {
                                          #region Datos
                                          Sia_coddia_tdia = siadiagnosticos.sia_coddia_tdia,
                                          Sia_indice_tdia = (int)siadiagnosticos.sia_indice_tdia,
                                          Sia_desdia_tdia = siadiagnosticos.sia_desdia_tdia,
                                          Sia_desaux_tdia = siadiagnosticos.sia_desaux_tdia,
                                          Sia_altcos_tdia = siadiagnosticos.sia_altcos_tdia,
                                          Sia_notifc_tdia = siadiagnosticos.sia_notifc_tdia,
                                          Sia_sexapl_tdia = siadiagnosticos.sia_sexapl_tdia,
                                          Sia_edaini_tdia = (int)siadiagnosticos.sia_edaini_tdia,
                                          Sia_medini_tdia = siadiagnosticos.sia_medini_tdia,
                                          Sia_edafin_tdia = (int)siadiagnosticos.sia_edafin_tdia,
                                          Sia_medfin_tdia = siadiagnosticos.sia_medfin_tdia,
                                          #endregion
                                      };
                    return lobConsulta.ToList();
                }
                else
                {
                    var lobConsulta = from siadiagnosticos in _context.Siadiagnosticos
                                      where siadiagnosticos.sia_coddia_tdia.Contains(tcrBuscar) || siadiagnosticos.sia_desdia_tdia.Contains(tcrBuscar)
                                      select new ModeloSiaDiagnosticos
                                      {
                                          #region Datos
                                          Sia_coddia_tdia = siadiagnosticos.sia_coddia_tdia,
                                          Sia_indice_tdia = (int)siadiagnosticos.sia_indice_tdia,
                                          Sia_desdia_tdia = siadiagnosticos.sia_desdia_tdia,
                                          Sia_desaux_tdia = siadiagnosticos.sia_desaux_tdia,
                                          Sia_altcos_tdia = siadiagnosticos.sia_altcos_tdia,
                                          Sia_notifc_tdia = siadiagnosticos.sia_notifc_tdia,
                                          Sia_sexapl_tdia = siadiagnosticos.sia_sexapl_tdia,
                                          Sia_edaini_tdia = (int)siadiagnosticos.sia_edaini_tdia,
                                          Sia_medini_tdia = siadiagnosticos.sia_medini_tdia,
                                          Sia_edafin_tdia = (int)siadiagnosticos.sia_edafin_tdia,
                                          Sia_medfin_tdia = siadiagnosticos.sia_medfin_tdia,
                                          #endregion
                                      };
                    return lobConsulta.ToList();
                }
            }
        }
        #endregion
        #endregion
    }
}
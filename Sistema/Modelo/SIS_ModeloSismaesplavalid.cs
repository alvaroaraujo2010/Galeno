//- MARMOTA-GENCODE: VERSION 2.0 - 06/10/2014 05:17:32 PM
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

namespace Sistema.Modelo
{
    /// <summary>
    /// Descripcion para la Vista de  la tabla: sismaesplavalid
    /// </summary>
    public class ModeloSismaesplavalid : clBaseInpc
    {
        #region Modelo Attributos
        private static DbAplicacion _context;
        #region Modelo Propiedades Notificacion
        #region Sis_secreg_siva: Codigo plantilla
        private String _sis_secreg_siva;
        /// <summary>
        /// <para>TABLA: sismaesplavalid</para>
        /// <para>TABLA NATIVA: sismaesplavalid</para>
        /// <para>CAMPO: Codigo plantilla</para>
        /// <para>NOMBRE: sis_secreg_siva (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        ///Código secuencial unico registro maestro para plantillas
        /// </para>
        /// </summary>
        public String Sis_secreg_siva
        {
            get { return _sis_secreg_siva; }
            set
            {
                if (_sis_secreg_siva == value) return;
                _sis_secreg_siva = value;
                OnPropertyChanged("Sis_secreg_siva");
            }
        }
        #endregion
        #region Sis_codarc_siar: Identificador archivos
        private String _sis_codarc_siar;
        /// <summary>
        /// <para>TABLA: sismaesplavalid</para>
        /// <para>TABLA NATIVA: sistipoarchivos</para>
        /// <para>CAMPO: Identificador archivos</para>
        /// <para>NOMBRE: sis_codarc_siar (char:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Código identificador clasificacion del archivo: RIPSAC = Rips
        /// consulta, RIPSAP=Rips Procedimiento, RE4505 = Resolucion 4505
        /// y otros
        /// </para>
        /// </summary>
        public String Sis_codarc_siar
        {
            get { return _sis_codarc_siar; }
            set
            {
                if (_sis_codarc_siar == value) return;
                _sis_codarc_siar = value;
                OnPropertyChanged("Sis_codarc_siar");
            }
        }
        #endregion
        #region Sis_despla_siva: Descripción  plantilla
        private String _sis_despla_siva;
        /// <summary>
        /// <para>TABLA: sismaesplavalid</para>
        /// <para>TABLA NATIVA: sismaesplavalid</para>
        /// <para>CAMPO: Descripción  plantilla</para>
        /// <para>NOMBRE: sis_despla_siva (char:50)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        /// Nombre o descripción de la plantilla ejemplo: Validacion 4505
        /// EPS033 - Saludvida
        /// </para>
        /// </summary>
        public String Sis_despla_siva
        {
            get { return _sis_despla_siva; }
            set
            {
                if (_sis_despla_siva == value) return;
                _sis_despla_siva = value;
                OnPropertyChanged("Sis_despla_siva");
            }
        }
        #endregion
        #region Sis_codval_siva: Codigo fuente plantilla
        private String _sis_codval_siva;
        /// <summary>
        /// <para>TABLA: sismaesplavalid</para>
        /// <para>TABLA NATIVA: sismaesplavalid</para>
        /// <para>CAMPO: Codigo fuente plantilla</para>
        /// <para>NOMBRE: sis_codval_siva (memo:)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        ///Codigo fuente base de las funciones de validacion
        /// </para>
        /// </summary>
        public String Sis_codval_siva
        {
            get { return _sis_codval_siva; }
            set
            {
                if (_sis_codval_siva == value) return;
                _sis_codval_siva = value;
                OnPropertyChanged("Sis_codval_siva");
            }
        }
        #endregion
        #region Sis_secdet_siva: Secuencial reg Detalles
        private int _sis_secdet_siva;
        /// <summary>
        /// <para>TABLA: sismaesplavalid</para>
        /// <para>TABLA NATIVA: sismaesplavalid</para>
        /// <para>CAMPO: Secuencial reg Detalles</para>
        /// <para>NOMBRE: sis_secdet_siva (int:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        ///Campo para generar el secuencial de los registros detalles
        /// </para>
        /// </summary>
        public int Sis_secdet_siva
        {
            get { return _sis_secdet_siva; }
            set
            {
                if (_sis_secdet_siva == value) return;
                _sis_secdet_siva = value;
                OnPropertyChanged("Sis_secdet_siva");
            }
        }
        #endregion
        #region Sis_tippla_siva: Tipo plantilla
        private String _sis_tippla_siva;
        /// <summary>
        /// <para>TABLA: sismaesplavalid</para>
        /// <para>TABLA NATIVA: sismaesplavalid</para>
        /// <para>CAMPO: Tipo plantilla</para>
        /// <para>NOMBRE: sis_tippla_siva (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        /// Tipo plantilla: 1= Plantilla Validacion por defecto  2= Planitlla
        /// validacion personalizada
        /// </para>
        /// </summary>
        public String Sis_tippla_siva
        {
            get { return _sis_tippla_siva; }
            set
            {
                if (_sis_tippla_siva == value) return;
                _sis_tippla_siva = value;
                OnPropertyChanged("Sis_tippla_siva");
            }
        }
        #endregion
        #region Sis_estreg_siva: Estado plantilla
        private String _sis_estreg_siva;
        /// <summary>
        /// <para>TABLA: sismaesplavalid</para>
        /// <para>TABLA NATIVA: sismaesplavalid</para>
        /// <para>CAMPO: Estado plantilla</para>
        /// <para>NOMBRE: sis_estreg_siva (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        ///Estado plantilla 1=Activa 2=Inactiva
        /// </para>
        /// </summary>
        public String Sis_estreg_siva
        {
            get { return _sis_estreg_siva; }
            set
            {
                if (_sis_estreg_siva == value) return;
                _sis_estreg_siva = value;
                OnPropertyChanged("Sis_estreg_siva");
            }
        }
        #endregion
        #region Sis_desarc_siar: Descripción archivo
        private String _sis_desarc_siar;
        /// <summary>
        /// <para>TABLA: sismaesplavalid</para>
        /// <para>TABLA NATIVA: sistipoarchivos</para>
        /// <para>CAMPO: Descripción archivo</para>
        /// <para>NOMBRE: sis_desarc_siar (char:50)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripción identificador de archivos
        /// </para>
        /// </summary>
        public String Sis_desarc_siar
        {
            get { return _sis_desarc_siar; }
            set
            {
                if (_sis_desarc_siar == value) return;
                _sis_desarc_siar = value;
                OnPropertyChanged("Sis_desarc_siar");
            }
        }
        #endregion
        #endregion
        #endregion
        #region Metodos para edicion de registros
        #region Adicionar Registro
        public static string flgAddRegistro(ModeloSismaesplavalid tobjModelo)
        {
            var lcrCodigoGen = SysModelo.fcrGenerarNuevoCodigo("SIS-PLANTILLA-VALIDACION", "SIS", "Maestro Planitllas para validación de archivos");
            if (!flgBuscarSismaesplavalid(lcrCodigoGen))
            {
                using (_context = new DbAplicacion())
                {
                    var lobjRegistro = new EFsismaesplavalid
                    {
                        #region cargar Registro
                        sis_secreg_siva = tobjModelo.Sis_secreg_siva,
                        sis_codarc_siar = tobjModelo.Sis_codarc_siar,
                        sis_despla_siva = tobjModelo.Sis_despla_siva,
                        sis_codval_siva = tobjModelo.Sis_codval_siva,
                        sis_secdet_siva = tobjModelo.Sis_secdet_siva,
                        sis_tippla_siva = tobjModelo.Sis_tippla_siva,
                        sis_estreg_siva = tobjModelo.Sis_estreg_siva,
                        #endregion
                    };
                    lobjRegistro.sis_secreg_siva = lcrCodigoGen;
                    _context.AddToSismaesplavalid(lobjRegistro);
                    _context.SaveChanges();
                }
            }
            else
            {
                lcrCodigoGen = string.Empty;
                MessageBox.Show("Nuevo codigo Generado esta desactualizado, revisar llave: \n" +
                                "'SIS-PLANTILLA-VALIDACION': Maestro Planitllas para validación de archivos en Maestro Secuenciales.");
            }
            return lcrCodigoGen;
        }
        #endregion
        #region Modificar Registro
        public static void fcvActualizar(ModeloSismaesplavalid tobjModelo)
        {
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Sismaesplavalid.FirstOrDefault(p => p.sis_secreg_siva == tobjModelo.Sis_secreg_siva);
                if (lobjRegistro != null)
                {
                    lobjRegistro.sis_secreg_siva = tobjModelo.Sis_secreg_siva;
                    lobjRegistro.sis_codarc_siar = tobjModelo.Sis_codarc_siar;
                    lobjRegistro.sis_despla_siva = tobjModelo.Sis_despla_siva;
                    lobjRegistro.sis_codval_siva = tobjModelo.Sis_codval_siva;
                    lobjRegistro.sis_secdet_siva = (int)tobjModelo.Sis_secdet_siva;
                    lobjRegistro.sis_tippla_siva = tobjModelo.Sis_tippla_siva;
                    lobjRegistro.sis_estreg_siva = tobjModelo.Sis_estreg_siva;
                    _context.SaveChanges();
                }
            }
        }
        #endregion
        #region Eliminar registro
        public static void fcvEliminar(string tcrCodigo)
        {
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Sismaesplavalid.FirstOrDefault(p => p.sis_secreg_siva == tcrCodigo);
                if (lobjRegistro != null)
                {
                    _context.DeleteObject(lobjRegistro);
                    _context.SaveChanges();
                }
            }
        }
        #endregion
        #region Buscar SISMAESPLAVALID: Logica
        /// <summary>
        /// <para>TABLA: sismaesplavalid</para>
        /// <para>TITULO: Maestro plantillas para validación de archivos</para>
        /// <para>MODULO: SIS</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro de plantillas para configurar validacion personalizada
        /// de archivos tales como: Archivos Rips  Archivo Resolución 4505
        /// y otros.
        /// </para>
        /// </summary>
        public static bool flgBuscarSismaesplavalid(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Sismaesplavalid.FirstOrDefault(p => p.sis_secreg_siva == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Listar Registros
        public static List<ModeloSismaesplavalid> flsListaSismaesplavalid(string tcrBuscar)
        {
            using (_context = new DbAplicacion())
            {
                if (string.IsNullOrEmpty(tcrBuscar))
                {
                    var lobConsulta = from sismaesplavalid in _context.Sismaesplavalid
                                      join sistipoarchivos in _context.Sistipoarchivos on sismaesplavalid.sis_codarc_siar equals sistipoarchivos.sis_codarc_siar into tmsistipoarchivos
                                      from siar in tmsistipoarchivos.DefaultIfEmpty()
                                      select new ModeloSismaesplavalid
                                      {
                                          Sis_secreg_siva = sismaesplavalid.sis_secreg_siva,
                                          Sis_codarc_siar = sismaesplavalid.sis_codarc_siar,
                                          Sis_despla_siva = sismaesplavalid.sis_despla_siva,
                                          Sis_codval_siva = sismaesplavalid.sis_codval_siva,
                                          Sis_secdet_siva = (int)sismaesplavalid.sis_secdet_siva,
                                          Sis_tippla_siva = sismaesplavalid.sis_tippla_siva,
                                          Sis_estreg_siva = sismaesplavalid.sis_estreg_siva,
                                          Sis_desarc_siar = siar.sis_desarc_siar,
                                      };
                    return lobConsulta.ToList();
                }
                else
                {
                    var lobConsulta = from sismaesplavalid in _context.Sismaesplavalid
                                      join sistipoarchivos in _context.Sistipoarchivos on sismaesplavalid.sis_codarc_siar equals sistipoarchivos.sis_codarc_siar into tmsistipoarchivos
                                      from siar in tmsistipoarchivos.DefaultIfEmpty()
                                      where sismaesplavalid.sis_secreg_siva.Contains(tcrBuscar) || sismaesplavalid.sis_despla_siva.Contains(tcrBuscar)
                                      select new ModeloSismaesplavalid
                                      {
                                          Sis_secreg_siva = sismaesplavalid.sis_secreg_siva,
                                          Sis_codarc_siar = sismaesplavalid.sis_codarc_siar,
                                          Sis_despla_siva = sismaesplavalid.sis_despla_siva,
                                          Sis_codval_siva = sismaesplavalid.sis_codval_siva,
                                          Sis_secdet_siva = (int)sismaesplavalid.sis_secdet_siva,
                                          Sis_tippla_siva = sismaesplavalid.sis_tippla_siva,
                                          Sis_estreg_siva = sismaesplavalid.sis_estreg_siva,
                                          Sis_desarc_siar = siar.sis_desarc_siar,
                                      };
                    return lobConsulta.ToList();
                }
            }
        }
        #endregion
        #endregion
    }
    /// <summary>
    /// Descripcion para la Vista de  la tabla: sismadeplavalid
    /// </summary>
    public class ModeloSismadeplavalid : clBaseInpc
    {
        #region Modelo Attributos
        private static DbAplicacion _context;
        #region Modelo Propiedades Notificacion
        #region Sis_secreg_sivd: Codigo registro
        private String _sis_secreg_sivd;
        /// <summary>
        /// <para>TABLA: sismadeplavalid</para>
        /// <para>TABLA NATIVA: sismadeplavalid</para>
        /// <para>CAMPO: Codigo registro</para>
        /// <para>NOMBRE: sis_secreg_sivd (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        /// Código secuencial detalle id unico para cada registro de campo
        /// </para>
        /// </summary>
        public String Sis_secreg_sivd
        {
            get { return _sis_secreg_sivd; }
            set
            {
                if (_sis_secreg_sivd == value) return;
                _sis_secreg_sivd = value;
                OnPropertyChanged("Sis_secreg_sivd");
            }
        }
        #endregion
        #region Sis_secreg_siva: Codigo plantilla
        private String _sis_secreg_siva;
        /// <summary>
        /// <para>TABLA: sismadeplavalid</para>
        /// <para>TABLA NATIVA: sismaesplavalid</para>
        /// <para>CAMPO: Codigo plantilla</para>
        /// <para>NOMBRE: sis_secreg_siva (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Secuencial relacionado con la tabla principal R1  maestro para
        /// plantillas para validacion
        /// </para>
        /// </summary>
        public String Sis_secreg_siva
        {
            get { return _sis_secreg_siva; }
            set
            {
                if (_sis_secreg_siva == value) return;
                _sis_secreg_siva = value;
                OnPropertyChanged("Sis_secreg_siva");
            }
        }
        #endregion
        #region Sis_codcam_sivd: Nombre unico campo
        private String _sis_codcam_sivd;
        /// <summary>
        /// <para>TABLA: sismadeplavalid</para>
        /// <para>TABLA NATIVA: sismadeplavalid</para>
        /// <para>CAMPO: Nombre unico campo</para>
        /// <para>NOMBRE: sis_codcam_sivd (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        /// Nombre único del campo (ejemplo: SSP_CAM025_MS45, HCL_CODREG_HCVD)
        /// </para>
        /// </summary>
        public String Sis_codcam_sivd
        {
            get { return _sis_codcam_sivd; }
            set
            {
                if (_sis_codcam_sivd == value) return;
                _sis_codcam_sivd = value;
                OnPropertyChanged("Sis_codcam_sivd");
            }
        }
        #endregion
        #region Sis_nomcam_sivd: Titulo o Etiqueta
        private String _sis_nomcam_sivd;
        /// <summary>
        /// <para>TABLA: sismadeplavalid</para>
        /// <para>TABLA NATIVA: sismadeplavalid</para>
        /// <para>CAMPO: Titulo o Etiqueta</para>
        /// <para>NOMBRE: sis_nomcam_sivd (char:150)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        ///Titulo o etiqueta del campo (descripcion corta del campo)
        /// </para>
        /// </summary>
        public String Sis_nomcam_sivd
        {
            get { return _sis_nomcam_sivd; }
            set
            {
                if (_sis_nomcam_sivd == value) return;
                _sis_nomcam_sivd = value;
                OnPropertyChanged("Sis_nomcam_sivd");
            }
        }
        #endregion
        #region Sis_codval_sivd: Codigo fuente validacion
        private String _sis_codval_sivd;
        /// <summary>
        /// <para>TABLA: sismadeplavalid</para>
        /// <para>TABLA NATIVA: sismadeplavalid</para>
        /// <para>CAMPO: Codigo fuente validacion</para>
        /// <para>NOMBRE: sis_codval_sivd (memo:)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        ///Codigo fuente para realizar validación personalizada
        /// </para>
        /// </summary>
        public String Sis_codval_sivd
        {
            get { return _sis_codval_sivd; }
            set
            {
                if (_sis_codval_sivd == value) return;
                _sis_codval_sivd = value;
                OnPropertyChanged("Sis_codval_sivd");
            }
        }
        #endregion
        #region Sis_ordvis_sivd: Orden Vista
        private int _sis_ordvis_sivd;
        /// <summary>
        /// <para>TABLA: sismadeplavalid</para>
        /// <para>TABLA NATIVA: sismadeplavalid</para>
        /// <para>CAMPO: Orden Vista</para>
        /// <para>NOMBRE: sis_ordvis_sivd (int:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        /// Orden de vista del campo en la resolucion (inicia desde campo
        /// cero (0) hasta 118)
        /// </para>
        /// </summary>
        public int Sis_ordvis_sivd
        {
            get { return _sis_ordvis_sivd; }
            set
            {
                if (_sis_ordvis_sivd == value) return;
                _sis_ordvis_sivd = value;
                OnPropertyChanged("Sis_ordvis_sivd");
            }
        }
        #endregion
        #region Sis_estreg_sivd: Estado campo validación
        private String _sis_estreg_sivd;
        /// <summary>
        /// <para>TABLA: sismadeplavalid</para>
        /// <para>TABLA NATIVA: sismadeplavalid</para>
        /// <para>CAMPO: Estado campo validación</para>
        /// <para>NOMBRE: sis_estreg_sivd (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        ///Estado del campo para validación: 1=Activo 2=Inactivo
        /// </para>
        /// </summary>
        public String Sis_estreg_sivd
        {
            get { return _sis_estreg_sivd; }
            set
            {
                if (_sis_estreg_sivd == value) return;
                _sis_estreg_sivd = value;
                OnPropertyChanged("Sis_estreg_sivd");
            }
        }
        #endregion
        #region Sis_despla_siva: Descripción  plantilla
        private String _sis_despla_siva;
        /// <summary>
        /// <para>TABLA: sismadeplavalid</para>
        /// <para>TABLA NATIVA: sismaesplavalid</para>
        /// <para>CAMPO: Descripción  plantilla</para>
        /// <para>NOMBRE: sis_despla_siva (char:50)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        /// Nombre o descripción de la plantilla ejemplo: Validacion 4505
        /// EPS033 - Saludvida
        /// </para>
        /// </summary>
        public String Sis_despla_siva
        {
            get { return _sis_despla_siva; }
            set
            {
                if (_sis_despla_siva == value) return;
                _sis_despla_siva = value;
                OnPropertyChanged("Sis_despla_siva");
            }
        }
        #endregion
        #region Sis_estado_imaen: Estado del registro para edicion
        private string _sis_estado_imaen;
        /// <summary>
        /// <para>CAMPO: Estado del Registro Para Edicion</para>
        /// <para>NOMBRE: Sis_estado_imaen (char:1)</para>
        /// <para>DESCRIPCION:
        /// Estado del registro para proceso de edicion
        /// I=Ingnorar,M=Modificar,A=Adicionar
        /// E=Eliminar,N=Nulo (esta en nulo)
        /// </para>
        /// </summary>
        public String Sis_estado_imaen
        {
            get { return _sis_estado_imaen; }
            set
            {
                if (_sis_estado_imaen == value) return;
                _sis_estado_imaen = value;
                OnPropertyChanged("Sis_estado_imaen");
            }
        }
        #endregion
        #endregion
        #endregion
        #region Metodos para edicion de registros
        #region Adicionar Registro Relacion
        public static bool flgAddRegistro(ModeloSismadeplavalid tobTempReg, string tcrCodigoR1)
        {
            bool llgReturn = false;
            try
            {
                using (_context = new DbAplicacion())
                {
                    llgReturn = true;
                    var lobEFReg = new EFsismadeplavalid();
                    //-----------------------
                    if (tobTempReg.Sis_estado_imaen == "M")
                    {
                        lobEFReg = _context.Sismadeplavalid.FirstOrDefault(p => p.sis_secreg_sivd == tobTempReg.Sis_secreg_sivd);
                    }
                    if (tobTempReg.Sis_estado_imaen == "A" || tobTempReg.Sis_estado_imaen == "M") // Adicionar o Modificar
                    {
                        #region cargar Registro
                        if (lobEFReg != null)
                        {
                            lobEFReg.sis_secreg_sivd = tobTempReg.Sis_secreg_sivd;
                            lobEFReg.sis_secreg_siva = tobTempReg.Sis_secreg_siva;
                            lobEFReg.sis_codcam_sivd = tobTempReg.Sis_codcam_sivd;
                            lobEFReg.sis_nomcam_sivd = tobTempReg.Sis_nomcam_sivd;
                            lobEFReg.sis_codval_sivd = tobTempReg.Sis_codval_sivd;
                            lobEFReg.sis_ordvis_sivd = (int)tobTempReg.Sis_ordvis_sivd;
                            lobEFReg.sis_estreg_sivd = tobTempReg.Sis_estreg_sivd;
                        }
                        #endregion
                    }
                    //---------------------------
                    // Guardar cambios o eliminar
                    //---------------------------
                    if (lobEFReg != null)
                    {
                        switch (tobTempReg.Sis_estado_imaen)
                        {
                            case "A": // Adicionar el registro
                                lobEFReg.sis_secreg_sivd = tcrCodigoR1 + lobEFReg.sis_secreg_sivd; // concatenar
                                _context.AddToSismadeplavalid(lobEFReg);
                                _context.SaveChanges();
                                break;

                            case "M": // Modificar el registro
                                _context.SaveChanges();
                                break;

                            case "E": // Eliminar el registro
                                var lobjRegistro = _context.Sismadeplavalid.FirstOrDefault(p => p.sis_secreg_sivd == tobTempReg.Sis_secreg_sivd);
                                if (lobjRegistro != null)
                                {
                                    _context.DeleteObject(lobjRegistro);
                                    _context.SaveChanges();
                                }
                                break;
                        }
                    }
                }
            }
            catch (NotImplementedException ex)
            {
                llgReturn = false;
                MessageBox.Show(ex.Message, "Modelo Error Metodo: flgAddRegistro");
            }
            return llgReturn;
        }
        #endregion
        #region Buscar SISMADEPLAVALID: Logica
        /// <summary>
        /// <para>TABLA: sismadeplavalid</para>
        /// <para>TITULO: Registros o campos detalle para plantillas de validación</para>
        /// <para>MODULO: SIS</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Registros o campos detalle para configurar las validaciones
        /// de cada plantilla personalizada
        /// </para>
        /// </summary>
        public static bool flgBuscarSismadeplavalid(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Sismadeplavalid.FirstOrDefault(p => p.sis_secreg_sivd == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Listar Registros
        public static List<ModeloSismadeplavalid> flsListaSismadeplavalid(string tcrBuscar)
        {
            using (_context = new DbAplicacion())
            {
                var lobConsulta = from sismadeplavalid in _context.Sismadeplavalid
                                  join sismaesplavalid in _context.Sismaesplavalid on sismadeplavalid.sis_secreg_siva equals sismaesplavalid.sis_secreg_siva into tmsismaesplavalid
                                  from siva in tmsismaesplavalid.DefaultIfEmpty()
                                  where sismadeplavalid.sis_secreg_siva == tcrBuscar
                                  select new ModeloSismadeplavalid
                                  {
                                      Sis_secreg_sivd = sismadeplavalid.sis_secreg_sivd,
                                      Sis_secreg_siva = sismadeplavalid.sis_secreg_siva,
                                      Sis_codcam_sivd = sismadeplavalid.sis_codcam_sivd,
                                      Sis_nomcam_sivd = sismadeplavalid.sis_nomcam_sivd,
                                      Sis_codval_sivd = sismadeplavalid.sis_codval_sivd,
                                      Sis_ordvis_sivd = (int)sismadeplavalid.sis_ordvis_sivd,
                                      Sis_estreg_sivd = sismadeplavalid.sis_estreg_sivd,
                                      Sis_despla_siva = siva.sis_despla_siva,
                                      Sis_estado_imaen = "I",
                                  };
                return lobConsulta.ToList();
            }
        }
        #endregion
        #endregion
    }
}
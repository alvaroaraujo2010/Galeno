//- MARMOTA-GENCODE: VERSION 2.0 - 04/11/2016 07:06:25 AM
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

namespace Inventarios.Modelo
{
    /// <summary>
    /// Descripcion para la Vista de  la tabla: invalmacenmaest
    /// </summary>
    public class ModeloInvMaestroalmacen : clBaseInpc
    {
        #region Modelo Attributos
        private static DbAplicacion _context;
        #region Modelo Propiedades Notificacion
        #region Inv_codalm_inal: Código Almacén
        private String _inv_codalm_inal;
        /// <summary>
        /// <para>TABLA: invalmacenmaest</para>
        /// <para>TABLA NATIVA: invalmacenmaest</para>
        /// <para>CAMPO: Código Almacén</para>
        /// <para>NOMBRE: inv_codalm_inal (char:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        ///Código del Almacén
        /// </para>
        /// </summary>
        public String Inv_codalm_inal
        {
            get { return _inv_codalm_inal; }
            set
            {
                if (_inv_codalm_inal == value) return;
                _inv_codalm_inal = value;
                OnPropertyChanged("Inv_codalm_inal");
            }
        }
        #endregion
        #region Inv_desalm_inal: Descripción Almacén
        private String _inv_desalm_inal;
        /// <summary>
        /// <para>TABLA: invalmacenmaest</para>
        /// <para>TABLA NATIVA: invalmacenmaest</para>
        /// <para>CAMPO: Descripción Almacén</para>
        /// <para>NOMBRE: inv_desalm_inal (char:60)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripción del almacén
        /// </para>
        /// </summary>
        public String Inv_desalm_inal
        {
            get { return _inv_desalm_inal; }
            set
            {
                if (_inv_desalm_inal == value) return;
                _inv_desalm_inal = value;
                OnPropertyChanged("Inv_desalm_inal");
            }
        }
        #endregion
        #region Inv_polpre_inal: Origen Gestion Precios
        private String _inv_polpre_inal;
        /// <summary>
        /// <para>TABLA: invalmacenmaest</para>
        /// <para>TABLA NATIVA: invalmacenmaest</para>
        /// <para>CAMPO: Origen Gestion Precios</para>
        /// <para>NOMBRE: inv_polpre_inal (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        /// Configruacion orgen gestion precio de Venta: 1= Precio según
        /// configuracion Maestro almacen (aqui) 2= Precio desde Valores
        /// Configuracion en Manual tarifario 3=Precio desde  Configuracion
        /// en manual de cada articulo
        /// </para>
        /// </summary>
        public String Inv_polpre_inal
        {
            get { return _inv_polpre_inal; }
            set
            {
                if (_inv_polpre_inal == value) return;
                _inv_polpre_inal = value;
                OnPropertyChanged("Inv_polpre_inal");
            }
        }
        #endregion
        #region Inv_polppi_inal: Politica precios
        private String _inv_polppi_inal;
        /// <summary>
        /// <para>TABLA: invalmacenmaest</para>
        /// <para>TABLA NATIVA: invalmacenmaest</para>
        /// <para>CAMPO: Politica precios</para>
        /// <para>NOMBRE: inv_polppi_inal (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        /// (Cuando se aplique desde almacen) Políticas Precios calculo
        /// valor venta articulos Almacén: 1= No Aplica desde almacen,
        /// 2=Costo ultima compra mas incremento  3= Precio desde manual
        /// articulos
        /// </para>
        /// </summary>
        public String Inv_polppi_inal
        {
            get { return _inv_polppi_inal; }
            set
            {
                if (_inv_polppi_inal == value) return;
                _inv_polppi_inal = value;
                OnPropertyChanged("Inv_polppi_inal");
            }
        }
        #endregion
        #region Inv_porive_inal: Procentaje incremento
        private float _inv_porive_inal;
        /// <summary>
        /// <para>TABLA: invalmacenmaest</para>
        /// <para>TABLA NATIVA: invalmacenmaest</para>
        /// <para>CAMPO: Procentaje incremento</para>
        /// <para>NOMBRE: inv_porive_inal (float:52)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        /// Porcentaje Incremento para Precios de Venta  Cuando se Controle
        /// desde Aquí
        /// </para>
        /// </summary>
        public float Inv_porive_inal
        {
            get { return _inv_porive_inal; }
            set
            {
                if (_inv_porive_inal == value) return;
                _inv_porive_inal = value;
                OnPropertyChanged("Inv_porive_inal");
            }
        }
        #endregion
        #region Inv_gesfar_inal: Formulas consulta externa
        private String _inv_gesfar_inal;
        /// <summary>
        /// <para>TABLA: invalmacenmaest</para>
        /// <para>TABLA NATIVA: invalmacenmaest</para>
        /// <para>CAMPO: Formulas consulta externa</para>
        /// <para>NOMBRE: inv_gesfar_inal (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        /// Realiza entrega de formulas medicas (medicamentos consulta
        /// externa) 1= Entrega de formulas medicas 2= No entrega formulas
        /// medicas
        /// </para>
        /// </summary>
        public String Inv_gesfar_inal
        {
            get { return _inv_gesfar_inal; }
            set
            {
                if (_inv_gesfar_inal == value) return;
                _inv_gesfar_inal = value;
                OnPropertyChanged("Inv_gesfar_inal");
            }
        }
        #endregion
        #region Inv_geshos_inal: Medicamentos intrahospitalarios
        private String _inv_geshos_inal;
        /// <summary>
        /// <para>TABLA: invalmacenmaest</para>
        /// <para>TABLA NATIVA: invalmacenmaest</para>
        /// <para>CAMPO: Medicamentos intrahospitalarios</para>
        /// <para>NOMBRE: inv_geshos_inal (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        /// Gestiona medicamentos intrahospitalarios a pacientes  internados:
        /// 1= Gestiona medicamentos a pacientes internados 2= No gestiona
        /// medicamentos intrahospitalarios
        /// </para>
        /// </summary>
        public String Inv_geshos_inal
        {
            get { return _inv_geshos_inal; }
            set
            {
                if (_inv_geshos_inal == value) return;
                _inv_geshos_inal = value;
                OnPropertyChanged("Inv_geshos_inal");
            }
        }
        #endregion
        #region Inv_genfac_inal: Facturacion medicamentos
        private String _inv_genfac_inal;
        /// <summary>
        /// <para>TABLA: invalmacenmaest</para>
        /// <para>TABLA NATIVA: invalmacenmaest</para>
        /// <para>CAMPO: Facturacion medicamentos</para>
        /// <para>NOMBRE: inv_genfac_inal (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        /// Generar registro facturacion de servicios medicos al entregar
        /// medicamentos: 1= Generar facturacion medica al entregar medicamentos
        /// 2=No generar registro en facturacion medica
        /// </para>
        /// </summary>
        public String Inv_genfac_inal
        {
            get { return _inv_genfac_inal; }
            set
            {
                if (_inv_genfac_inal == value) return;
                _inv_genfac_inal = value;
                OnPropertyChanged("Inv_genfac_inal");
            }
        }
        #endregion
        #region Sia_codare_aser: Código área de servicios
        private String _sia_codare_aser;
        /// <summary>
        /// <para>TABLA: invalmacenmaest</para>
        /// <para>TABLA NATIVA: siaareapreservi</para>
        /// <para>CAMPO: Código área de servicios</para>
        /// <para>NOMBRE: sia_codare_aser (char:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION:
        /// Codigo area prestacion de servicios medicos  a la cual pertenece
        /// el centro de producción
        /// </para>
        /// </summary>
        public String Sia_codare_aser
        {
            get { return _sia_codare_aser; }
            set
            {
                if (_sia_codare_aser == value) return;
                _sia_codare_aser = value;
                OnPropertyChanged("Sia_codare_aser");
            }
        }
        #endregion
        #region Fcm_codcpr_cpro: Centro producción
        private String _fcm_codcpr_cpro;
        /// <summary>
        /// <para>TABLA: invalmacenmaest</para>
        /// <para>TABLA NATIVA: fcmcenproduccio</para>
        /// <para>CAMPO: Centro producción</para>
        /// <para>NOMBRE: fcm_codcpr_cpro (char:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
        /// <para>DESCRIPCION:
        /// Codigo del centro de producción para contabilizacion de gastos
        /// </para>
        /// </summary>
        public String Fcm_codcpr_cpro
        {
            get { return _fcm_codcpr_cpro; }
            set
            {
                if (_fcm_codcpr_cpro == value) return;
                _fcm_codcpr_cpro = value;
                OnPropertyChanged("Fcm_codcpr_cpro");
            }
        }
        #endregion
        #region Sia_codcat_ceat: Código centro atención
        private String _sia_codcat_ceat;
        /// <summary>
        /// <para>TABLA: invalmacenmaest</para>
        /// <para>TABLA NATIVA: siacentroaten</para>
        /// <para>CAMPO: Código centro atención</para>
        /// <para>NOMBRE: sia_codcat_ceat (char:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 11</para>
        /// <para>DESCRIPCION:
        ///Centro de Atención  cuando hay varias sedes
        /// </para>
        /// </summary>
        public String Sia_codcat_ceat
        {
            get { return _sia_codcat_ceat; }
            set
            {
                if (_sia_codcat_ceat == value) return;
                _sia_codcat_ceat = value;
                OnPropertyChanged("Sia_codcat_ceat");
            }
        }
        #endregion
        #region Inv_conreg_inal: Contador items
        private int _inv_conreg_inal;
        /// <summary>
        /// <para>TABLA: invalmacenmaest</para>
        /// <para>TABLA NATIVA: invalmacenmaest</para>
        /// <para>CAMPO: Contador items</para>
        /// <para>NOMBRE: inv_conreg_inal (int:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 12</para>
        /// <para>DESCRIPCION:
        /// Contador para generar el secuencial unico de registros en detalle
        /// (gestion interna)
        /// </para>
        /// </summary>
        public int Inv_conreg_inal
        {
            get { return _inv_conreg_inal; }
            set
            {
                if (_inv_conreg_inal == value) return;
                _inv_conreg_inal = value;
                OnPropertyChanged("Inv_conreg_inal");
            }
        }
        #endregion
        #region Inv_estalm_inal: Estado del Almacén
        private String _inv_estalm_inal;
        /// <summary>
        /// <para>TABLA: invalmacenmaest</para>
        /// <para>TABLA NATIVA: invalmacenmaest</para>
        /// <para>CAMPO: Estado del Almacén</para>
        /// <para>NOMBRE: inv_estalm_inal (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 13</para>
        /// <para>DESCRIPCION:
        ///Estado del Almacén 1=Activo 2=Inactivo
        /// </para>
        /// </summary>
        public String Inv_estalm_inal
        {
            get { return _inv_estalm_inal; }
            set
            {
                if (_inv_estalm_inal == value) return;
                _inv_estalm_inal = value;
                OnPropertyChanged("Inv_estalm_inal");
            }
        }
        #endregion
        #region Sia_desare_aser: Nombre área de servicios
        private String _sia_desare_aser;
        /// <summary>
        /// <para>TABLA: invalmacenmaest</para>
        /// <para>TABLA NATIVA: siaareapreservi</para>
        /// <para>CAMPO: Nombre área de servicios</para>
        /// <para>NOMBRE: sia_desare_aser (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripción área de prestación servicios médicos
        /// </para>
        /// </summary>
        public String Sia_desare_aser
        {
            get { return _sia_desare_aser; }
            set
            {
                if (_sia_desare_aser == value) return;
                _sia_desare_aser = value;
                OnPropertyChanged("Sia_desare_aser");
            }
        }
        #endregion
        #region Fcm_descpr_cpro: Nombre centro producción
        private String _fcm_descpr_cpro;
        /// <summary>
        /// <para>TABLA: invalmacenmaest</para>
        /// <para>TABLA NATIVA: fcmcenproduccio</para>
        /// <para>CAMPO: Nombre centro producción</para>
        /// <para>NOMBRE: fcm_descpr_cpro (char:80)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Nombre o descripción del centro de produccion en prestacion
        /// de servicios medicos
        /// </para>
        /// </summary>
        public String Fcm_descpr_cpro
        {
            get { return _fcm_descpr_cpro; }
            set
            {
                if (_fcm_descpr_cpro == value) return;
                _fcm_descpr_cpro = value;
                OnPropertyChanged("Fcm_descpr_cpro");
            }
        }
        #endregion
        #region Sia_descat_ceat: Descripción centro atención
        private String _sia_descat_ceat;
        /// <summary>
        /// <para>TABLA: invalmacenmaest</para>
        /// <para>TABLA NATIVA: siacentroaten</para>
        /// <para>CAMPO: Descripción centro atención</para>
        /// <para>NOMBRE: sia_descat_ceat (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripción Centro de Atención  cuando hay varias sedes
        /// </para>
        /// </summary>
        public String Sia_descat_ceat
        {
            get { return _sia_descat_ceat; }
            set
            {
                if (_sia_descat_ceat == value) return;
                _sia_descat_ceat = value;
                OnPropertyChanged("Sia_descat_ceat");
            }
        }
        #endregion
        #endregion
        #endregion
        #region Metodos para edicion de registros
        #region Adicionar Registro
        public static String flgAddRegistro(ModeloInvMaestroalmacen tobjModelo)
        {
            var lcrCodigoGen = SysModelo.fcrGenerarNuevoCodigo("INV-MAE-ALMACEN", "INV", "Maestro de Almacenes");
            try
            {
                if (!flgBuscarInvalmacenmaest(lcrCodigoGen))
                {
                    using (_context = new DbAplicacion())
                    {
                        var lobjRegistro = new EFinvalmacenmaest
                        {
                            #region cargar Registro
                            inv_codalm_inal = tobjModelo.Inv_codalm_inal,
                            inv_desalm_inal = tobjModelo.Inv_desalm_inal,
                            inv_polpre_inal = tobjModelo.Inv_polpre_inal,
                            inv_polppi_inal = tobjModelo.Inv_polppi_inal,
                            inv_porive_inal = tobjModelo.Inv_porive_inal,
                            inv_gesfar_inal = tobjModelo.Inv_gesfar_inal,
                            inv_geshos_inal = tobjModelo.Inv_geshos_inal,
                            inv_genfac_inal = tobjModelo.Inv_genfac_inal,
                            sia_codare_aser = tobjModelo.Sia_codare_aser,
                            fcm_codcpr_cpro = tobjModelo.Fcm_codcpr_cpro,
                            sia_codcat_ceat = tobjModelo.Sia_codcat_ceat,
                            inv_conreg_inal = tobjModelo.Inv_conreg_inal,
                            inv_estalm_inal = tobjModelo.Inv_estalm_inal,
                            #endregion
                        };
                        lobjRegistro.inv_codalm_inal = lcrCodigoGen;
                        _context.AddToInvalmacenmaest(lobjRegistro);
                        _context.SaveChanges();
                    }
                }
                else
                {
                    lcrCodigoGen = String.Empty;
                    MessageBox.Show("Nuevo codigo Generado esta desactualizado, revisar llave: \n" +
                                "'INV-MAE-ALMACEN': Maestro de Almacenes en Maestro Secuenciales.");
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
        public static void fcvActualizar(ModeloInvMaestroalmacen tobjModelo)
        {
            try
            {
                using (_context = new DbAplicacion())
                {
                    var lobjRegistro = _context.Invalmacenmaest.FirstOrDefault(p => p.inv_codalm_inal == tobjModelo.Inv_codalm_inal);
                    if (lobjRegistro != null)
                    {
                        #region cargar Registro
                        lobjRegistro.inv_codalm_inal = tobjModelo.Inv_codalm_inal;
                        lobjRegistro.inv_desalm_inal = tobjModelo.Inv_desalm_inal;
                        lobjRegistro.inv_polpre_inal = tobjModelo.Inv_polpre_inal;
                        lobjRegistro.inv_polppi_inal = tobjModelo.Inv_polppi_inal;
                        lobjRegistro.inv_porive_inal = (float)tobjModelo.Inv_porive_inal;
                        lobjRegistro.inv_gesfar_inal = tobjModelo.Inv_gesfar_inal;
                        lobjRegistro.inv_geshos_inal = tobjModelo.Inv_geshos_inal;
                        lobjRegistro.inv_genfac_inal = tobjModelo.Inv_genfac_inal;
                        lobjRegistro.sia_codare_aser = tobjModelo.Sia_codare_aser;
                        lobjRegistro.fcm_codcpr_cpro = tobjModelo.Fcm_codcpr_cpro;
                        lobjRegistro.sia_codcat_ceat = tobjModelo.Sia_codcat_ceat;
                        lobjRegistro.inv_conreg_inal = (int)tobjModelo.Inv_conreg_inal;
                        lobjRegistro.inv_estalm_inal = tobjModelo.Inv_estalm_inal;
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
                    var lobjRegistro = _context.Invalmacenmaest.FirstOrDefault(p => p.inv_codalm_inal == tcrCodigo);
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
        #region Buscar INVALMACENMAEST: Logica
        /// <summary>
        /// <para>TABLA: invalmacenmaest</para>
        /// <para>TITULO: Tabla Maestro almacenes</para>
        /// <para>MODULO: INV</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Registra todos los almacenes existentes dentro de la empresa
        /// </para>
        /// </summary>
        public static bool flgBuscarInvalmacenmaest(String tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Invalmacenmaest.FirstOrDefault(p => p.inv_codalm_inal == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Listar Registros
        public static List<ModeloInvMaestroalmacen> flsListaInvalmacenmaest(String tcrBuscar)
        {
            using (_context = new DbAplicacion())
            {
                if (String.IsNullOrEmpty(tcrBuscar))
                {
                    var lobConsulta = from invalmacenmaest in _context.Invalmacenmaest
                                      join siaareapreservi in _context.Siaareapreservi on invalmacenmaest.sia_codare_aser equals siaareapreservi.sia_codare_aser into tmsiaareapreservi
                                      join fcmcenproduccio in _context.Fcmcenproduccio on invalmacenmaest.fcm_codcpr_cpro equals fcmcenproduccio.fcm_codcpr_cpro into tmfcmcenproduccio
                                      join siacentroaten in _context.Siacentroaten on invalmacenmaest.sia_codcat_ceat equals siacentroaten.sia_codcat_ceat into tmsiacentroaten
                                      from aser in tmsiaareapreservi.DefaultIfEmpty()
                                      from cpro in tmfcmcenproduccio.DefaultIfEmpty()
                                      from ceat in tmsiacentroaten.DefaultIfEmpty()
                                      select new ModeloInvMaestroalmacen
                                      {
                                          #region Datos
                                          Inv_codalm_inal = invalmacenmaest.inv_codalm_inal,
                                          Inv_desalm_inal = invalmacenmaest.inv_desalm_inal,
                                          Inv_polpre_inal = invalmacenmaest.inv_polpre_inal,
                                          Inv_polppi_inal = invalmacenmaest.inv_polppi_inal,
                                          Inv_porive_inal = (float)invalmacenmaest.inv_porive_inal,
                                          Inv_gesfar_inal = invalmacenmaest.inv_gesfar_inal,
                                          Inv_geshos_inal = invalmacenmaest.inv_geshos_inal,
                                          Inv_genfac_inal = invalmacenmaest.inv_genfac_inal,
                                          Sia_codare_aser = invalmacenmaest.sia_codare_aser,
                                          Fcm_codcpr_cpro = invalmacenmaest.fcm_codcpr_cpro,
                                          Sia_codcat_ceat = invalmacenmaest.sia_codcat_ceat,
                                          Inv_conreg_inal = (int)invalmacenmaest.inv_conreg_inal,
                                          Inv_estalm_inal = invalmacenmaest.inv_estalm_inal,
                                          Sia_desare_aser = aser.sia_desare_aser,
                                          Fcm_descpr_cpro = cpro.fcm_descpr_cpro,
                                          Sia_descat_ceat = ceat.sia_descat_ceat,
                                          #endregion
                                      };
                    return lobConsulta.ToList();
                }
                else
                {
                    var lobConsulta = from invalmacenmaest in _context.Invalmacenmaest
                                      join siaareapreservi in _context.Siaareapreservi on invalmacenmaest.sia_codare_aser equals siaareapreservi.sia_codare_aser into tmsiaareapreservi
                                      join fcmcenproduccio in _context.Fcmcenproduccio on invalmacenmaest.fcm_codcpr_cpro equals fcmcenproduccio.fcm_codcpr_cpro into tmfcmcenproduccio
                                      join siacentroaten in _context.Siacentroaten on invalmacenmaest.sia_codcat_ceat equals siacentroaten.sia_codcat_ceat into tmsiacentroaten
                                      from aser in tmsiaareapreservi.DefaultIfEmpty()
                                      from cpro in tmfcmcenproduccio.DefaultIfEmpty()
                                      from ceat in tmsiacentroaten.DefaultIfEmpty()
                                      where invalmacenmaest.inv_codalm_inal.Contains(tcrBuscar) || invalmacenmaest.inv_desalm_inal.Contains(tcrBuscar)
                                      select new ModeloInvMaestroalmacen
                                      {
                                          #region Datos
                                          Inv_codalm_inal = invalmacenmaest.inv_codalm_inal,
                                          Inv_desalm_inal = invalmacenmaest.inv_desalm_inal,
                                          Inv_polpre_inal = invalmacenmaest.inv_polpre_inal,
                                          Inv_polppi_inal = invalmacenmaest.inv_polppi_inal,
                                          Inv_porive_inal = (float)invalmacenmaest.inv_porive_inal,
                                          Inv_gesfar_inal = invalmacenmaest.inv_gesfar_inal,
                                          Inv_geshos_inal = invalmacenmaest.inv_geshos_inal,
                                          Inv_genfac_inal = invalmacenmaest.inv_genfac_inal,
                                          Sia_codare_aser = invalmacenmaest.sia_codare_aser,
                                          Fcm_codcpr_cpro = invalmacenmaest.fcm_codcpr_cpro,
                                          Sia_codcat_ceat = invalmacenmaest.sia_codcat_ceat,
                                          Inv_conreg_inal = (int)invalmacenmaest.inv_conreg_inal,
                                          Inv_estalm_inal = invalmacenmaest.inv_estalm_inal,
                                          Sia_desare_aser = aser.sia_desare_aser,
                                          Fcm_descpr_cpro = cpro.fcm_descpr_cpro,
                                          Sia_descat_ceat = ceat.sia_descat_ceat,
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
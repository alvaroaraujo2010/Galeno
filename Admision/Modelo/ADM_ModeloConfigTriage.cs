//- MARMOTA-GENCODE: VERSION 2.0 - 22/03/2018 04:59:57 PM
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

namespace Admision.Modelo
{
    /// <summary>
    /// Descripcion para la Vista de  la tabla: admtriagemaconf
    /// </summary>
    public class ModeloConfigTriage : clBaseInpc
    {
        #region Modelo Attributos
        private static DbAplicacion _context;
        #region Modelo Propiedades Notificacion
        #region Adm_nroreg_adct: Codigo registro
        private String _adm_nroreg_adct;
        /// <summary>
        /// <para>TABLA: admtriagemaconf</para>
        /// <para>TABLA NATIVA: admtriagemaconf</para>
        /// <para>CAMPO: Codigo registro</para>
        /// <para>NOMBRE: adm_nroreg_adct (char:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        ///Codigo unico secuencial del registro triage
        /// </para>
        /// </summary>
        public String Adm_nroreg_adct
        {
            get { return _adm_nroreg_adct; }
            set
            {
                if (_adm_nroreg_adct == value) return;
                _adm_nroreg_adct = value;
                OnPropertyChanged("Adm_nroreg_adct");
            }
        }
        #endregion
        #region Adm_clasif_tria: Clasificación triage
        private String _adm_clasif_tria;
        /// <summary>
        /// <para>TABLA: admtriagemaconf</para>
        /// <para>TABLA NATIVA: admtriagemaestr</para>
        /// <para>CAMPO: Clasificación triage</para>
        /// <para>NOMBRE: adm_clasif_tria (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Clasificacion de evaluacion Triage : 1= TRIAGE I  2= TRIAGE
        /// II  3= TRIAGE III  4= TRIAGE IV  5= TRIAGE V
        /// </para>
        /// </summary>
        public String Adm_clasif_tria
        {
            get { return _adm_clasif_tria; }
            set
            {
                if (_adm_clasif_tria == value) return;
                _adm_clasif_tria = value;
                OnPropertyChanged("Adm_clasif_tria");
            }
        }
        #endregion
        #region Adm_remisi_tria: Destino Remisión
        private String _adm_remisi_tria;
        /// <summary>
        /// <para>TABLA: admtriagemaconf</para>
        /// <para>TABLA NATIVA: admtriagemaestr</para>
        /// <para>CAMPO: Destino Remisión</para>
        /// <para>NOMBRE: adm_remisi_tria (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        /// Destino remisión paciente despues de evaluación : 1 = Consulta
        /// Externa  2 = Consulta prioritaria  3 = Urgencia
        /// </para>
        /// </summary>
        public String Adm_remisi_tria
        {
            get { return _adm_remisi_tria; }
            set
            {
                if (_adm_remisi_tria == value) return;
                _adm_remisi_tria = value;
                OnPropertyChanged("Adm_remisi_tria");
            }
        }
        #endregion
        #region Adm_titcla_adct: Titulo clasificación
        private String _adm_titcla_adct;
        /// <summary>
        /// <para>TABLA: admtriagemaconf</para>
        /// <para>TABLA NATIVA: admtriagemaconf</para>
        /// <para>CAMPO: Titulo clasificación</para>
        /// <para>NOMBRE: adm_titcla_adct (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        ///Titulo o nombre clasificacion Triage
        /// </para>
        /// </summary>
        public String Adm_titcla_adct
        {
            get { return _adm_titcla_adct; }
            set
            {
                if (_adm_titcla_adct == value) return;
                _adm_titcla_adct = value;
                OnPropertyChanged("Adm_titcla_adct");
            }
        }
        #endregion
        #region Adm_descla_adct: Descripcion clasificación
        private String _adm_descla_adct;
        /// <summary>
        /// <para>TABLA: admtriagemaconf</para>
        /// <para>TABLA NATIVA: admtriagemaconf</para>
        /// <para>CAMPO: Descripcion clasificación</para>
        /// <para>NOMBRE: adm_descla_adct (memo:)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        /// Descripcion de clasificacion Triage según caracteristicas de
        /// la condicion clinica y fisiologica del paciente al llegar
        /// y referencia en la normatividad
        /// </para>
        /// </summary>
        public String Adm_descla_adct
        {
            get { return _adm_descla_adct; }
            set
            {
                if (_adm_descla_adct == value) return;
                _adm_descla_adct = value;
                OnPropertyChanged("Adm_descla_adct");
            }
        }
        #endregion
        #region Adm_tiempo_adct: Tiempos para atencion medica
        private String _adm_tiempo_adct;
        /// <summary>
        /// <para>TABLA: admtriagemaconf</para>
        /// <para>TABLA NATIVA: admtriagemaconf</para>
        /// <para>CAMPO: Tiempos para atencion medica</para>
        /// <para>NOMBRE: adm_tiempo_adct (char:80)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        /// Descripcion corta del tiempo minimo o maximo  para que el paciente
        /// reciba atencion  medica según la conducta tommada, Ejemplo:
        /// Atencion medica ambulatoria antes de 72 horas
        /// </para>
        /// </summary>
        public String Adm_tiempo_adct
        {
            get { return _adm_tiempo_adct; }
            set
            {
                if (_adm_tiempo_adct == value) return;
                _adm_tiempo_adct = value;
                OnPropertyChanged("Adm_tiempo_adct");
            }
        }
        #endregion
        #region Adm_imagen_adct: Imagen (jpg)
        private String _adm_imagen_adct;
        /// <summary>
        /// <para>TABLA: admtriagemaconf</para>
        /// <para>TABLA NATIVA: admtriagemaconf</para>
        /// <para>CAMPO: Imagen (jpg)</para>
        /// <para>NOMBRE: adm_imagen_adct (char:60)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        /// Nombre de la imagen que representa el registro de clasificacion
        /// </para>
        /// </summary>
        public String Adm_imagen_adct
        {
            get { return _adm_imagen_adct; }
            set
            {
                if (_adm_imagen_adct == value) return;
                _adm_imagen_adct = value;
                OnPropertyChanged("Adm_imagen_adct");
            }
        }
        #endregion
        #region Adm_icolor_adct: Color  clasificación
        private String _adm_icolor_adct;
        /// <summary>
        /// <para>TABLA: admtriagemaconf</para>
        /// <para>TABLA NATIVA: admtriagemaconf</para>
        /// <para>CAMPO: Color  clasificación</para>
        /// <para>NOMBRE: adm_icolor_adct (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        ///Color según codigo clasificacion triage
        /// </para>
        /// </summary>
        public String Adm_icolor_adct
        {
            get { return _adm_icolor_adct; }
            set
            {
                if (_adm_icolor_adct == value) return;
                _adm_icolor_adct = value;
                OnPropertyChanged("Adm_icolor_adct");
            }
        }
        #endregion
        #region Adm_codoad_toad: Código Origen admisión
        private String _adm_codoad_toad;
        /// <summary>
        /// <para>TABLA: admtriagemaconf</para>
        /// <para>TABLA NATIVA: admviaingreso</para>
        /// <para>CAMPO: Código Origen admisión</para>
        /// <para>NOMBRE: adm_codoad_toad (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION:
        /// Código Origen de Admisión o vía de ingreso a la institución
        /// (desde la tabla origen admisión o vía de ingreso a la institución):1=Urge
        /// ncias 2=Consulta externa 3=Remitido 4=Nacido en la institución
        /// </para>
        /// </summary>
        public String Adm_codoad_toad
        {
            get { return _adm_codoad_toad; }
            set
            {
                if (_adm_codoad_toad == value) return;
                _adm_codoad_toad = value;
                OnPropertyChanged("Adm_codoad_toad");
            }
        }
        #endregion
        #region Sia_codare_aser: Código Área de servicios
        private String _sia_codare_aser;
        /// <summary>
        /// <para>TABLA: admtriagemaconf</para>
        /// <para>TABLA NATIVA: siaareapreservi</para>
        /// <para>CAMPO: Código Área de servicios</para>
        /// <para>NOMBRE: sia_codare_aser (char:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
        /// <para>DESCRIPCION:
        /// Código área de servicio donde se prestan los servicios (puede
        /// ser la misma desde el ingreso, cuando no hay traslados internos
        /// a otras aéreas)
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
        #region Desia_areing_aser: Nombre área de servicios
        private String _desia_areing_aser;
        /// <summary>
        /// <para>TABLA: siaareapreservi</para>
        /// <para>TABLA NATIVA: siaareapreservi</para>
        /// <para>CAMPO: Nombre área de servicios</para>
        /// <para>NOMBRE: desia_areing_aser (char:)</para>
        /// <para>ORDEN VISTA EN TABLA: 11</para>
        /// <para>DESCRIPCION:
        /// Relacion 'RB' - sia_areing_aser: Descripción área de prestación
        /// servicios médicos
        /// </para>
        /// </summary>
        public String Desia_areing_aser
        {
            get { return _desia_areing_aser; }
            set
            {
                if (_desia_areing_aser == value) return;
                _desia_areing_aser = value;
                OnPropertyChanged("Desia_areing_aser");
            }
        }
        #endregion
        #region Sia_areing_aser: Código Área de Ingreso
        private String _sia_areing_aser;
        /// <summary>
        /// <para>TABLA: admtriagemaconf</para>
        /// <para>TABLA NATIVA: siaareapreservi</para>
        /// <para>CAMPO: Código Área de Ingreso</para>
        /// <para>NOMBRE: sia_areing_aser (char:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 11</para>
        /// <para>DESCRIPCION:
        /// Código Área de Servicio Donde Ingresa o presta atención inicial,
        /// (este dato no cambia cuando hay traslados de área)
        /// </para>
        /// </summary>
        public String Sia_areing_aser
        {
            get { return _sia_areing_aser; }
            set
            {
                if (_sia_areing_aser == value) return;
                _sia_areing_aser = value;
                OnPropertyChanged("Sia_areing_aser");
            }
        }
        #endregion
        #region Fcm_codcpr_cpro: Centro producción
        private String _fcm_codcpr_cpro;
        /// <summary>
        /// <para>TABLA: admtriagemaconf</para>
        /// <para>TABLA NATIVA: fcmcenproduccio</para>
        /// <para>CAMPO: Centro producción</para>
        /// <para>NOMBRE: fcm_codcpr_cpro (char:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 12</para>
        /// <para>DESCRIPCION:
        ///Codigo del centro de producción generado por el sistema
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
        #region Adm_codtat_tatn: Tipo ambito de atención
        private String _adm_codtat_tatn;
        /// <summary>
        /// <para>TABLA: admtriagemaconf</para>
        /// <para>TABLA NATIVA: admtipoatencion</para>
        /// <para>CAMPO: Tipo ambito de atención</para>
        /// <para>NOMBRE: adm_codtat_tatn (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 13</para>
        /// <para>DESCRIPCION:
        /// Código Tipo de Atención o ámbito donde se prestara el servicio
        /// :1=Ambulatoria 2=Hospitalización 3=Urgencia
        /// </para>
        /// </summary>
        public String Adm_codtat_tatn
        {
            get { return _adm_codtat_tatn; }
            set
            {
                if (_adm_codtat_tatn == value) return;
                _adm_codtat_tatn = value;
                OnPropertyChanged("Adm_codtat_tatn");
            }
        }
        #endregion
        #region Adm_codcex_tcex: Causa Externa
        private String _adm_codcex_tcex;
        /// <summary>
        /// <para>TABLA: admtriagemaconf</para>
        /// <para>TABLA NATIVA: admcausaexterna</para>
        /// <para>CAMPO: Causa Externa</para>
        /// <para>NOMBRE: adm_codcex_tcex (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 14</para>
        /// <para>DESCRIPCION:
        /// Causa Externa Origen que origina la atención según Resolución:
        /// 3374 RIPS
        /// </para>
        /// </summary>
        public String Adm_codcex_tcex
        {
            get { return _adm_codcex_tcex; }
            set
            {
                if (_adm_codcex_tcex == value) return;
                _adm_codcex_tcex = value;
                OnPropertyChanged("Adm_codcex_tcex");
            }
        }
        #endregion
        #region Adm_estreg_adct: Estado Registro
        private String _adm_estreg_adct;
        /// <summary>
        /// <para>TABLA: admtriagemaconf</para>
        /// <para>TABLA NATIVA: admtriagemaconf</para>
        /// <para>CAMPO: Estado Registro</para>
        /// <para>NOMBRE: adm_estreg_adct (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 15</para>
        /// <para>DESCRIPCION:
        ///Estado del registro : 1= Activo  2=Inactivo
        /// </para>
        /// </summary>
        public String Adm_estreg_adct
        {
            get { return _adm_estreg_adct; }
            set
            {
                if (_adm_estreg_adct == value) return;
                _adm_estreg_adct = value;
                OnPropertyChanged("Adm_estreg_adct");
            }
        }
        #endregion
        #region Adm_desoad_toad: Decripcion Origen admisión
        private String _adm_desoad_toad;
        /// <summary>
        /// <para>TABLA: admtriagemaconf</para>
        /// <para>TABLA NATIVA: admviaingreso</para>
        /// <para>CAMPO: Decripcion Origen admisión</para>
        /// <para>NOMBRE: adm_desoad_toad (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Descripcion textual del origen de la admision o Via de Ingreso
        /// a la istitución
        /// </para>
        /// </summary>
        public String Adm_desoad_toad
        {
            get { return _adm_desoad_toad; }
            set
            {
                if (_adm_desoad_toad == value) return;
                _adm_desoad_toad = value;
                OnPropertyChanged("Adm_desoad_toad");
            }
        }
        #endregion
        #region Sia_desare_aser: Nombre área de servicios
        private String _sia_desare_aser;
        /// <summary>
        /// <para>TABLA: admtriagemaconf</para>
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
        /// <para>TABLA: admtriagemaconf</para>
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
        #region Adm_destat_tatn: Descripción tipo atención
        private String _adm_destat_tatn;
        /// <summary>
        /// <para>TABLA: admtriagemaconf</para>
        /// <para>TABLA NATIVA: admtipoatencion</para>
        /// <para>CAMPO: Descripción tipo atención</para>
        /// <para>NOMBRE: adm_destat_tatn (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Descripcion del tipo de Atencion según RIPS: Ambulatoria, Hospitalizacion
        /// y Urgencias
        /// </para>
        /// </summary>
        public String Adm_destat_tatn
        {
            get { return _adm_destat_tatn; }
            set
            {
                if (_adm_destat_tatn == value) return;
                _adm_destat_tatn = value;
                OnPropertyChanged("Adm_destat_tatn");
            }
        }
        #endregion
        #region Adm_descex_tcex: Decripcion causa externa
        private String _adm_descex_tcex;
        /// <summary>
        /// <para>TABLA: admtriagemaconf</para>
        /// <para>TABLA NATIVA: admcausaexterna</para>
        /// <para>CAMPO: Decripcion causa externa</para>
        /// <para>NOMBRE: adm_descex_tcex (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Descripcion textual causa externa que origina la admision o
        /// atencion medica
        /// </para>
        /// </summary>
        public String Adm_descex_tcex
        {
            get { return _adm_descex_tcex; }
            set
            {
                if (_adm_descex_tcex == value) return;
                _adm_descex_tcex = value;
                OnPropertyChanged("Adm_descex_tcex");
            }
        }
        #endregion
        #endregion
        #endregion
        #region Metodos para edicion de registros
        #region Adicionar Registro
        public static String flgAddRegistro(ModeloConfigTriage tobjModelo)
        {
            var lcrCodigoGen = SysModelo.fcrGenerarNuevoCodigo("ADM-ADMTRIAGEMACONF", "ADM", "Configuracion parametros evaluación Triage");
            try
            {
                if (!flgBuscarAdmtriagemaconf(lcrCodigoGen))
                {
                    using (_context = new DbAplicacion())
                    {
                        var lobjRegistro = new EFadmtriagemaconf
                        {
                            #region cargar Registro
                            adm_nroreg_adct = tobjModelo.Adm_nroreg_adct,
                            adm_clasif_tria = tobjModelo.Adm_clasif_tria,
                            adm_remisi_tria = tobjModelo.Adm_remisi_tria,
                            adm_titcla_adct = tobjModelo.Adm_titcla_adct,
                            adm_descla_adct = tobjModelo.Adm_descla_adct,
                            adm_tiempo_adct = tobjModelo.Adm_tiempo_adct,
                            adm_imagen_adct = tobjModelo.Adm_imagen_adct,
                            adm_icolor_adct = tobjModelo.Adm_icolor_adct,
                            adm_codoad_toad = tobjModelo.Adm_codoad_toad,
                            sia_codare_aser = tobjModelo.Sia_codare_aser,
                            sia_areing_aser = tobjModelo.Sia_areing_aser,
                            fcm_codcpr_cpro = tobjModelo.Fcm_codcpr_cpro,
                            adm_codtat_tatn = tobjModelo.Adm_codtat_tatn,
                            adm_codcex_tcex = tobjModelo.Adm_codcex_tcex,
                            adm_estreg_adct = tobjModelo.Adm_estreg_adct,
                            #endregion
                        };
                        lobjRegistro.adm_nroreg_adct = lcrCodigoGen;
                        _context.AddToAdmtriagemaconf(lobjRegistro);
                        _context.SaveChanges();
                    }
                }
                else
                {
                    lcrCodigoGen = String.Empty;
                    MessageBox.Show("Nuevo codigo Generado esta desactualizado, revisar llave: \n" +
                                "'ADM-ADMTRIAGEMACONF': Configuracion parametros evaluación Triage en Maestro Secuenciales.");
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
        public static void fcvActualizar(ModeloConfigTriage tobjModelo)
        {
            try
            {
                using (_context = new DbAplicacion())
                {
                    var lobjRegistro = _context.Admtriagemaconf.FirstOrDefault(p => p.adm_nroreg_adct == tobjModelo.Adm_nroreg_adct);
                    if (lobjRegistro != null)
                    {
                        #region cargar Registro
                        lobjRegistro.adm_nroreg_adct = tobjModelo.Adm_nroreg_adct;
                        lobjRegistro.adm_clasif_tria = tobjModelo.Adm_clasif_tria;
                        lobjRegistro.adm_remisi_tria = tobjModelo.Adm_remisi_tria;
                        lobjRegistro.adm_titcla_adct = tobjModelo.Adm_titcla_adct;
                        lobjRegistro.adm_descla_adct = tobjModelo.Adm_descla_adct;
                        lobjRegistro.adm_tiempo_adct = tobjModelo.Adm_tiempo_adct;
                        lobjRegistro.adm_imagen_adct = tobjModelo.Adm_imagen_adct;
                        lobjRegistro.adm_icolor_adct = tobjModelo.Adm_icolor_adct;
                        lobjRegistro.adm_codoad_toad = tobjModelo.Adm_codoad_toad;
                        lobjRegistro.sia_codare_aser = tobjModelo.Sia_codare_aser;
                        lobjRegistro.sia_areing_aser = tobjModelo.Sia_areing_aser;
                        lobjRegistro.fcm_codcpr_cpro = tobjModelo.Fcm_codcpr_cpro;
                        lobjRegistro.adm_codtat_tatn = tobjModelo.Adm_codtat_tatn;
                        lobjRegistro.adm_codcex_tcex = tobjModelo.Adm_codcex_tcex;
                        lobjRegistro.adm_estreg_adct = tobjModelo.Adm_estreg_adct;
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
                    var lobjRegistro = _context.Admtriagemaconf.FirstOrDefault(p => p.adm_nroreg_adct == tcrCodigo);
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
        #region Buscar ADMTRIAGEMACONF: Logica
        /// <summary>
        /// <para>TABLA: admtriagemaconf</para>
        /// <para>TITULO: Configuracion parametros evaluación Triage</para>
        /// <para>MODULO: ADM</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Configuracion parametros según niveles en la evaluación inicial
        /// Triage realizada a pacientes.
        /// </para>
        /// </summary>
        public static bool flgBuscarAdmtriagemaconf(String tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Admtriagemaconf.FirstOrDefault(p => p.adm_nroreg_adct == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Listar Registros
        public static List<ModeloConfigTriage> flsListaAdmtriagemaconf(String tcrBuscar)
        {
            using (_context = new DbAplicacion())
            {
                if (String.IsNullOrEmpty(tcrBuscar))
                {
                    var lobConsulta = from admtriagemaconf in _context.Admtriagemaconf
                                      join admviaingreso in _context.Admviaingreso on admtriagemaconf.adm_codoad_toad equals admviaingreso.adm_codoad_toad into tmadmviaingreso
                                      join siaareapreservi in _context.Siaareapreservi on admtriagemaconf.sia_codare_aser equals siaareapreservi.sia_codare_aser into tmsiaareapreservi
                                      join fcmcenproduccio in _context.Fcmcenproduccio on admtriagemaconf.fcm_codcpr_cpro equals fcmcenproduccio.fcm_codcpr_cpro into tmfcmcenproduccio
                                      join admtipoatencion in _context.Admtipoatencion on admtriagemaconf.adm_codtat_tatn equals admtipoatencion.adm_codtat_tatn into tmadmtipoatencion
                                      join admcausaexterna in _context.Admcausaexterna on admtriagemaconf.adm_codcex_tcex equals admcausaexterna.adm_codcex_tcex into tmadmcausaexterna
                                      from toad in tmadmviaingreso.DefaultIfEmpty()
                                      from aser in tmsiaareapreservi.DefaultIfEmpty()
                                      from cpro in tmfcmcenproduccio.DefaultIfEmpty()
                                      from tatn in tmadmtipoatencion.DefaultIfEmpty()
                                      from tcex in tmadmcausaexterna.DefaultIfEmpty()
                                      select new ModeloConfigTriage
                                      {
                                          #region Datos
                                          Adm_nroreg_adct = admtriagemaconf.adm_nroreg_adct,
                                          Adm_clasif_tria = admtriagemaconf.adm_clasif_tria,
                                          Adm_remisi_tria = admtriagemaconf.adm_remisi_tria,
                                          Adm_titcla_adct = admtriagemaconf.adm_titcla_adct,
                                          Adm_descla_adct = admtriagemaconf.adm_descla_adct,
                                          Adm_tiempo_adct = admtriagemaconf.adm_tiempo_adct,
                                          Adm_imagen_adct = admtriagemaconf.adm_imagen_adct,
                                          Adm_icolor_adct = admtriagemaconf.adm_icolor_adct,
                                          Adm_codoad_toad = admtriagemaconf.adm_codoad_toad,
                                          Sia_codare_aser = admtriagemaconf.sia_codare_aser,
                                          Sia_areing_aser = admtriagemaconf.sia_areing_aser,
                                          Desia_areing_aser = _context.Siaareapreservi.FirstOrDefault(rxp => rxp.sia_codare_aser == admtriagemaconf.sia_areing_aser).sia_desare_aser,
                                          Fcm_codcpr_cpro = admtriagemaconf.fcm_codcpr_cpro,
                                          Adm_codtat_tatn = admtriagemaconf.adm_codtat_tatn,
                                          Adm_codcex_tcex = admtriagemaconf.adm_codcex_tcex,
                                          Adm_estreg_adct = admtriagemaconf.adm_estreg_adct,
                                          Adm_desoad_toad = toad.adm_desoad_toad,
                                          Sia_desare_aser = aser.sia_desare_aser,
                                          Fcm_descpr_cpro = cpro.fcm_descpr_cpro,
                                          Adm_destat_tatn = tatn.adm_destat_tatn,
                                          Adm_descex_tcex = tcex.adm_descex_tcex,
                                          #endregion
                                      };
                    return lobConsulta.ToList();
                }
                else
                {
                    var lobConsulta = from admtriagemaconf in _context.Admtriagemaconf
                                      join admviaingreso in _context.Admviaingreso on admtriagemaconf.adm_codoad_toad equals admviaingreso.adm_codoad_toad into tmadmviaingreso
                                      join siaareapreservi in _context.Siaareapreservi on admtriagemaconf.sia_codare_aser equals siaareapreservi.sia_codare_aser into tmsiaareapreservi
                                      join fcmcenproduccio in _context.Fcmcenproduccio on admtriagemaconf.fcm_codcpr_cpro equals fcmcenproduccio.fcm_codcpr_cpro into tmfcmcenproduccio
                                      join admtipoatencion in _context.Admtipoatencion on admtriagemaconf.adm_codtat_tatn equals admtipoatencion.adm_codtat_tatn into tmadmtipoatencion
                                      join admcausaexterna in _context.Admcausaexterna on admtriagemaconf.adm_codcex_tcex equals admcausaexterna.adm_codcex_tcex into tmadmcausaexterna
                                      from toad in tmadmviaingreso.DefaultIfEmpty()
                                      from aser in tmsiaareapreservi.DefaultIfEmpty()
                                      from cpro in tmfcmcenproduccio.DefaultIfEmpty()
                                      from tatn in tmadmtipoatencion.DefaultIfEmpty()
                                      from tcex in tmadmcausaexterna.DefaultIfEmpty()
                                      where admtriagemaconf.adm_nroreg_adct.Contains(tcrBuscar) || admtriagemaconf.adm_titcla_adct.Contains(tcrBuscar) || admtriagemaconf.adm_descla_adct.Contains(tcrBuscar)
                                      || admtriagemaconf.adm_tiempo_adct.Contains(tcrBuscar)
                                      select new ModeloConfigTriage
                                      {
                                          #region Datos
                                          Adm_nroreg_adct = admtriagemaconf.adm_nroreg_adct,
                                          Adm_clasif_tria = admtriagemaconf.adm_clasif_tria,
                                          Adm_remisi_tria = admtriagemaconf.adm_remisi_tria,
                                          Adm_titcla_adct = admtriagemaconf.adm_titcla_adct,
                                          Adm_descla_adct = admtriagemaconf.adm_descla_adct,
                                          Adm_tiempo_adct = admtriagemaconf.adm_tiempo_adct,
                                          Adm_imagen_adct = admtriagemaconf.adm_imagen_adct,
                                          Adm_icolor_adct = admtriagemaconf.adm_icolor_adct,
                                          Adm_codoad_toad = admtriagemaconf.adm_codoad_toad,
                                          Sia_codare_aser = admtriagemaconf.sia_codare_aser,
                                          Sia_areing_aser = admtriagemaconf.sia_areing_aser,
                                          Desia_areing_aser = _context.Siaareapreservi.FirstOrDefault(rxp => rxp.sia_codare_aser == admtriagemaconf.sia_areing_aser).sia_desare_aser,
                                          Fcm_codcpr_cpro = admtriagemaconf.fcm_codcpr_cpro,
                                          Adm_codtat_tatn = admtriagemaconf.adm_codtat_tatn,
                                          Adm_codcex_tcex = admtriagemaconf.adm_codcex_tcex,
                                          Adm_estreg_adct = admtriagemaconf.adm_estreg_adct,
                                          Adm_desoad_toad = toad.adm_desoad_toad,
                                          Sia_desare_aser = aser.sia_desare_aser,
                                          Fcm_descpr_cpro = cpro.fcm_descpr_cpro,
                                          Adm_destat_tatn = tatn.adm_destat_tatn,
                                          Adm_descex_tcex = tcex.adm_descex_tcex,
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
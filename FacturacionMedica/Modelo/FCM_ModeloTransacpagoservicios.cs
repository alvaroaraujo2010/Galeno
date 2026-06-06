//- MARMOTA-GENCODE: VERSION 2.0 - 05/09/2013 08:45:00 AM
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

namespace FacturacionMedica.Modelo
{
    /// <summary>
    /// Descripcion para la Vista de  la tabla: fcmmaescajatran
    /// </summary>
    public class ModeloTransacpagoservicios : clBaseInpc
    {
        #region Modelo Attributos
        private static DbAplicacion _context;
        #region Modelo Propiedades Notificacion
        #region Fcm_codtra_mtrc: Código recibo de caja
        private String _fcm_codtra_mtrc;
        /// <summary>
        /// <para>TABLA: fcmmaescajatran</para>
        /// <para>TABLA NATIVA: fcmmaescajatran</para>
        /// <para>CAMPO: Código recibo de caja</para>
        /// <para>NOMBRE: fcm_codtra_mtrc (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        ///Codgio del recibo de caja  generado por el sistema
        /// </para>
        /// </summary>
        public String Fcm_codtra_mtrc
        {
            get { return _fcm_codtra_mtrc; }
            set
            {
                if (_fcm_codtra_mtrc == value) return;
                _fcm_codtra_mtrc = value;
                OnPropertyChanged("Fcm_codtra_mtrc");
            }
        }
        #endregion
        #region Adm_secadm_rgad: Código Admisión
        private String _adm_secadm_rgad;
        /// <summary>
        /// <para>TABLA: fcmmaescajatran</para>
        /// <para>TABLA NATIVA: admregadmision</para>
        /// <para>CAMPO: Código Admisión</para>
        /// <para>NOMBRE: adm_secadm_rgad (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Secuencial de Admisión del paciente o usuario que realiza el
        /// pago
        /// </para>
        /// </summary>
        public String Adm_secadm_rgad
        {
            get { return _adm_secadm_rgad; }
            set
            {
                if (_adm_secadm_rgad == value) return;
                _adm_secadm_rgad = value;
                OnPropertyChanged("Adm_secadm_rgad");
            }
        }
        #endregion
        #region Sia_idesec_usua: Código único del paciente
        private String _sia_idesec_usua;
        /// <summary>
        /// <para>TABLA: fcmmaescajatran</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Código único del paciente</para>
        /// <para>NOMBRE: sia_idesec_usua (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        ///Consecutivo Unico de paciente en el sistema
        /// </para>
        /// </summary>
        public String Sia_idesec_usua
        {
            get { return _sia_idesec_usua; }
            set
            {
                if (_sia_idesec_usua == value) return;
                _sia_idesec_usua = value;
                OnPropertyChanged("Sia_idesec_usua");
            }
        }
        #endregion
        #region Sia_nroide_usua: Numero de Identificación
        private String _sia_nroide_usua;
        /// <summary>
        /// <para>TABLA: fcmmaescajatran</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Numero de Identificación</para>
        /// <para>NOMBRE: sia_nroide_usua (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        /// Numero de identificacion del paciente: Registro civil, Cedula,
        /// Tarjeta de identidad y otros
        /// </para>
        /// </summary>
        public String Sia_nroide_usua
        {
            get { return _sia_nroide_usua; }
            set
            {
                if (_sia_nroide_usua == value) return;
                _sia_nroide_usua = value;
                OnPropertyChanged("Sia_nroide_usua");
            }
        }
        #endregion
        #region Fcm_autdes_ades: Autorización descuento
        private String _fcm_autdes_ades;
        /// <summary>
        /// <para>TABLA: fcmmaescajatran</para>
        /// <para>TABLA NATIVA: fcmdescueautori</para>
        /// <para>CAMPO: Autorización descuento</para>
        /// <para>NOMBRE: fcm_autdes_ades (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        /// Numero de autorizacion del descuento aprobado para el momento
        /// del pago (cuando aplique)
        /// </para>
        /// </summary>
        public String Fcm_autdes_ades
        {
            get { return _fcm_autdes_ades; }
            set
            {
                if (_fcm_autdes_ades == value) return;
                _fcm_autdes_ades = value;
                OnPropertyChanged("Fcm_autdes_ades");
            }
        }
        #endregion
        #region Fcm_descon_mtrc: Concepto del pago
        private String _fcm_descon_mtrc;
        /// <summary>
        /// <para>TABLA: fcmmaescajatran</para>
        /// <para>TABLA NATIVA: fcmmaescajatran</para>
        /// <para>CAMPO: Concepto del pago</para>
        /// <para>NOMBRE: fcm_descon_mtrc (char:150)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        /// descripción del concepto o pago por el cual se dio el recibo
        /// de caja
        /// </para>
        /// </summary>
        public String Fcm_descon_mtrc
        {
            get { return _fcm_descon_mtrc; }
            set
            {
                if (_fcm_descon_mtrc == value) return;
                _fcm_descon_mtrc = value;
                OnPropertyChanged("Fcm_descon_mtrc");
            }
        }
        #endregion
        #region Fcm_rfecha_mtrc: Fecha del recibo
        private DateTime _fcm_rfecha_mtrc;
        /// <summary>
        /// <para>TABLA: fcmmaescajatran</para>
        /// <para>TABLA NATIVA: fcmmaescajatran</para>
        /// <para>CAMPO: Fecha del recibo</para>
        /// <para>NOMBRE: fcm_rfecha_mtrc (fecha:)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        ///Fecha del recibo de caja
        /// </para>
        /// </summary>
        public DateTime Fcm_rfecha_mtrc
        {
            get { return _fcm_rfecha_mtrc; }
            set
            {
                if (_fcm_rfecha_mtrc == value) return;
                _fcm_rfecha_mtrc = value;
                OnPropertyChanged("Fcm_rfecha_mtrc");
            }
        }
        #endregion
        #region Fcm_rehora_mtrc: Hora del recibo
        private Decimal _fcm_rehora_mtrc;
        /// <summary>
        /// <para>TABLA: fcmmaescajatran</para>
        /// <para>TABLA NATIVA: fcmmaescajatran</para>
        /// <para>CAMPO: Hora del recibo</para>
        /// <para>NOMBRE: fcm_rehora_mtrc (hora:52)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        /// Hora en que se genero el recibo, hora en formato 12 ejem: 10:25:AM
        /// </para>
        /// </summary>
        public Decimal Fcm_rehora_mtrc
        {
            get { return _fcm_rehora_mtrc; }
            set
            {
                if (_fcm_rehora_mtrc == value) return;
                _fcm_rehora_mtrc = value;
                OnPropertyChanged("Fcm_rehora_mtrc");
            }
        }
        #endregion
        #region Fcm_tipefe_mtrc: Tipo de pago efectivo
        private String _fcm_tipefe_mtrc;
        /// <summary>
        /// <para>TABLA: fcmmaescajatran</para>
        /// <para>TABLA NATIVA: fcmmaescajatran</para>
        /// <para>CAMPO: Tipo de pago efectivo</para>
        /// <para>NOMBRE: fcm_tipefe_mtrc (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION:
        /// Tipo de efectivo utlizado par el pago: EFECTIVO, TARJETA,CHEQUE,EFECTIVO-
        /// Y-TARJETA,EFECTIVO-Y-CHEQUE,CHEQUE-Y-TARJETA
        /// </para>
        /// </summary>
        public String Fcm_tipefe_mtrc
        {
            get { return _fcm_tipefe_mtrc; }
            set
            {
                if (_fcm_tipefe_mtrc == value) return;
                _fcm_tipefe_mtrc = value;
                OnPropertyChanged("Fcm_tipefe_mtrc");
            }
        }
        #endregion
        #region Fcm_valref_dfac: Valor en efectivo
        private float _fcm_valref_dfac;
        /// <summary>
        /// <para>TABLA: fcmmaescajatran</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Valor en efectivo</para>
        /// <para>NOMBRE: fcm_valref_dfac (float:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
        /// <para>DESCRIPCION:
        /// Valor a recaudar en efectivo sin el descuento (solo valor cobrado
        /// en efectivo) por cobros de copagos o valor total del servicio
        /// (no siempre representa el valor total del servicio)
        /// </para>
        /// </summary>
        public float Fcm_valref_dfac
        {
            get { return _fcm_valref_dfac; }
            set
            {
                if (_fcm_valref_dfac == value) return;
                _fcm_valref_dfac = value;
                OnPropertyChanged("Fcm_valref_dfac");
            }
        }
        #endregion
        #region Fcm_valdes_dfac: Valor del descuento
        private float _fcm_valdes_dfac;
        /// <summary>
        /// <para>TABLA: fcmmaescajatran</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Valor del descuento</para>
        /// <para>NOMBRE: fcm_valdes_dfac (float:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 11</para>
        /// <para>DESCRIPCION:
        /// Valor total del descuento realizado al cliente cuando exista
        /// </para>
        /// </summary>
        public float Fcm_valdes_dfac
        {
            get { return _fcm_valdes_dfac; }
            set
            {
                if (_fcm_valdes_dfac == value) return;
                _fcm_valdes_dfac = value;
                OnPropertyChanged("Fcm_valdes_dfac");
            }
        }
        #endregion
        #region Fcm_valefe_mtrc: Valor billete Efectivo
        private int _fcm_valefe_mtrc;
        /// <summary>
        /// <para>TABLA: fcmmaescajatran</para>
        /// <para>TABLA NATIVA: fcmmaescajatran</para>
        /// <para>CAMPO: Valor billete Efectivo</para>
        /// <para>NOMBRE: fcm_valefe_mtrc (int:12)</para>
        /// <para>ORDEN VISTA EN TABLA: 12</para>
        /// <para>DESCRIPCION:
        /// Efectivo (Billete) presentado en ventanilla por el cliente,
        /// de este se hara la deduccion del pago
        /// </para>
        /// </summary>
        public int Fcm_valefe_mtrc
        {
            get { return _fcm_valefe_mtrc; }
            set
            {
                if (_fcm_valefe_mtrc == value) return;
                _fcm_valefe_mtrc = value;
                OnPropertyChanged("Fcm_valefe_mtrc");
            }
        }
        #endregion
        #region Fcm_valcam_mtrc: Valor cambio efectivo
        private int _fcm_valcam_mtrc;
        /// <summary>
        /// <para>TABLA: fcmmaescajatran</para>
        /// <para>TABLA NATIVA: fcmmaescajatran</para>
        /// <para>CAMPO: Valor cambio efectivo</para>
        /// <para>NOMBRE: fcm_valcam_mtrc (int:12)</para>
        /// <para>ORDEN VISTA EN TABLA: 13</para>
        /// <para>DESCRIPCION:
        /// Valor del cambio cuando despues de la transaccion se debe un
        /// valor cambio: FCM_VALCAM_MTRC=FCM_VALEFE_MTRC-FCM_VALPAG_MTRC
        /// </para>
        /// </summary>
        public int Fcm_valcam_mtrc
        {
            get { return _fcm_valcam_mtrc; }
            set
            {
                if (_fcm_valcam_mtrc == value) return;
                _fcm_valcam_mtrc = value;
                OnPropertyChanged("Fcm_valcam_mtrc");
            }
        }
        #endregion
        #region Fcm_valefe_dfac: Valor pago en efectivo
        private float _fcm_valefe_dfac;
        /// <summary>
        /// <para>TABLA: fcmmaescajatran</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Valor pago en efectivo</para>
        /// <para>NOMBRE: fcm_valefe_dfac (float:17,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 14</para>
        /// <para>DESCRIPCION:
        /// Valor pagado en efectivo correspondiente al servicio (con el
        /// descuento)
        /// </para>
        /// </summary>
        public float Fcm_valefe_dfac
        {
            get { return _fcm_valefe_dfac; }
            set
            {
                if (_fcm_valefe_dfac == value) return;
                _fcm_valefe_dfac = value;
                OnPropertyChanged("Fcm_valefe_dfac");
            }
        }
        #endregion
        #region Sia_codcat_ceat: Código centro atención
        private String _sia_codcat_ceat;
        /// <summary>
        /// <para>TABLA: fcmmaescajatran</para>
        /// <para>TABLA NATIVA: siacentroaten</para>
        /// <para>CAMPO: Código centro atención</para>
        /// <para>NOMBRE: sia_codcat_ceat (char:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 15</para>
        /// <para>DESCRIPCION:
        ///Centro de Atencion  cuando hay varias sedes
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
        #region Fcm_secdet_mtrc: Secuencial reg Detalles
        private int _fcm_secdet_mtrc;
        /// <summary>
        /// <para>TABLA: fcmmaescajatran</para>
        /// <para>TABLA NATIVA: fcmmaescajatran</para>
        /// <para>CAMPO: Secuencial reg Detalles</para>
        /// <para>NOMBRE: fcm_secdet_mtrc (int:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 16</para>
        /// <para>DESCRIPCION:
        /// Campo para generar el secuencial de los registros detalles
        /// de la transaccion
        /// </para>
        /// </summary>
        public int Fcm_secdet_mtrc
        {
            get { return _fcm_secdet_mtrc; }
            set
            {
                if (_fcm_secdet_mtrc == value) return;
                _fcm_secdet_mtrc = value;
                OnPropertyChanged("Fcm_secdet_mtrc");
            }
        }
        #endregion
        #region Sys_codusu_usux: Código Digitador
        private String _sys_codusu_usux;
        /// <summary>
        /// <para>TABLA: fcmmaescajatran</para>
        /// <para>TABLA NATIVA: sysusuarios</para>
        /// <para>CAMPO: Código Digitador</para>
        /// <para>NOMBRE: sys_codusu_usux (char:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 17</para>
        /// <para>DESCRIPCION:
        /// Código del Digitador Usuario del sistema que diligencia el
        /// registro de atencion o admision
        /// </para>
        /// </summary>
        public String Sys_codusu_usux
        {
            get { return _sys_codusu_usux; }
            set
            {
                if (_sys_codusu_usux == value) return;
                _sys_codusu_usux = value;
                OnPropertyChanged("Sys_codusu_usux");
            }
        }
        #endregion
        #region Sis_estreg_mtrc: Estado del recibo
        private String _sis_estreg_mtrc;
        /// <summary>
        /// <para>TABLA: fcmmaescajatran</para>
        /// <para>TABLA NATIVA: fcmmaescajatran</para>
        /// <para>CAMPO: Estado del recibo</para>
        /// <para>NOMBRE: sis_estreg_mtrc (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 18</para>
        /// <para>DESCRIPCION:
        ///Estado  del recibo:  2=Confirmado 3=Anulado
        /// </para>
        /// </summary>
        public String Sis_estreg_mtrc
        {
            get { return _sis_estreg_mtrc; }
            set
            {
                if (_sis_estreg_mtrc == value) return;
                _sis_estreg_mtrc = value;
                OnPropertyChanged("Sis_estreg_mtrc");
            }
        }
        #endregion
        #region Sia_nomusu_usua: Nombre paciente
        private String _sia_nomusu_usua;
        /// <summary>
        /// <para>TABLA: fcmmaescajatran</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Nombre paciente</para>
        /// <para>NOMBRE: sia_nomusu_usua (char:50)</para>
        /// <para>ORDEN VISTA EN TABLA: 12</para>
        /// <para>DESCRIPCION:
        ///Nombre concatenado del paciente (Apellidos y Nombres)
        /// </para>
        /// </summary>
        public String Sia_nomusu_usua
        {
            get { return _sia_nomusu_usua; }
            set
            {
                if (_sia_nomusu_usua == value) return;
                _sia_nomusu_usua = value;
                OnPropertyChanged("Sia_nomusu_usua");
            }
        }
        #endregion
        #region Fcm_notaut_ades: Nota
        private String _fcm_notaut_ades;
        /// <summary>
        /// <para>TABLA: fcmmaescajatran</para>
        /// <para>TABLA NATIVA: fcmdescueautori</para>
        /// <para>CAMPO: Nota</para>
        /// <para>NOMBRE: fcm_notaut_ades (char:150)</para>
        /// <para>ORDEN VISTA EN TABLA: 13</para>
        /// <para>DESCRIPCION:
        ///Nota textual de la autorización
        /// </para>
        /// </summary>
        public String Fcm_notaut_ades
        {
            get { return _fcm_notaut_ades; }
            set
            {
                if (_fcm_notaut_ades == value) return;
                _fcm_notaut_ades = value;
                OnPropertyChanged("Fcm_notaut_ades");
            }
        }
        #endregion
        #region Sia_descat_ceat: Descripción centro atención
        private String _sia_descat_ceat;
        /// <summary>
        /// <para>TABLA: fcmmaescajatran</para>
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
        #region Sys_nomusu_usux: Nombre Usuario
        private String _sys_nomusu_usux;
        /// <summary>
        /// <para>TABLA: fcmmaescajatran</para>
        /// <para>TABLA NATIVA: sysusuarios</para>
        /// <para>CAMPO: Nombre Usuario</para>
        /// <para>NOMBRE: sys_nomusu_usux (char:50)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        ///Nombre Completo del  usuario
        /// </para>
        /// </summary>
        public String Sys_nomusu_usux
        {
            get { return _sys_nomusu_usux; }
            set
            {
                if (_sys_nomusu_usux == value) return;
                _sys_nomusu_usux = value;
                OnPropertyChanged("Sys_nomusu_usux");
            }
        }
        #endregion
        #endregion
        #endregion
        #region Metodos para edicion de registros
        #region Adicionar Registro
        public static string flgAddRegistro(ModeloTransacpagoservicios tobjModelo)
        {
            var lcrCodigoGen = SysModelo.fcrGenerarNuevoCodigo("FCM-CAJA-PAGOS-SERV", "FCM", "Transaccion Caja pagos efectivo facturación");
            if (!flgBuscarFcmmaescajatran(lcrCodigoGen))
            {
                using (_context = new DbAplicacion())
                {
                    var lobjRegistro = new EFfcmmaescajatran
                    {
                        #region cargar Registro
                        fcm_codtra_mtrc = tobjModelo.Fcm_codtra_mtrc,
                        adm_secadm_rgad = tobjModelo.Adm_secadm_rgad,
                        sia_idesec_usua = tobjModelo.Sia_idesec_usua,
                        sia_nroide_usua = tobjModelo.Sia_nroide_usua,
                        fcm_autdes_ades = tobjModelo.Fcm_autdes_ades,
                        fcm_descon_mtrc = tobjModelo.Fcm_descon_mtrc,
                        fcm_rfecha_mtrc = tobjModelo.Fcm_rfecha_mtrc,
                        fcm_rehora_mtrc = tobjModelo.Fcm_rehora_mtrc,
                        fcm_tipefe_mtrc = tobjModelo.Fcm_tipefe_mtrc,
                        fcm_valref_dfac = tobjModelo.Fcm_valref_dfac,
                        fcm_valdes_dfac = tobjModelo.Fcm_valdes_dfac,
                        fcm_valefe_mtrc = tobjModelo.Fcm_valefe_mtrc,
                        fcm_valcam_mtrc = tobjModelo.Fcm_valcam_mtrc,
                        fcm_valefe_dfac = tobjModelo.Fcm_valefe_dfac,
                        sia_codcat_ceat = tobjModelo.Sia_codcat_ceat,
                        fcm_secdet_mtrc = tobjModelo.Fcm_secdet_mtrc,
                        sys_codusu_usux = tobjModelo.Sys_codusu_usux,
                        sis_estreg_mtrc = tobjModelo.Sis_estreg_mtrc,
                        #endregion
                    };
                    lobjRegistro.fcm_codtra_mtrc = lcrCodigoGen;
                    _context.AddToFcmmaescajatran(lobjRegistro);
                    _context.SaveChanges();
                }
            }
            else
            {
                lcrCodigoGen = string.Empty;
                MessageBox.Show("Nuevo codigo Generado esta desactualizado, revisar llave: \n" +
                                "'FCM-CAJA-PAGOS-SERV': Transaccion Caja pagos efectivo facturación en Maestro Secuenciales.");
            }
            return lcrCodigoGen;
        }
        #endregion
        #region Modificar Registro
        public static void fcvActualizar(ModeloTransacpagoservicios tobjModelo)
        {
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Fcmmaescajatran.FirstOrDefault(p => p.fcm_codtra_mtrc == tobjModelo.Fcm_codtra_mtrc);
                if (lobjRegistro != null)
                {
                    lobjRegistro.fcm_codtra_mtrc = tobjModelo.Fcm_codtra_mtrc;
                    lobjRegistro.adm_secadm_rgad = tobjModelo.Adm_secadm_rgad;
                    lobjRegistro.sia_idesec_usua = tobjModelo.Sia_idesec_usua;
                    lobjRegistro.sia_nroide_usua = tobjModelo.Sia_nroide_usua;
                    lobjRegistro.fcm_autdes_ades = tobjModelo.Fcm_autdes_ades;
                    lobjRegistro.fcm_descon_mtrc = tobjModelo.Fcm_descon_mtrc;
                    lobjRegistro.fcm_rfecha_mtrc = (DateTime)tobjModelo.Fcm_rfecha_mtrc;
                    lobjRegistro.fcm_rehora_mtrc = (Decimal)tobjModelo.Fcm_rehora_mtrc;
                    lobjRegistro.fcm_tipefe_mtrc = tobjModelo.Fcm_tipefe_mtrc;
                    lobjRegistro.fcm_valref_dfac = (float)tobjModelo.Fcm_valref_dfac;
                    lobjRegistro.fcm_valdes_dfac = (float)tobjModelo.Fcm_valdes_dfac;
                    lobjRegistro.fcm_valefe_mtrc = (int)tobjModelo.Fcm_valefe_mtrc;
                    lobjRegistro.fcm_valcam_mtrc = (int)tobjModelo.Fcm_valcam_mtrc;
                    lobjRegistro.fcm_valefe_dfac = (int)tobjModelo.Fcm_valefe_dfac;
                    lobjRegistro.sia_codcat_ceat = tobjModelo.Sia_codcat_ceat;
                    lobjRegistro.fcm_secdet_mtrc = (int)tobjModelo.Fcm_secdet_mtrc;
                    lobjRegistro.sys_codusu_usux = tobjModelo.Sys_codusu_usux;
                    lobjRegistro.sis_estreg_mtrc = tobjModelo.Sis_estreg_mtrc;
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
                var lobjRegistro = _context.Fcmmaescajatran.FirstOrDefault(p => p.fcm_codtra_mtrc == tcrCodigo);
                if (lobjRegistro != null)
                {
                    _context.DeleteObject(lobjRegistro);
                    _context.SaveChanges();
                }
            }
        }
        #endregion
        #region Buscar FCMMAESCAJATRAN: Logica
        /// <summary>
        /// <para>TABLA: fcmmaescajatran</para>
        /// <para>TITULO: Maestro Transacciones caja</para>
        /// <para>MODULO: FCM</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro para almacenar los datos de recibos de cajas que se
        /// generen en facturacion por concepto de pagos en efectivo o
        /// en cheque de: copagos, cuotas moderadoras, pagos particulares
        /// y otros pagos
        /// </para>
        /// </summary>
        public static bool flgBuscarFcmmaescajatran(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Fcmmaescajatran.FirstOrDefault(p => p.fcm_codtra_mtrc == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Listar Registros
        public static List<ModeloTransacpagoservicios> flsListaFcmmaescajatran(string tcrBuscar)
        {
            using (_context = new DbAplicacion())
            {
                if (string.IsNullOrEmpty(tcrBuscar))
                {
                    var lobConsulta = from fcmmaescajatran in _context.Fcmmaescajatran
                                      join admregadmision in _context.Admregadmision on fcmmaescajatran.adm_secadm_rgad equals admregadmision.adm_secadm_rgad into tmadmregadmision
                                      join siausuarioatend in _context.Siausuarioatend on fcmmaescajatran.sia_idesec_usua equals siausuarioatend.sia_idesec_usua into tmsiausuarioatend
                                      join fcmdescueautori in _context.Fcmdescueautori on fcmmaescajatran.fcm_autdes_ades equals fcmdescueautori.fcm_autdes_ades into tmfcmdescueautori
                                      join siacentroaten in _context.Siacentroaten on fcmmaescajatran.sia_codcat_ceat equals siacentroaten.sia_codcat_ceat into tmsiacentroaten
                                      join sysusuarios in _context.Sysusuarios on fcmmaescajatran.sys_codusu_usux equals sysusuarios.sys_codusu_usux into tmsysusuarios
                                      from rgad in tmadmregadmision.DefaultIfEmpty()
                                      from usua in tmsiausuarioatend.DefaultIfEmpty()
                                      from ades in tmfcmdescueautori.DefaultIfEmpty()
                                      from ceat in tmsiacentroaten.DefaultIfEmpty()
                                      from usux in tmsysusuarios.DefaultIfEmpty()
                                      select new ModeloTransacpagoservicios
                                      {
                                          Fcm_codtra_mtrc = fcmmaescajatran.fcm_codtra_mtrc,
                                          Adm_secadm_rgad = fcmmaescajatran.adm_secadm_rgad,
                                          Sia_idesec_usua = fcmmaescajatran.sia_idesec_usua,
                                          Sia_nroide_usua = fcmmaescajatran.sia_nroide_usua,
                                          Fcm_autdes_ades = fcmmaescajatran.fcm_autdes_ades,
                                          Fcm_descon_mtrc = fcmmaescajatran.fcm_descon_mtrc,
                                          Fcm_rfecha_mtrc = (DateTime)fcmmaescajatran.fcm_rfecha_mtrc,
                                          Fcm_rehora_mtrc = (Decimal)fcmmaescajatran.fcm_rehora_mtrc,
                                          Fcm_tipefe_mtrc = fcmmaescajatran.fcm_tipefe_mtrc,
                                          Fcm_valref_dfac = (float)fcmmaescajatran.fcm_valref_dfac,
                                          Fcm_valdes_dfac = (float)fcmmaescajatran.fcm_valdes_dfac,
                                          Fcm_valefe_mtrc = (int)fcmmaescajatran.fcm_valefe_mtrc,
                                          Fcm_valcam_mtrc = (int)fcmmaescajatran.fcm_valcam_mtrc,
                                          Fcm_valefe_dfac = (int)fcmmaescajatran.fcm_valefe_dfac,
                                          Sia_codcat_ceat = fcmmaescajatran.sia_codcat_ceat,
                                          Fcm_secdet_mtrc = (int)fcmmaescajatran.fcm_secdet_mtrc,
                                          Sys_codusu_usux = fcmmaescajatran.sys_codusu_usux,
                                          Sis_estreg_mtrc = fcmmaescajatran.sis_estreg_mtrc,
                                          Sia_nomusu_usua = usua.sia_nomusu_usua,
                                          Fcm_notaut_ades = ades.fcm_notaut_ades,
                                          Sia_descat_ceat = ceat.sia_descat_ceat,
                                          Sys_nomusu_usux = usux.sys_nomusu_usux,
                                      };
                    return lobConsulta.ToList();
                }
                else
                {
                    var lobConsulta = from fcmmaescajatran in _context.Fcmmaescajatran
                                      join admregadmision in _context.Admregadmision on fcmmaescajatran.adm_secadm_rgad equals admregadmision.adm_secadm_rgad into tmadmregadmision
                                      join siausuarioatend in _context.Siausuarioatend on fcmmaescajatran.sia_idesec_usua equals siausuarioatend.sia_idesec_usua into tmsiausuarioatend
                                      join fcmdescueautori in _context.Fcmdescueautori on fcmmaescajatran.fcm_autdes_ades equals fcmdescueautori.fcm_autdes_ades into tmfcmdescueautori
                                      join siacentroaten in _context.Siacentroaten on fcmmaescajatran.sia_codcat_ceat equals siacentroaten.sia_codcat_ceat into tmsiacentroaten
                                      join sysusuarios in _context.Sysusuarios on fcmmaescajatran.sys_codusu_usux equals sysusuarios.sys_codusu_usux into tmsysusuarios
                                      from rgad in tmadmregadmision.DefaultIfEmpty()
                                      from usua in tmsiausuarioatend.DefaultIfEmpty()
                                      from ades in tmfcmdescueautori.DefaultIfEmpty()
                                      from ceat in tmsiacentroaten.DefaultIfEmpty()
                                      from usux in tmsysusuarios.DefaultIfEmpty()
                                      where fcmmaescajatran.fcm_codtra_mtrc.Contains(tcrBuscar) || fcmmaescajatran.fcm_descon_mtrc.Contains(tcrBuscar)
                                      select new ModeloTransacpagoservicios
                                      {
                                          Fcm_codtra_mtrc = fcmmaescajatran.fcm_codtra_mtrc,
                                          Adm_secadm_rgad = fcmmaescajatran.adm_secadm_rgad,
                                          Sia_idesec_usua = fcmmaescajatran.sia_idesec_usua,
                                          Sia_nroide_usua = fcmmaescajatran.sia_nroide_usua,
                                          Fcm_autdes_ades = fcmmaescajatran.fcm_autdes_ades,
                                          Fcm_descon_mtrc = fcmmaescajatran.fcm_descon_mtrc,
                                          Fcm_rfecha_mtrc = (DateTime)fcmmaescajatran.fcm_rfecha_mtrc,
                                          Fcm_rehora_mtrc = (Decimal)fcmmaescajatran.fcm_rehora_mtrc,
                                          Fcm_tipefe_mtrc = fcmmaescajatran.fcm_tipefe_mtrc,
                                          Fcm_valref_dfac = (float)fcmmaescajatran.fcm_valref_dfac,
                                          Fcm_valdes_dfac = (float)fcmmaescajatran.fcm_valdes_dfac,
                                          Fcm_valefe_mtrc = (int)fcmmaescajatran.fcm_valefe_mtrc,
                                          Fcm_valcam_mtrc = (int)fcmmaescajatran.fcm_valcam_mtrc,
                                          Fcm_valefe_dfac = (int)fcmmaescajatran.fcm_valefe_dfac,
                                          Sia_codcat_ceat = fcmmaescajatran.sia_codcat_ceat,
                                          Fcm_secdet_mtrc = (int)fcmmaescajatran.fcm_secdet_mtrc,
                                          Sys_codusu_usux = fcmmaescajatran.sys_codusu_usux,
                                          Sis_estreg_mtrc = fcmmaescajatran.sis_estreg_mtrc,
                                          Sia_nomusu_usua = usua.sia_nomusu_usua,
                                          Fcm_notaut_ades = ades.fcm_notaut_ades,
                                          Sia_descat_ceat = ceat.sia_descat_ceat,
                                          Sys_nomusu_usux = usux.sys_nomusu_usux,
                                      };
                    return lobConsulta.ToList();
                }
            }
        }
        #endregion
        #endregion
    }
    /// <summary>
    /// Descripcion para la Vista de  la tabla: fcmmaescajadeta
    /// </summary>
    public class ModeloTransDetalles : clBaseInpc
    {
        #region Modelo Attributos
        private static DbAplicacion _context;
        #region Modelo Propiedades pivadas
        private String _fcm_codrca_rcad;
        private String _fcm_codtra_mtrc;
        private String _fcm_secreg_mfac;
        private String _fcm_numfac_mfac;
        private String _fcm_desser_sips;
        private float _fcm_valref_dfac;
        private float _fcm_valefe_dfac;
        private float _fcm_pordes_dfac;
        private float _fcm_valdes_dfac;
        private int _fcm_valpag_mtrc;
        private String _fcm_tippag_rcad;
        private String _fcm_estreg_rcad;
        private String _fcm_descon_mtrc;
        private string _sis_estado_imaen;
        #endregion
        #region Modelo Propiedades Notificacion
        #region Fcm_codrca_rcad: Código único registro
        /// <summary>
        /// <para>TABLA: fcmmaescajadeta</para>
        /// <para>TABLA NATIVA: fcmmaescajadeta</para>
        /// <para>CAMPO: Código único registro</para>
        /// <para>NOMBRE: fcm_codrca_rcad (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        ///Codgio del recibo de caja  generado por el sistema
        /// </para>
        /// </summary>
        public String Fcm_codrca_rcad
        {
            get { return _fcm_codrca_rcad; }
            set
            {
                if (_fcm_codrca_rcad == value) return;
                _fcm_codrca_rcad = value;
                OnPropertyChanged("Fcm_codrca_rcad");
            }
        }
        #endregion
        #region Fcm_codtra_mtrc: Código recibo de caja
        /// <summary>
        /// <para>TABLA: fcmmaescajadeta</para>
        /// <para>TABLA NATIVA: fcmmaescajatran</para>
        /// <para>CAMPO: Código recibo de caja</para>
        /// <para>NOMBRE: fcm_codtra_mtrc (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Codgio del recibo de caja  generado por el sistema
        /// </para>
        /// </summary>
        public String Fcm_codtra_mtrc
        {
            get { return _fcm_codtra_mtrc; }
            set
            {
                if (_fcm_codtra_mtrc == value) return;
                _fcm_codtra_mtrc = value;
                OnPropertyChanged("Fcm_codtra_mtrc");
            }
        }
        #endregion
        #region Fcm_secreg_mfac: Código orden medica
        /// <summary>
        /// <para>TABLA: fcmmaescajadeta</para>
        /// <para>TABLA NATIVA: fcmmaesfacturas</para>
        /// <para>CAMPO: Código orden medica</para>
        /// <para>NOMBRE: fcm_secreg_mfac (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        /// Secuencial unico de la orden medica facturada (generado por
        /// el sistema)
        /// </para>
        /// </summary>
        public String Fcm_secreg_mfac
        {
            get { return _fcm_secreg_mfac; }
            set
            {
                if (_fcm_secreg_mfac == value) return;
                _fcm_secreg_mfac = value;
                OnPropertyChanged("Fcm_secreg_mfac");
            }
        }
        #endregion
        #region Fcm_numfac_mfac: Numero Factura
        /// <summary>
        /// <para>TABLA: fcmmaescajadeta</para>
        /// <para>TABLA NATIVA: fcmmaesfacturas</para>
        /// <para>CAMPO: Numero Factura</para>
        /// <para>NOMBRE: fcm_numfac_mfac (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        /// Numero de la factura generada en la confirmación de facturas
        /// </para>
        /// </summary>
        public String Fcm_numfac_mfac
        {
            get { return _fcm_numfac_mfac; }
            set
            {
                if (_fcm_numfac_mfac == value) return;
                _fcm_numfac_mfac = value;
                OnPropertyChanged("Fcm_numfac_mfac");
            }
        }
        #endregion
        #region Fcm_desser_sips: Nombre servicios
        /// <summary>
        /// <para>TABLA: fcmmaescajadeta</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Nombre servicios</para>
        /// <para>NOMBRE: fcm_desser_sips (char:250)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        ///Descripción textual de lso servicios IPS  que son cobrados
        /// </para>
        /// </summary>
        public String Fcm_desser_sips
        {
            get { return _fcm_desser_sips; }
            set
            {
                if (_fcm_desser_sips == value) return;
                _fcm_desser_sips = value;
                OnPropertyChanged("Fcm_desser_sips");
            }
        }
        #endregion
        #region Fcm_valref_dfac: Valor en efectivo
        /// <summary>
        /// <para>TABLA: fcmmaescajadeta</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Valor en efectivo</para>
        /// <para>NOMBRE: fcm_valref_dfac (float:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        /// Valor recuadado en efectivo (solo valor cobrado en efectivo)
        /// por cobros de copagos o valor total del servicio (no siempre
        /// representa el valor total del servicio)
        /// </para>
        /// </summary>
        public float Fcm_valref_dfac
        {
            get { return _fcm_valref_dfac; }
            set
            {
                if (_fcm_valref_dfac == value) return;
                _fcm_valref_dfac = value;
                OnPropertyChanged("Fcm_valref_dfac");
            }
        }
        #endregion
        #region Fcm_valefe_dfac: Valor efectivo final
        /// <summary>
        /// <para>TABLA: fcmmaescajadeta</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Valor efectivo final</para>
        /// <para>NOMBRE: fcm_valefe_dfac (float:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        /// Valor final recuadado en efectivo con el descuento realizado
        /// </para>
        /// </summary>
        public float Fcm_valefe_dfac
        {
            get { return _fcm_valefe_dfac; }
            set
            {
                if (_fcm_valefe_dfac == value) return;
                _fcm_valefe_dfac = value;
                OnPropertyChanged("Fcm_valefe_dfac");
            }
        }
        #endregion
        #region Fcm_pordes_dfac: Porcentaje del descuento
        /// <summary>
        /// <para>TABLA: fcmmaescajadeta</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Porcentaje del descuento</para>
        /// <para>NOMBRE: fcm_pordes_dfac (float:62)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        /// Porcentaje de descuento aplicada (cuando el descuento se haya
        /// calculado en porcentaje)
        /// </para>
        /// </summary>
        public float Fcm_pordes_dfac
        {
            get { return _fcm_pordes_dfac; }
            set
            {
                if (_fcm_pordes_dfac == value) return;
                _fcm_pordes_dfac = value;
                OnPropertyChanged("Fcm_pordes_dfac");
            }
        }
        #endregion
        #region Fcm_valdes_dfac: Valor del descuento
        /// <summary>
        /// <para>TABLA: fcmmaescajadeta</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Valor del descuento</para>
        /// <para>NOMBRE: fcm_valdes_dfac (float:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        ///Valor total del descuento realizado al cliente
        /// </para>
        /// </summary>
        public float Fcm_valdes_dfac
        {
            get { return _fcm_valdes_dfac; }
            set
            {
                if (_fcm_valdes_dfac == value) return;
                _fcm_valdes_dfac = value;
                OnPropertyChanged("Fcm_valdes_dfac");
            }
        }
        #endregion
        #region Fcm_valpag_mtrc: Valor pago en efectivo
        /// <summary>
        /// <para>TABLA: fcmmaescajadeta</para>
        /// <para>TABLA NATIVA: fcmmaescajatran</para>
        /// <para>CAMPO: Valor pago en efectivo</para>
        /// <para>NOMBRE: fcm_valpag_mtrc (int:12)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION:
        /// Valor pagado en efectivo correspondiente a la orden de  servicio
        /// </para>
        /// </summary>
        public int Fcm_valpag_mtrc
        {
            get { return _fcm_valpag_mtrc; }
            set
            {
                if (_fcm_valpag_mtrc == value) return;
                _fcm_valpag_mtrc = value;
                OnPropertyChanged("Fcm_valpag_mtrc");
            }
        }
        #endregion
        #region Fcm_tippag_rcad: Tipo pago realizado
        /// <summary>
        /// <para>TABLA: fcmmaescajadeta</para>
        /// <para>TABLA NATIVA: fcmmaescajadeta</para>
        /// <para>CAMPO: Tipo pago realizado</para>
        /// <para>NOMBRE: fcm_tippag_rcad (char:90)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
        /// <para>DESCRIPCION:
        /// Tipo pago en efectivo textual asi: VALOR-SERVICIO,  COPAGO,
        /// CUOTA-MODERADORA, CARGO-USUARIO y OTROS
        /// </para>
        /// </summary>
        public String Fcm_tippag_rcad
        {
            get { return _fcm_tippag_rcad; }
            set
            {
                if (_fcm_tippag_rcad == value) return;
                _fcm_tippag_rcad = value;
                OnPropertyChanged("Fcm_tippag_rcad");
            }
        }
        #endregion
        #region Sis_idterc_sitr: Código tercero (contable)
        private String _sis_idterc_sitr;
        /// <summary>
        /// <para>TABLA: fcmmaescajadeta</para>
        /// <para>TABLA NATIVA: conterceros</para>
        /// <para>CAMPO: Código tercero (contable)</para>
        /// <para>NOMBRE: con_idesec_mter (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
        /// <para>DESCRIPCION:
        /// Código de Empresa cliente y/o tercero EPS o asegurador según
        /// módulos administrativos
        /// </para>
        /// </summary>
        public String Sis_idterc_sitr
        {
            get { return _sis_idterc_sitr; }
            set
            {
                if (_sis_idterc_sitr == value) return;
                _sis_idterc_sitr = value;
                OnPropertyChanged("Sis_idterc_sitr");
            }
        }
        #endregion
        #region Fcm_estreg_rcad: Estado del recibo
        /// <summary>
        /// <para>TABLA: fcmmaescajadeta</para>
        /// <para>TABLA NATIVA: fcmmaescajadeta</para>
        /// <para>CAMPO: Estado del recibo</para>
        /// <para>NOMBRE: fcm_estreg_rcad (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 12</para>
        /// <para>DESCRIPCION:
        ///Estado del recibo:  2=Confirmado 3=Anulado
        /// </para>
        /// </summary>
        public String Fcm_estreg_rcad
        {
            get { return _fcm_estreg_rcad; }
            set
            {
                if (_fcm_estreg_rcad == value) return;
                _fcm_estreg_rcad = value;
                OnPropertyChanged("Fcm_estreg_rcad");
            }
        }
        #endregion
        #region Fcm_descon_mtrc: Concepto del pago
        /// <summary>
        /// <para>TABLA: fcmmaescajadeta</para>
        /// <para>TABLA NATIVA: fcmmaescajatran</para>
        /// <para>CAMPO: Concepto del pago</para>
        /// <para>NOMBRE: fcm_descon_mtrc (char:150)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        /// descripción del concepto o pago por el cual se dio el recibo
        /// de caja
        /// </para>
        /// </summary>
        public String Fcm_descon_mtrc
        {
            get { return _fcm_descon_mtrc; }
            set
            {
                if (_fcm_descon_mtrc == value) return;
                _fcm_descon_mtrc = value;
                OnPropertyChanged("Fcm_descon_mtrc");
            }
        }
        #endregion
        #region Sis_razsoc_sitr: Nombre / Razon social
        private String _sis_razsoc_sitr;
        /// <summary>
        /// <para>TABLA: fcmmaescajadeta</para>
        /// <para>TABLA NATIVA: sismaesterceros</para>
        /// <para>CAMPO: Nombre / Razon social</para>
        /// <para>NOMBRE: con_razsoc_mter (char:50)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION:
        /// Razon social de la empresa o nombre completo concatenado cuando
        /// es persona natural
        /// </para>
        /// </summary>
        public String Sis_razsoc_sitr
        {
            get { return _sis_razsoc_sitr; }
            set
            {
                if (_sis_razsoc_sitr == value) return;
                _sis_razsoc_sitr = value;
                OnPropertyChanged("Sis_razsoc_sitr");
            }
        }
        #endregion
        #region Sis_estado_imaen: Estado del registro para edicion
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
        public static bool flgAddRegistro(ModeloTransDetalles tobTempReg, string tcrCodigoR1)
        {
            bool llgReturn = false;
            try
            {
                using (_context = new DbAplicacion())
                {
                    llgReturn = true;
                    var lobEFReg = new EFfcmmaescajadeta();
                    //-----------------------
                    if (tobTempReg.Sis_estado_imaen == "M")
                    {
                        lobEFReg = _context.Fcmmaescajadeta.FirstOrDefault(p => p.fcm_codrca_rcad == tobTempReg.Fcm_codrca_rcad);
                    }
                    if (tobTempReg.Sis_estado_imaen == "A" || tobTempReg.Sis_estado_imaen == "M") // Adicionar o Modificar
                    {
                        #region cargar Registro
                        if (lobEFReg != null)
                        {
                            lobEFReg.fcm_codrca_rcad = tobTempReg.Fcm_codrca_rcad;
                            lobEFReg.fcm_codtra_mtrc = tobTempReg.Fcm_codtra_mtrc;
                            lobEFReg.fcm_secreg_mfac = tobTempReg.Fcm_secreg_mfac;
                            lobEFReg.fcm_numfac_mfac = tobTempReg.Fcm_numfac_mfac;
                            lobEFReg.fcm_desser_sips = tobTempReg.Fcm_desser_sips;
                            lobEFReg.fcm_valref_dfac = (float)tobTempReg.Fcm_valref_dfac;
                            lobEFReg.fcm_pordes_dfac = (float)tobTempReg.Fcm_pordes_dfac;
                            lobEFReg.fcm_valdes_dfac = (float)tobTempReg.Fcm_valdes_dfac;
                            lobEFReg.fcm_valefe_dfac = (int)tobTempReg.Fcm_valefe_dfac;
                            lobEFReg.fcm_tippag_rcad = tobTempReg.Fcm_tippag_rcad;
                            lobEFReg.sis_idterc_sitr = tobTempReg.Sis_idterc_sitr;
                            lobEFReg.fcm_estreg_rcad = tobTempReg.Fcm_estreg_rcad;
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
                                lobEFReg.fcm_codrca_rcad = tcrCodigoR1 + lobEFReg.fcm_codrca_rcad; // concatenar
                                _context.AddToFcmmaescajadeta(lobEFReg);
                                _context.SaveChanges();
                                break;

                            case "M": // Modificar el registro
                                _context.SaveChanges();
                                break;

                            case "E": // Eliminar el registro
                                var lobjRegistro = _context.Fcmmaescajadeta.FirstOrDefault(p => p.fcm_codrca_rcad == tobTempReg.Fcm_codrca_rcad);
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
        #region Buscar FCMMAESCAJADETA: Logica
        /// <summary>
        /// <para>TABLA: fcmmaescajadeta</para>
        /// <para>TITULO: Detalles transacciones caja</para>
        /// <para>MODULO: FCM</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro para almacenar los detalles de recibos de cajas, es
        /// decir, registros de cada de las facturas y /o ordenes de  servicios
        /// prestados que dieron lugar a cobro en efectivo
        /// </para>
        /// </summary>
        public static bool flgBuscarFcmmaescajadeta(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Fcmmaescajadeta.FirstOrDefault(p => p.fcm_codrca_rcad == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Listar Registros
        public static List<ModeloTransDetalles> flsListaFcmmaescajadeta(string tcrBuscar)
        {
            using (_context = new DbAplicacion())
            {
                var lobConsulta = from fcmmaescajadeta in _context.Fcmmaescajadeta
                                  join fcmmaescajatran in _context.Fcmmaescajatran on fcmmaescajadeta.fcm_codtra_mtrc equals fcmmaescajatran.fcm_codtra_mtrc into tmfcmmaescajatran
                                  join fcmmaesfacturas in _context.Fcmmaesfacturas on fcmmaescajadeta.fcm_secreg_mfac equals fcmmaesfacturas.fcm_secreg_mfac into tmfcmmaesfacturas
                                  join sismaesterceros in _context.Sismaesterceros on fcmmaescajadeta.sis_idterc_sitr equals sismaesterceros.sis_idterc_sitr into tmsismaesterceros
                                  from mtrc in tmfcmmaescajatran.DefaultIfEmpty()
                                  from mfac in tmfcmmaesfacturas.DefaultIfEmpty()
                                  from mter in tmsismaesterceros.DefaultIfEmpty()
                                  where fcmmaescajadeta.fcm_codtra_mtrc == tcrBuscar
                                  select new ModeloTransDetalles
                                  {
                                      Fcm_codrca_rcad = fcmmaescajadeta.fcm_codrca_rcad,
                                      Fcm_codtra_mtrc = fcmmaescajadeta.fcm_codtra_mtrc,
                                      Fcm_secreg_mfac = fcmmaescajadeta.fcm_secreg_mfac,
                                      Fcm_numfac_mfac = fcmmaescajadeta.fcm_numfac_mfac,
                                      Fcm_desser_sips = fcmmaescajadeta.fcm_desser_sips,
                                      Fcm_valref_dfac = (float)fcmmaescajadeta.fcm_valref_dfac,
                                      Fcm_pordes_dfac = (float)fcmmaescajadeta.fcm_pordes_dfac,
                                      Fcm_valdes_dfac = (float)fcmmaescajadeta.fcm_valdes_dfac,
                                      Fcm_valefe_dfac = (float)fcmmaescajadeta.fcm_valefe_dfac,
                                      Fcm_tippag_rcad = fcmmaescajadeta.fcm_tippag_rcad,
                                      Sis_idterc_sitr = fcmmaescajadeta.sis_idterc_sitr,
                                      Fcm_estreg_rcad = fcmmaescajadeta.fcm_estreg_rcad,
                                      Fcm_descon_mtrc = mtrc.fcm_descon_mtrc,
                                      Sis_razsoc_sitr = mter.sis_razsoc_sitr,
                                      Sis_estado_imaen = "I",
                                  };
                return lobConsulta.ToList();
            }
        }
        #endregion
        #endregion
    }
}
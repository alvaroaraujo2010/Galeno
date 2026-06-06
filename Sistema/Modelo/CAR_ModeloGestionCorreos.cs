//- MARMOTA-GENCODE: VERSION 2.0 - 17/10/2020 05:35:17 AM
using System;
using System.Windows;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.Generic;
using Datos.Modelos;

namespace Sistema.Modelo
{
    /// <summary>
    /// Carfemailgestioma: Maestro gestor de correos grupales que se envian al adquirente 
    /// </summary>
    public class ModeloCarfemailgestioma : clBaseInpc
    {
        #region Modelo Attributos
        private static DbAplicacion _context;
        #region Modelo Propiedades Notificacion
        #region Car_secreg_cagm: Código unico registro
        private String _car_secreg_cagm;
        /// <summary>
        /// <para>TABLA: carfemailgestioma</para>
        /// <para>TABLA NATIVA: carfemailgestioma</para>
        /// <para>CAMPO: Código unico registro</para>
        /// <para>NOMBRE: car_secreg_cagm (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCIÓN: Secuencial unico registro</para>
        /// </summary>
        public String Car_secreg_cagm
        {
            get { return _car_secreg_cagm; }
            set
            {
                if (_car_secreg_cagm == value) return;
                _car_secreg_cagm = value;
                OnPropertyChanged("Car_secreg_cagm");
            }
        }
        #endregion
        #region Fcm_secraz_fcem: Razon social Empresa
        private String _fcm_secraz_fcem;
        /// <summary>
        /// <para>TABLA: carfemailgestioma</para>
        /// <para>TABLA NATIVA: fcmfemaesrazsocma</para>
        /// <para>CAMPO: Razon social Empresa</para>
        /// <para>NOMBRE: fcm_secraz_fcem (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCIÓN: Codigo unico Razon Social empresa para gestion documentos DIAN</para>
        /// </summary>
        public String Fcm_secraz_fcem
        {
            get { return _fcm_secraz_fcem; }
            set
            {
                if (_fcm_secraz_fcem == value) return;
                _fcm_secraz_fcem = value;
                OnPropertyChanged("Fcm_secraz_fcem");
            }
        }
        #endregion
        #region Car_gresum_cagm: Generar archivo resumen
        private String _car_gresum_cagm;
        /// <summary>
        /// <para>TABLA: carfemailgestioma</para>
        /// <para>TABLA NATIVA: carfemailgestioma</para>
        /// <para>CAMPO: Generar archivo resumen</para>
        /// <para>NOMBRE: car_gresum_cagm (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCIÓN: 
        /// Generar o no generar un archvo comprimido con todos los archivos marcados como incluidos que
        /// pertenencen a las facturas incluidas: 1=Generar Archivo Resumen 2=No generar archivo resumen
        /// </para>
        /// </summary>
        public String Car_gresum_cagm
        {
            get { return _car_gresum_cagm; }
            set
            {
                if (_car_gresum_cagm == value) return;
                _car_gresum_cagm = value;
                OnPropertyChanged("Car_gresum_cagm");
            }
        }
        #endregion
        #region Car_arcnom_cagm: Nombre archivo resumen
        private String _car_arcnom_cagm;
        /// <summary>
        /// <para>TABLA: carfemailgestioma</para>
        /// <para>TABLA NATIVA: carfemailgestioma</para>
        /// <para>CAMPO: Nombre archivo resumen</para>
        /// <para>NOMBRE: car_arcnom_cagm (char:80)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCIÓN: 
        /// Nombre del archivo Resumen que se genarará, no incluir extencion sin espeacios y sin caracteres
        /// especiales
        /// </para>
        /// </summary>
        public String Car_arcnom_cagm
        {
            get { return _car_arcnom_cagm; }
            set
            {
                if (_car_arcnom_cagm == value) return;
                _car_arcnom_cagm = value;
                OnPropertyChanged("Car_arcnom_cagm");
            }
        }
        #endregion
        #region Car_gesori_cagm: Origen gestion
        private String _car_gesori_cagm;
        /// <summary>
        /// <para>TABLA: carfemailgestioma</para>
        /// <para>TABLA NATIVA: carfemailgestioma</para>
        /// <para>CAMPO: Origen gestion</para>
        /// <para>NOMBRE: car_gesori_cagm (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCIÓN: 
        /// Origen gestion correo: NA=Llamado desde el modulo gestion correo 01=Desde Gestion Cartera (cuenta
        /// de cobro) 02=Desde Facturacion Ventas (punto pos) 03=Desde Facturacion Medica
        /// </para>
        /// </summary>
        public String Car_gesori_cagm
        {
            get { return _car_gesori_cagm; }
            set
            {
                if (_car_gesori_cagm == value) return;
                _car_gesori_cagm = value;
                OnPropertyChanged("Car_gesori_cagm");
            }
        }
        #endregion
        #region Car_secref_cagm: Codigo unico registro
        private String _car_secref_cagm;
        /// <summary>
        /// <para>TABLA: carfemailgestioma</para>
        /// <para>TABLA NATIVA: carfemailgestioma</para>
        /// <para>CAMPO: Codigo unico registro</para>
        /// <para>NOMBRE: car_secref_cagm (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCIÓN: 
        /// Codigo unico registro referencia: documento factura  cuenta de cobro  y otros según el tipo
        /// origen gestion  (campo CAR_GESORI_CAGM)
        /// </para>
        /// </summary>
        public String Car_secref_cagm
        {
            get { return _car_secref_cagm; }
            set
            {
                if (_car_secref_cagm == value) return;
                _car_secref_cagm = value;
                OnPropertyChanged("Car_secref_cagm");
            }
        }
        #endregion
        #region Fcm_numfac_mfac: Numero Factura cuenta
        private String _fcm_numfac_mfac;
        /// <summary>
        /// <para>TABLA: carfemailgestioma</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefma</para>
        /// <para>CAMPO: Numero Factura cuenta</para>
        /// <para>NOMBRE: fcm_numfac_mfac (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCIÓN: Numero del documento o  factura generada y recibida en con éxito en DIAN</para>
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
        #region Car_tphost_caml: Tipo servidor de correo
        private String _car_tphost_caml;
        /// <summary>
        /// <para>TABLA: carfemailgestioma</para>
        /// <para>TABLA NATIVA: </para>
        /// <para>CAMPO: Tipo servidor de correo</para>
        /// <para>NOMBRE: car_tphost_caml (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCIÓN: 
        /// Tipo servidor de correo con el cual se realiza el envio: 1=Servidor de correo de Hotmail 2=Servidor
        /// de correo Gmail
        /// </para>
        /// </summary>
        public String Car_tphost_caml
        {
            get { return _car_tphost_caml; }
            set
            {
                if (_car_tphost_caml == value) return;
                _car_tphost_caml = value;
                OnPropertyChanged("Car_tphost_caml");
            }
        }
        #endregion
        #region Car_faddre_caml: Remitente
        private String _car_faddre_caml;
        /// <summary>
        /// <para>TABLA: carfemailgestioma</para>
        /// <para>TABLA NATIVA: </para>
        /// <para>CAMPO: Remitente</para>
        /// <para>NOMBRE: car_faddre_caml (char:150)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCIÓN: 
        /// Cuenta de correo desde el cual se envia el mail (se asme por defecto el que esta registrado
        /// en la razon social de la empresa)
        /// </para>
        /// </summary>
        public String Car_faddre_caml
        {
            get { return _car_faddre_caml; }
            set
            {
                if (_car_faddre_caml == value) return;
                _car_faddre_caml = value;
                OnPropertyChanged("Car_faddre_caml");
            }
        }
        #endregion
        #region Sis_idterc_sitr: Codigo Adquirente
        private String _sis_idterc_sitr;
        /// <summary>
        /// <para>TABLA: carfemailgestioma</para>
        /// <para>TABLA NATIVA: sismaesterceros</para>
        /// <para>CAMPO: Codigo Adquirente</para>
        /// <para>NOMBRE: sis_idterc_sitr (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCIÓN: 
        /// Código de Adquirente o Empresa cliente y/o tercero EPS o asegurador según módulos administrativos
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
        #region Car_taddre_caml: Destinatario
        private String _car_taddre_caml;
        /// <summary>
        /// <para>TABLA: carfemailgestioma</para>
        /// <para>TABLA NATIVA: </para>
        /// <para>CAMPO: Destinatario</para>
        /// <para>NOMBRE: car_taddre_caml (char:150)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCIÓN: 
        /// Cuenta de correo destino al cual se envia el correo (se asme por defecto el que esta registrado
        /// en la razon social del adquirente)
        /// </para>
        /// </summary>
        public String Car_taddre_caml
        {
            get { return _car_taddre_caml; }
            set
            {
                if (_car_taddre_caml == value) return;
                _car_taddre_caml = value;
                OnPropertyChanged("Car_taddre_caml");
            }
        }
        #endregion
        #region Car_caddre_caml: Segundo Destinatario
        private String _car_caddre_caml;
        /// <summary>
        /// <para>TABLA: carfemailgestioma</para>
        /// <para>TABLA NATIVA: </para>
        /// <para>CAMPO: Segundo Destinatario</para>
        /// <para>NOMBRE: car_caddre_caml (char:150)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
        /// <para>DESCRIPCIÓN: Cuenta de correo segundo destinatario al cual se envia el mensaje de correo</para>
        /// </summary>
        public String Car_caddre_caml
        {
            get { return _car_caddre_caml; }
            set
            {
                if (_car_caddre_caml == value) return;
                _car_caddre_caml = value;
                OnPropertyChanged("Car_caddre_caml");
            }
        }
        #endregion
        #region Car_subjec_caml: Asunto
        private String _car_subjec_caml;
        /// <summary>
        /// <para>TABLA: carfemailgestioma</para>
        /// <para>TABLA NATIVA: </para>
        /// <para>CAMPO: Asunto</para>
        /// <para>NOMBRE: car_subjec_caml (char:150)</para>
        /// <para>ORDEN VISTA EN TABLA: 11</para>
        /// <para>DESCRIPCIÓN: Asunto del correo</para>
        /// </summary>
        public String Car_subjec_caml
        {
            get { return _car_subjec_caml; }
            set
            {
                if (_car_subjec_caml == value) return;
                _car_subjec_caml = value;
                OnPropertyChanged("Car_subjec_caml");
            }
        }
        #endregion
        #region Car_bodyms_caml: Cuerpo del mensaje
        private String _car_bodyms_caml;
        /// <summary>
        /// <para>TABLA: carfemailgestioma</para>
        /// <para>TABLA NATIVA: </para>
        /// <para>CAMPO: Cuerpo del mensaje</para>
        /// <para>NOMBRE: car_bodyms_caml (memo:)</para>
        /// <para>ORDEN VISTA EN TABLA: 12</para>
        /// <para>DESCRIPCIÓN: Texto (Body) cuerpo del mensaje (puede venir de una plantilla)</para>
        /// </summary>
        public String Car_bodyms_caml
        {
            get { return _car_bodyms_caml; }
            set
            {
                if (_car_bodyms_caml == value) return;
                _car_bodyms_caml = value;
                OnPropertyChanged("Car_bodyms_caml");
            }
        }
        #endregion
        #region Car_envfec_caml: Fecha envio
        private DateTime _car_envfec_caml;
        /// <summary>
        /// <para>TABLA: carfemailgestioma</para>
        /// <para>TABLA NATIVA: </para>
        /// <para>CAMPO: Fecha envio</para>
        /// <para>NOMBRE: car_envfec_caml (fecha:8)</para>
        /// <para>ORDEN VISTA EN TABLA: 13</para>
        /// <para>DESCRIPCIÓN: Fecha del envio al adquirente</para>
        /// </summary>
        public DateTime Car_envfec_caml
        {
            get { return _car_envfec_caml; }
            set
            {
                if (_car_envfec_caml == value) return;
                _car_envfec_caml = value;
                OnPropertyChanged("Car_envfec_caml");
            }
        }
        #endregion
        #region Car_envhor_caml: Hora envio
        private Decimal _car_envhor_caml;
        /// <summary>
        /// <para>TABLA: carfemailgestioma</para>
        /// <para>TABLA NATIVA: </para>
        /// <para>CAMPO: Hora envio</para>
        /// <para>NOMBRE: car_envhor_caml (hora:52)</para>
        /// <para>ORDEN VISTA EN TABLA: 14</para>
        /// <para>DESCRIPCIÓN: Hora de envio correo al adquirente</para>
        /// </summary>
        public Decimal Car_envhor_caml
        {
            get { return _car_envhor_caml; }
            set
            {
                if (_car_envhor_caml == value) return;
                _car_envhor_caml = value;
                OnPropertyChanged("Car_envhor_caml");
            }
        }
        #endregion
        #region Car_estenv_caml: Estado del envio
        private String _car_estenv_caml;
        /// <summary>
        /// <para>TABLA: carfemailgestioma</para>
        /// <para>TABLA NATIVA: </para>
        /// <para>CAMPO: Estado del envio</para>
        /// <para>NOMBRE: car_estenv_caml (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 15</para>
        /// <para>DESCRIPCIÓN: Estado del envio: 1=Recibido con éxito, 2=Hubo algun error al enviar el correo 3=Pendiente para enviar</para>
        /// </summary>
        public String Car_estenv_caml
        {
            get { return _car_estenv_caml; }
            set
            {
                if (_car_estenv_caml == value) return;
                _car_estenv_caml = value;
                OnPropertyChanged("Car_estenv_caml");
            }
        }
        #endregion
        #region Car_merror_caml: Error de envio
        private String _car_merror_caml;
        /// <summary>
        /// <para>TABLA: carfemailgestioma</para>
        /// <para>TABLA NATIVA: </para>
        /// <para>CAMPO: Error de envio</para>
        /// <para>NOMBRE: car_merror_caml (char:180)</para>
        /// <para>ORDEN VISTA EN TABLA: 16</para>
        /// <para>DESCRIPCIÓN: Descripcion del error de envio cuando este ocurra</para>
        /// </summary>
        public String Car_merror_caml
        {
            get { return _car_merror_caml; }
            set
            {
                if (_car_merror_caml == value) return;
                _car_merror_caml = value;
                OnPropertyChanged("Car_merror_caml");
            }
        }
        #endregion
        #region Car_secdet_cagm: Secuencial reg Detalles
        private int _car_secdet_cagm;
        /// <summary>
        /// <para>TABLA: carfemailgestioma</para>
        /// <para>TABLA NATIVA: carfemailgestioma</para>
        /// <para>CAMPO: Secuencial reg Detalles</para>
        /// <para>NOMBRE: car_secdet_cagm (int:8)</para>
        /// <para>ORDEN VISTA EN TABLA: 17</para>
        /// <para>DESCRIPCIÓN: Campo para generar el secuencial de los registros detalles</para>
        /// </summary>
        public int Car_secdet_cagm
        {
            get { return _car_secdet_cagm; }
            set
            {
                if (_car_secdet_cagm == value) return;
                _car_secdet_cagm = value;
                OnPropertyChanged("Car_secdet_cagm");
            }
        }
        #endregion
        #region Car_estpro_cagm: Estado Registro
        private String _car_estpro_cagm;
        /// <summary>
        /// <para>TABLA: carfemailgestioma</para>
        /// <para>TABLA NATIVA: carfemailgestioma</para>
        /// <para>CAMPO: Estado Registro</para>
        /// <para>NOMBRE: car_estpro_cagm (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 18</para>
        /// <para>DESCRIPCIÓN: Estado del registro: 1=Abierto 2=Confirmado y enviado al menos una vez</para>
        /// </summary>
        public String Car_estpro_cagm
        {
            get { return _car_estpro_cagm; }
            set
            {
                if (_car_estpro_cagm == value) return;
                _car_estpro_cagm = value;
                OnPropertyChanged("Car_estpro_cagm");
            }
        }
        #endregion
        // Datos adicionales
        #region Fcm_nomcom_fcem: Nombre Comercial
        private String _fcm_nomcom_fcem;
        /// <summary>
        /// <para>TABLA: temporal</para>
        /// <para>TABLA NATIVA: fcmfemaesrazsocma</para>
        /// <para>CAMPO: Nombre Comercial</para>
        /// <para>NOMBRE: fcm_nomcom_fcem (char:150)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCIÓN: Nombre comercial de la empresa</para>
        /// </summary>
        public String Fcm_nomcom_fcem
        {
            get { return _fcm_nomcom_fcem; }
            set
            {
                if (_fcm_nomcom_fcem == value) return;
                _fcm_nomcom_fcem = value;
                OnPropertyChanged("Fcm_nomcom_fcem");
            }
        }
        #endregion
        #region Sis_razsoc_sitr: Nombre o Razon social
        private String _sis_razsoc_sitr;
        /// <summary>
        /// <para>TABLA: temporal</para>
        /// <para>TABLA NATIVA: sismaesterceros</para>
        /// <para>CAMPO: Nombre / Razon social</para>
        /// <para>NOMBRE: sis_razsoc_sitr (char:240)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
        /// <para>DESCRIPCIÓN: Razon social de la empresa o nombre completo concatenado cuando es persona natural</para>
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
        #region Sis_emailc_sitr: Correo electrinico
        private String _sis_emailc_sitr;
        /// <summary>
        /// <para>TABLA: temporal</para>
        /// <para>TABLA NATIVA: sismaesterceros</para>
        /// <para>CAMPO: Correo electrinico</para>
        /// <para>NOMBRE: sis_emailc_sitr (char:80)</para>
        /// <para>ORDEN VISTA EN TABLA: 20</para>
        /// <para>DESCRIPCION: Correo electronico para contacto o envia facturas</para>
        /// </summary>
        public String Sis_emailc_sitr
        {
            get { return _sis_emailc_sitr; }
            set
            {
                if (_sis_emailc_sitr == value) return;
                _sis_emailc_sitr = value;
                OnPropertyChanged("Sis_emailc_sitr");
            }
        }
        #endregion
        #endregion
        #endregion
        #region Metodos para edicion de registros
        #region Adicionar Registro
        public static String flgAddRegistro(ModeloCarfemailgestioma tobjModelo)
        {
            var lcrCodigoGen = SysModelo.fcrGenerarNuevoCodigo("CAR-CARFEMAILGESTIOMA", "CAR", "Maestro gestor de correos grupales que se envian al adquirente");
            try
            {
                if (!flgBuscarCarfemailgestioma(lcrCodigoGen))
                {
                    using (_context = new DbAplicacion())
                    {
                        var lobjRegistro = new EFcarfemailgestioma
                        {
                            #region cargar Registro
                            car_secreg_cagm = tobjModelo.Car_secreg_cagm,
                            fcm_secraz_fcem = tobjModelo.Fcm_secraz_fcem,
                            car_gresum_cagm = tobjModelo.Car_gresum_cagm,
                            car_arcnom_cagm = tobjModelo.Car_arcnom_cagm,
                            car_gesori_cagm = tobjModelo.Car_gesori_cagm,
                            car_secref_cagm = tobjModelo.Car_secref_cagm,
                            fcm_numfac_mfac = tobjModelo.Fcm_numfac_mfac,
                            car_tphost_caml = tobjModelo.Car_tphost_caml,
                            car_faddre_caml = tobjModelo.Car_faddre_caml,
                            sis_idterc_sitr = tobjModelo.Sis_idterc_sitr,
                            car_taddre_caml = tobjModelo.Car_taddre_caml,
                            car_caddre_caml = tobjModelo.Car_caddre_caml,
                            car_subjec_caml = tobjModelo.Car_subjec_caml,
                            car_bodyms_caml = tobjModelo.Car_bodyms_caml,
                            car_envfec_caml = tobjModelo.Car_envfec_caml,
                            car_envhor_caml = tobjModelo.Car_envhor_caml,
                            car_estenv_caml = tobjModelo.Car_estenv_caml,
                            car_merror_caml = tobjModelo.Car_merror_caml,
                            car_secdet_cagm = tobjModelo.Car_secdet_cagm,
                            car_estpro_cagm = tobjModelo.Car_estpro_cagm,
                            #endregion
                        };
                        lobjRegistro.car_secreg_cagm = lcrCodigoGen;
                        _context.AddToCarfemailgestioma(lobjRegistro);
                        _context.SaveChanges();
                    }
                }
                else
                {
                    lcrCodigoGen = String.Empty;
                    MessageBox.Show("Nuevo codigo Generado esta desactualizado, revisar llave: \n" +
                                "'CAR-CARFEMAILGESTIOMA': Maestro gestor de correos grupales que se envian al adquirente en Maestro Secuenciales.");
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
        public static void FcvActualizar(ModeloCarfemailgestioma tobjModelo)
        {
            try
            {
                using (_context = new DbAplicacion())
                {
                    var lobjRegistro = _context.Carfemailgestioma.FirstOrDefault(p => p.car_secreg_cagm == tobjModelo.Car_secreg_cagm);
                    if (lobjRegistro != null)
                    {
                        #region cargar Registro
                        lobjRegistro.car_secreg_cagm = tobjModelo.Car_secreg_cagm;
                        lobjRegistro.fcm_secraz_fcem = tobjModelo.Fcm_secraz_fcem;
                        lobjRegistro.car_gresum_cagm = tobjModelo.Car_gresum_cagm;
                        lobjRegistro.car_arcnom_cagm = tobjModelo.Car_arcnom_cagm;
                        lobjRegistro.car_gesori_cagm = tobjModelo.Car_gesori_cagm;
                        lobjRegistro.car_secref_cagm = tobjModelo.Car_secref_cagm;
                        lobjRegistro.fcm_numfac_mfac = tobjModelo.Fcm_numfac_mfac;
                        lobjRegistro.car_tphost_caml = tobjModelo.Car_tphost_caml;
                        lobjRegistro.car_faddre_caml = tobjModelo.Car_faddre_caml;
                        lobjRegistro.sis_idterc_sitr = tobjModelo.Sis_idterc_sitr;
                        lobjRegistro.car_taddre_caml = tobjModelo.Car_taddre_caml;
                        lobjRegistro.car_caddre_caml = tobjModelo.Car_caddre_caml;
                        lobjRegistro.car_subjec_caml = tobjModelo.Car_subjec_caml;
                        lobjRegistro.car_bodyms_caml = tobjModelo.Car_bodyms_caml;
                        lobjRegistro.car_envfec_caml = (DateTime)tobjModelo.Car_envfec_caml;
                        lobjRegistro.car_envhor_caml = (Decimal)tobjModelo.Car_envhor_caml;
                        lobjRegistro.car_estenv_caml = tobjModelo.Car_estenv_caml;
                        lobjRegistro.car_merror_caml = tobjModelo.Car_merror_caml;
                        lobjRegistro.car_secdet_cagm = (int)tobjModelo.Car_secdet_cagm;
                        lobjRegistro.car_estpro_cagm = tobjModelo.Car_estpro_cagm;
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
                    var lobjRegistro = _context.Carfemailgestioma.FirstOrDefault(p => p.car_secreg_cagm == tcrCodigo);
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
        #region Buscar CARFEMAILGESTIOMA: Logica
        /// <summary>
        /// <para>TABLA: carfemailgestioma</para>
        /// <para>TITULO: Maestro gestor de correos grupales que se envian al adquiren</para>
        /// <para>MODULO: CAR</para>
        /// <para>VALOR RETORNO: Devuelve valor de tipo logico True/False pa indicar si existe o no el código.</para>
        /// <para>DESCRIPCIÓN TABLA: 
        /// Maestro Administrador lista correos de facturas que se envian a los adquirentes, permite llevar
        /// un control de correos enviados y facilitar esta gestion
        /// </para>
        /// </summary>
        public static bool flgBuscarCarfemailgestioma(String tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Carfemailgestioma.FirstOrDefault(p => p.car_secreg_cagm == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Listar Registros
        public static List<ModeloCarfemailgestioma> flsListaCarfemailgestioma(String tcrBuscar)
        {
            using (_context = new DbAplicacion())
            {
                if (String.IsNullOrEmpty(tcrBuscar))
                {
                    var lobConsulta = from carfemailgestioma in _context.Carfemailgestioma
                                      join fcmfemaesrazsocma in _context.Fcmfemaesrazsocma on carfemailgestioma.fcm_secraz_fcem equals fcmfemaesrazsocma.fcm_secraz_fcem into tmfcmfemaesrazsocma
                                      join sismaesterceros in _context.Sismaesterceros on carfemailgestioma.sis_idterc_sitr equals sismaesterceros.sis_idterc_sitr into tmsismaesterceros
                                      from fcem in tmfcmfemaesrazsocma.DefaultIfEmpty()
                                      from sitr in tmsismaesterceros.DefaultIfEmpty()
                                      select new ModeloCarfemailgestioma
                                      {
                                          #region Datos
                                          Car_secreg_cagm = carfemailgestioma.car_secreg_cagm,
                                          Fcm_secraz_fcem = carfemailgestioma.fcm_secraz_fcem,
                                          Car_gresum_cagm = carfemailgestioma.car_gresum_cagm,
                                          Car_arcnom_cagm = carfemailgestioma.car_arcnom_cagm,
                                          Car_gesori_cagm = carfemailgestioma.car_gesori_cagm,
                                          Car_secref_cagm = carfemailgestioma.car_secref_cagm,
                                          Fcm_numfac_mfac = carfemailgestioma.fcm_numfac_mfac,
                                          Car_tphost_caml = carfemailgestioma.car_tphost_caml,
                                          Car_faddre_caml = carfemailgestioma.car_faddre_caml,
                                          Sis_idterc_sitr = carfemailgestioma.sis_idterc_sitr,
                                          Car_taddre_caml = carfemailgestioma.car_taddre_caml,
                                          Car_caddre_caml = carfemailgestioma.car_caddre_caml,
                                          Car_subjec_caml = carfemailgestioma.car_subjec_caml,
                                          Car_bodyms_caml = carfemailgestioma.car_bodyms_caml,
                                          Car_envfec_caml = (DateTime)carfemailgestioma.car_envfec_caml,
                                          Car_envhor_caml = (Decimal)carfemailgestioma.car_envhor_caml,
                                          Car_estenv_caml = carfemailgestioma.car_estenv_caml,
                                          Car_merror_caml = carfemailgestioma.car_merror_caml,
                                          Car_secdet_cagm = (int)carfemailgestioma.car_secdet_cagm,
                                          Car_estpro_cagm = carfemailgestioma.car_estpro_cagm,
                                          Fcm_nomcom_fcem = fcem.fcm_nomcom_fcem,
                                          Sis_razsoc_sitr = sitr.sis_razsoc_sitr,
                                          Sis_emailc_sitr = sitr.sis_emailc_sitr
                                          #endregion
                                      };
                    return lobConsulta.ToList();
                }
                else
                {
                    var lobConsulta = from carfemailgestioma in _context.Carfemailgestioma
                                      join fcmfemaesrazsocma in _context.Fcmfemaesrazsocma on carfemailgestioma.fcm_secraz_fcem equals fcmfemaesrazsocma.fcm_secraz_fcem into tmfcmfemaesrazsocma
                                      join sismaesterceros in _context.Sismaesterceros on carfemailgestioma.sis_idterc_sitr equals sismaesterceros.sis_idterc_sitr into tmsismaesterceros
                                      from fcem in tmfcmfemaesrazsocma.DefaultIfEmpty()
                                      from sitr in tmsismaesterceros.DefaultIfEmpty()
                                      where carfemailgestioma.car_secreg_cagm == tcrBuscar
                                      select new ModeloCarfemailgestioma
                                      {
                                          #region Datos
                                          Car_secreg_cagm = carfemailgestioma.car_secreg_cagm,
                                          Fcm_secraz_fcem = carfemailgestioma.fcm_secraz_fcem,
                                          Car_gresum_cagm = carfemailgestioma.car_gresum_cagm,
                                          Car_arcnom_cagm = carfemailgestioma.car_arcnom_cagm,
                                          Car_gesori_cagm = carfemailgestioma.car_gesori_cagm,
                                          Car_secref_cagm = carfemailgestioma.car_secref_cagm,
                                          Fcm_numfac_mfac = carfemailgestioma.fcm_numfac_mfac,
                                          Car_tphost_caml = carfemailgestioma.car_tphost_caml,
                                          Car_faddre_caml = carfemailgestioma.car_faddre_caml,
                                          Sis_idterc_sitr = carfemailgestioma.sis_idterc_sitr,
                                          Car_taddre_caml = carfemailgestioma.car_taddre_caml,
                                          Car_caddre_caml = carfemailgestioma.car_caddre_caml,
                                          Car_subjec_caml = carfemailgestioma.car_subjec_caml,
                                          Car_bodyms_caml = carfemailgestioma.car_bodyms_caml,
                                          Car_envfec_caml = (DateTime)carfemailgestioma.car_envfec_caml,
                                          Car_envhor_caml = (Decimal)carfemailgestioma.car_envhor_caml,
                                          Car_estenv_caml = carfemailgestioma.car_estenv_caml,
                                          Car_merror_caml = carfemailgestioma.car_merror_caml,
                                          Car_secdet_cagm = (int)carfemailgestioma.car_secdet_cagm,
                                          Car_estpro_cagm = carfemailgestioma.car_estpro_cagm,
                                          Fcm_nomcom_fcem = fcem.fcm_nomcom_fcem,
                                          Sis_razsoc_sitr = sitr.sis_razsoc_sitr,
                                          Sis_emailc_sitr = sitr.sis_emailc_sitr
                                          #endregion
                                      };
                    return lobConsulta.ToList();
                }
            }
        }
        #endregion
        #endregion
    }
    /// <summary>
    /// Carfemailgestiomf: Referencias a documentos que pertenencen a 
    /// listas en una cuentas de cobro de facturas DIAN o facturas individuales
    /// </summary>
    public class ModeloCarfemailgestiomf : clBaseInpc
    {
        #region Modelo Attributos
        private static DbAplicacion _context;
        #region Modelo Propiedades Notificacion
        #region Car_secreg_cagf: Código unico registro
        private String _car_secreg_cagf;
        /// <summary>
        /// <para>TABLA: carfemailgestiomf</para>
        /// <para>TABLA NATIVA: carfemailgestiomf</para>
        /// <para>CAMPO: Código unico registro</para>
        /// <para>NOMBRE: car_secreg_cagf (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCIÓN: Secuencial unico registro email para evio (generado por el sistema)</para>
        /// </summary>
        public String Car_secreg_cagf
        {
            get { return _car_secreg_cagf; }
            set
            {
                if (_car_secreg_cagf == value) return;
                _car_secreg_cagf = value;
                OnPropertyChanged("Car_secreg_cagf");
            }
        }
        #endregion
        #region Car_secreg_cagm: Código gestor correo
        private String _car_secreg_cagm;
        /// <summary>
        /// <para>TABLA: carfemailgestiomf</para>
        /// <para>TABLA NATIVA: carfemailgestioma</para>
        /// <para>CAMPO: Código gestor correo</para>
        /// <para>NOMBRE: car_secreg_cagm (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCIÓN: Secuencial registro maestro gestor de correos</para>
        /// </summary>
        public String Car_secreg_cagm
        {
            get { return _car_secreg_cagm; }
            set
            {
                if (_car_secreg_cagm == value) return;
                _car_secreg_cagm = value;
                OnPropertyChanged("Car_secreg_cagm");
            }
        }
        #endregion
        #region Fcm_secreg_mfac: Codigo facturacion
        private String _fcm_secreg_mfac;
        /// <summary>
        /// <para>TABLA: carfemailgestiomf</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefma</para>
        /// <para>CAMPO: Codigo facturacion</para>
        /// <para>NOMBRE: fcm_secreg_mfac (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCIÓN: Secuencial unico de la orden Factura-Nota Debito-Nota-Credito (generado por el sistema)</para>
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
        #region Fcm_numfac_mfac: Numero Documento
        private String _fcm_numfac_mfac;
        /// <summary>
        /// <para>TABLA: carfemailgestiomf</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefma</para>
        /// <para>CAMPO: Numero Documento</para>
        /// <para>NOMBRE: fcm_numfac_mfac (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCIÓN: 
        /// Numero Dian del documento generado al confirmar el documento y enviado a DIAN (aceptado con
        /// éxito en DIAN)
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
        #region Car_estreg_cagf: Estado Registro
        private String _car_estreg_cagf;
        /// <summary>
        /// <para>TABLA: carfemailgestiomf</para>
        /// <para>TABLA NATIVA: carfemailgestiomf</para>
        /// <para>CAMPO: Estado Registro</para>
        /// <para>NOMBRE: car_estreg_cagf (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCIÓN: Estado del registro según envio : 1=Activo 2=InactivoEnviado a dian con Éxito</para>
        /// </summary>
        public String Car_estreg_cagf
        {
            get { return _car_estreg_cagf; }
            set
            {
                if (_car_estreg_cagf == value) return;
                _car_estreg_cagf = value;
                OnPropertyChanged("Car_estreg_cagf");
            }
        }
        #endregion
        #region Sis_estado_imaen: Estado del registro para edicion
        private String _sis_estado_imaen;
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
        #region Registros datos complementarios
        // Referencia a la factura DIAN
        #region lobRegFact: Registro referencia a la factura DIAN
        /// <summary>
        /// <para>Registro referencia a la factura dian y sus caracteristicas</para> 
        /// </summary>
        public ModeloFeFacturaMa lobRegFact;
        #endregion Registro referencia a la factura DIAN>

        #endregion Registros datos complementarios>
        #endregion
        #region Metodos para edicion de registros
        #region Adicionar Registro Relacion
        public static bool flgAddRegistro(ModeloCarfemailgestiomf tobTempReg, String tcrCodigoR1)
        {
            bool llgReturn = false;
            try
            {
                using (_context = new DbAplicacion())
                {
                    llgReturn = true;
                    var lobEFReg = new EFcarfemailgestiomf();
                    //-----------------------
                    if (tobTempReg.Sis_estado_imaen == "M")
                    {
                        lobEFReg = _context.Carfemailgestiomf.FirstOrDefault(p => p.car_secreg_cagf == tobTempReg.Car_secreg_cagf);
                    }
                    if (tobTempReg.Sis_estado_imaen == "A" || tobTempReg.Sis_estado_imaen == "M") // Adicionar o Modificar
                    {
                        #region cargar Registro
                        if (lobEFReg != null)
                        {
                            lobEFReg.car_secreg_cagf = tobTempReg.Car_secreg_cagf;
                            lobEFReg.car_secreg_cagm = tobTempReg.Car_secreg_cagm;
                            lobEFReg.fcm_secreg_mfac = tobTempReg.Fcm_secreg_mfac;
                            lobEFReg.fcm_numfac_mfac = tobTempReg.Fcm_numfac_mfac;
                            lobEFReg.car_estreg_cagf = tobTempReg.Car_estreg_cagf;
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
                                lobEFReg.car_secreg_cagf = tcrCodigoR1 + lobEFReg.car_secreg_cagf; // concatenar
                                _context.AddToCarfemailgestiomf(lobEFReg);
                                _context.SaveChanges();
                                break;

                            case "M": // Modificar el registro
                                _context.SaveChanges();
                                break;

                            case "E": // Eliminar el registro
                                var lobjRegistro = _context.Carfemailgestiomf.FirstOrDefault(p => p.car_secreg_cagf == tobTempReg.Car_secreg_cagf);
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
            catch (Exception ex)
            {
                llgReturn = false;
                MessageBox.Show(ex.Message, "Modelo Error Metodo: flgAddRegistro");
            }
            return llgReturn;
        }
        #endregion
        #region Buscar CARFEMAILGESTIOMF: Logica
        /// <summary>
        /// <para>TABLA: carfemailgestiomf</para>
        /// <para>TITULO: Referencias a documentos en cuentas de cobro con varias fact</para>
        /// <para>MODULO: CAR</para>
        /// <para>VALOR RETORNO: Devuelve valor de tipo logico True/False pa indicar si existe o no el código.</para>
        /// <para>DESCRIPCIÓN TABLA: Maestro lista referencias a documentos en cuentas de cobro  varias facturas DIAN</para>
        /// </summary>
        public static bool flgBuscarCarfemailgestiomf(String tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Carfemailgestiomf.FirstOrDefault(p => p.car_secreg_cagf == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Listar Registros
        /// <summary>
        /// Listado Registros detalles tipo documentos-facturas DIAN relacionadas en gestor de correos
        /// </summary>
        /// <param name="tcrIdRegistro">Codigo unico del registro maestro gestor correos</param>
        /// <returns></returns>
        public static List<ModeloCarfemailgestiomf> FlsListaCarfemailgestiomf(String tcrIdRegistro)
        {
            List<ModeloCarfemailgestiomf> lobConsulta;
            using (_context = new DbAplicacion())
            {
                lobConsulta = (from carfemailgestiomf in _context.Carfemailgestiomf
                                  join fcmfemaesfactefma in _context.Fcmfemaesfactefma on carfemailgestiomf.fcm_secreg_mfac equals fcmfemaesfactefma.fcm_secreg_mfac into tmfcmfemaesfactefma
                                  from mfac in tmfcmfemaesfactefma.DefaultIfEmpty()
                                  where carfemailgestiomf.car_secreg_cagm == tcrIdRegistro
                               select new ModeloCarfemailgestiomf
                                  {
                                      Car_secreg_cagf = carfemailgestiomf.car_secreg_cagf,
                                      Car_secreg_cagm = carfemailgestiomf.car_secreg_cagm,
                                      Fcm_secreg_mfac = carfemailgestiomf.fcm_secreg_mfac,
                                      Fcm_numfac_mfac = carfemailgestiomf.fcm_numfac_mfac,
                                      Car_estreg_cagf = carfemailgestiomf.car_estreg_cagf,
                                      Sis_estado_imaen = "I",
                                  }).ToList();
            }
            // aqui cargar cada factura Dian
            if (lobConsulta != null)
            {
                foreach (var lobReg in lobConsulta)
                {
                    lobReg.lobRegFact = ModeloFeFacturaMa.FobRegistroFcmfemaesfactefma("ID", lobReg.Fcm_secreg_mfac);
                }
            }

            return lobConsulta;
        }
        #endregion
        #endregion
    }
}
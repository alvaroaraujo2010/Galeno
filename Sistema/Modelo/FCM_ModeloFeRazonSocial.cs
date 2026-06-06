//- MARMOTA-GENCODE: VERSION 2.0 - 14/09/2020 12:08:57 PM
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
    /// Fcmfemaesrazsocma: Lista de Razones sociales con las que se puede enviar documentos eletronicos  firmados a la DIAN
    /// </summary>
    public class ModeloFeRazonSocial : clBaseInpc
    {
        #region Modelo Attributos
        private static DbAplicacion _context;
        #region Modelo Propiedades Notificacion
        // Datos de la razon social
        #region Fcm_secraz_fcem: Codigo unico Razon social
        private String _fcm_secraz_fcem;
        /// <summary>
        /// <para>TABLA: fcmfemaesrazsocma</para>
        /// <para>TABLA NATIVA: fcmfemaesrazsocma</para>
        /// <para>CAMPO: Codigo unico Razon social</para>
        /// <para>NOMBRE: fcm_secraz_fcem (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCIÓN: Codigo secuencial unico razon social empresa</para>
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
        #region Fcm_tipjur_fcem: Tipo organización jurídica
        private String _fcm_tipjur_fcem;
        /// <summary>
        /// <para>TABLA: fcmfemaesrazsocma</para>
        /// <para>TABLA NATIVA: fcmfemaesrazsocma</para>
        /// <para>CAMPO: Tipo organización jurídica</para>
        /// <para>NOMBRE: fcm_tipjur_fcem (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCIÓN: 
        /// Identificador de tipo de organización jurídica de la de persona: 1=Persona Juridica 2=Persona
        /// natural
        /// </para>
        /// </summary>
        public String Fcm_tipjur_fcem
        {
            get { return _fcm_tipjur_fcem; }
            set
            {
                if (_fcm_tipjur_fcem == value) return;
                _fcm_tipjur_fcem = value;
                OnPropertyChanged("Fcm_tipjur_fcem");
            }
        }
        #endregion
        #region Fcm_tipdoc_fctn: Tipo Documento Nit
        private String _fcm_tipdoc_fctn;
        /// <summary>
        /// <para>TABLA: fcmfemaesrazsocma</para>
        /// <para>TABLA NATIVA: </para>
        /// <para>CAMPO: Tipo Documento Nit</para>
        /// <para>NOMBRE: fcm_tipdoc_fctn (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCIÓN: 
        /// Tipo numero documento Nit: Registro civil-Tarjeta de identidad,Cédula de ciudadanía-Tarjeta
        /// de extranjería-Cédula de extranjería-NIT-Pasaporte-Documento de identificación extranjero-NIT
        /// de otro país-NUIP
        /// </para>
        /// </summary>
        public String Fcm_tipdoc_fctn
        {
            get { return _fcm_tipdoc_fctn; }
            set
            {
                if (_fcm_tipdoc_fctn == value) return;
                _fcm_tipdoc_fctn = value;
                OnPropertyChanged("Fcm_tipdoc_fctn");
            }
        }
        #endregion
        #region Fcm_numdoc_fcem: Numero Nit
        private String _fcm_numdoc_fcem;
        /// <summary>
        /// <para>TABLA: fcmfemaesrazsocma</para>
        /// <para>TABLA NATIVA: fcmfemaesrazsocma</para>
        /// <para>CAMPO: Numero Nit</para>
        /// <para>NOMBRE: fcm_numdoc_fcem (char:15)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCIÓN: Numero del Nit de la empresa</para>
        /// </summary>
        public String Fcm_numdoc_fcem
        {
            get { return _fcm_numdoc_fcem; }
            set
            {
                if (_fcm_numdoc_fcem == value) return;
                _fcm_numdoc_fcem = value;
                OnPropertyChanged("Fcm_numdoc_fcem");
            }
        }
        #endregion
        #region Fcm_digver_fcem: Digito de verificacion
        private String _fcm_digver_fcem;
        /// <summary>
        /// <para>TABLA: fcmfemaesrazsocma</para>
        /// <para>TABLA NATIVA: fcmfemaesrazsocma</para>
        /// <para>CAMPO: Digito de verificacion</para>
        /// <para>NOMBRE: fcm_digver_fcem (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCIÓN: Digito de verifcacion del Nit</para>
        /// </summary>
        public String Fcm_digver_fcem
        {
            get { return _fcm_digver_fcem; }
            set
            {
                if (_fcm_digver_fcem == value) return;
                _fcm_digver_fcem = value;
                OnPropertyChanged("Fcm_digver_fcem");
            }
        }
        #endregion
        #region Fcm_numprn_fcem: Nit Para impresión
        private String _fcm_numprn_fcem;
        /// <summary>
        /// <para>TABLA: fcmfemaesrazsocma</para>
        /// <para>TABLA NATIVA: fcmfemaesrazsocma</para>
        /// <para>CAMPO: Nit Para impresión</para>
        /// <para>NOMBRE: fcm_numprn_fcem (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCIÓN: 
        /// Numero del Nit de la empresa con puntos separadores y digito deverifiacion ejemplo:  854.000.235-9
        /// </para>
        /// </summary>
        public String Fcm_numprn_fcem
        {
            get { return _fcm_numprn_fcem; }
            set
            {
                if (_fcm_numprn_fcem == value) return;
                _fcm_numprn_fcem = value;
                OnPropertyChanged("Fcm_numprn_fcem");
            }
        }
        #endregion
        #region Fcm_codips_fcem: Codigo IPS
        private String _fcm_codips_fcem;
        /// <summary>
        /// <para>TABLA: fcmfemaesrazsocma</para>
        /// <para>TABLA NATIVA: fcmfemaesrazsocma</para>
        /// <para>CAMPO: Codigo IPS</para>
        /// <para>NOMBRE: fcm_codips_fcem (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCIÓN: 
        /// Codigo prestador de servicios de salud y de habilitacion según Ministerio de Salud de Colombia
        /// </para>
        /// </summary>
        public String Fcm_codips_fcem
        {
            get { return _fcm_codips_fcem; }
            set
            {
                if (_fcm_codips_fcem == value) return;
                _fcm_codips_fcem = value;
                OnPropertyChanged("Fcm_codips_fcem");
            }
        }
        #endregion
        #region Fcm_nomcom_fcem: Nombre Comercial
        private String _fcm_nomcom_fcem;
        /// <summary>
        /// <para>TABLA: fcmfemaesrazsocma</para>
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
        #region Fcm_razsoc_fcem: Razon social (tributaria)
        private String _fcm_razsoc_fcem;
        /// <summary>
        /// <para>TABLA: fcmfemaesrazsocma</para>
        /// <para>TABLA NATIVA: fcmfemaesrazsocma</para>
        /// <para>CAMPO: Razon social (tributaria)</para>
        /// <para>NOMBRE: fcm_razsoc_fcem (char:240)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCIÓN: Nombre o Razón Social (para inforamción tributaria) informacion legal</para>
        /// </summary>
        public String Fcm_razsoc_fcem
        {
            get { return _fcm_razsoc_fcem; }
            set
            {
                if (_fcm_razsoc_fcem == value) return;
                _fcm_razsoc_fcem = value;
                OnPropertyChanged("Fcm_razsoc_fcem");
            }
        }
        #endregion
        #region Fcm_slogan_fcem: Slogan de la empresa
        private String _fcm_slogan_fcem;
        /// <summary>
        /// <para>TABLA: fcmfemaesrazsocma</para>
        /// <para>TABLA NATIVA: fcmfemaesrazsocma</para>
        /// <para>CAMPO: Slogan de la empresa</para>
        /// <para>NOMBRE: fcm_slogan_fcem (char:150)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
        /// <para>DESCRIPCIÓN: Texto slogan de la empresa, para impresión en documentos</para>
        /// </summary>
        public String Fcm_slogan_fcem
        {
            get { return _fcm_slogan_fcem; }
            set
            {
                if (_fcm_slogan_fcem == value) return;
                _fcm_slogan_fcem = value;
                OnPropertyChanged("Fcm_slogan_fcem");
            }
        }
        #endregion
        #region Fcm_notpag_fcem: Texto Pie de pagina
        private String _fcm_notpag_fcem;
        /// <summary>
        /// <para>TABLA: fcmfemaesrazsocma</para>
        /// <para>TABLA NATIVA: fcmfemaesrazsocma</para>
        /// <para>CAMPO: Texto Pie de pagina</para>
        /// <para>NOMBRE: fcm_notpag_fcem (memo:)</para>
        /// <para>ORDEN VISTA EN TABLA: 11</para>
        /// <para>DESCRIPCIÓN: Texto largo para impresión en pie de pagina en documentos</para>
        /// </summary>
        public String Fcm_notpag_fcem
        {
            get { return _fcm_notpag_fcem; }
            set
            {
                if (_fcm_notpag_fcem == value) return;
                _fcm_notpag_fcem = value;
                OnPropertyChanged("Fcm_notpag_fcem");
            }
        }
        #endregion
        #region Fcm_codres_fcrf: Responsabilidades Fiscales
        private String _fcm_codres_fcrf;
        /// <summary>
        /// <para>TABLA: fcmfemaesrazsocma</para>
        /// <para>TABLA NATIVA: </para>
        /// <para>CAMPO: Responsabilidades Fiscales</para>
        /// <para>NOMBRE: fcm_codres_fcrf (char:150)</para>
        /// <para>ORDEN VISTA EN TABLA: 12</para>
        /// <para>DESCRIPCIÓN: 
        /// Responsabilidades fiscales de la empresa según lista  Dian Resolucion Facturacion Eletronica
        /// FAJ26
        /// </para>
        /// </summary>
        public String Fcm_codres_fcrf
        {
            get { return _fcm_codres_fcrf; }
            set
            {
                if (_fcm_codres_fcrf == value) return;
                _fcm_codres_fcrf = value;
                OnPropertyChanged("Fcm_codres_fcrf");
            }
        }
        #endregion
        #region Sis_codact_sitr: Codigos actividad CIIU
        private String _sis_codact_sitr;
        /// <summary>
        /// <para>TABLA: fcmfemaesrazsocma</para>
        /// <para>TABLA NATIVA: </para>
        /// <para>CAMPO: Codigos actividad CIIU</para>
        /// <para>NOMBRE: sis_codact_sitr (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 13</para>
        /// <para>DESCRIPCIÓN: Lista de códigos de actividad económica CIIU según Dian FAJ04 (separados por punto y coma)</para>
        /// </summary>
        public String Sis_codact_sitr
        {
            get { return _sis_codact_sitr; }
            set
            {
                if (_sis_codact_sitr == value) return;
                _sis_codact_sitr = value;
                OnPropertyChanged("Sis_codact_sitr");
            }
        }
        #endregion
        #region Fcm_imglog_fcem: Imagen logotipo
        private String _fcm_imglog_fcem;
        /// <summary>
        /// <para>TABLA: fcmfemaesrazsocma</para>
        /// <para>TABLA NATIVA: fcmfemaesrazsocma</para>
        /// <para>CAMPO: Imagen logotipo</para>
        /// <para>NOMBRE: fcm_imglog_fcem (char:80)</para>
        /// <para>ORDEN VISTA EN TABLA: 14</para>
        /// <para>DESCRIPCIÓN: Imagen (tipo JPG o PNG) logotipo de la empresa guardado en la ruta de reportes</para>
        /// </summary>
        public String Fcm_imglog_fcem
        {
            get { return _fcm_imglog_fcem; }
            set
            {
                if (_fcm_imglog_fcem == value) return;
                _fcm_imglog_fcem = value;
                OnPropertyChanged("Fcm_imglog_fcem");
            }
        }
        #endregion
        #region Fcm_imgcab_fcem: Imagen Encabezado
        private String _fcm_imgcab_fcem;
        /// <summary>
        /// <para>TABLA: fcmfemaesrazsocma</para>
        /// <para>TABLA NATIVA: fcmfemaesrazsocma</para>
        /// <para>CAMPO: Imagen Encabezado</para>
        /// <para>NOMBRE: fcm_imgcab_fcem (char:80)</para>
        /// <para>ORDEN VISTA EN TABLA: 15</para>
        /// <para>DESCRIPCIÓN: 
        /// Imagen (tipo JPG o PNG) logotipo para encabezado de documentos y otros  guardado en la ruta
        /// de reportes
        /// </para>
        /// </summary>
        public String Fcm_imgcab_fcem
        {
            get { return _fcm_imgcab_fcem; }
            set
            {
                if (_fcm_imgcab_fcem == value) return;
                _fcm_imgcab_fcem = value;
                OnPropertyChanged("Fcm_imgcab_fcem");
            }
        }
        #endregion
        // Datos de localizacion
        #region Sis_idemun_muni: Codigo Municipio Residencia
        private String _sis_idemun_muni;
        /// <summary>
        /// <para>TABLA: fcmfemaesrazsocma</para>
        /// <para>TABLA NATIVA: </para>
        /// <para>CAMPO: Codigo Municipio Residencia</para>
        /// <para>NOMBRE: sis_idemun_muni (char:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 16</para>
        /// <para>DESCRIPCIÓN: 
        /// Codigo DANE Municipio de residencia  donde ejerce la activid (Id Unico Municipio: Cod.DANE.Departamento+C
        /// od.DANE.Municipio)
        /// </para>
        /// </summary>
        public String Sis_idemun_muni
        {
            get { return _sis_idemun_muni; }
            set
            {
                if (_sis_idemun_muni == value) return;
                _sis_idemun_muni = value;
                OnPropertyChanged("Sis_idemun_muni");
            }
        }
        #endregion
        #region Fcm_dirres_fcem: Direccion Residencia
        private String _fcm_dirres_fcem;
        /// <summary>
        /// <para>TABLA: fcmfemaesrazsocma</para>
        /// <para>TABLA NATIVA: fcmfemaesrazsocma</para>
        /// <para>CAMPO: Direccion Residencia</para>
        /// <para>NOMBRE: fcm_dirres_fcem (char:150)</para>
        /// <para>ORDEN VISTA EN TABLA: 17</para>
        /// <para>DESCRIPCIÓN: Direccion de residencia comercial</para>
        /// </summary>
        public String Fcm_dirres_fcem
        {
            get { return _fcm_dirres_fcem; }
            set
            {
                if (_fcm_dirres_fcem == value) return;
                _fcm_dirres_fcem = value;
                OnPropertyChanged("Fcm_dirres_fcem");
            }
        }
        #endregion
        #region Fcm_nrotel_fcem: Telefonos contacto
        private String _fcm_nrotel_fcem;
        /// <summary>
        /// <para>TABLA: fcmfemaesrazsocma</para>
        /// <para>TABLA NATIVA: fcmfemaesrazsocma</para>
        /// <para>CAMPO: Telefonos contacto</para>
        /// <para>NOMBRE: fcm_nrotel_fcem (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 18</para>
        /// <para>DESCRIPCIÓN: Telefonos para contacto</para>
        /// </summary>
        public String Fcm_nrotel_fcem
        {
            get { return _fcm_nrotel_fcem; }
            set
            {
                if (_fcm_nrotel_fcem == value) return;
                _fcm_nrotel_fcem = value;
                OnPropertyChanged("Fcm_nrotel_fcem");
            }
        }
        #endregion
        #region Fcm_correo_fcem: Correo Electronico
        private String _fcm_correo_fcem;
        /// <summary>
        /// <para>TABLA: fcmfemaesrazsocma</para>
        /// <para>TABLA NATIVA: fcmfemaesrazsocma</para>
        /// <para>CAMPO: Correo Electronico</para>
        /// <para>NOMBRE: fcm_correo_fcem (char:80)</para>
        /// <para>ORDEN VISTA EN TABLA: 19</para>
        /// <para>DESCRIPCIÓN: Correo eletronico  empresarial para recibir notificaciones legales</para>
        /// </summary>
        public String Fcm_correo_fcem
        {
            get { return _fcm_correo_fcem; }
            set
            {
                if (_fcm_correo_fcem == value) return;
                _fcm_correo_fcem = value;
                OnPropertyChanged("Fcm_correo_fcem");
            }
        }
        #endregion
        #region Sis_codpos_sicp: Codigo Postal
        private String _sis_codpos_sicp;
        /// <summary>
        /// <para>TABLA: fcmfemaesrazsocma</para>
        /// <para>TABLA NATIVA: </para>
        /// <para>CAMPO: Codigo Postal</para>
        /// <para>NOMBRE: sis_codpos_sicp (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 20</para>
        /// <para>DESCRIPCIÓN: Codigo postal según lugar de Residencia</para>
        /// </summary>
        public String Sis_codpos_sicp
        {
            get { return _sis_codpos_sicp; }
            set
            {
                if (_sis_codpos_sicp == value) return;
                _sis_codpos_sicp = value;
                OnPropertyChanged("Sis_codpos_sicp");
            }
        }
        #endregion
        // Representante legal
        #region Fcm_reptdo_fcem: Tipo Documento
        private String _fcm_reptdo_fcem;
        /// <summary>
        /// <para>TABLA: fcmfemaesrazsocma</para>
        /// <para>TABLA NATIVA: fcmfemaesrazsocma</para>
        /// <para>CAMPO: Tipo Documento</para>
        /// <para>NOMBRE: fcm_reptdo_fcem (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 21</para>
        /// <para>DESCRIPCIÓN: 
        /// Tipo documento de indentificacion del Representante legal: CC=Cedula de ciudadania  CE=Cedula
        /// de Extranjeria PA=Pasaporte
        /// </para>
        /// </summary>
        public String Fcm_reptdo_fcem
        {
            get { return _fcm_reptdo_fcem; }
            set
            {
                if (_fcm_reptdo_fcem == value) return;
                _fcm_reptdo_fcem = value;
                OnPropertyChanged("Fcm_reptdo_fcem");
            }
        }
        #endregion
        #region Fcm_repndo_fcem: Numero documento
        private String _fcm_repndo_fcem;
        /// <summary>
        /// <para>TABLA: fcmfemaesrazsocma</para>
        /// <para>TABLA NATIVA: fcmfemaesrazsocma</para>
        /// <para>CAMPO: Numero documento</para>
        /// <para>NOMBRE: fcm_repndo_fcem (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 22</para>
        /// <para>DESCRIPCIÓN: Numero docuemtno de identidad del responsable de facturacion</para>
        /// </summary>
        public String Fcm_repndo_fcem
        {
            get { return _fcm_repndo_fcem; }
            set
            {
                if (_fcm_repndo_fcem == value) return;
                _fcm_repndo_fcem = value;
                OnPropertyChanged("Fcm_repndo_fcem");
            }
        }
        #endregion
        #region Fcm_repnom_fcem: Nombre Representante
        private String _fcm_repnom_fcem;
        /// <summary>
        /// <para>TABLA: fcmfemaesrazsocma</para>
        /// <para>TABLA NATIVA: fcmfemaesrazsocma</para>
        /// <para>CAMPO: Nombre Representante</para>
        /// <para>NOMBRE: fcm_repnom_fcem (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 23</para>
        /// <para>DESCRIPCIÓN: Nombre del Usuario facturador o contacto</para>
        /// </summary>
        public String Fcm_repnom_fcem
        {
            get { return _fcm_repnom_fcem; }
            set
            {
                if (_fcm_repnom_fcem == value) return;
                _fcm_repnom_fcem = value;
                OnPropertyChanged("Fcm_repnom_fcem");
            }
        }
        #endregion
        #region Fcm_reptel_fcem: Telefonos contacto
        private String _fcm_reptel_fcem;
        /// <summary>
        /// <para>TABLA: fcmfemaesrazsocma</para>
        /// <para>TABLA NATIVA: fcmfemaesrazsocma</para>
        /// <para>CAMPO: Telefonos contacto</para>
        /// <para>NOMBRE: fcm_reptel_fcem (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 24</para>
        /// <para>DESCRIPCIÓN: Telefono del representante legal de la empresa</para>
        /// </summary>
        public String Fcm_reptel_fcem
        {
            get { return _fcm_reptel_fcem; }
            set
            {
                if (_fcm_reptel_fcem == value) return;
                _fcm_reptel_fcem = value;
                OnPropertyChanged("Fcm_reptel_fcem");
            }
        }
        #endregion
        #region Fcm_repema_fcem: Correo Electronico
        private String _fcm_repema_fcem;
        /// <summary>
        /// <para>TABLA: fcmfemaesrazsocma</para>
        /// <para>TABLA NATIVA: fcmfemaesrazsocma</para>
        /// <para>CAMPO: Correo Electronico</para>
        /// <para>NOMBRE: fcm_repema_fcem (char:80)</para>
        /// <para>ORDEN VISTA EN TABLA: 25</para>
        /// <para>DESCRIPCIÓN: Correo eletronico representante legal de la empresa</para>
        /// </summary>
        public String Fcm_repema_fcem
        {
            get { return _fcm_repema_fcem; }
            set
            {
                if (_fcm_repema_fcem == value) return;
                _fcm_repema_fcem = value;
                OnPropertyChanged("Fcm_repema_fcem");
            }
        }
        #endregion
        #region Fcm_repimg_fcem: Imagen Firma
        private String _fcm_repimg_fcem;
        /// <summary>
        /// <para>TABLA: fcmfemaesrazsocma</para>
        /// <para>TABLA NATIVA: fcmfemaesrazsocma</para>
        /// <para>CAMPO: Imagen Firma</para>
        /// <para>NOMBRE: fcm_repimg_fcem (char:80)</para>
        /// <para>ORDEN VISTA EN TABLA: 26</para>
        /// <para>DESCRIPCIÓN: Imagen (tipo JPG o PNG) para mostrar la firma del representante legal de la empresa</para>
        /// </summary>
        public String Fcm_repimg_fcem
        {
            get { return _fcm_repimg_fcem; }
            set
            {
                if (_fcm_repimg_fcem == value) return;
                _fcm_repimg_fcem = value;
                OnPropertyChanged("Fcm_repimg_fcem");
            }
        }
        #endregion
        // Persona Responsable de facturacion
        #region Fcm_ctotdo_fcem: Tipo Documento
        private String _fcm_ctotdo_fcem;
        /// <summary>
        /// <para>TABLA: fcmfemaesrazsocma</para>
        /// <para>TABLA NATIVA: fcmfemaesrazsocma</para>
        /// <para>CAMPO: Tipo Documento</para>
        /// <para>NOMBRE: fcm_ctotdo_fcem (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 27</para>
        /// <para>DESCRIPCIÓN: 
        /// Tipo documento de indentificacion del responsable de facturacion: CC=Cedula de ciudadania
        /// CE=Cedula de Extranjeria PA=Pasaporte
        /// </para>
        /// </summary>
        public String Fcm_ctotdo_fcem
        {
            get { return _fcm_ctotdo_fcem; }
            set
            {
                if (_fcm_ctotdo_fcem == value) return;
                _fcm_ctotdo_fcem = value;
                OnPropertyChanged("Fcm_ctotdo_fcem");
            }
        }
        #endregion
        #region Fcm_ctondo_fcem: Numero documento
        private String _fcm_ctondo_fcem;
        /// <summary>
        /// <para>TABLA: fcmfemaesrazsocma</para>
        /// <para>TABLA NATIVA: fcmfemaesrazsocma</para>
        /// <para>CAMPO: Numero documento</para>
        /// <para>NOMBRE: fcm_ctondo_fcem (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 28</para>
        /// <para>DESCRIPCIÓN: Numero docuemtno de identidad del responsable de facturacion</para>
        /// </summary>
        public String Fcm_ctondo_fcem
        {
            get { return _fcm_ctondo_fcem; }
            set
            {
                if (_fcm_ctondo_fcem == value) return;
                _fcm_ctondo_fcem = value;
                OnPropertyChanged("Fcm_ctondo_fcem");
            }
        }
        #endregion
        #region Fcm_ctonom_fcem: Nombre Funcionario
        private String _fcm_ctonom_fcem;
        /// <summary>
        /// <para>TABLA: fcmfemaesrazsocma</para>
        /// <para>TABLA NATIVA: fcmfemaesrazsocma</para>
        /// <para>CAMPO: Nombre Funcionario</para>
        /// <para>NOMBRE: fcm_ctonom_fcem (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 29</para>
        /// <para>DESCRIPCIÓN: Nombre del Usuario facturador o contacto para firma facturación</para>
        /// </summary>
        public String Fcm_ctonom_fcem
        {
            get { return _fcm_ctonom_fcem; }
            set
            {
                if (_fcm_ctonom_fcem == value) return;
                _fcm_ctonom_fcem = value;
                OnPropertyChanged("Fcm_ctonom_fcem");
            }
        }
        #endregion
        #region Fcm_ctotel_fcem: Telefonos contacto
        private String _fcm_ctotel_fcem;
        /// <summary>
        /// <para>TABLA: fcmfemaesrazsocma</para>
        /// <para>TABLA NATIVA: fcmfemaesrazsocma</para>
        /// <para>CAMPO: Telefonos contacto</para>
        /// <para>NOMBRE: fcm_ctotel_fcem (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 30</para>
        /// <para>DESCRIPCIÓN: Telefono del Area de Facturacion o contacto con la empresa</para>
        /// </summary>
        public String Fcm_ctotel_fcem
        {
            get { return _fcm_ctotel_fcem; }
            set
            {
                if (_fcm_ctotel_fcem == value) return;
                _fcm_ctotel_fcem = value;
                OnPropertyChanged("Fcm_ctotel_fcem");
            }
        }
        #endregion
        #region Fcm_ctoema_fcem: Correo Electronico
        private String _fcm_ctoema_fcem;
        /// <summary>
        /// <para>TABLA: fcmfemaesrazsocma</para>
        /// <para>TABLA NATIVA: fcmfemaesrazsocma</para>
        /// <para>CAMPO: Correo Electronico</para>
        /// <para>NOMBRE: fcm_ctoema_fcem (char:80)</para>
        /// <para>ORDEN VISTA EN TABLA: 31</para>
        /// <para>DESCRIPCIÓN: Correo eletronico para contacto con Facturación</para>
        /// </summary>
        public String Fcm_ctoema_fcem
        {
            get { return _fcm_ctoema_fcem; }
            set
            {
                if (_fcm_ctoema_fcem == value) return;
                _fcm_ctoema_fcem = value;
                OnPropertyChanged("Fcm_ctoema_fcem");
            }
        }
        #endregion
        #region Fcm_ctoimg_fcem: Imagen Firma
        private String _fcm_ctoimg_fcem;
        /// <summary>
        /// <para>TABLA: fcmfemaesrazsocma</para>
        /// <para>TABLA NATIVA: fcmfemaesrazsocma</para>
        /// <para>CAMPO: Imagen Firma</para>
        /// <para>NOMBRE: fcm_ctoimg_fcem (char:80)</para>
        /// <para>ORDEN VISTA EN TABLA: 32</para>
        /// <para>DESCRIPCIÓN: Imagen (tipo JPG o PNG) para mostrar la firma del encargado de firmar facturas</para>
        /// </summary>
        public String Fcm_ctoimg_fcem
        {
            get { return _fcm_ctoimg_fcem; }
            set
            {
                if (_fcm_ctoimg_fcem == value) return;
                _fcm_ctoimg_fcem = value;
                OnPropertyChanged("Fcm_ctoimg_fcem");
            }
        }
        #endregion
        // Datos de facturacion
        #region Fcm_ambien_fcem: Ambiente Facturación
        private String _fcm_ambien_fcem;
        /// <summary>
        /// <para>TABLA: fcmfemaesrazsocma</para>
        /// <para>TABLA NATIVA: fcmfemaesrazsocma</para>
        /// <para>CAMPO: Ambiente Facturación</para>
        /// <para>NOMBRE: fcm_ambien_fcem (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 33</para>
        /// <para>DESCRIPCIÓN: Ambiente facturación Produccion o Ambiente de Pruebas</para>
        /// </summary>
        public String Fcm_ambien_fcem
        {
            get { return _fcm_ambien_fcem; }
            set
            {
                if (_fcm_ambien_fcem == value) return;
                _fcm_ambien_fcem = value;
                OnPropertyChanged("Fcm_ambien_fcem");
            }
        }
        #endregion
        #region Fcm_sofnom_fcem: Nombre software Propio
        private String _fcm_sofnom_fcem;
        /// <summary>
        /// <para>TABLA: fcmfemaesrazsocma</para>
        /// <para>TABLA NATIVA: fcmfemaesrazsocma</para>
        /// <para>CAMPO: Nombre software Propio</para>
        /// <para>NOMBRE: fcm_sofnom_fcem (char:70)</para>
        /// <para>ORDEN VISTA EN TABLA: 34</para>
        /// <para>DESCRIPCIÓN: 
        /// Nombre del Software tal como quedo registrado en la plataforma de Facturación Electrónica de
        /// la DIAN
        /// </para>
        /// </summary>
        public String Fcm_sofnom_fcem
        {
            get { return _fcm_sofnom_fcem; }
            set
            {
                if (_fcm_sofnom_fcem == value) return;
                _fcm_sofnom_fcem = value;
                OnPropertyChanged("Fcm_sofnom_fcem");
            }
        }
        #endregion
        #region Fcm_sofide_fcem: Codigo registro software
        private String _fcm_sofide_fcem;
        /// <summary>
        /// <para>TABLA: fcmfemaesrazsocma</para>
        /// <para>TABLA NATIVA: fcmfemaesrazsocma</para>
        /// <para>CAMPO: Codigo registro software</para>
        /// <para>NOMBRE: fcm_sofide_fcem (char:80)</para>
        /// <para>ORDEN VISTA EN TABLA: 35</para>
        /// <para>DESCRIPCIÓN: Codigo unico registro del Software en la plataforma de Facturación Electrónica de DIAN</para>
        /// </summary>
        public String Fcm_sofide_fcem
        {
            get { return _fcm_sofide_fcem; }
            set
            {
                if (_fcm_sofide_fcem == value) return;
                _fcm_sofide_fcem = value;
                OnPropertyChanged("Fcm_sofide_fcem");
            }
        }
        #endregion
        #region Fcm_sofpin_fcem: Pin del software
        private String _fcm_sofpin_fcem;
        /// <summary>
        /// <para>TABLA: fcmfemaesrazsocma</para>
        /// <para>TABLA NATIVA: fcmfemaesrazsocma</para>
        /// <para>CAMPO: Pin del software</para>
        /// <para>NOMBRE: fcm_sofpin_fcem (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 36</para>
        /// <para>DESCRIPCIÓN: Numero de Pin dado en el registro DIAN del Software</para>
        /// </summary>
        public String Fcm_sofpin_fcem
        {
            get { return _fcm_sofpin_fcem; }
            set
            {
                if (_fcm_sofpin_fcem == value) return;
                _fcm_sofpin_fcem = value;
                OnPropertyChanged("Fcm_sofpin_fcem");
            }
        }
        #endregion
        #region Fcm_setpru_fcem: Set de pruebas
        private String _fcm_setpru_fcem;
        /// <summary>
        /// <para>TABLA: fcmfemaesrazsocma</para>
        /// <para>TABLA NATIVA: fcmfemaesrazsocma</para>
        /// <para>CAMPO: Set de pruebas</para>
        /// <para>NOMBRE: fcm_setpru_fcem (char:80)</para>
        /// <para>ORDEN VISTA EN TABLA: 37</para>
        /// <para>DESCRIPCIÓN: Numero del set de pruebas (TestSetId) dado por DIAN para el Software</para>
        /// </summary>
        public String Fcm_setpru_fcem
        {
            get { return _fcm_setpru_fcem; }
            set
            {
                if (_fcm_setpru_fcem == value) return;
                _fcm_setpru_fcem = value;
                OnPropertyChanged("Fcm_setpru_fcem");
            }
        }
        #endregion
        #region Fcm_urlset_fcem: Url Ser de Preubas
        private String _fcm_urlset_fcem;
        /// <summary>
        /// <para>TABLA: fcmfemaesrazsocma</para>
        /// <para>TABLA NATIVA: fcmfemaesrazsocma</para>
        /// <para>CAMPO: Url Ser de Preubas</para>
        /// <para>NOMBRE: fcm_urlset_fcem (char:80)</para>
        /// <para>ORDEN VISTA EN TABLA: 38</para>
        /// <para>DESCRIPCIÓN: 
        /// Url del Web Service para conexión y envio del set de facturas del software en ambiente de pruebas
        /// para habilitación
        /// </para>
        /// </summary>
        public String Fcm_urlset_fcem
        {
            get { return _fcm_urlset_fcem; }
            set
            {
                if (_fcm_urlset_fcem == value) return;
                _fcm_urlset_fcem = value;
                OnPropertyChanged("Fcm_urlset_fcem");
            }
        }
        #endregion
        #region Fcm_urlpro_fcem: Url para Producción
        private String _fcm_urlpro_fcem;
        /// <summary>
        /// <para>TABLA: fcmfemaesrazsocma</para>
        /// <para>TABLA NATIVA: fcmfemaesrazsocma</para>
        /// <para>CAMPO: Url para Producción</para>
        /// <para>NOMBRE: fcm_urlpro_fcem (char:80)</para>
        /// <para>ORDEN VISTA EN TABLA: 39</para>
        /// <para>DESCRIPCIÓN: 
        /// Url del Web Service para conexión y envio de facturas en Ambiente de Producción del software
        /// habilitado
        /// </para>
        /// </summary>
        public String Fcm_urlpro_fcem
        {
            get { return _fcm_urlpro_fcem; }
            set
            {
                if (_fcm_urlpro_fcem == value) return;
                _fcm_urlpro_fcem = value;
                OnPropertyChanged("Fcm_urlpro_fcem");
            }
        }
        #endregion
        #region Fcm_clatec_fcem: Clave Técnica Software
        private String _fcm_clatec_fcem;
        /// <summary>
        /// <para>TABLA: fcmfemaesrazsocma</para>
        /// <para>TABLA NATIVA: fcmfemaesrazsocma</para>
        /// <para>CAMPO: Clave Técnica Software</para>
        /// <para>NOMBRE: fcm_clatec_fcem (char:80)</para>
        /// <para>ORDEN VISTA EN TABLA: 40</para>
        /// <para>DESCRIPCIÓN: 
        /// Codigo clave Tecnica del Software al momento de ser habilitado para pasar al Ambiente Producción
        /// </para>
        /// </summary>
        public String Fcm_clatec_fcem
        {
            get { return _fcm_clatec_fcem; }
            set
            {
                if (_fcm_clatec_fcem == value) return;
                _fcm_clatec_fcem = value;
                OnPropertyChanged("Fcm_clatec_fcem");
            }
        }
        #endregion
        #region Fcm_conser_fcem: Contador envio documentos
        private int _fcm_conser_fcem;
        /// <summary>
        /// <para>TABLA: fcmfemaesrazsocma</para>
        /// <para>TABLA NATIVA: fcmfemaesrazsocma</para>
        /// <para>CAMPO: Contador envio documentos</para>
        /// <para>NOMBRE: fcm_conser_fcem (int:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 41</para>
        /// <para>DESCRIPCIÓN: 
        /// Contador para envios de documentos a la DIAN, se utiliza para generar el nombre del archivo
        /// a enviar
        /// </para>
        /// </summary>
        public int Fcm_conser_fcem
        {
            get { return _fcm_conser_fcem; }
            set
            {
                if (_fcm_conser_fcem == value) return;
                _fcm_conser_fcem = value;
                OnPropertyChanged("Fcm_conser_fcem");
            }
        }
        #endregion
        // Certificado Digital
        #region Fcm_certip_fcem: Tipo certificado
        private String _fcm_certip_fcem;
        /// <summary>
        /// <para>TABLA: fcmfemaesrazsocma</para>
        /// <para>TABLA NATIVA: fcmfemaesrazsocma</para>
        /// <para>CAMPO: Tipo certificado</para>
        /// <para>NOMBRE: fcm_certip_fcem (char:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 43</para>
        /// <para>DESCRIPCIÓN: Tipo de certificado digital expedido por la DIAN (PFX o P12)</para>
        /// </summary>
        public String Fcm_certip_fcem
        {
            get { return _fcm_certip_fcem; }
            set
            {
                if (_fcm_certip_fcem == value) return;
                _fcm_certip_fcem = value;
                OnPropertyChanged("Fcm_certip_fcem");
            }
        }
        #endregion
        #region Fcm_cerarc_fcem: Archivo del Certificado
        private String _fcm_cerarc_fcem;
        /// <summary>
        /// <para>TABLA: fcmfemaesrazsocma</para>
        /// <para>TABLA NATIVA: fcmfemaesrazsocma</para>
        /// <para>CAMPO: Archivo del Certificado</para>
        /// <para>NOMBRE: fcm_cerarc_fcem (char:50)</para>
        /// <para>ORDEN VISTA EN TABLA: 44</para>
        /// <para>DESCRIPCIÓN: 
        /// Nombre del archivo fisico del certificado digital con extencion para ser localizado por la
        /// aplicación
        /// </para>
        /// </summary>
        public String Fcm_cerarc_fcem
        {
            get { return _fcm_cerarc_fcem; }
            set
            {
                if (_fcm_cerarc_fcem == value) return;
                _fcm_cerarc_fcem = value;
                OnPropertyChanged("Fcm_cerarc_fcem");
            }
        }
        #endregion
        #region Fcm_cerark_fcem: Archivo de Clave
        private String _fcm_cerark_fcem;
        /// <summary>
        /// <para>TABLA: fcmfemaesrazsocma</para>
        /// <para>TABLA NATIVA: fcmfemaesrazsocma</para>
        /// <para>CAMPO: Archivo de Clave</para>
        /// <para>NOMBRE: fcm_cerark_fcem (char:50)</para>
        /// <para>ORDEN VISTA EN TABLA: 45</para>
        /// <para>DESCRIPCIÓN: 
        /// Nombre del archivo fisico  que contiene la  clave de apertura del  archivo certificado digital
        /// </para>
        /// </summary>
        public String Fcm_cerark_fcem
        {
            get { return _fcm_cerark_fcem; }
            set
            {
                if (_fcm_cerark_fcem == value) return;
                _fcm_cerark_fcem = value;
                OnPropertyChanged("Fcm_cerark_fcem");
            }
        }
        #endregion
        #region Fcm_cerkey_fcem: Clave del certificado
        private String _fcm_cerkey_fcem;
        /// <summary>
        /// <para>TABLA: fcmfemaesrazsocma</para>
        /// <para>TABLA NATIVA: fcmfemaesrazsocma</para>
        /// <para>CAMPO: Clave del certificado</para>
        /// <para>NOMBRE: fcm_cerkey_fcem (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 46</para>
        /// <para>DESCRIPCIÓN: Clave en base64  del certificado Contenido Hash  guardado en la base de datos</para>
        /// </summary>
        public String Fcm_cerkey_fcem
        {
            get { return _fcm_cerkey_fcem; }
            set
            {
                if (_fcm_cerkey_fcem == value) return;
                _fcm_cerkey_fcem = value;
                OnPropertyChanged("Fcm_cerkey_fcem");
            }
        }
        #endregion
        #region Fcm_cerhas_fcem: Certificado Hash
        private String _fcm_cerhas_fcem;
        /// <summary>
        /// <para>TABLA: fcmfemaesrazsocma</para>
        /// <para>TABLA NATIVA: fcmfemaesrazsocma</para>
        /// <para>CAMPO: Certificado Hash</para>
        /// <para>NOMBRE: fcm_cerhas_fcem (memo:)</para>
        /// <para>ORDEN VISTA EN TABLA: 47</para>
        /// <para>DESCRIPCIÓN: 
        /// Contenido Hash del certificado digital guardado en la base de datos en base64  para evitar
        /// el uso de archivos fisicos
        /// </para>
        /// </summary>
        public String Fcm_cerhas_fcem
        {
            get { return _fcm_cerhas_fcem; }
            set
            {
                if (_fcm_cerhas_fcem == value) return;
                _fcm_cerhas_fcem = value;
                OnPropertyChanged("Fcm_cerhas_fcem");
            }
        }
        #endregion
        // Datos adicionales tabla
        #region Fcm_secres_srfa: Codigo Resolución Dian
        private String _fcm_secres_srfa;
        /// <summary>
        /// <para>TABLA: fcmfemaesrazsocma</para>
        /// <para>TABLA NATIVA: fcmsecrfacturas</para>
        /// <para>CAMPO: Codigo Resolución Dian</para>
        /// <para>NOMBRE: fcm_secres_srfa (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 48</para>
        /// <para>DESCRIPCIÓN: 
        /// Secuencial unico  en el sistema (maestro de resoluciones para rangos de facturacion DIAN) para
        /// referenciar de la resolución Dian
        /// </para>
        /// </summary>
        public String Fcm_secres_srfa
        {
            get { return _fcm_secres_srfa; }
            set
            {
                if (_fcm_secres_srfa == value) return;
                _fcm_secres_srfa = value;
                OnPropertyChanged("Fcm_secres_srfa");
            }
        }
        #endregion
        #region Fcm_congen_fcem: Contador registros detalles
        private int _fcm_congen_fcem;
        /// <summary>
        /// <para>TABLA: fcmfemaesrazsocma</para>
        /// <para>TABLA NATIVA: fcmfemaesrazsocma</para>
        /// <para>CAMPO: Contador registros detalles</para>
        /// <para>NOMBRE: fcm_congen_fcem (int:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 49</para>
        /// <para>DESCRIPCIÓN: Contador  para generar registros tipo detalles cuando se requiera</para>
        /// </summary>
        public int Fcm_congen_fcem
        {
            get { return _fcm_congen_fcem; }
            set
            {
                if (_fcm_congen_fcem == value) return;
                _fcm_congen_fcem = value;
                OnPropertyChanged("Fcm_congen_fcem");
            }
        }
        #endregion
        #region Fcm_estreg_fcem: Estado registro
        private String _fcm_estreg_fcem;
        /// <summary>
        /// <para>TABLA: fcmfemaesrazsocma</para>
        /// <para>TABLA NATIVA: fcmfemaesrazsocma</para>
        /// <para>CAMPO: Estado registro</para>
        /// <para>NOMBRE: fcm_estreg_fcem (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 50</para>
        /// <para>DESCRIPCIÓN: Estado del registro 1=Activo 2=inactivo</para>
        /// </summary>
        public String Fcm_estreg_fcem
        {
            get { return _fcm_estreg_fcem; }
            set
            {
                if (_fcm_estreg_fcem == value) return;
                _fcm_estreg_fcem = value;
                OnPropertyChanged("Fcm_estreg_fcem");
            }
        }
        #endregion
        // Datos adicionales temporales
        #region Sis_codmun_muni: Codigo Municipio
        private String _sis_codmun_muni;
        /// <summary>
        /// <para>TABLA: temporal</para>
        /// <para>TABLA NATIVA: sistabmunicipio</para>
        /// <para>CAMPO: Codigo Municipio</para>
        /// <para>NOMBRE: sis_codmun_muni (char:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 12</para>
        /// <para>DESCRIPCION:
        ///Codigo Municipio según DANE
        /// </para>
        /// </summary>
        public String Sis_codmun_muni
        {
            get { return _sis_codmun_muni; }
            set
            {
                if (_sis_codmun_muni == value) return;
                _sis_codmun_muni = value;
                OnPropertyChanged("Sis_codmun_muni");
            }
        }
        #endregion
        #region Sis_coddep_dpto: Codigo Departamento
        private String _sis_coddep_dpto;
        /// <summary>
        /// <para>TABLA: temporal</para>
        /// <para>TABLA NATIVA: sistabdepartame</para>
        /// <para>CAMPO: Codigo Departamento</para>
        /// <para>NOMBRE: sis_coddep_dpto (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 13</para>
        /// <para>DESCRIPCION:
        ///Codigo  del departamento DANE
        /// </para>
        /// </summary>
        public String Sis_coddep_dpto
        {
            get { return _sis_coddep_dpto; }
            set
            {
                if (_sis_coddep_dpto == value) return;
                _sis_coddep_dpto = value;
                OnPropertyChanged("Sis_coddep_dpto");
            }
        }
        #endregion
        #region Sis_nommun_muni: Nombre del Muncipio
        private String _sis_nommun_muni;
        /// <summary>
        /// <para>TABLA: fcmfemaesrazsocma</para>
        /// <para>TABLA NATIVA: sistabmunicipio</para>
        /// <para>CAMPO: Nombre del Muncipio</para>
        /// <para>NOMBRE: sis_nommun_muni (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        ///Nombre del Muncipio
        /// </para>
        /// </summary>
        public String Sis_nommun_muni
        {
            get { return _sis_nommun_muni; }
            set
            {
                if (_sis_nommun_muni == value) return;
                _sis_nommun_muni = value;
                OnPropertyChanged("Sis_nommun_muni");
            }
        }
        #endregion
        #region Sis_desdep_dpto: Nombre del departamento
        private String _sis_desdep_dpto;
        /// <summary>
        /// <para>TABLA: temporal</para>
        /// <para>TABLA NATIVA: sistabdepartame</para>
        /// <para>CAMPO: Nombre del departamento</para>
        /// <para>NOMBRE: sis_desdep_dpto (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Nombre del departamento segun DANE
        /// </para>
        /// </summary>
        public String Sis_desdep_dpto
        {
            get { return _sis_desdep_dpto; }
            set
            {
                if (_sis_desdep_dpto == value) return;
                _sis_desdep_dpto = value;
                OnPropertyChanged("Sis_desdep_dpto");
            }
        }
        #endregion
        #endregion
        #endregion

        #region Metodos para edicion de registros
        #region Adicionar Registro
        public static String FlgAddRegistro(ModeloFeRazonSocial tobjModelo)
        {
            var lcrCodigoGen = SysModelo.fcrGenerarNuevoCodigo("FCM-FCMFEMAESRAZSOCMA", "FCM", "Maestro Razon social de la empresa");
            try
            {
                if (!flgBuscarFcmfemaesrazsocma(lcrCodigoGen))
                {
                    using (_context = new DbAplicacion())
                    {
                        var lobjRegistro = new EFfcmfemaesrazsocma
                        {
                            #region cargar Registro
                            fcm_secraz_fcem = tobjModelo.Fcm_secraz_fcem,
                            fcm_tipjur_fcem = tobjModelo.Fcm_tipjur_fcem,
                            fcm_tipdoc_fctn = tobjModelo.Fcm_tipdoc_fctn,
                            fcm_numdoc_fcem = tobjModelo.Fcm_numdoc_fcem,
                            fcm_digver_fcem = tobjModelo.Fcm_digver_fcem,
                            fcm_numprn_fcem = tobjModelo.Fcm_numprn_fcem,
                            fcm_codips_fcem = tobjModelo.Fcm_codips_fcem,
                            fcm_nomcom_fcem = tobjModelo.Fcm_nomcom_fcem,
                            fcm_razsoc_fcem = tobjModelo.Fcm_razsoc_fcem,
                            fcm_slogan_fcem = tobjModelo.Fcm_slogan_fcem,
                            fcm_notpag_fcem = tobjModelo.Fcm_notpag_fcem,
                            fcm_codres_fcrf = tobjModelo.Fcm_codres_fcrf,
                            sis_codact_sitr = tobjModelo.Sis_codact_sitr,
                            fcm_imglog_fcem = tobjModelo.Fcm_imglog_fcem,
                            fcm_imgcab_fcem = tobjModelo.Fcm_imgcab_fcem,
                            sis_idemun_muni = tobjModelo.Sis_idemun_muni,
                            fcm_dirres_fcem = tobjModelo.Fcm_dirres_fcem,
                            fcm_nrotel_fcem = tobjModelo.Fcm_nrotel_fcem,
                            fcm_correo_fcem = tobjModelo.Fcm_correo_fcem,
                            sis_codpos_sicp = tobjModelo.Sis_codpos_sicp,
                            fcm_reptdo_fcem = tobjModelo.Fcm_reptdo_fcem,
                            fcm_repndo_fcem = tobjModelo.Fcm_repndo_fcem,
                            fcm_repnom_fcem = tobjModelo.Fcm_repnom_fcem,
                            fcm_reptel_fcem = tobjModelo.Fcm_reptel_fcem,
                            fcm_repema_fcem = tobjModelo.Fcm_repema_fcem,
                            fcm_repimg_fcem = tobjModelo.Fcm_repimg_fcem,
                            fcm_ctotdo_fcem = tobjModelo.Fcm_ctotdo_fcem,
                            fcm_ctondo_fcem = tobjModelo.Fcm_ctondo_fcem,
                            fcm_ctonom_fcem = tobjModelo.Fcm_ctonom_fcem,
                            fcm_ctotel_fcem = tobjModelo.Fcm_ctotel_fcem,
                            fcm_ctoema_fcem = tobjModelo.Fcm_ctoema_fcem,
                            fcm_ctoimg_fcem = tobjModelo.Fcm_ctoimg_fcem,
                            fcm_ambien_fcem = tobjModelo.Fcm_ambien_fcem,
                            fcm_sofnom_fcem = tobjModelo.Fcm_sofnom_fcem,
                            fcm_sofide_fcem = tobjModelo.Fcm_sofide_fcem,
                            fcm_sofpin_fcem = tobjModelo.Fcm_sofpin_fcem,
                            fcm_setpru_fcem = tobjModelo.Fcm_setpru_fcem,
                            fcm_urlset_fcem = tobjModelo.Fcm_urlset_fcem,
                            fcm_urlpro_fcem = tobjModelo.Fcm_urlpro_fcem,
                            fcm_clatec_fcem = tobjModelo.Fcm_clatec_fcem,
                            fcm_conser_fcem = tobjModelo.Fcm_conser_fcem,
                            fcm_certip_fcem = tobjModelo.Fcm_certip_fcem,
                            fcm_cerarc_fcem = tobjModelo.Fcm_cerarc_fcem,
                            fcm_cerark_fcem = tobjModelo.Fcm_cerark_fcem,
                            fcm_cerkey_fcem = tobjModelo.Fcm_cerkey_fcem,
                            fcm_cerhas_fcem = tobjModelo.Fcm_cerhas_fcem,
                            fcm_secres_srfa = tobjModelo.Fcm_secres_srfa,
                            fcm_congen_fcem = tobjModelo.Fcm_congen_fcem,
                            fcm_estreg_fcem = tobjModelo.Fcm_estreg_fcem,
                            #endregion
                        };
                        lobjRegistro.fcm_secraz_fcem = lcrCodigoGen;
                        _context.AddToFcmfemaesrazsocma(lobjRegistro);
                        _context.SaveChanges();
                    }
                }
                else
                {
                    lcrCodigoGen = String.Empty;
                    MessageBox.Show("Nuevo codigo Generado esta desactualizado, revisar llave: \n" +
                                "'FCM-FCMFEMAESRAZSOCMA': Maestro Razon social de la empresa en Maestro Secuenciales.");
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
        public static void FcvActualizar(ModeloFeRazonSocial tobjModelo)
        {
            try
            {
                using (_context = new DbAplicacion())
                {
                    var lobjRegistro = _context.Fcmfemaesrazsocma.FirstOrDefault(p => p.fcm_secraz_fcem == tobjModelo.Fcm_secraz_fcem);
                    if (lobjRegistro != null)
                    {
                        #region cargar Registro
                        lobjRegistro.fcm_secraz_fcem = tobjModelo.Fcm_secraz_fcem;
                        lobjRegistro.fcm_tipjur_fcem = tobjModelo.Fcm_tipjur_fcem;
                        lobjRegistro.fcm_tipdoc_fctn = tobjModelo.Fcm_tipdoc_fctn;
                        lobjRegistro.fcm_numdoc_fcem = tobjModelo.Fcm_numdoc_fcem;
                        lobjRegistro.fcm_digver_fcem = tobjModelo.Fcm_digver_fcem;
                        lobjRegistro.fcm_numprn_fcem = tobjModelo.Fcm_numprn_fcem;
                        lobjRegistro.fcm_codips_fcem = tobjModelo.Fcm_codips_fcem;
                        lobjRegistro.fcm_nomcom_fcem = tobjModelo.Fcm_nomcom_fcem;
                        lobjRegistro.fcm_razsoc_fcem = tobjModelo.Fcm_razsoc_fcem;
                        lobjRegistro.fcm_slogan_fcem = tobjModelo.Fcm_slogan_fcem;
                        lobjRegistro.fcm_notpag_fcem = tobjModelo.Fcm_notpag_fcem;
                        lobjRegistro.fcm_codres_fcrf = tobjModelo.Fcm_codres_fcrf;
                        lobjRegistro.sis_codact_sitr = tobjModelo.Sis_codact_sitr;
                        lobjRegistro.fcm_imglog_fcem = tobjModelo.Fcm_imglog_fcem;
                        lobjRegistro.fcm_imgcab_fcem = tobjModelo.Fcm_imgcab_fcem;
                        lobjRegistro.sis_idemun_muni = tobjModelo.Sis_idemun_muni;
                        lobjRegistro.fcm_dirres_fcem = tobjModelo.Fcm_dirres_fcem;
                        lobjRegistro.fcm_nrotel_fcem = tobjModelo.Fcm_nrotel_fcem;
                        lobjRegistro.fcm_correo_fcem = tobjModelo.Fcm_correo_fcem;
                        lobjRegistro.sis_codpos_sicp = tobjModelo.Sis_codpos_sicp;
                        lobjRegistro.fcm_reptdo_fcem = tobjModelo.Fcm_reptdo_fcem;
                        lobjRegistro.fcm_repndo_fcem = tobjModelo.Fcm_repndo_fcem;
                        lobjRegistro.fcm_repnom_fcem = tobjModelo.Fcm_repnom_fcem;
                        lobjRegistro.fcm_reptel_fcem = tobjModelo.Fcm_reptel_fcem;
                        lobjRegistro.fcm_repema_fcem = tobjModelo.Fcm_repema_fcem;
                        lobjRegistro.fcm_repimg_fcem = tobjModelo.Fcm_repimg_fcem;
                        lobjRegistro.fcm_ctotdo_fcem = tobjModelo.Fcm_ctotdo_fcem;
                        lobjRegistro.fcm_ctondo_fcem = tobjModelo.Fcm_ctondo_fcem;
                        lobjRegistro.fcm_ctonom_fcem = tobjModelo.Fcm_ctonom_fcem;
                        lobjRegistro.fcm_ctotel_fcem = tobjModelo.Fcm_ctotel_fcem;
                        lobjRegistro.fcm_ctoema_fcem = tobjModelo.Fcm_ctoema_fcem;
                        lobjRegistro.fcm_ctoimg_fcem = tobjModelo.Fcm_ctoimg_fcem;
                        lobjRegistro.fcm_ambien_fcem = tobjModelo.Fcm_ambien_fcem;
                        lobjRegistro.fcm_sofnom_fcem = tobjModelo.Fcm_sofnom_fcem;
                        lobjRegistro.fcm_sofide_fcem = tobjModelo.Fcm_sofide_fcem;
                        lobjRegistro.fcm_sofpin_fcem = tobjModelo.Fcm_sofpin_fcem;
                        lobjRegistro.fcm_setpru_fcem = tobjModelo.Fcm_setpru_fcem;
                        lobjRegistro.fcm_urlset_fcem = tobjModelo.Fcm_urlset_fcem;
                        lobjRegistro.fcm_urlpro_fcem = tobjModelo.Fcm_urlpro_fcem;
                        lobjRegistro.fcm_clatec_fcem = tobjModelo.Fcm_clatec_fcem;
                        lobjRegistro.fcm_conser_fcem = (int)tobjModelo.Fcm_conser_fcem;
                        lobjRegistro.fcm_certip_fcem = tobjModelo.Fcm_certip_fcem;
                        lobjRegistro.fcm_cerarc_fcem = tobjModelo.Fcm_cerarc_fcem;
                        lobjRegistro.fcm_cerark_fcem = tobjModelo.Fcm_cerark_fcem;
                        lobjRegistro.fcm_cerkey_fcem = tobjModelo.Fcm_cerkey_fcem;
                        lobjRegistro.fcm_cerhas_fcem = tobjModelo.Fcm_cerhas_fcem;
                        lobjRegistro.fcm_secres_srfa = tobjModelo.Fcm_secres_srfa;
                        lobjRegistro.fcm_congen_fcem = (int)tobjModelo.Fcm_congen_fcem;
                        lobjRegistro.fcm_estreg_fcem = tobjModelo.Fcm_estreg_fcem;
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
                    var lobjRegistro = _context.Fcmfemaesrazsocma.FirstOrDefault(p => p.fcm_secraz_fcem == tcrCodigo);
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
        #region Buscar FCMFEMAESRAZSOCMA: Logica
        /// <summary>
        /// <para>TABLA: fcmfemaesrazsocma</para>
        /// <para>TITULO: Maestro Razon social de la empresa</para>
        /// <para>MODULO: FCM</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Lista de Razones sociales con las que se puede enviar documentos
        /// eletronicos  firmados a la DIAN
        /// </para>
        /// </summary>
        public static bool flgBuscarFcmfemaesrazsocma(String tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Fcmfemaesrazsocma.FirstOrDefault(p => p.fcm_secraz_fcem == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region FnuGenerarSecuencialEnvioDian: Generar Secuencial de envio
        /// <summary>
        /// Generar el numero secuencial de envio anual a Dian
        /// </summary>
        /// <param name="tcrTipo">Tipo consulta "ID"= Numero unico del registro "NIT"=Numero de NIT</param>
        /// <param name="tcrCodigo">Codigo unico Registro Razon social  o Numero del Nit</param>
        /// <returns></returns>
        public static int FnuGenerarSecuencialEnvioDian(String tcrTipo, String tcrCodigo)
        {
            int lnuReturn = 0;
            using (_context = new DbAplicacion())
            {
                EFfcmfemaesrazsocma lobjRegistro = null;

                if (tcrTipo == "ID")
                {
                    lobjRegistro = _context.Fcmfemaesrazsocma.FirstOrDefault(p => p.fcm_secraz_fcem == tcrCodigo);
                }
                else 
                {
                    lobjRegistro = _context.Fcmfemaesrazsocma.FirstOrDefault(p => p.fcm_numdoc_fcem == tcrCodigo);
                }

                if (lobjRegistro != null)
                {
                    lobjRegistro.fcm_conser_fcem += 1;
                    _context.SaveChanges();

                    lnuReturn = (int)lobjRegistro.fcm_conser_fcem;
                };
            }
            return lnuReturn;
        }
        #endregion

        #region Listar Registros
        public static List<ModeloFeRazonSocial> FlsListaFcmfemaesrazsocma(String tcrBuscar)
        {
            using (_context = new DbAplicacion())
            {
                if (String.IsNullOrEmpty(tcrBuscar))
                {
                    var lobConsulta = from fcmfemaesrazsocma in _context.Fcmfemaesrazsocma
                                      join sistabmunicipio in _context.Sistabmunicipio on fcmfemaesrazsocma.sis_idemun_muni equals sistabmunicipio.sis_idemun_muni into tmsistabmunicipio
                                      from muni in tmsistabmunicipio.DefaultIfEmpty()
                                      select new ModeloFeRazonSocial
                                      {
                                          #region Datos
                                          Fcm_secraz_fcem = fcmfemaesrazsocma.fcm_secraz_fcem,
                                          Fcm_tipjur_fcem = fcmfemaesrazsocma.fcm_tipjur_fcem,
                                          Fcm_tipdoc_fctn = fcmfemaesrazsocma.fcm_tipdoc_fctn,
                                          Fcm_numdoc_fcem = fcmfemaesrazsocma.fcm_numdoc_fcem,
                                          Fcm_digver_fcem = fcmfemaesrazsocma.fcm_digver_fcem,
                                          Fcm_numprn_fcem = fcmfemaesrazsocma.fcm_numprn_fcem,
                                          Fcm_codips_fcem = fcmfemaesrazsocma.fcm_codips_fcem,
                                          Fcm_nomcom_fcem = fcmfemaesrazsocma.fcm_nomcom_fcem,
                                          Fcm_razsoc_fcem = fcmfemaesrazsocma.fcm_razsoc_fcem,
                                          Fcm_slogan_fcem = fcmfemaesrazsocma.fcm_slogan_fcem,
                                          Fcm_notpag_fcem = fcmfemaesrazsocma.fcm_notpag_fcem,
                                          Fcm_codres_fcrf = fcmfemaesrazsocma.fcm_codres_fcrf,
                                          Sis_codact_sitr = fcmfemaesrazsocma.sis_codact_sitr,
                                          Fcm_imglog_fcem = fcmfemaesrazsocma.fcm_imglog_fcem,
                                          Fcm_imgcab_fcem = fcmfemaesrazsocma.fcm_imgcab_fcem,
                                          Sis_idemun_muni = fcmfemaesrazsocma.sis_idemun_muni,
                                          Fcm_dirres_fcem = fcmfemaesrazsocma.fcm_dirres_fcem,
                                          Fcm_nrotel_fcem = fcmfemaesrazsocma.fcm_nrotel_fcem,
                                          Fcm_correo_fcem = fcmfemaesrazsocma.fcm_correo_fcem,
                                          Sis_codpos_sicp = fcmfemaesrazsocma.sis_codpos_sicp,
                                          Fcm_reptdo_fcem = fcmfemaesrazsocma.fcm_reptdo_fcem,
                                          Fcm_repndo_fcem = fcmfemaesrazsocma.fcm_repndo_fcem,
                                          Fcm_repnom_fcem = fcmfemaesrazsocma.fcm_repnom_fcem,
                                          Fcm_reptel_fcem = fcmfemaesrazsocma.fcm_reptel_fcem,
                                          Fcm_repema_fcem = fcmfemaesrazsocma.fcm_repema_fcem,
                                          Fcm_repimg_fcem = fcmfemaesrazsocma.fcm_repimg_fcem,
                                          Fcm_ctotdo_fcem = fcmfemaesrazsocma.fcm_ctotdo_fcem,
                                          Fcm_ctondo_fcem = fcmfemaesrazsocma.fcm_ctondo_fcem,
                                          Fcm_ctonom_fcem = fcmfemaesrazsocma.fcm_ctonom_fcem,
                                          Fcm_ctotel_fcem = fcmfemaesrazsocma.fcm_ctotel_fcem,
                                          Fcm_ctoema_fcem = fcmfemaesrazsocma.fcm_ctoema_fcem,
                                          Fcm_ctoimg_fcem = fcmfemaesrazsocma.fcm_ctoimg_fcem,
                                          Fcm_ambien_fcem = fcmfemaesrazsocma.fcm_ambien_fcem,
                                          Fcm_sofnom_fcem = fcmfemaesrazsocma.fcm_sofnom_fcem,
                                          Fcm_sofide_fcem = fcmfemaesrazsocma.fcm_sofide_fcem,
                                          Fcm_sofpin_fcem = fcmfemaesrazsocma.fcm_sofpin_fcem,
                                          Fcm_setpru_fcem = fcmfemaesrazsocma.fcm_setpru_fcem,
                                          Fcm_urlset_fcem = fcmfemaesrazsocma.fcm_urlset_fcem,
                                          Fcm_urlpro_fcem = fcmfemaesrazsocma.fcm_urlpro_fcem,
                                          Fcm_clatec_fcem = fcmfemaesrazsocma.fcm_clatec_fcem,
                                          Fcm_conser_fcem = (int)fcmfemaesrazsocma.fcm_conser_fcem,
                                          Fcm_certip_fcem = fcmfemaesrazsocma.fcm_certip_fcem,
                                          Fcm_cerarc_fcem = fcmfemaesrazsocma.fcm_cerarc_fcem,
                                          Fcm_cerark_fcem = fcmfemaesrazsocma.fcm_cerark_fcem,
                                          Fcm_cerkey_fcem = fcmfemaesrazsocma.fcm_cerkey_fcem,
                                          Fcm_cerhas_fcem = fcmfemaesrazsocma.fcm_cerhas_fcem,
                                          Fcm_secres_srfa = fcmfemaesrazsocma.fcm_secres_srfa,
                                          Fcm_congen_fcem = (int)fcmfemaesrazsocma.fcm_congen_fcem,
                                          Fcm_estreg_fcem = fcmfemaesrazsocma.fcm_estreg_fcem,
                                          Sis_nommun_muni = muni.sis_nommun_muni,
                                          #endregion
                                      };
                    return lobConsulta.ToList();
                }
                else
                {
                    var lobConsulta = from fcmfemaesrazsocma in _context.Fcmfemaesrazsocma
                                      join sistabmunicipio in _context.Sistabmunicipio on fcmfemaesrazsocma.sis_idemun_muni equals sistabmunicipio.sis_idemun_muni into tmsistabmunicipio
                                      from muni in tmsistabmunicipio.DefaultIfEmpty()
                                      where fcmfemaesrazsocma.fcm_secraz_fcem == tcrBuscar
                                      select new ModeloFeRazonSocial
                                      {
                                          #region Datos
                                          Fcm_secraz_fcem = fcmfemaesrazsocma.fcm_secraz_fcem,
                                          Fcm_tipjur_fcem = fcmfemaesrazsocma.fcm_tipjur_fcem,
                                          Fcm_tipdoc_fctn = fcmfemaesrazsocma.fcm_tipdoc_fctn,
                                          Fcm_numdoc_fcem = fcmfemaesrazsocma.fcm_numdoc_fcem,
                                          Fcm_digver_fcem = fcmfemaesrazsocma.fcm_digver_fcem,
                                          Fcm_numprn_fcem = fcmfemaesrazsocma.fcm_numprn_fcem,
                                          Fcm_codips_fcem = fcmfemaesrazsocma.fcm_codips_fcem,
                                          Fcm_nomcom_fcem = fcmfemaesrazsocma.fcm_nomcom_fcem,
                                          Fcm_razsoc_fcem = fcmfemaesrazsocma.fcm_razsoc_fcem,
                                          Fcm_slogan_fcem = fcmfemaesrazsocma.fcm_slogan_fcem,
                                          Fcm_notpag_fcem = fcmfemaesrazsocma.fcm_notpag_fcem,
                                          Fcm_codres_fcrf = fcmfemaesrazsocma.fcm_codres_fcrf,
                                          Sis_codact_sitr = fcmfemaesrazsocma.sis_codact_sitr,
                                          Fcm_imglog_fcem = fcmfemaesrazsocma.fcm_imglog_fcem,
                                          Fcm_imgcab_fcem = fcmfemaesrazsocma.fcm_imgcab_fcem,
                                          Sis_idemun_muni = fcmfemaesrazsocma.sis_idemun_muni,
                                          Fcm_dirres_fcem = fcmfemaesrazsocma.fcm_dirres_fcem,
                                          Fcm_nrotel_fcem = fcmfemaesrazsocma.fcm_nrotel_fcem,
                                          Fcm_correo_fcem = fcmfemaesrazsocma.fcm_correo_fcem,
                                          Sis_codpos_sicp = fcmfemaesrazsocma.sis_codpos_sicp,
                                          Fcm_reptdo_fcem = fcmfemaesrazsocma.fcm_reptdo_fcem,
                                          Fcm_repndo_fcem = fcmfemaesrazsocma.fcm_repndo_fcem,
                                          Fcm_repnom_fcem = fcmfemaesrazsocma.fcm_repnom_fcem,
                                          Fcm_reptel_fcem = fcmfemaesrazsocma.fcm_reptel_fcem,
                                          Fcm_repema_fcem = fcmfemaesrazsocma.fcm_repema_fcem,
                                          Fcm_repimg_fcem = fcmfemaesrazsocma.fcm_repimg_fcem,
                                          Fcm_ctotdo_fcem = fcmfemaesrazsocma.fcm_ctotdo_fcem,
                                          Fcm_ctondo_fcem = fcmfemaesrazsocma.fcm_ctondo_fcem,
                                          Fcm_ctonom_fcem = fcmfemaesrazsocma.fcm_ctonom_fcem,
                                          Fcm_ctotel_fcem = fcmfemaesrazsocma.fcm_ctotel_fcem,
                                          Fcm_ctoema_fcem = fcmfemaesrazsocma.fcm_ctoema_fcem,
                                          Fcm_ctoimg_fcem = fcmfemaesrazsocma.fcm_ctoimg_fcem,
                                          Fcm_ambien_fcem = fcmfemaesrazsocma.fcm_ambien_fcem,
                                          Fcm_sofnom_fcem = fcmfemaesrazsocma.fcm_sofnom_fcem,
                                          Fcm_sofide_fcem = fcmfemaesrazsocma.fcm_sofide_fcem,
                                          Fcm_sofpin_fcem = fcmfemaesrazsocma.fcm_sofpin_fcem,
                                          Fcm_setpru_fcem = fcmfemaesrazsocma.fcm_setpru_fcem,
                                          Fcm_urlset_fcem = fcmfemaesrazsocma.fcm_urlset_fcem,
                                          Fcm_urlpro_fcem = fcmfemaesrazsocma.fcm_urlpro_fcem,
                                          Fcm_clatec_fcem = fcmfemaesrazsocma.fcm_clatec_fcem,
                                          Fcm_conser_fcem = (int)fcmfemaesrazsocma.fcm_conser_fcem,
                                          Fcm_certip_fcem = fcmfemaesrazsocma.fcm_certip_fcem,
                                          Fcm_cerarc_fcem = fcmfemaesrazsocma.fcm_cerarc_fcem,
                                          Fcm_cerark_fcem = fcmfemaesrazsocma.fcm_cerark_fcem,
                                          Fcm_cerkey_fcem = fcmfemaesrazsocma.fcm_cerkey_fcem,
                                          Fcm_cerhas_fcem = fcmfemaesrazsocma.fcm_cerhas_fcem,
                                          Fcm_secres_srfa = fcmfemaesrazsocma.fcm_secres_srfa,
                                          Fcm_congen_fcem = (int)fcmfemaesrazsocma.fcm_congen_fcem,
                                          Fcm_estreg_fcem = fcmfemaesrazsocma.fcm_estreg_fcem,
                                          Sis_nommun_muni = muni.sis_nommun_muni,
                                          #endregion
                                      };
                    return lobConsulta.ToList();
                }
            }
        }
        #endregion
        #region Un solo Registro
        /// <summary>
        /// Generar un registro de factura completo con productos venta, datos del cliente y demas
        /// </summary>
        /// <param name="tcrTipo">Tipo consulta "ID"= Numero unico del registro "NIT"=Numero de NIT</param>
        /// <param name="tcrIdRegistro">Codigo del registro o numero de factura</param>
        /// <returns></returns>
        public static ModeloFeRazonSocial FlsListaFcmfemaesrazsocmaID(String tcrTipo, String tcrIdRegistro)
        {
            ModeloFeRazonSocial lobConsulta = null;
            using (_context = new DbAplicacion())
            {
                if (tcrTipo == "ID")
                {
                    lobConsulta = (from fcmfemaesrazsocma in _context.Fcmfemaesrazsocma
                                   join sistabmunicipio in _context.Sistabmunicipio on fcmfemaesrazsocma.sis_idemun_muni equals sistabmunicipio.sis_idemun_muni into tmsistabmunicipio
                                   from muni in tmsistabmunicipio.DefaultIfEmpty()
                                   where fcmfemaesrazsocma.fcm_secraz_fcem == tcrIdRegistro
                                   select new ModeloFeRazonSocial
                                   {
                                       #region Datos
                                       Fcm_secraz_fcem = fcmfemaesrazsocma.fcm_secraz_fcem,
                                       Fcm_tipjur_fcem = fcmfemaesrazsocma.fcm_tipjur_fcem,
                                       Fcm_tipdoc_fctn = fcmfemaesrazsocma.fcm_tipdoc_fctn,
                                       Fcm_numdoc_fcem = fcmfemaesrazsocma.fcm_numdoc_fcem,
                                       Fcm_digver_fcem = fcmfemaesrazsocma.fcm_digver_fcem,
                                       Fcm_numprn_fcem = fcmfemaesrazsocma.fcm_numprn_fcem,
                                       Fcm_codips_fcem = fcmfemaesrazsocma.fcm_codips_fcem,
                                       Fcm_nomcom_fcem = fcmfemaesrazsocma.fcm_nomcom_fcem,
                                       Fcm_razsoc_fcem = fcmfemaesrazsocma.fcm_razsoc_fcem,
                                       Fcm_slogan_fcem = fcmfemaesrazsocma.fcm_slogan_fcem,
                                       Fcm_notpag_fcem = fcmfemaesrazsocma.fcm_notpag_fcem,
                                       Fcm_codres_fcrf = fcmfemaesrazsocma.fcm_codres_fcrf,
                                       Sis_codact_sitr = fcmfemaesrazsocma.sis_codact_sitr,
                                       Fcm_imglog_fcem = fcmfemaesrazsocma.fcm_imglog_fcem,
                                       Fcm_imgcab_fcem = fcmfemaesrazsocma.fcm_imgcab_fcem,
                                       Sis_idemun_muni = fcmfemaesrazsocma.sis_idemun_muni,
                                       Fcm_dirres_fcem = fcmfemaesrazsocma.fcm_dirres_fcem,
                                       Fcm_nrotel_fcem = fcmfemaesrazsocma.fcm_nrotel_fcem,
                                       Fcm_correo_fcem = fcmfemaesrazsocma.fcm_correo_fcem,
                                       Sis_codpos_sicp = fcmfemaesrazsocma.sis_codpos_sicp,
                                       Fcm_reptdo_fcem = fcmfemaesrazsocma.fcm_reptdo_fcem,
                                       Fcm_repndo_fcem = fcmfemaesrazsocma.fcm_repndo_fcem,
                                       Fcm_repnom_fcem = fcmfemaesrazsocma.fcm_repnom_fcem,
                                       Fcm_reptel_fcem = fcmfemaesrazsocma.fcm_reptel_fcem,
                                       Fcm_repema_fcem = fcmfemaesrazsocma.fcm_repema_fcem,
                                       Fcm_repimg_fcem = fcmfemaesrazsocma.fcm_repimg_fcem,
                                       Fcm_ctotdo_fcem = fcmfemaesrazsocma.fcm_ctotdo_fcem,
                                       Fcm_ctondo_fcem = fcmfemaesrazsocma.fcm_ctondo_fcem,
                                       Fcm_ctonom_fcem = fcmfemaesrazsocma.fcm_ctonom_fcem,
                                       Fcm_ctotel_fcem = fcmfemaesrazsocma.fcm_ctotel_fcem,
                                       Fcm_ctoema_fcem = fcmfemaesrazsocma.fcm_ctoema_fcem,
                                       Fcm_ctoimg_fcem = fcmfemaesrazsocma.fcm_ctoimg_fcem,
                                       Fcm_ambien_fcem = fcmfemaesrazsocma.fcm_ambien_fcem,
                                       Fcm_sofnom_fcem = fcmfemaesrazsocma.fcm_sofnom_fcem,
                                       Fcm_sofide_fcem = fcmfemaesrazsocma.fcm_sofide_fcem,
                                       Fcm_sofpin_fcem = fcmfemaesrazsocma.fcm_sofpin_fcem,
                                       Fcm_setpru_fcem = fcmfemaesrazsocma.fcm_setpru_fcem,
                                       Fcm_urlset_fcem = fcmfemaesrazsocma.fcm_urlset_fcem,
                                       Fcm_urlpro_fcem = fcmfemaesrazsocma.fcm_urlpro_fcem,
                                       Fcm_clatec_fcem = fcmfemaesrazsocma.fcm_clatec_fcem,
                                       Fcm_conser_fcem = (int)fcmfemaesrazsocma.fcm_conser_fcem,
                                       Fcm_certip_fcem = fcmfemaesrazsocma.fcm_certip_fcem,
                                       Fcm_cerarc_fcem = fcmfemaesrazsocma.fcm_cerarc_fcem,
                                       Fcm_cerark_fcem = fcmfemaesrazsocma.fcm_cerark_fcem,
                                       Fcm_cerkey_fcem = fcmfemaesrazsocma.fcm_cerkey_fcem,
                                       Fcm_cerhas_fcem = fcmfemaesrazsocma.fcm_cerhas_fcem,
                                       Fcm_secres_srfa = fcmfemaesrazsocma.fcm_secres_srfa,
                                       Fcm_congen_fcem = (int)fcmfemaesrazsocma.fcm_congen_fcem,
                                       Fcm_estreg_fcem = fcmfemaesrazsocma.fcm_estreg_fcem,
                                       Sis_nommun_muni = muni.sis_nommun_muni,
                                       Sis_codmun_muni = muni.sis_codmun_muni,
                                       Sis_coddep_dpto = muni.sis_coddep_dpto,
                                       Sis_desdep_dpto = _context.Sistabdepartame.FirstOrDefault(rxp => rxp.sis_coddep_dpto == muni.sis_coddep_dpto).sis_desdep_dpto,
                                       #endregion
                                   }).FirstOrDefault();
                }
                else
                {
                    lobConsulta = (from fcmfemaesrazsocma in _context.Fcmfemaesrazsocma
                                   join sistabmunicipio in _context.Sistabmunicipio on fcmfemaesrazsocma.sis_idemun_muni equals sistabmunicipio.sis_idemun_muni into tmsistabmunicipio
                                   from muni in tmsistabmunicipio.DefaultIfEmpty()
                                   where fcmfemaesrazsocma.fcm_numdoc_fcem == tcrIdRegistro
                                   select new ModeloFeRazonSocial
                                   {
                                       #region Datos
                                       Fcm_secraz_fcem = fcmfemaesrazsocma.fcm_secraz_fcem,
                                       Fcm_tipjur_fcem = fcmfemaesrazsocma.fcm_tipjur_fcem,
                                       Fcm_tipdoc_fctn = fcmfemaesrazsocma.fcm_tipdoc_fctn,
                                       Fcm_numdoc_fcem = fcmfemaesrazsocma.fcm_numdoc_fcem,
                                       Fcm_digver_fcem = fcmfemaesrazsocma.fcm_digver_fcem,
                                       Fcm_numprn_fcem = fcmfemaesrazsocma.fcm_numprn_fcem,
                                       Fcm_codips_fcem = fcmfemaesrazsocma.fcm_codips_fcem,
                                       Fcm_nomcom_fcem = fcmfemaesrazsocma.fcm_nomcom_fcem,
                                       Fcm_razsoc_fcem = fcmfemaesrazsocma.fcm_razsoc_fcem,
                                       Fcm_slogan_fcem = fcmfemaesrazsocma.fcm_slogan_fcem,
                                       Fcm_notpag_fcem = fcmfemaesrazsocma.fcm_notpag_fcem,
                                       Fcm_codres_fcrf = fcmfemaesrazsocma.fcm_codres_fcrf,
                                       Sis_codact_sitr = fcmfemaesrazsocma.sis_codact_sitr,
                                       Fcm_imglog_fcem = fcmfemaesrazsocma.fcm_imglog_fcem,
                                       Fcm_imgcab_fcem = fcmfemaesrazsocma.fcm_imgcab_fcem,
                                       Sis_idemun_muni = fcmfemaesrazsocma.sis_idemun_muni,
                                       Fcm_dirres_fcem = fcmfemaesrazsocma.fcm_dirres_fcem,
                                       Fcm_nrotel_fcem = fcmfemaesrazsocma.fcm_nrotel_fcem,
                                       Fcm_correo_fcem = fcmfemaesrazsocma.fcm_correo_fcem,
                                       Sis_codpos_sicp = fcmfemaesrazsocma.sis_codpos_sicp,
                                       Fcm_reptdo_fcem = fcmfemaesrazsocma.fcm_reptdo_fcem,
                                       Fcm_repndo_fcem = fcmfemaesrazsocma.fcm_repndo_fcem,
                                       Fcm_repnom_fcem = fcmfemaesrazsocma.fcm_repnom_fcem,
                                       Fcm_reptel_fcem = fcmfemaesrazsocma.fcm_reptel_fcem,
                                       Fcm_repema_fcem = fcmfemaesrazsocma.fcm_repema_fcem,
                                       Fcm_repimg_fcem = fcmfemaesrazsocma.fcm_repimg_fcem,
                                       Fcm_ctotdo_fcem = fcmfemaesrazsocma.fcm_ctotdo_fcem,
                                       Fcm_ctondo_fcem = fcmfemaesrazsocma.fcm_ctondo_fcem,
                                       Fcm_ctonom_fcem = fcmfemaesrazsocma.fcm_ctonom_fcem,
                                       Fcm_ctotel_fcem = fcmfemaesrazsocma.fcm_ctotel_fcem,
                                       Fcm_ctoema_fcem = fcmfemaesrazsocma.fcm_ctoema_fcem,
                                       Fcm_ctoimg_fcem = fcmfemaesrazsocma.fcm_ctoimg_fcem,
                                       Fcm_ambien_fcem = fcmfemaesrazsocma.fcm_ambien_fcem,
                                       Fcm_sofnom_fcem = fcmfemaesrazsocma.fcm_sofnom_fcem,
                                       Fcm_sofide_fcem = fcmfemaesrazsocma.fcm_sofide_fcem,
                                       Fcm_sofpin_fcem = fcmfemaesrazsocma.fcm_sofpin_fcem,
                                       Fcm_setpru_fcem = fcmfemaesrazsocma.fcm_setpru_fcem,
                                       Fcm_urlset_fcem = fcmfemaesrazsocma.fcm_urlset_fcem,
                                       Fcm_urlpro_fcem = fcmfemaesrazsocma.fcm_urlpro_fcem,
                                       Fcm_clatec_fcem = fcmfemaesrazsocma.fcm_clatec_fcem,
                                       Fcm_conser_fcem = (int)fcmfemaesrazsocma.fcm_conser_fcem,
                                       Fcm_certip_fcem = fcmfemaesrazsocma.fcm_certip_fcem,
                                       Fcm_cerarc_fcem = fcmfemaesrazsocma.fcm_cerarc_fcem,
                                       Fcm_cerark_fcem = fcmfemaesrazsocma.fcm_cerark_fcem,
                                       Fcm_cerkey_fcem = fcmfemaesrazsocma.fcm_cerkey_fcem,
                                       Fcm_cerhas_fcem = fcmfemaesrazsocma.fcm_cerhas_fcem,
                                       Fcm_secres_srfa = fcmfemaesrazsocma.fcm_secres_srfa,
                                       Fcm_congen_fcem = (int)fcmfemaesrazsocma.fcm_congen_fcem,
                                       Fcm_estreg_fcem = fcmfemaesrazsocma.fcm_estreg_fcem,
                                       Sis_nommun_muni = muni.sis_nommun_muni,
                                       Sis_codmun_muni = muni.sis_codmun_muni,
                                       Sis_coddep_dpto = muni.sis_coddep_dpto,
                                       Sis_desdep_dpto = _context.Sistabdepartame.FirstOrDefault(rxp => rxp.sis_coddep_dpto == muni.sis_coddep_dpto).sis_desdep_dpto,
                                       #endregion
                                   }).FirstOrDefault();
                }
                return lobConsulta;
            }
        }
        #endregion
        #endregion
    }
}
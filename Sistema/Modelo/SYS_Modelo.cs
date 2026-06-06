//- MARMOTA-GENCODE: VERSION 2.0 - 12/05/2015 06:54:24 PM
using System;
using System.Windows;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.Generic;
using System.Data;
using Datos.Modelos;
using Sistema.Utilidades;
using Sistema.Modelo;
using Sistema.Clases;

namespace Sistema.Modelo
{
    /// <summary>
    /// <para>Tabla Sysadmsmensajes: Administrador para notificación servicios de mensajeria del sistema</para> 
    /// <para>para notificaciones.</para> 
    /// </summary>
    public class SysModeloAdminMensajes : clBaseInpc
    {
        #region Modelo Attributos
        private static DbAplicacion _context;
        #region Modelo Propiedades Notificacion
        #region Sys_codsec_syam: Código notificación
        private String _sys_codsec_syam;
        /// <summary>
        /// <para>TABLA: sysadmsmensajes</para>
        /// <para>TABLA NATIVA: sysadmsmensajes</para>
        /// <para>CAMPO: Código notificación</para>
        /// <para>NOMBRE: sys_codsec_syam (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        ///Código único notificación generada por el sistema
        /// </para>
        /// </summary>
        public String Sys_codsec_syam
        {
            get { return _sys_codsec_syam; }
            set
            {
                if (_sys_codsec_syam == value) return;
                _sys_codsec_syam = value;
                OnPropertyChanged("Sys_codsec_syam");
            }
        }
        #endregion
        #region Sys_llavis_syam: llave vista mensaje
        private long _sys_llavis_syam;
        /// <summary>
        /// <para>TABLA: sysadmsmensajes</para>
        /// <para>TABLA NATIVA: sysadmsmensajes</para>
        /// <para>CAMPO: llave vista mensaje</para>
        /// <para>NOMBRE: sys_llavis_syam (int:12)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// llave numerica para orden vista de notificaciones y filtro
        /// de nitficaciones  llave: (Año+Mes+Dia+HoraMilitar+Minutos)
        /// </para>
        /// </summary>
        public long Sys_llavis_syam
        {
            get { return _sys_llavis_syam; }
            set
            {
                if (_sys_llavis_syam == value) return;
                _sys_llavis_syam = value;
                OnPropertyChanged("Sys_llavis_syam");
            }
        }
        #endregion
        #region Sys_parent_syam: Código mensaje padre
        private String _sys_parent_syam;
        /// <summary>
        /// <para>TABLA: sysadmsmensajes</para>
        /// <para>TABLA NATIVA: sysadmsmensajes</para>
        /// <para>CAMPO: Código mensaje padre</para>
        /// <para>NOMBRE: sys_parent_syam (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        /// Código único notificación mensaje padre desde el cual se genera
        /// una copia para otros usuarios
        /// </para>
        /// </summary>
        public String Sys_parent_syam
        {
            get { return _sys_parent_syam; }
            set
            {
                if (_sys_parent_syam == value) return;
                _sys_parent_syam = value;
                OnPropertyChanged("Sys_parent_syam");
            }
        }
        #endregion
        #region Sys_desmsj_syam: Descripción notificación
        private String _sys_desmsj_syam;
        /// <summary>
        /// <para>TABLA: sysadmsmensajes</para>
        /// <para>TABLA NATIVA: sysadmsmensajes</para>
        /// <para>CAMPO: Descripción notificación</para>
        /// <para>NOMBRE: sys_desmsj_syam (char:80)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        /// Descripción de la notificación enviada según el evento ocurrido
        /// que debe ser notificado
        /// </para>
        /// </summary>
        public String Sys_desmsj_syam
        {
            get { return _sys_desmsj_syam; }
            set
            {
                if (_sys_desmsj_syam == value) return;
                _sys_desmsj_syam = value;
                OnPropertyChanged("Sys_desmsj_syam");
            }
        }
        #endregion
        #region Sys_notmsj_syam: Nota de notificación
        private String _sys_notmsj_syam;
        /// <summary>
        /// <para>TABLA: sysadmsmensajes</para>
        /// <para>TABLA NATIVA: sysadmsmensajes</para>
        /// <para>CAMPO: Nota de notificación</para>
        /// <para>NOMBRE: sys_notmsj_syam (memo:)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        ///Nota del mensaje (tamaño largo)
        /// </para>
        /// </summary>
        public String Sys_notmsj_syam
        {
            get { return _sys_notmsj_syam; }
            set
            {
                if (_sys_notmsj_syam == value) return;
                _sys_notmsj_syam = value;
                OnPropertyChanged("Sys_notmsj_syam");
            }
        }
        #endregion
        #region Sys_regeve_sytm: Código registro evento
        private String _sys_regeve_sytm;
        /// <summary>
        /// <para>TABLA: sysadmsmensajes</para>
        /// <para>TABLA NATIVA: sysadmstipomens</para>
        /// <para>CAMPO: Código registro evento</para>
        /// <para>NOMBRE: sys_regeve_sytm (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        /// Código del registro de evento que desencadena la notificación,
        /// pude ser: Código registro admisión, Código registro historia
        /// clínica, Id solicitud descuento en facturación y mas
        /// </para>
        /// </summary>
        public String Sys_regeve_sytm
        {
            get { return _sys_regeve_sytm; }
            set
            {
                if (_sys_regeve_sytm == value) return;
                _sys_regeve_sytm = value;
                OnPropertyChanged("Sys_regeve_sytm");
            }
        }
        #endregion
        #region Sys_tipmsj_syam: Tipo mensaje
        private String _sys_tipmsj_syam;
        /// <summary>
        /// <para>TABLA: sysadmsmensajes</para>
        /// <para>TABLA NATIVA: sysadmsmensajes</para>
        /// <para>CAMPO: Tipo mensaje</para>
        /// <para>NOMBRE: sys_tipmsj_syam (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        /// Tipo mensaje enviado: 1= Mensaje Publico ( no genera notificación
        /// de recibido) 2= Mensaje publico masivo con notificación de
        /// recibido  (a todos los usuarios, activos , grupos de usuarios
        /// y otros) 3= Mensaje Privado (solo a un usuario en particular)
        /// </para>
        /// </summary>
        public String Sys_tipmsj_syam
        {
            get { return _sys_tipmsj_syam; }
            set
            {
                if (_sys_tipmsj_syam == value) return;
                _sys_tipmsj_syam = value;
                OnPropertyChanged("Sys_tipmsj_syam");
            }
        }
        #endregion
        #region Sys_coduse_usux: Usuario que genera
        private String _sys_coduse_usux;
        /// <summary>
        /// <para>TABLA: sysadmsmensajes</para>
        /// <para>TABLA NATIVA: sysusuarios</para>
        /// <para>CAMPO: Usuario que genera</para>
        /// <para>NOMBRE: sys_coduse_usux (char:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        ///Código único del usuario que genera y envía el mensaje
        /// </para>
        /// </summary>
        public String Sys_coduse_usux
        {
            get { return _sys_coduse_usux; }
            set
            {
                if (_sys_coduse_usux == value) return;
                _sys_coduse_usux = value;
                OnPropertyChanged("Sys_coduse_usux");
            }
        }
        #endregion
        #region Sys_codusu_usux: Usuario que recibe
        private String _sys_codusu_usux;
        /// <summary>
        /// <para>TABLA: sysadmsmensajes</para>
        /// <para>TABLA NATIVA: sysusuarios</para>
        /// <para>CAMPO: Usuario que recibe</para>
        /// <para>NOMBRE: sys_codusu_usux (char:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        /// Código único del usuario que recibe el mensaje (para los mensajes
        /// públicos el usuario es un id general único)
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
        #region Sys_codtip_sytm: Código tipo de mensajes
        private String _sys_codtip_sytm;
        /// <summary>
        /// <para>TABLA: sysadmsmensajes</para>
        /// <para>TABLA NATIVA: sysadmstipomens</para>
        /// <para>CAMPO: Código tipo de mensajes</para>
        /// <para>NOMBRE: sys_codtip_sytm (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION:
        ///Código tipos de mensajes  ejemplo: ADM001 = Registro de admisión FCM001 = Autorizacion descuento en caja facturacion
        /// </para>
        /// </summary>
        public String Sys_codtip_sytm
        {
            get { return _sys_codtip_sytm; }
            set
            {
                if (_sys_codtip_sytm == value) return;
                _sys_codtip_sytm = value;
                OnPropertyChanged("Sys_codtip_sytm");
            }
        }
        #endregion
        #region Sys_codmsg_symg: Codigo grupo
        private String _sys_codmsg_symg;
        /// <summary>
        /// <para>TABLA: sysadmsmensajes</para>
        /// <para>TABLA NATIVA: sysadmgrupomens</para>
        /// <para>CAMPO: Codigo grupo</para>
        /// <para>NOMBRE: sys_codmsg_symg (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
        /// <para>DESCRIPCION:
        /// Código único grupos de mensajes  ejm: MSG = Mensajes general
        /// SYS: = Grupos mensajes de sistema FCM =Facturacion
        /// </para>
        /// </summary>
        public String Sys_codmsg_symg
        {
            get { return _sys_codmsg_symg; }
            set
            {
                if (_sys_codmsg_symg == value) return;
                _sys_codmsg_symg = value;
                OnPropertyChanged("Sys_codmsg_symg");
            }
        }
        #endregion
        #region Sys_codper_perf: Perfil usuario recibe
        private String _sys_codper_perf;
        /// <summary>
        /// <para>TABLA: sysadmsmensajes</para>
        /// <para>TABLA NATIVA: sysperfiusuario</para>
        /// <para>CAMPO: Perfil usuario recibe</para>
        /// <para>NOMBRE: sys_codper_perf (char:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 12</para>
        /// <para>DESCRIPCION:
        ///Código perfil de usuarios que reciben  el mensaje
        /// </para>
        /// </summary>
        public String Sys_codper_perf
        {
            get { return _sys_codper_perf; }
            set
            {
                if (_sys_codper_perf == value) return;
                _sys_codper_perf = value;
                OnPropertyChanged("Sys_codper_perf");
            }
        }
        #endregion
        #region Sys_sisfec_syam: Fecha sistema
        private DateTime _sys_sisfec_syam;
        /// <summary>
        /// <para>TABLA: sysadmsmensajes</para>
        /// <para>TABLA NATIVA: sysadmsmensajes</para>
        /// <para>CAMPO: Fecha sistema</para>
        /// <para>NOMBRE: sys_sisfec_syam (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 11</para>
        /// <para>DESCRIPCION:
        ///Fecha  del sistema cuando se genera registro del evento
        /// </para>
        /// </summary>
        public DateTime Sys_sisfec_syam
        {
            get { return _sys_sisfec_syam; }
            set
            {
                if (_sys_sisfec_syam == value) return;
                _sys_sisfec_syam = value;
                OnPropertyChanged("Sys_sisfec_syam");
            }
        }
        #endregion
        #region Sys_sishor_syam: Hora sistema
        private Decimal _sys_sishor_syam;
        /// <summary>
        /// <para>TABLA: sysadmsmensajes</para>
        /// <para>TABLA NATIVA: sysadmsmensajes</para>
        /// <para>CAMPO: Hora sistema</para>
        /// <para>NOMBRE: sys_sishor_syam (hora:52)</para>
        /// <para>ORDEN VISTA EN TABLA: 12</para>
        /// <para>DESCRIPCION:
        /// Hora de del sistema al generar registro de evento en formato
        /// militar  (HH) ejm: 16
        /// </para>
        /// </summary>
        public Decimal Sys_sishor_syam
        {
            get { return _sys_sishor_syam; }
            set
            {
                if (_sys_sishor_syam == value) return;
                _sys_sishor_syam = value;
                OnPropertyChanged("Sys_sishor_syam");
            }
        }
        #endregion
        #region Sys_vinfec_syam: Fecha inicia vigencia
        private DateTime _sys_vinfec_syam;
        /// <summary>
        /// <para>TABLA: sysadmsmensajes</para>
        /// <para>TABLA NATIVA: sysadmsmensajes</para>
        /// <para>CAMPO: Fecha inicia vigencia</para>
        /// <para>NOMBRE: sys_vinfec_syam (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 13</para>
        /// <para>DESCRIPCION:
        /// Fecha  del sistema cuando inicia la vigencia del mensaje (cuando
        /// no aplica vigencia, se asume fecha generación mensaje en sistema)
        /// </para>
        /// </summary>
        public DateTime Sys_vinfec_syam
        {
            get { return _sys_vinfec_syam; }
            set
            {
                if (_sys_vinfec_syam == value) return;
                _sys_vinfec_syam = value;
                OnPropertyChanged("Sys_vinfec_syam");
            }
        }
        #endregion
        #region Sys_vinhor_syam: Hora inicia vigencia
        private Decimal _sys_vinhor_syam;
        /// <summary>
        /// <para>TABLA: sysadmsmensajes</para>
        /// <para>TABLA NATIVA: sysadmsmensajes</para>
        /// <para>CAMPO: Hora inicia vigencia</para>
        /// <para>NOMBRE: sys_vinhor_syam (hora:52)</para>
        /// <para>ORDEN VISTA EN TABLA: 14</para>
        /// <para>DESCRIPCION:
        /// Hora de del sistema cuando inicia vigencia el evento del mensaje
        /// en formato militar  (HH) ejm: 16
        /// </para>
        /// </summary>
        public Decimal Sys_vinhor_syam
        {
            get { return _sys_vinhor_syam; }
            set
            {
                if (_sys_vinhor_syam == value) return;
                _sys_vinhor_syam = value;
                OnPropertyChanged("Sys_vinhor_syam");
            }
        }
        #endregion
        #region Sys_vfnfec_syam: Fecha fin vigencia
        private DateTime _sys_vfnfec_syam;
        /// <summary>
        /// <para>TABLA: sysadmsmensajes</para>
        /// <para>TABLA NATIVA: sysadmsmensajes</para>
        /// <para>CAMPO: Fecha fin vigencia</para>
        /// <para>NOMBRE: sys_vfnfec_syam (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 15</para>
        /// <para>DESCRIPCION:
        /// Fecha  del sistema cuando finalización  la vigencia del mensaje
        /// (cuando no aplica vigencia debe estar vacía)
        /// </para>
        /// </summary>
        public DateTime Sys_vfnfec_syam
        {
            get { return _sys_vfnfec_syam; }
            set
            {
                if (_sys_vfnfec_syam == value) return;
                _sys_vfnfec_syam = value;
                OnPropertyChanged("Sys_vfnfec_syam");
            }
        }
        #endregion
        #region Sys_vfnhor_syam: Hora fin vigencia
        private Decimal _sys_vfnhor_syam;
        /// <summary>
        /// <para>TABLA: sysadmsmensajes</para>
        /// <para>TABLA NATIVA: sysadmsmensajes</para>
        /// <para>CAMPO: Hora fin vigencia</para>
        /// <para>NOMBRE: sys_vfnhor_syam (hora:52)</para>
        /// <para>ORDEN VISTA EN TABLA: 16</para>
        /// <para>DESCRIPCION:
        /// Hora de del sistema cuando finaliza vigencia el evento del
        /// mensaje en formato militar  (HH) ejm: 16
        /// </para>
        /// </summary>
        public Decimal Sys_vfnhor_syam
        {
            get { return _sys_vfnhor_syam; }
            set
            {
                if (_sys_vfnhor_syam == value) return;
                _sys_vfnhor_syam = value;
                OnPropertyChanged("Sys_vfnhor_syam");
            }
        }
        #endregion
        #region Sys_vfrfec_syam: Fecha vista mensaje
        private DateTime _sys_vfrfec_syam;
        /// <summary>
        /// <para>TABLA: sysadmsmensajes</para>
        /// <para>TABLA NATIVA: sysadmsmensajes</para>
        /// <para>CAMPO: Fecha vista mensaje</para>
        /// <para>NOMBRE: sys_vfrfec_syam (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 17</para>
        /// <para>DESCRIPCION:
        /// Fecha  del sistema cuando el destinatario marco el mensaje
        /// como visto
        /// </para>
        /// </summary>
        public DateTime Sys_vfrfec_syam
        {
            get { return _sys_vfrfec_syam; }
            set
            {
                if (_sys_vfrfec_syam == value) return;
                _sys_vfrfec_syam = value;
                OnPropertyChanged("Sys_vfrfec_syam");
            }
        }
        #endregion
        #region Sys_vfrhor_syam: Hora vista mensaje
        private Decimal _sys_vfrhor_syam;
        /// <summary>
        /// <para>TABLA: sysadmsmensajes</para>
        /// <para>TABLA NATIVA: sysadmsmensajes</para>
        /// <para>CAMPO: Hora vista mensaje</para>
        /// <para>NOMBRE: sys_vfrhor_syam (hora:52)</para>
        /// <para>ORDEN VISTA EN TABLA: 18</para>
        /// <para>DESCRIPCION:
        /// Hora de del sistema cuando el destinatario marco el mensaje
        /// como visto formato militar  (HH) ejm: 16
        /// </para>
        /// </summary>
        public Decimal Sys_vfrhor_syam
        {
            get { return _sys_vfrhor_syam; }
            set
            {
                if (_sys_vfrhor_syam == value) return;
                _sys_vfrhor_syam = value;
                OnPropertyChanged("Sys_vfrhor_syam");
            }
        }
        #endregion
        #region Sys_msjvis_syam: Marca mensaje visto
        private String _sys_msjvis_syam;
        /// <summary>
        /// <para>TABLA: sysadmsmensajes</para>
        /// <para>TABLA NATIVA: sysadmsmensajes</para>
        /// <para>CAMPO: Marca mensaje visto</para>
        /// <para>NOMBRE: sys_msjvis_syam (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 19</para>
        /// <para>DESCRIPCION:
        /// Marca para saber si el mensaje fue revisado por el usuario
        /// destino: 1= Mensaje Activo (no visto por el destinatario) 
        /// 2= Mensaje inactivo (visto por el destnatario)
        /// </para>
        /// </summary>
        public String Sys_msjvis_syam
        {
            get { return _sys_msjvis_syam; }
            set
            {
                if (_sys_msjvis_syam == value) return;
                _sys_msjvis_syam = value;
                OnPropertyChanged("Sys_msjvis_syam");
            }
        }
        #endregion
        #region Sys_desmsj_sytm: Descripción tipo
        private String _sys_desmsj_sytm;
        /// <summary>
        /// <para>TABLA: sysadmsmensajes</para>
        /// <para>TABLA NATIVA: sysadmstipomens</para>
        /// <para>CAMPO: Descripción tipo</para>
        /// <para>NOMBRE: sys_desmsj_sytm (char:80)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Descripción del tipo notificación enviada según el evento ocurrido
        /// que debe ser notificado
        /// </para>
        /// </summary>
        public String Sys_desmsj_sytm
        {
            get { return _sys_desmsj_sytm; }
            set
            {
                if (_sys_desmsj_sytm == value) return;
                _sys_desmsj_sytm = value;
                OnPropertyChanged("Sys_desmsj_sytm");
            }
        }
        #endregion
        #region Sys_desmsg_symg: Descripción grupo
        private String _sys_desmsg_symg;
        /// <summary>
        /// <para>TABLA: sysadmsmensajes</para>
        /// <para>TABLA NATIVA: sysadmgrupomens</para>
        /// <para>CAMPO: Descripción grupo</para>
        /// <para>NOMBRE: sys_desmsg_symg (char:80)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripción grupos de mensajes
        /// </para>
        /// </summary>
        public String Sys_desmsg_symg
        {
            get { return _sys_desmsg_symg; }
            set
            {
                if (_sys_desmsg_symg == value) return;
                _sys_desmsg_symg = value;
                OnPropertyChanged("Sys_desmsg_symg");
            }
        }
        #endregion
        #region Grc_iderec_grcm: Código único recurso
        private String _grc_iderec_grcm;
        /// <summary>
        /// <para>TABLA: temporal</para>
        /// <para>TABLA NATIVA: </para>
        /// <para>CAMPO: Código único recurso</para>
        /// <para>NOMBRE: grc_iderec_grcm (char:50)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
        /// <para>DESCRIPCION:
        /// Código único del recurso de imagen que representa el evento
        /// (viene de galería de recursos)
        /// </para>
        /// </summary>
        public String Grc_iderec_grcm
        {
            get { return _grc_iderec_grcm; }
            set
            {
                if (_grc_iderec_grcm == value) return;
                _grc_iderec_grcm = value;
                OnPropertyChanged("Grc_iderec_grcm");
            }
        }
        #endregion
        #region Gestion del registro cargado en vista y referencia al objeto
        /// <summary>
        /// Referencia al objeto que representa la vista del registro
        /// </summary>
        public FrameworkElement GestionRefObjeto { get; set; }
        /// <summary>
        /// llave de busqueda para registros cargados en vista
        /// </summary>
        public String GestionLlaveBusqueda { get; set; }
        /// <summary>
        /// Estado del registro "XX" = No cargado en vista "OK" = cargado en vista
        /// </summary>
        public String GestionEstadoRegistro { get; set; }      
        #endregion
        #endregion
        #endregion
        #region Metodos para edicion de registros
        #region Adicionar Registro
        public static string flgAddRegistro(SysModeloAdminMensajes tobjModelo)
        {
        	var lcrCodigoGen = SysModelo.fcrGenerarNuevoCodigo("SYS-SYSADMSMENSAJES", "SYS", "Generar id notificación servicio de mensajes");
        	try
        	{
            	if (!flgBuscarSysadmsmensajes(lcrCodigoGen))
            	{
                	using (_context = new DbAplicacion())
                	{
                        tobjModelo.Sys_parent_syam = tobjModelo.Sys_parent_syam == "XX" ? lcrCodigoGen : tobjModelo.Sys_parent_syam;
        				var lobjRegistro = new EFsysadmsmensajes
        				{
        					#region cargar Registro
                            sys_codsec_syam = tobjModelo.Sys_codsec_syam,
                            sys_llavis_syam = tobjModelo.Sys_llavis_syam,
                            sys_parent_syam = tobjModelo.Sys_parent_syam,
                            sys_desmsj_syam = tobjModelo.Sys_desmsj_syam,
                            sys_notmsj_syam = tobjModelo.Sys_notmsj_syam,
                            sys_regeve_sytm = tobjModelo.Sys_regeve_sytm,
                            sys_tipmsj_syam = tobjModelo.Sys_tipmsj_syam,
                            sys_coduse_usux = tobjModelo.Sys_coduse_usux,
                            sys_codusu_usux = tobjModelo.Sys_codusu_usux,
                            sys_codtip_sytm = tobjModelo.Sys_codtip_sytm,
                            sys_codmsg_symg = tobjModelo.Sys_codmsg_symg,
                            sys_codper_perf = tobjModelo.Sys_codper_perf,
                            sys_sisfec_syam = tobjModelo.Sys_sisfec_syam,
                            sys_sishor_syam = tobjModelo.Sys_sishor_syam,
                            sys_vinfec_syam = tobjModelo.Sys_vinfec_syam,
                            sys_vinhor_syam = tobjModelo.Sys_vinhor_syam,
                            sys_vfnfec_syam = tobjModelo.Sys_vfnfec_syam,
                            sys_vfnhor_syam = tobjModelo.Sys_vfnhor_syam,
                            sys_vfrfec_syam = tobjModelo.Sys_vfrfec_syam,
                            sys_vfrhor_syam = tobjModelo.Sys_vfrhor_syam,
                            sys_msjvis_syam = tobjModelo.Sys_msjvis_syam,
        					#endregion
        				};
        				lobjRegistro.sys_codsec_syam = lcrCodigoGen;
        				_context.AddToSysadmsmensajes(lobjRegistro);
        				_context.SaveChanges();
                	}
            	}
            	else
            	{
                	lcrCodigoGen = string.Empty;
                	MessageBox.Show("Nuevo codigo generado esta desactualizado, revisar llave: \n"+
                                "'SYS-SYSADMSMENSAJES': Administrador para notificación servicio de mensajes en Maestro Secuenciales.");
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
        public static void fcvActualizar(SysModeloAdminMensajes tobjModelo)
        {
        	try
        	{
                using (_context = new DbAplicacion())
                {
        			var lobjRegistro = _context.Sysadmsmensajes.FirstOrDefault(p => p.sys_codsec_syam == tobjModelo.Sys_codsec_syam);
        			if (lobjRegistro != null)
        			{
                        lobjRegistro.sys_codsec_syam = tobjModelo.Sys_codsec_syam;
                        lobjRegistro.sys_llavis_syam = (int)tobjModelo.Sys_llavis_syam;
                        lobjRegistro.sys_parent_syam = tobjModelo.Sys_parent_syam;
                        lobjRegistro.sys_desmsj_syam = tobjModelo.Sys_desmsj_syam;
                        lobjRegistro.sys_notmsj_syam = tobjModelo.Sys_notmsj_syam;
                        lobjRegistro.sys_regeve_sytm = tobjModelo.Sys_regeve_sytm;
                        lobjRegistro.sys_tipmsj_syam = tobjModelo.Sys_tipmsj_syam;
                        lobjRegistro.sys_coduse_usux = tobjModelo.Sys_coduse_usux;
                        lobjRegistro.sys_codusu_usux = tobjModelo.Sys_codusu_usux;
                        lobjRegistro.sys_codtip_sytm = tobjModelo.Sys_codtip_sytm;
                        lobjRegistro.sys_codmsg_symg = tobjModelo.Sys_codmsg_symg;
                        lobjRegistro.sys_codper_perf = tobjModelo.Sys_codper_perf;
                        lobjRegistro.sys_sisfec_syam = (DateTime)tobjModelo.Sys_sisfec_syam;
                        lobjRegistro.sys_sishor_syam = (Decimal)tobjModelo.Sys_sishor_syam;
                        lobjRegistro.sys_vinfec_syam = (DateTime)tobjModelo.Sys_vinfec_syam;
                        lobjRegistro.sys_vinhor_syam = (Decimal)tobjModelo.Sys_vinhor_syam;
                        lobjRegistro.sys_vfnfec_syam = (DateTime)tobjModelo.Sys_vfnfec_syam;
                        lobjRegistro.sys_vfnhor_syam = (Decimal)tobjModelo.Sys_vfnhor_syam;
                        lobjRegistro.sys_vfrfec_syam = (DateTime)tobjModelo.Sys_vfrfec_syam;
                        lobjRegistro.sys_vfrhor_syam = (Decimal)tobjModelo.Sys_vfrhor_syam;
                        lobjRegistro.sys_msjvis_syam = tobjModelo.Sys_msjvis_syam;
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
        #region flstCargarNotifiYaVistaPerfil: Cargar notificacion ya vista para marcar 
        /// <summary>
        /// Cargar lista de notificacion ya vista (un tipo tcrIdTipoNotificacion) para marcar como ya vista en perfil activo
        /// </summary>
        public static List<EFsysadmsmensajes> flstCargarNotifiYaVistaPerfil(String tcrPerfil, String tcrIdTipoNotificacion)
        {
            List<EFsysadmsmensajes> tmpConsulta = null;
            try
            {
                using (_context = new DbAplicacion())
                {
                    tmpConsulta = (from tmp in _context.Sysadmsmensajes
                                   where tmp.sys_codtip_sytm == tcrIdTipoNotificacion &&
                                         tmp.sys_codper_perf == tcrPerfil &&
                                         tmp.sys_msjvis_syam == "1"
                                   select tmp).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Modelo Error Metodo: flstCargarNotifiYaVistaPerfil");
            }
            return tmpConsulta;
        }
        #endregion
        #region fcvMarcaNotifiYaVistaPerfil: Marcar notificacion como ya vista para el perfil
        /// <summary>
        /// Marcar todas las notificacion del tipo tcrIdTipoNotificacion como ya vista para el perfil
        /// </summary>
        public static void fcvMarcaNotifiYaVistaPerfil(String tcrPerfil, String tcrIdUsuario, String tcrIdTipoNotificacion)
        {
            try
            {
                var tmpConsulta = (from tmp in _context.Sysadmsmensajes
                                   where tmp.sys_codtip_sytm == tcrIdTipoNotificacion &&
                                         tmp.sys_codper_perf == tcrPerfil &&
                                         tmp.sys_msjvis_syam == "1"
                                   select tmp).ToList();
                if (tmpConsulta != null)
                {
                    foreach (var lobReg in tmpConsulta)
                    {
                        fcvMarcaNotifiYaVista(lobReg.sys_codsec_syam, tcrIdUsuario);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Modelo Error Metodo: fcvMarcaNotifiYaVistaPerfil");
            }
        }
        #endregion
        #region fcvMarcaNotifiYaVista: Marcar notificacion como ya vista
        /// <summary>
        /// Marcar la notificacion com ya vista
        /// </summary>
        public static void fcvMarcaNotifiYaVista(String tcrIdRegistroNotific, String tcrIdUsuario)
        {
            try
            {
                String gcrSeparadorDecimal = Funciones.fcrLeerConfiguracionRegional("DECIMAL");
                using (_context = new DbAplicacion())
                {
                    var lobjRegistro = _context.Sysadmsmensajes.FirstOrDefault(p => p.sys_codsec_syam == tcrIdRegistroNotific);
                    if (lobjRegistro != null)
                    {
                        lobjRegistro.sys_llavis_syam = fnuNuevaLlaveRegistroVista((int)lobjRegistro.sys_llavis_syam);
                        lobjRegistro.sys_codusu_usux = tcrIdUsuario;
                        lobjRegistro.sys_vfrfec_syam = Convert.ToDateTime(Funciones.fcrFechaActual());
                        lobjRegistro.sys_vfrhor_syam = Convert.ToDecimal(Funciones.fcrHoraActual("24", gcrSeparadorDecimal));
                        lobjRegistro.sys_msjvis_syam = "2";
                        _context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Modelo Error Metodo: fcvMarcaNotifiYaVista");
            }
        }
        #endregion
        #region fcrNuevaLlaveRegistroVista: Nueva llave para notificacion como ya vista
        /// <summary>
        /// Nueva llave para notificacion como ya vista
        /// </summary>
        public static int fnuNuevaLlaveRegistroVista(int tnuLlaveRegistro)
        {
            var lnullave = tnuLlaveRegistro;
            var lcrLlave = tnuLlaveRegistro.ToString().Trim();
            try
            {
                if (!String.IsNullOrWhiteSpace(lcrLlave))
                {
                    var lnuLen = lcrLlave.Length;

                    // quitar el ultimo y sumarlo
                    lnullave = Convert.ToInt32(lcrLlave.Substring(0, lnuLen - 1)) + Convert.ToInt32(lcrLlave.Substring(lnuLen-1, 1));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Modelo Error Metodo: fcvMarcaNotifiYaVista");
            }
            return lnullave;
        }
        #endregion
        #region Eliminar registro
        public static void fcvEliminar(string tcrCodigo)
        {
        	try
        	{
                using (_context = new DbAplicacion())
                {
        			var lobjRegistro = _context.Sysadmsmensajes.FirstOrDefault(p => p.sys_codsec_syam == tcrCodigo);
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
        #region Buscar SYSADMSMENSAJES: Logica
        /// <summary>
        /// <para>TABLA: sysadmsmensajes</para>
        /// <para>TITULO: Administrador para notificación servicio de mensajes</para>
        /// <para>MODULO: SYS</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Administrador para notificación del  servicio de mensajes que
        /// son generados en los distintos procesos en módulos del sistema
        /// </para>
        /// </summary>
        public static bool flgBuscarSysadmsmensajes(string tcrCodigo)
        {
        	bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Sysadmsmensajes.FirstOrDefault(p => p.sys_codsec_syam == tcrCodigo);
                if (lobjRegistro != null)
                {
                	llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Listar Registros
        public static List<SysModeloAdminMensajes> flsListaSysadmsmensajes(string tcrBuscar)
        {
            using (_context = new DbAplicacion())
            {
                var lobConsulta = from sysadmsmensajes in _context.Sysadmsmensajes
                                  join sysadmstipomens in _context.Sysadmstipomens on sysadmsmensajes.sys_codtip_sytm equals sysadmstipomens.sys_codtip_sytm into tmsysadmstipomens
                                  join sysadmgrupomens in _context.Sysadmgrupomens on sysadmsmensajes.sys_codmsg_symg equals sysadmgrupomens.sys_codmsg_symg into tmsysadmgrupomens
                                  from sytm in tmsysadmstipomens.DefaultIfEmpty()
                                  from symg in tmsysadmgrupomens.DefaultIfEmpty()
                                  where sysadmsmensajes.sys_codsec_syam == tcrBuscar
                                  select new SysModeloAdminMensajes
                                  {
                                      Sys_codsec_syam = sysadmsmensajes.sys_codsec_syam,
                                      Sys_llavis_syam = (int)sysadmsmensajes.sys_llavis_syam,
                                      Sys_parent_syam = sysadmsmensajes.sys_parent_syam,
                                      Sys_desmsj_syam = sysadmsmensajes.sys_desmsj_syam,
                                      Sys_notmsj_syam = sysadmsmensajes.sys_notmsj_syam,
                                      Sys_regeve_sytm = sysadmsmensajes.sys_regeve_sytm,
                                      Sys_tipmsj_syam = sysadmsmensajes.sys_tipmsj_syam,
                                      Sys_coduse_usux = sysadmsmensajes.sys_coduse_usux,
                                      Sys_codusu_usux = sysadmsmensajes.sys_codusu_usux,
                                      Sys_codtip_sytm = sysadmsmensajes.sys_codtip_sytm,
                                      Sys_codmsg_symg = sysadmsmensajes.sys_codmsg_symg,
                                      Sys_codper_perf = sysadmsmensajes.sys_codper_perf,
                                      Sys_sisfec_syam = (DateTime)sysadmsmensajes.sys_sisfec_syam,
                                      Sys_sishor_syam = (Decimal)sysadmsmensajes.sys_sishor_syam,
                                      Sys_vinfec_syam = (DateTime)sysadmsmensajes.sys_vinfec_syam,
                                      Sys_vinhor_syam = (Decimal)sysadmsmensajes.sys_vinhor_syam,
                                      Sys_vfnfec_syam = (DateTime)sysadmsmensajes.sys_vfnfec_syam,
                                      Sys_vfnhor_syam = (Decimal)sysadmsmensajes.sys_vfnhor_syam,
                                      Sys_vfrfec_syam = (DateTime)sysadmsmensajes.sys_vfrfec_syam,
                                      Sys_vfrhor_syam = (Decimal)sysadmsmensajes.sys_vfrhor_syam,
                                      Sys_msjvis_syam = sysadmsmensajes.sys_msjvis_syam,
                                      Sys_desmsj_sytm = sytm.sys_desmsj_sytm,
                                      Sys_desmsg_symg = symg.sys_desmsg_symg,
                                      GestionLlaveBusqueda = String.Empty,
                                      GestionEstadoRegistro = "XX"
                                  };
                return lobConsulta.ToList();
            }
        }
        #endregion
        #region flsListaSysadmsmensajesModulo: mostrar lista de mensajes por perfil y modulo
        /// <summary>
        /// <para>Filtro general para mostrar lista de mensajes para un perfil modulo y tipo notificación</para>
        /// </summary>
        public static List<SysModeloAdminMensajes> flsListaSysadmsmensajesModulo(String tcrIdPerfil, String tcrIdModulo, String tcrIdNotificaciones)
        {
            List<SysModeloAdminMensajes> lobReturn = null;
            using (_context = new DbAplicacion())
            {

                if (!String.IsNullOrWhiteSpace(tcrIdPerfil))
                {
                    #region Consulta
                    var lobConsulta = from sysadmsmensajes in _context.Sysadmsmensajes
                                      join sysadmstipomens in _context.Sysadmstipomens on sysadmsmensajes.sys_codtip_sytm equals sysadmstipomens.sys_codtip_sytm into tmsysadmstipomens
                                      join sysadmgrupomens in _context.Sysadmgrupomens on sysadmsmensajes.sys_codmsg_symg equals sysadmgrupomens.sys_codmsg_symg into tmsysadmgrupomens
                                      from sytm in tmsysadmstipomens.DefaultIfEmpty()
                                      from symg in tmsysadmgrupomens.DefaultIfEmpty()
                                      where sysadmsmensajes.sys_codmsg_symg == tcrIdModulo && 
                                            sysadmsmensajes.sys_codtip_sytm == tcrIdNotificaciones &&
                                            sysadmsmensajes.sys_codper_perf == tcrIdPerfil
                                      orderby sysadmsmensajes.sys_llavis_syam descending 
                                      select new SysModeloAdminMensajes
                                      {
                                          Sys_codsec_syam = sysadmsmensajes.sys_codsec_syam,
                                          Sys_llavis_syam = (int)sysadmsmensajes.sys_llavis_syam,
                                          Sys_parent_syam = sysadmsmensajes.sys_parent_syam,
                                          Sys_desmsj_syam = sysadmsmensajes.sys_desmsj_syam,
                                          Sys_notmsj_syam = sysadmsmensajes.sys_notmsj_syam,
                                          Sys_regeve_sytm = sysadmsmensajes.sys_regeve_sytm,
                                          Sys_tipmsj_syam = sysadmsmensajes.sys_tipmsj_syam,
                                          Sys_coduse_usux = sysadmsmensajes.sys_coduse_usux,
                                          Sys_codusu_usux = sysadmsmensajes.sys_codusu_usux,
                                          Sys_codtip_sytm = sysadmsmensajes.sys_codtip_sytm,
                                          Sys_codmsg_symg = sysadmsmensajes.sys_codmsg_symg,
                                          Sys_codper_perf = sysadmsmensajes.sys_codper_perf,
                                          Sys_sisfec_syam = (DateTime)sysadmsmensajes.sys_sisfec_syam,
                                          Sys_sishor_syam = (Decimal)sysadmsmensajes.sys_sishor_syam,
                                          Sys_vinfec_syam = (DateTime)sysadmsmensajes.sys_vinfec_syam,
                                          Sys_vinhor_syam = (Decimal)sysadmsmensajes.sys_vinhor_syam,
                                          Sys_vfnfec_syam = (DateTime)sysadmsmensajes.sys_vfnfec_syam,
                                          Sys_vfnhor_syam = (Decimal)sysadmsmensajes.sys_vfnhor_syam,
                                          Sys_vfrfec_syam = (DateTime)sysadmsmensajes.sys_vfrfec_syam,
                                          Sys_vfrhor_syam = (Decimal)sysadmsmensajes.sys_vfrhor_syam,
                                          Sys_msjvis_syam = sysadmsmensajes.sys_msjvis_syam,
                                          Sys_desmsj_sytm = sytm.sys_desmsj_sytm,
                                          Grc_iderec_grcm = sytm.grc_iderec_grcm,
                                          Sys_desmsg_symg = symg.sys_desmsg_symg,
                                          GestionLlaveBusqueda = String.Empty,
                                          GestionEstadoRegistro = "XX"
                                      };
                    #endregion
                    lobReturn = lobConsulta != null ? lobConsulta.Take(300).ToList() : null;
                }
                else
                {
                    #region Consulta
                    var lobConsulta = from sysadmsmensajes in _context.Sysadmsmensajes
                                      join sysadmstipomens in _context.Sysadmstipomens on sysadmsmensajes.sys_codtip_sytm equals sysadmstipomens.sys_codtip_sytm into tmsysadmstipomens
                                      join sysadmgrupomens in _context.Sysadmgrupomens on sysadmsmensajes.sys_codmsg_symg equals sysadmgrupomens.sys_codmsg_symg into tmsysadmgrupomens
                                      from sytm in tmsysadmstipomens.DefaultIfEmpty()
                                      from symg in tmsysadmgrupomens.DefaultIfEmpty()
                                      where sysadmsmensajes.sys_codmsg_symg == tcrIdModulo && 
                                            sysadmsmensajes.sys_codtip_sytm == tcrIdNotificaciones
                                      orderby sysadmsmensajes.sys_llavis_syam descending 
                                      select new SysModeloAdminMensajes
                                      {
                                          Sys_codsec_syam = sysadmsmensajes.sys_codsec_syam,
                                          Sys_llavis_syam = (int)sysadmsmensajes.sys_llavis_syam,
                                          Sys_parent_syam = sysadmsmensajes.sys_parent_syam,
                                          Sys_desmsj_syam = sysadmsmensajes.sys_desmsj_syam,
                                          Sys_notmsj_syam = sysadmsmensajes.sys_notmsj_syam,
                                          Sys_regeve_sytm = sysadmsmensajes.sys_regeve_sytm,
                                          Sys_tipmsj_syam = sysadmsmensajes.sys_tipmsj_syam,
                                          Sys_coduse_usux = sysadmsmensajes.sys_coduse_usux,
                                          Sys_codusu_usux = sysadmsmensajes.sys_codusu_usux,
                                          Sys_codtip_sytm = sysadmsmensajes.sys_codtip_sytm,
                                          Sys_codmsg_symg = sysadmsmensajes.sys_codmsg_symg,
                                          Sys_codper_perf = sysadmsmensajes.sys_codper_perf,
                                          Sys_sisfec_syam = (DateTime)sysadmsmensajes.sys_sisfec_syam,
                                          Sys_sishor_syam = (Decimal)sysadmsmensajes.sys_sishor_syam,
                                          Sys_vinfec_syam = (DateTime)sysadmsmensajes.sys_vinfec_syam,
                                          Sys_vinhor_syam = (Decimal)sysadmsmensajes.sys_vinhor_syam,
                                          Sys_vfnfec_syam = (DateTime)sysadmsmensajes.sys_vfnfec_syam,
                                          Sys_vfnhor_syam = (Decimal)sysadmsmensajes.sys_vfnhor_syam,
                                          Sys_vfrfec_syam = (DateTime)sysadmsmensajes.sys_vfrfec_syam,
                                          Sys_vfrhor_syam = (Decimal)sysadmsmensajes.sys_vfrhor_syam,
                                          Sys_msjvis_syam = sysadmsmensajes.sys_msjvis_syam,
                                          Sys_desmsj_sytm = sytm.sys_desmsj_sytm,
                                          Grc_iderec_grcm = sytm.grc_iderec_grcm,
                                          Sys_desmsg_symg = symg.sys_desmsg_symg,
                                          GestionLlaveBusqueda = String.Empty,
                                          GestionEstadoRegistro = "XX"
                                      };
                    #endregion
                    lobReturn = lobConsulta != null ? lobConsulta.Take(300).ToList() : null;
                }

                return lobReturn;
            }
        }
        #endregion
        #region flsListaSysadmsmensajesModuloUs: mostrar lista mensajes para usuario modulo y notificación
        /// <summary>
        /// <para>Filtro general para mostrar mensajes para un usuario modulo y tipo notificación</para>
        /// </summary>
        public static List<SysModeloAdminMensajes> flsListaSysadmsmensajesModuloUs(String tcrIdUsuario, String tcrIdModulo, String tcrIdNotificaciones)
        {
            List<SysModeloAdminMensajes> lobReturn = null;
            using (_context = new DbAplicacion())
            {

                if (!String.IsNullOrWhiteSpace(tcrIdModulo))
                {
                    #region Consulta
                    var lobConsulta = from sysadmsmensajes in _context.Sysadmsmensajes
                                      join sysadmstipomens in _context.Sysadmstipomens on sysadmsmensajes.sys_codtip_sytm equals sysadmstipomens.sys_codtip_sytm into tmsysadmstipomens
                                      join sysadmgrupomens in _context.Sysadmgrupomens on sysadmsmensajes.sys_codmsg_symg equals sysadmgrupomens.sys_codmsg_symg into tmsysadmgrupomens
                                      from sytm in tmsysadmstipomens.DefaultIfEmpty()
                                      from symg in tmsysadmgrupomens.DefaultIfEmpty()
                                      where sysadmsmensajes.sys_codmsg_symg == tcrIdModulo &&
                                            sysadmsmensajes.sys_codtip_sytm == tcrIdNotificaciones &&
                                            sysadmsmensajes.sys_codusu_usux == tcrIdUsuario
                                      orderby sysadmsmensajes.sys_llavis_syam descending
                                      select new SysModeloAdminMensajes
                                      {
                                          Sys_codsec_syam = sysadmsmensajes.sys_codsec_syam,
                                          Sys_llavis_syam = (int)sysadmsmensajes.sys_llavis_syam,
                                          Sys_parent_syam = sysadmsmensajes.sys_parent_syam,
                                          Sys_desmsj_syam = sysadmsmensajes.sys_desmsj_syam,
                                          Sys_notmsj_syam = sysadmsmensajes.sys_notmsj_syam,
                                          Sys_regeve_sytm = sysadmsmensajes.sys_regeve_sytm,
                                          Sys_tipmsj_syam = sysadmsmensajes.sys_tipmsj_syam,
                                          Sys_coduse_usux = sysadmsmensajes.sys_coduse_usux,
                                          Sys_codusu_usux = sysadmsmensajes.sys_codusu_usux,
                                          Sys_codtip_sytm = sysadmsmensajes.sys_codtip_sytm,
                                          Sys_codmsg_symg = sysadmsmensajes.sys_codmsg_symg,
                                          Sys_codper_perf = sysadmsmensajes.sys_codper_perf,
                                          Sys_sisfec_syam = (DateTime)sysadmsmensajes.sys_sisfec_syam,
                                          Sys_sishor_syam = (Decimal)sysadmsmensajes.sys_sishor_syam,
                                          Sys_vinfec_syam = (DateTime)sysadmsmensajes.sys_vinfec_syam,
                                          Sys_vinhor_syam = (Decimal)sysadmsmensajes.sys_vinhor_syam,
                                          Sys_vfnfec_syam = (DateTime)sysadmsmensajes.sys_vfnfec_syam,
                                          Sys_vfnhor_syam = (Decimal)sysadmsmensajes.sys_vfnhor_syam,
                                          Sys_vfrfec_syam = (DateTime)sysadmsmensajes.sys_vfrfec_syam,
                                          Sys_vfrhor_syam = (Decimal)sysadmsmensajes.sys_vfrhor_syam,
                                          Sys_msjvis_syam = sysadmsmensajes.sys_msjvis_syam,
                                          Sys_desmsj_sytm = sytm.sys_desmsj_sytm,
                                          Grc_iderec_grcm = sytm.grc_iderec_grcm,
                                          Sys_desmsg_symg = symg.sys_desmsg_symg,
                                          GestionLlaveBusqueda = String.Empty,
                                          GestionEstadoRegistro = "XX"
                                      };
                    #endregion
                    lobReturn = lobConsulta != null ? lobConsulta.Take(300).ToList() : null;
                }
                else
                {
                    #region Consulta
                    var lobConsulta = from sysadmsmensajes in _context.Sysadmsmensajes
                                      join sysadmstipomens in _context.Sysadmstipomens on sysadmsmensajes.sys_codtip_sytm equals sysadmstipomens.sys_codtip_sytm into tmsysadmstipomens
                                      join sysadmgrupomens in _context.Sysadmgrupomens on sysadmsmensajes.sys_codmsg_symg equals sysadmgrupomens.sys_codmsg_symg into tmsysadmgrupomens
                                      from sytm in tmsysadmstipomens.DefaultIfEmpty()
                                      from symg in tmsysadmgrupomens.DefaultIfEmpty()
                                      where sysadmsmensajes.sys_codusu_usux == tcrIdUsuario &&
                                            sysadmsmensajes.sys_codtip_sytm == tcrIdNotificaciones
                                      orderby sysadmsmensajes.sys_llavis_syam descending
                                      select new SysModeloAdminMensajes
                                      {
                                          Sys_codsec_syam = sysadmsmensajes.sys_codsec_syam,
                                          Sys_llavis_syam = (int)sysadmsmensajes.sys_llavis_syam,
                                          Sys_parent_syam = sysadmsmensajes.sys_parent_syam,
                                          Sys_desmsj_syam = sysadmsmensajes.sys_desmsj_syam,
                                          Sys_notmsj_syam = sysadmsmensajes.sys_notmsj_syam,
                                          Sys_regeve_sytm = sysadmsmensajes.sys_regeve_sytm,
                                          Sys_tipmsj_syam = sysadmsmensajes.sys_tipmsj_syam,
                                          Sys_coduse_usux = sysadmsmensajes.sys_coduse_usux,
                                          Sys_codusu_usux = sysadmsmensajes.sys_codusu_usux,
                                          Sys_codtip_sytm = sysadmsmensajes.sys_codtip_sytm,
                                          Sys_codmsg_symg = sysadmsmensajes.sys_codmsg_symg,
                                          Sys_codper_perf = sysadmsmensajes.sys_codper_perf,
                                          Sys_sisfec_syam = (DateTime)sysadmsmensajes.sys_sisfec_syam,
                                          Sys_sishor_syam = (Decimal)sysadmsmensajes.sys_sishor_syam,
                                          Sys_vinfec_syam = (DateTime)sysadmsmensajes.sys_vinfec_syam,
                                          Sys_vinhor_syam = (Decimal)sysadmsmensajes.sys_vinhor_syam,
                                          Sys_vfnfec_syam = (DateTime)sysadmsmensajes.sys_vfnfec_syam,
                                          Sys_vfnhor_syam = (Decimal)sysadmsmensajes.sys_vfnhor_syam,
                                          Sys_vfrfec_syam = (DateTime)sysadmsmensajes.sys_vfrfec_syam,
                                          Sys_vfrhor_syam = (Decimal)sysadmsmensajes.sys_vfrhor_syam,
                                          Sys_msjvis_syam = sysadmsmensajes.sys_msjvis_syam,
                                          Sys_desmsj_sytm = sytm.sys_desmsj_sytm,
                                          Grc_iderec_grcm = sytm.grc_iderec_grcm,
                                          Sys_desmsg_symg = symg.sys_desmsg_symg,
                                          GestionLlaveBusqueda = String.Empty,
                                          GestionEstadoRegistro = "XX"
                                      };
                    #endregion
                    lobReturn = lobConsulta != null ? lobConsulta.Take(300).ToList() : null;
                }

                return lobReturn;
            }
        }
        #endregion
        #region Verificacion de mensajes activos para un grupo o modulo
        /// <summary>
        /// Filtro para contar mensajes por grupo o modulo 
        /// </summary>
        public static int fnuContadorMensajesGrupo(String tcrModulo)
        {
            int lnuTotal = 0;
            using (_context = new DbAplicacion())
            {
                lnuTotal = (from tmp in _context.Sysadmsmensajes
                                   where tmp.sys_codmsg_symg == tcrModulo && 
                                         tmp.sys_msjvis_syam == "1"
                                   select tmp).Count();                           
            }
            return lnuTotal;
        }
        #endregion
        #region flstMensajesPorGruposYPerfil: Generar lista de mensajes activos para los grupos o modulos
        /// <summary>
        /// <para>Filtro para generar lista mensajes por modulos  y perfil del usuario activo</para>
        /// <para>Genera un resumen totalizado por cada notificacion usuario y modulo</para>
        /// 
        /// </summary>
        public static List<SysAdmGrupoNotifi> flstMensajesPorGruposYPerfil(String tcrPerfil, String tcrIdUsuario, String tcrModulo)
        {
            List<SysAdmGrupoNotifi> tmpList = null;

            var lcrFiltro = String.IsNullOrWhiteSpace(tcrModulo) ? "" : "sysadmsmensajes.sys_codmsg_symg = '" + tcrModulo + "' AND ";

            // Rango de fechas
            var lcrFechaIni = Funciones.fcrConvertFecha(Funciones.FdaFechaActual().AddDays(-15));
            lcrFechaIni     = Funciones.fcrFechaTextoCambiarFormato("DMY", "/", lcrFechaIni, "YMD", "-");
            var lcrFechaFin = Funciones.fcrFechaTextoCambiarFormato("DMY","/",Funciones.fcrFechaActual(),"YMD","-");
            lcrFiltro = lcrFiltro + "sysadmsmensajes.sys_sisfec_syam >= '" + lcrFechaIni + "' AND sysadmsmensajes.sys_sisfec_syam <= '" + lcrFechaFin + "' AND ";


            #region Linea SQl para ejecutar
            var lcrLineaSqlSelct = "SELECT sysadmsmensajes.sys_codmsg_symg," +
                                           "sysadmgrupomens.sys_desmsg_symg," +
                                           "sysadmsmensajes.sys_codtip_sytm," +
                                           "sysadmstipomens.sys_desmsj_sytm," +
                                           "sysadmsmensajes.sys_codper_perf," +
                                           "sysadmsmensajes.sys_codusu_usux," +
                                           "sysadmsmensajes.sys_tipmsj_syam," +
                                           "sysadmsmensajes.sys_llavis_syam," +
                                           "COUNT(sysadmsmensajes.sys_codtip_sytm) AS sys_totuni_symg " +
                                    "FROM sysadmsmensajes " +
                                         "INNER JOIN sysadmstipomens ON (sysadmsmensajes.sys_codtip_sytm = sysadmstipomens.sys_codtip_sytm) " +
                                         "INNER JOIN sysadmgrupomens ON (sysadmsmensajes.sys_codmsg_symg = sysadmgrupomens.sys_codmsg_symg) " +
                                    "WHERE "+ lcrFiltro +
                                           "sysadmsmensajes.sys_codper_perf = '" + tcrPerfil + "' AND " +
                                           "sysadmsmensajes.sys_msjvis_syam = '1' " +
                                       "GROUP BY sysadmsmensajes.sys_codtip_sytm," +
                                                "sysadmsmensajes.sys_tipmsj_syam," +
                                                "sysadmsmensajes.sys_codusu_usux " +
                                       "ORDER BY sysadmsmensajes.sys_llavis_syam DESC LIMIT 300"; 
            #endregion
            var tmpConsulta = Funciones.fobConsultaSqlDataAdapter(lcrLineaSqlSelct);
            if (tmpConsulta != null)
            {
                tmpList = new List<SysAdmGrupoNotifi>();
                var lobRegEx = new SysAdmGrupoNotifi();
                var lobRegAux = new SysAdmGrupoNotifi();
                // Generar resumen 
                foreach (DataRow lobReg in tmpConsulta.Rows)
                {
                    var lcrIdGrupo              = lobReg["sys_codmsg_symg"].ToString().Trim();
                    var lcrNombreGrupo          = lobReg["sys_desmsg_symg"].ToString().Trim();
                    var lcrIdNotificacion       = lobReg["sys_codtip_sytm"].ToString().Trim();
                    var lcrNombreNotificacion   = lobReg["sys_desmsj_sytm"].ToString().Trim();
                    var lcrIdPerfil             = lobReg["sys_codper_perf"].ToString().Trim();
                    var lcrIdUsuario            = lobReg["sys_codusu_usux"].ToString().Trim();
                    var lcrTipoNotifiPublico    = lobReg["sys_tipmsj_syam"].ToString().Trim();
                    var lnuLlaveFechaHora       = Convert.ToInt64(lobReg["sys_llavis_syam"].ToString());
                    var lnuContador             = Convert.ToInt32(lobReg["sys_totuni_symg"].ToString());
                    var lcrOnairisMensaje       = lobReg["sys_desmsj_sytm"].ToString().Trim();

                    if (lcrTipoNotifiPublico != "3" || (lcrTipoNotifiPublico == "3" && lcrIdUsuario == tcrIdUsuario))
                    {
                        lobRegEx = tmpList.FirstOrDefault(x => x.IdNotificacion == lcrIdNotificacion && x.IdGrupo == lcrIdGrupo);
                        if (lobRegEx == null)
                        {

                            lobRegAux = new SysAdmGrupoNotifi();

                            lobRegAux.IdGrupo            = lcrIdGrupo;
                            lobRegAux.NombreGrupo        = lcrNombreGrupo;
                            lobRegAux.IdNotificacion     = lcrIdNotificacion;
                            lobRegAux.NombreNotificacion = lcrNombreNotificacion;
                            lobRegAux.IdPerfil           = lcrIdPerfil;
                            lobRegAux.IdUsuario          = lcrIdUsuario;
                            lobRegAux.TipoNotifiPublico  = lcrTipoNotifiPublico;
                            lobRegAux.LlaveFechaHora     = lnuLlaveFechaHora;
                            lobRegAux.Contador           = lnuContador;
                            lobRegAux.OnairisMensaje     = lcrOnairisMensaje;

                            tmpList.Add(lobRegAux);
                        }
                        else
                        {
                            lobRegEx.LlaveFechaHora = lnuLlaveFechaHora > lobRegEx.LlaveFechaHora ? lnuLlaveFechaHora : lobRegEx.LlaveFechaHora;
                            lobRegEx.Contador += lnuContador;
                        }
                    }
                }
            }
            return tmpList;
        }
        #endregion
        #region flstMensajesPorGruposYPerfilXX: Generar lista de mensajes activos para los grupos o modulos
        /// <summary>
        /// <para>Filtro para generar lista mensajes por modulos  y perfil del usuario activo</para>
        /// <para>Genera un resumen totalizado por cada notificacion usuario y modulo</para>
        /// 
        /// </summary>
        public static List<SysAdmGrupoNotifi> flstMensajesPorGruposYPerfilXX(String tcrPerfil, String tcrIdUsuario, String tcrModulo)
        {
            List<SysAdmGrupoNotifi> tmpList = null;
            List<SysAdmGrupoNotifi> tmpConsulta = null;

            using (_context = new DbAplicacion())
            {
                if (!String.IsNullOrWhiteSpace(tcrModulo))
                {
                    #region Generar
                    tmpConsulta = (from tmp in _context.Sysadmsmensajes
                                   join sysadmstipomens in _context.Sysadmstipomens on tmp.sys_codtip_sytm equals sysadmstipomens.sys_codtip_sytm into tmsysadmstipomens
                                   join sysadmgrupomens in _context.Sysadmgrupomens on tmp.sys_codmsg_symg equals sysadmgrupomens.sys_codmsg_symg into tmsysadmgrupomens
                                   from sytm in tmsysadmstipomens.DefaultIfEmpty()
                                   from symg in tmsysadmgrupomens.DefaultIfEmpty()
                                   where tmp.sys_codmsg_symg == tcrModulo &&
                                         tmp.sys_codper_perf == tcrPerfil &&
                                         tmp.sys_msjvis_syam == "1"
                                   orderby tmp.sys_llavis_syam descending
                                   select new SysAdmGrupoNotifi
                                  {
                                      IdGrupo               = tmp.sys_codmsg_symg,
                                      NombreGrupo           = symg.sys_desmsg_symg,
                                      IdNotificacion        = tmp.sys_codtip_sytm,
                                      NombreNotificacion    = sytm.sys_desmsj_sytm,
                                      IdPerfil              = tmp.sys_codper_perf,
                                      IdUsuario             = tmp.sys_codusu_usux,
                                      TipoNotifiPublico     = tmp.sys_tipmsj_syam,
                                      LlaveFechaHora        = (int)tmp.sys_llavis_syam,
                                      Contador              = 1,
                                      OnairisMensaje        = sytm.sys_desmsj_sytm,
                                  }).ToList();
                    #endregion
                }
                else
                {
                    #region Generar
                    tmpConsulta = (from tmp in _context.Sysadmsmensajes
                                   join sysadmstipomens in _context.Sysadmstipomens on tmp.sys_codtip_sytm equals sysadmstipomens.sys_codtip_sytm into tmsysadmstipomens
                                   join sysadmgrupomens in _context.Sysadmgrupomens on tmp.sys_codmsg_symg equals sysadmgrupomens.sys_codmsg_symg into tmsysadmgrupomens
                                   from sytm in tmsysadmstipomens.DefaultIfEmpty()
                                   from symg in tmsysadmgrupomens.DefaultIfEmpty()
                                   where tmp.sys_codper_perf == tcrPerfil &&
                                         tmp.sys_msjvis_syam == "1"
                                   orderby tmp.sys_llavis_syam descending
                                   select new SysAdmGrupoNotifi
                                   {
                                       IdGrupo              = tmp.sys_codmsg_symg,
                                       NombreGrupo          = symg.sys_desmsg_symg,
                                       IdNotificacion       = tmp.sys_codtip_sytm,
                                       NombreNotificacion   = sytm.sys_desmsj_sytm,
                                       IdPerfil             = tmp.sys_codper_perf,
                                       IdUsuario            = tmp.sys_codusu_usux,
                                       TipoNotifiPublico    = tmp.sys_tipmsj_syam,
                                       LlaveFechaHora       = (int)tmp.sys_llavis_syam,
                                       Contador             = 1,
                                       OnairisMensaje       = sytm.sys_desmsj_sytm,
                                   }).ToList();
                    #endregion
                }
            }
            if (tmpConsulta != null)
            {
                tmpList = new List<SysAdmGrupoNotifi>();
                var lobRegEx = new SysAdmGrupoNotifi();
                var lobRegAux= new SysAdmGrupoNotifi();
                // Generar resumen 
                foreach (var lobReg in tmpConsulta)
                {
                    if (lobReg.TipoNotifiPublico!="3" || (lobReg.TipoNotifiPublico == "3"  && lobReg.IdUsuario == tcrIdUsuario))
                    {
                        lobRegEx = tmpList.FirstOrDefault(x => x.IdNotificacion == lobReg.IdNotificacion && x.IdGrupo == lobReg.IdGrupo);
                        if (lobRegEx == null)
                        {
                            lobRegAux = new SysAdmGrupoNotifi();

                            lobRegAux.IdGrupo            = lobReg.IdGrupo;
                            lobRegAux.NombreGrupo        = lobReg.NombreGrupo;
                            lobRegAux.IdNotificacion     = lobReg.IdNotificacion;
                            lobRegAux.NombreNotificacion = lobReg.NombreNotificacion;
                            lobRegAux.IdPerfil           = lobReg.IdPerfil;
                            lobRegAux.IdUsuario          = lobReg.IdUsuario;
                            lobRegAux.TipoNotifiPublico  = lobReg.TipoNotifiPublico;
                            lobRegAux.LlaveFechaHora     = lobReg.LlaveFechaHora;
                            lobRegAux.Contador           = 1;
                            lobRegAux.OnairisMensaje     = lobReg.OnairisMensaje;

                            tmpList.Add(lobRegAux);
                        }
                        else 
                        {
                            lobRegEx.LlaveFechaHora = lobReg.LlaveFechaHora > lobRegEx.LlaveFechaHora ? lobReg.LlaveFechaHora : lobRegEx.LlaveFechaHora;
                            lobRegEx.Contador++;
                        }
                    }
                }
            }
            return tmpList;
        }
        #endregion
        #endregion
    }
    /// <summary>
    /// tabla: sysadmnotigrupo notificaciones por grupo o modulo
    /// </summary>
    public class SysModeloNotifiPorGrupo : clBaseInpc
    {
        #region Modelo Attributos
        private static DbAplicacion _context;
        #region Modelo Propiedades Notificacion
        #region Sys_codreg_syng: Codigo registro
        private String _sys_codreg_syng;
        /// <summary>
        /// <para>TABLA: sysadmnotigrupo</para>
        /// <para>TABLA NATIVA: sysadmnotigrupo</para>
        /// <para>CAMPO: Codigo registro</para>
        /// <para>NOMBRE: sys_codreg_syng (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        ///Código único registro
        /// </para>
        /// </summary>
        public String Sys_codreg_syng
        {
            get { return _sys_codreg_syng; }
            set
            {
                if (_sys_codreg_syng == value) return;
                _sys_codreg_syng = value;
                OnPropertyChanged("Sys_codreg_syng");
            }
        }
        #endregion
        #region Sys_codper_perf: Perfil usuario recibe
        private String _sys_codper_perf;
        /// <summary>
        /// <para>TABLA: sysadmnotigrupo</para>
        /// <para>TABLA NATIVA: sysperfiusuario</para>
        /// <para>CAMPO: Perfil usuario recibe</para>
        /// <para>NOMBRE: sys_codper_perf (char:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Código perfil de usuarios que reciben  el mensaje
        /// </para>
        /// </summary>
        public String Sys_codper_perf
        {
            get { return _sys_codper_perf; }
            set
            {
                if (_sys_codper_perf == value) return;
                _sys_codper_perf = value;
                OnPropertyChanged("Sys_codper_perf");
            }
        }
        #endregion
        #region Sys_gruvis_syvg: Grupo vistas
        private String _sys_gruvis_syvg;
        /// <summary>
        /// <para>TABLA: sysadmnotigrupo</para>
        /// <para>TABLA NATIVA: </para>
        /// <para>CAMPO: Grupo vistas</para>
        /// <para>NOMBRE: sys_gruvis_syvg (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Grupo vista notificaciones para un formulario  ejemplo: FCM-FACT
        /// = Vista notificaciones en vista facturación
        /// </para>
        /// </summary>
        public String Sys_gruvis_syvg
        {
            get { return _sys_gruvis_syvg; }
            set
            {
                if (_sys_gruvis_syvg == value) return;
                _sys_gruvis_syvg = value;
                OnPropertyChanged("Sys_gruvis_syvg");
            }
        }
        #endregion
        #region Sys_titulo_syng: Titulo Botones
        private String _sys_titulo_syng;
        /// <summary>
        /// <para>TABLA: sysadmnotigrupo</para>
        /// <para>TABLA NATIVA: sysadmnotigrupo</para>
        /// <para>CAMPO: Titulo Botones</para>
        /// <para>NOMBRE: sys_titulo_syng (char:35)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        ///Titulo para el Boton en vista notificaciones
        /// </para>
        /// </summary>
        public String Sys_titulo_syng
        {
            get { return _sys_titulo_syng; }
            set
            {
                if (_sys_titulo_syng == value) return;
                _sys_titulo_syng = value;
                OnPropertyChanged("Sys_titulo_syng");
            }
        }
        #endregion
        #region Sys_codmsg_symg: Codigo grupo
        private String _sys_codmsg_symg;
        /// <summary>
        /// <para>TABLA: sysadmnotigrupo</para>
        /// <para>TABLA NATIVA: sysadmgrupomens</para>
        /// <para>CAMPO: Codigo grupo</para>
        /// <para>NOMBRE: sys_codmsg_symg (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Grupos de mensajes o modulos:  MSG = Mensajes general SYS:
        /// = Grupos mensajes de sistema ADM:= Mensajes modulo admisión
        /// </para>
        /// </summary>
        public String Sys_codmsg_symg
        {
            get { return _sys_codmsg_symg; }
            set
            {
                if (_sys_codmsg_symg == value) return;
                _sys_codmsg_symg = value;
                OnPropertyChanged("Sys_codmsg_symg");
            }
        }
        #endregion
        #region Sys_codtip_sytm: Tipo de mensajes
        private String _sys_codtip_sytm;
        /// <summary>
        /// <para>TABLA: sysadmnotigrupo</para>
        /// <para>TABLA NATIVA: sysadmstipomens</para>
        /// <para>CAMPO: Tipo de mensajes</para>
        /// <para>NOMBRE: sys_codtip_sytm (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        ///Código tipos de mensajes ejemplo: ADM001 = Registro de admisión generado para un paciente y otros
        /// </para>
        /// 
        /// </summary>
        public String Sys_codtip_sytm
        {
            get { return _sys_codtip_sytm; }
            set
            {
                if (_sys_codtip_sytm == value) return;
                _sys_codtip_sytm = value;
                OnPropertyChanged("Sys_codtip_sytm");
            }
        }
        #endregion
        #region Sys_estreg_syng: Estado Registro
        private String _sys_estreg_syng;
        /// <summary>
        /// <para>TABLA: sysadmnotigrupo</para>
        /// <para>TABLA NATIVA: sysadmnotigrupo</para>
        /// <para>CAMPO: Estado Registro</para>
        /// <para>NOMBRE: sys_estreg_syng (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        ///Estado del registro
        /// </para>
        /// </summary>
        public String Sys_estreg_syng
        {
            get { return _sys_estreg_syng; }
            set
            {
                if (_sys_estreg_syng == value) return;
                _sys_estreg_syng = value;
                OnPropertyChanged("Sys_estreg_syng");
            }
        }
        #endregion
        #region Sys_desmsg_symg: Descripción grupo
        private String _sys_desmsg_symg;
        /// <summary>
        /// <para>TABLA: sysadmnotigrupo</para>
        /// <para>TABLA NATIVA: sysadmgrupomens</para>
        /// <para>CAMPO: Descripción grupo</para>
        /// <para>NOMBRE: sys_desmsg_symg (char:80)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripción grupos de mensajes
        /// </para>
        /// </summary>
        public String Sys_desmsg_symg
        {
            get { return _sys_desmsg_symg; }
            set
            {
                if (_sys_desmsg_symg == value) return;
                _sys_desmsg_symg = value;
                OnPropertyChanged("Sys_desmsg_symg");
            }
        }
        #endregion
        #region Sys_desmsj_sytm: Descripción tipo
        private String _sys_desmsj_sytm;
        /// <summary>
        /// <para>TABLA: sysadmnotigrupo</para>
        /// <para>TABLA NATIVA: sysadmstipomens</para>
        /// <para>CAMPO: Descripción tipo</para>
        /// <para>NOMBRE: sys_desmsj_sytm (char:80)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Descripción del tipo notificación enviada según el evento ocurrido
        /// que debe ser notificado
        /// </para>
        /// </summary>
        public String Sys_desmsj_sytm
        {
            get { return _sys_desmsj_sytm; }
            set
            {
                if (_sys_desmsj_sytm == value) return;
                _sys_desmsj_sytm = value;
                OnPropertyChanged("Sys_desmsj_sytm");
            }
        }
        #endregion
        #region Grc_iderec_grcm: Código único recurso
        private String _grc_iderec_grcm;
        /// <summary>
        /// <para>TABLA: temporal</para>
        /// <para>TABLA NATIVA: </para>
        /// <para>CAMPO: Código único recurso</para>
        /// <para>NOMBRE: grc_iderec_grcm (char:50)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
        /// <para>DESCRIPCION:
        /// Código único del recurso de imagen que representa el evento
        /// (viene de galería de recursos)
        /// </para>
        /// </summary>
        public String Grc_iderec_grcm
        {
            get { return _grc_iderec_grcm; }
            set
            {
                if (_grc_iderec_grcm == value) return;
                _grc_iderec_grcm = value;
                OnPropertyChanged("Grc_iderec_grcm");
            }
        }
        #endregion
        #endregion
        #endregion
        #region Metodos para edicion de registros
        #region Adicionar Registro
        public static string flgAddRegistro(SysModeloNotifiPorGrupo tobjModelo)
        {
            var lcrCodigoGen = string.Empty;
            try
            {
                using (_context = new DbAplicacion())
                {
                    var lobjRegistro = new EFsysadmnotigrupo
                    {
                        #region cargar Registro
                        sys_codreg_syng = tobjModelo.Sys_codreg_syng,
                        sys_codper_perf = tobjModelo.Sys_codper_perf,
                        sys_gruvis_syvg = tobjModelo.Sys_gruvis_syvg,
                        sys_titulo_syng = tobjModelo.Sys_titulo_syng,
                        sys_codmsg_symg = tobjModelo.Sys_codmsg_symg,
                        sys_codtip_sytm = tobjModelo.Sys_codtip_sytm,
                        sys_estreg_syng = tobjModelo.Sys_estreg_syng,
                        #endregion
                    };
                    lcrCodigoGen = lobjRegistro.sys_codreg_syng;
                    _context.AddToSysadmnotigrupo(lobjRegistro);
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
        public static void fcvActualizar(SysModeloNotifiPorGrupo tobjModelo)
        {
            try
            {
                using (_context = new DbAplicacion())
                {
                    var lobjRegistro = _context.Sysadmnotigrupo.FirstOrDefault(p => p.sys_codreg_syng == tobjModelo.Sys_codreg_syng);
                    if (lobjRegistro != null)
                    {
                        lobjRegistro.sys_codreg_syng = tobjModelo.Sys_codreg_syng;
                        lobjRegistro.sys_codper_perf = tobjModelo.Sys_codper_perf;
                        lobjRegistro.sys_gruvis_syvg = tobjModelo.Sys_gruvis_syvg;
                        lobjRegistro.sys_titulo_syng = tobjModelo.Sys_titulo_syng;
                        lobjRegistro.sys_codmsg_symg = tobjModelo.Sys_codmsg_symg;
                        lobjRegistro.sys_codtip_sytm = tobjModelo.Sys_codtip_sytm;
                        lobjRegistro.sys_estreg_syng = tobjModelo.Sys_estreg_syng;
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
                    var lobjRegistro = _context.Sysadmnotigrupo.FirstOrDefault(p => p.sys_codreg_syng == tcrCodigo);
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
        #region flsListaSysadmnotigrupo: Listar Registros por IG de la tabla
        /// <summary>
        /// Seleccionar registro por IG de la tabla (sys_codreg_syng)
        /// </summary>
        public static List<SysModeloNotifiPorGrupo> flsListaSysadmnotigrupo(string tcrBuscar)
        {
            using (_context = new DbAplicacion())
            {
                var lobConsulta = from sysadmnotigrupo in _context.Sysadmnotigrupo
                                  join sysadmgrupomens in _context.Sysadmgrupomens on sysadmnotigrupo.sys_codmsg_symg equals sysadmgrupomens.sys_codmsg_symg into tmsysadmgrupomens
                                  join sysadmstipomens in _context.Sysadmstipomens on sysadmnotigrupo.sys_codtip_sytm equals sysadmstipomens.sys_codtip_sytm into tmsysadmstipomens
                                  from symg in tmsysadmgrupomens.DefaultIfEmpty()
                                  from sytm in tmsysadmstipomens.DefaultIfEmpty()
                                  where sysadmnotigrupo.sys_codreg_syng == tcrBuscar
                                  select new SysModeloNotifiPorGrupo
                                  {
                                      Sys_codreg_syng = sysadmnotigrupo.sys_codreg_syng,
                                      Sys_gruvis_syvg = sysadmnotigrupo.sys_gruvis_syvg,
                                      Sys_titulo_syng = sysadmnotigrupo.sys_titulo_syng,
                                      Sys_codmsg_symg = sysadmnotigrupo.sys_codmsg_symg,
                                      Sys_codtip_sytm = sysadmnotigrupo.sys_codtip_sytm,
                                      Sys_estreg_syng = sysadmnotigrupo.sys_estreg_syng,
                                      Sys_desmsg_symg = symg.sys_desmsg_symg,
                                      Sys_desmsj_sytm = sytm.sys_desmsj_sytm,
                                      Grc_iderec_grcm = sytm.grc_iderec_grcm,
                                  };
                return lobConsulta.ToList();
            }
        }
        #endregion
        #region flsListaSysadmnotigrupoEx: Listar Registros por Vista notificaciones por Vista
        /// <summary>
        /// Seleccionar tipos de notificaciones para una vista 
        /// </summary>
        public static List<SysModeloNotifiPorGrupo> flsListaSysadmnotigrupoEx(String tcrIdPerfil, String tcrIdVista)
        {
            using (_context = new DbAplicacion())
            {
                var lobConsulta = from sysadmnotigrupo in _context.Sysadmnotigrupo
                                  join sysadmgrupomens in _context.Sysadmgrupomens on sysadmnotigrupo.sys_codmsg_symg equals sysadmgrupomens.sys_codmsg_symg into tmsysadmgrupomens
                                  join sysadmstipomens in _context.Sysadmstipomens on sysadmnotigrupo.sys_codtip_sytm equals sysadmstipomens.sys_codtip_sytm into tmsysadmstipomens
                                  from symg in tmsysadmgrupomens.DefaultIfEmpty()
                                  from sytm in tmsysadmstipomens.DefaultIfEmpty()
                                  where sysadmnotigrupo.sys_gruvis_syvg == tcrIdVista &&
                                        sysadmnotigrupo.sys_codper_perf == tcrIdPerfil
                                  select new SysModeloNotifiPorGrupo
                                  {
                                      Sys_codreg_syng = sysadmnotigrupo.sys_codreg_syng,
                                      Sys_codper_perf = sysadmnotigrupo.sys_codper_perf,
                                      Sys_gruvis_syvg = sysadmnotigrupo.sys_gruvis_syvg,
                                      Sys_titulo_syng = sysadmnotigrupo.sys_titulo_syng,
                                      Sys_codmsg_symg = sysadmnotigrupo.sys_codmsg_symg,
                                      Sys_codtip_sytm = sysadmnotigrupo.sys_codtip_sytm,
                                      Sys_estreg_syng = sysadmnotigrupo.sys_estreg_syng,
                                      Sys_desmsg_symg = symg.sys_desmsg_symg,
                                      Sys_desmsj_sytm = sytm.sys_desmsj_sytm,
                                      Grc_iderec_grcm = sytm.grc_iderec_grcm,
                                  };
                return lobConsulta.ToList();
            }
        }
        #endregion
        #region flsListaSysadmNotiGrupoPerfilModulo: Listar Registros para tipo notificacion dada a generar por Modulo
        /// <summary>
        /// Generar lista registros notificacion (segun parametro tcrIdNotificacion) dada para generar notifiaciones por Modulo y perfil 
        /// </summary>
        public static List<SysModeloNotifiPorGrupo> flsListaSysadmNotiGrupoPerfilModulo(String tcrIdNotificacion ,String tcrEstado)
        {
            List<SysModeloNotifiPorGrupo> tmpList = null;
            List<SysModeloNotifiPorGrupo> tmpConsulta = null;
            using (_context = new DbAplicacion())
            {
                tmpConsulta = (from sysadmnotigrupo in _context.Sysadmnotigrupo
                                  join sysadmgrupomens in _context.Sysadmgrupomens on sysadmnotigrupo.sys_codmsg_symg equals sysadmgrupomens.sys_codmsg_symg into tmsysadmgrupomens
                                  join sysadmstipomens in _context.Sysadmstipomens on sysadmnotigrupo.sys_codtip_sytm equals sysadmstipomens.sys_codtip_sytm into tmsysadmstipomens
                                  from symg in tmsysadmgrupomens.DefaultIfEmpty()
                                  from sytm in tmsysadmstipomens.DefaultIfEmpty()
                               where sysadmnotigrupo.sys_codtip_sytm == tcrIdNotificacion && sysadmnotigrupo.sys_estreg_syng == tcrEstado
                                  select new SysModeloNotifiPorGrupo
                                  {
                                      Sys_codreg_syng = sysadmnotigrupo.sys_codreg_syng,
                                      Sys_codper_perf = sysadmnotigrupo.sys_codper_perf,
                                      Sys_gruvis_syvg = sysadmnotigrupo.sys_gruvis_syvg,
                                      Sys_titulo_syng = sysadmnotigrupo.sys_titulo_syng,
                                      Sys_codmsg_symg = sysadmnotigrupo.sys_codmsg_symg,
                                      Sys_codtip_sytm = sysadmnotigrupo.sys_codtip_sytm,
                                      Sys_estreg_syng = sysadmnotigrupo.sys_estreg_syng,
                                      Sys_desmsg_symg = symg.sys_desmsg_symg,
                                      Sys_desmsj_sytm = sytm.sys_desmsj_sytm,
                                      Grc_iderec_grcm = sytm.grc_iderec_grcm,
                                  }).ToList();
            }
            if (tmpConsulta != null)
            {
                tmpList = new List<SysModeloNotifiPorGrupo>();
                var lobRegEx = new SysModeloNotifiPorGrupo();
                var lobRegAux = new SysModeloNotifiPorGrupo();
                // Generar Notificacines por grupo y perfil 
                foreach (var lobReg in tmpConsulta)
                {
                    lobRegEx = tmpList.FirstOrDefault(x => x.Sys_codmsg_symg == lobReg.Sys_codmsg_symg && x.Sys_codper_perf == lobReg.Sys_codper_perf);
                    if (lobRegEx == null)
                    {
                        lobRegAux = new SysModeloNotifiPorGrupo();

                        lobRegAux.Sys_codper_perf = lobReg.Sys_codper_perf;
                        lobRegAux.Sys_gruvis_syvg = lobReg.Sys_gruvis_syvg;
                        lobRegAux.Sys_titulo_syng = lobReg.Sys_titulo_syng;
                        lobRegAux.Sys_codmsg_symg = lobReg.Sys_codmsg_symg;
                        lobRegAux.Sys_codtip_sytm = lobReg.Sys_codtip_sytm;
                        lobRegAux.Sys_estreg_syng = lobReg.Sys_estreg_syng;
                        lobRegAux.Sys_desmsg_symg = lobReg.Sys_desmsg_symg;
                        lobRegAux.Sys_desmsj_sytm = lobReg.Sys_desmsj_sytm;
                        lobRegAux.Grc_iderec_grcm = lobReg.Grc_iderec_grcm;

                        tmpList.Add(lobRegAux);
                    }
                }
            }
            return tmpList;
        }
        #endregion
        #endregion
    }
}
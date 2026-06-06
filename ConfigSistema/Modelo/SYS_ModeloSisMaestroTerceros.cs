//- MARMOTA-GENCODE: VERSION 2.0 - 04/10/2017 11:50:47 AM
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

namespace Systemas.Modelo
{
    /// <summary>
    /// Descripcion para la Vista de  la tabla: sismaesterceros
    /// </summary>
    public class ModeloSisMaestroTerceros : clBaseInpc
    {
        #region Modelo Attributos
        private static DbAplicacion _context;
        #region Modelo Propiedades Notificacion
        #region Sis_idterc_sitr: Codigo unico tercero
        private String _sis_idterc_sitr;
        /// <summary>
        /// <para>TABLA: sismaesterceros</para>
        /// <para>TABLA NATIVA: sismaesterceros</para>
        /// <para>CAMPO: Codigo unico tercero</para>
        /// <para>NOMBRE: sis_idterc_sitr (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        /// Codigo unico secuencial del tercero generado por el sistema
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
        #region Sis_tipide_tido: Tipo documento
        private String _sis_tipide_tido;
        /// <summary>
        /// <para>TABLA: sismaesterceros</para>
        /// <para>TABLA NATIVA: sistipidtercer</para>
        /// <para>CAMPO: Tipo documento</para>
        /// <para>NOMBRE: sis_tipide_tido (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Tipo identificacion de documento del tercero :1= Nit, 2= Cedula,
        /// 3=Cedula de Extranjería, 4= Tarjeta  de Identidad, 5=Pasaporte
        /// 6=Otros documento extranjero
        /// </para>
        /// </summary>
        public String Sis_tipide_tido
        {
            get { return _sis_tipide_tido; }
            set
            {
                if (_sis_tipide_tido == value) return;
                _sis_tipide_tido = value;
                OnPropertyChanged("Sis_tipide_tido");
            }
        }
        #endregion
        #region Sis_numide_sitr: Numero dcumento
        private String _sis_numide_sitr;
        /// <summary>
        /// <para>TABLA: sismaesterceros</para>
        /// <para>TABLA NATIVA: sismaesterceros</para>
        /// <para>CAMPO: Numero dcumento</para>
        /// <para>NOMBRE: sis_numide_sitr (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        ///Numero docuemto de identificacion del tercero
        /// </para>
        /// </summary>
        public String Sis_numide_sitr
        {
            get { return _sis_numide_sitr; }
            set
            {
                if (_sis_numide_sitr == value) return;
                _sis_numide_sitr = value;
                OnPropertyChanged("Sis_numide_sitr");
            }
        }
        #endregion
        #region Sis_lugexp_sitr: Lugar exped documento
        private String _sis_lugexp_sitr;
        /// <summary>
        /// <para>TABLA: sismaesterceros</para>
        /// <para>TABLA NATIVA: sismaesterceros</para>
        /// <para>CAMPO: Lugar exped documento</para>
        /// <para>NOMBRE: sis_lugexp_sitr (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        ///lugar de expedicion del documento de identidad
        /// </para>
        /// </summary>
        public String Sis_lugexp_sitr
        {
            get { return _sis_lugexp_sitr; }
            set
            {
                if (_sis_lugexp_sitr == value) return;
                _sis_lugexp_sitr = value;
                OnPropertyChanged("Sis_lugexp_sitr");
            }
        }
        #endregion
        #region Sis_priape_sitr: Primer apellido
        private String _sis_priape_sitr;
        /// <summary>
        /// <para>TABLA: sismaesterceros</para>
        /// <para>TABLA NATIVA: sismaesterceros</para>
        /// <para>CAMPO: Primer apellido</para>
        /// <para>NOMBRE: sis_priape_sitr (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        /// Primer apellido del tercero (cuando se trata de persona natural)
        /// </para>
        /// </summary>
        public String Sis_priape_sitr
        {
            get { return _sis_priape_sitr; }
            set
            {
                if (_sis_priape_sitr == value) return;
                _sis_priape_sitr = value;
                OnPropertyChanged("Sis_priape_sitr");
            }
        }
        #endregion
        #region Sis_segape_sitr: Segundo apellido
        private String _sis_segape_sitr;
        /// <summary>
        /// <para>TABLA: sismaesterceros</para>
        /// <para>TABLA NATIVA: sismaesterceros</para>
        /// <para>CAMPO: Segundo apellido</para>
        /// <para>NOMBRE: sis_segape_sitr (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        /// segundo apellido del tercero (cuando se trata de persona natural)
        /// </para>
        /// </summary>
        public String Sis_segape_sitr
        {
            get { return _sis_segape_sitr; }
            set
            {
                if (_sis_segape_sitr == value) return;
                _sis_segape_sitr = value;
                OnPropertyChanged("Sis_segape_sitr");
            }
        }
        #endregion
        #region Sis_prinom_sitr: Primer nombre
        private String _sis_prinom_sitr;
        /// <summary>
        /// <para>TABLA: sismaesterceros</para>
        /// <para>TABLA NATIVA: sismaesterceros</para>
        /// <para>CAMPO: Primer nombre</para>
        /// <para>NOMBRE: sis_prinom_sitr (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        /// Primer nombre del tercero (cuando se trata de persona natural)
        /// </para>
        /// </summary>
        public String Sis_prinom_sitr
        {
            get { return _sis_prinom_sitr; }
            set
            {
                if (_sis_prinom_sitr == value) return;
                _sis_prinom_sitr = value;
                OnPropertyChanged("Sis_prinom_sitr");
            }
        }
        #endregion
        #region Sis_segnom_sitr: Segundo nombre
        private String _sis_segnom_sitr;
        /// <summary>
        /// <para>TABLA: sismaesterceros</para>
        /// <para>TABLA NATIVA: sismaesterceros</para>
        /// <para>CAMPO: Segundo nombre</para>
        /// <para>NOMBRE: sis_segnom_sitr (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        /// Segundo nombre del tercero (cuando se trata de persona natural)
        /// </para>
        /// </summary>
        public String Sis_segnom_sitr
        {
            get { return _sis_segnom_sitr; }
            set
            {
                if (_sis_segnom_sitr == value) return;
                _sis_segnom_sitr = value;
                OnPropertyChanged("Sis_segnom_sitr");
            }
        }
        #endregion
        #region Sis_razsoc_sitr: Nombre / Razon social
        private String _sis_razsoc_sitr;
        /// <summary>
        /// <para>TABLA: sismaesterceros</para>
        /// <para>TABLA NATIVA: sismaesterceros</para>
        /// <para>CAMPO: Nombre / Razon social</para>
        /// <para>NOMBRE: sis_razsoc_sitr (char:50)</para>
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
        #region Sis_tipper_sitr: Tipo Persona
        private String _sis_tipper_sitr;
        /// <summary>
        /// <para>TABLA: sismaesterceros</para>
        /// <para>TABLA NATIVA: sismaesterceros</para>
        /// <para>CAMPO: Tipo Persona</para>
        /// <para>NOMBRE: sis_tipper_sitr (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
        /// <para>DESCRIPCION:
        ///Tipo persona 1=Juridica 2= Pesona natural
        /// </para>
        /// </summary>
        public String Sis_tipper_sitr
        {
            get { return _sis_tipper_sitr; }
            set
            {
                if (_sis_tipper_sitr == value) return;
                _sis_tipper_sitr = value;
                OnPropertyChanged("Sis_tipper_sitr");
            }
        }
        #endregion
        #region Sis_idemun_muni: Id Unico Municipio
        private String _sis_idemun_muni;
        /// <summary>
        /// <para>TABLA: sismaesterceros</para>
        /// <para>TABLA NATIVA: sistabmunicipio</para>
        /// <para>CAMPO: Id Unico Municipio</para>
        /// <para>NOMBRE: sis_idemun_muni (char:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 11</para>
        /// <para>DESCRIPCION:
        /// Id Unico Municipio: Cod.DANE.Departamento+Cod.DANE.Municipio
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
        #region Sis_codmun_muni: Codigo Municipio
        private String _sis_codmun_muni;
        /// <summary>
        /// <para>TABLA: sismaesterceros</para>
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
        #region Sis_coddep_dpto: Codigo Dpartamento
        private String _sis_coddep_dpto;
        /// <summary>
        /// <para>TABLA: sismaesterceros</para>
        /// <para>TABLA NATIVA: sistabdepartame</para>
        /// <para>CAMPO: Codigo Dpartamento</para>
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
        #region Sis_codact_sitr: Codigo actividad economica
        private String _sis_codact_sitr;
        /// <summary>
        /// <para>TABLA: sismaesterceros</para>
        /// <para>TABLA NATIVA: sismaesterceros</para>
        /// <para>CAMPO: Codigo actividad economica</para>
        /// <para>NOMBRE: sis_codact_sitr (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 14</para>
        /// <para>DESCRIPCION:
        ///Codigo CIU de la actividad econnomica
        /// </para>
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
        #region Sis_tipcnt_sitr: Regimen contribuyente
        private String _sis_tipcnt_sitr;
        /// <summary>
        /// <para>TABLA: sismaesterceros</para>
        /// <para>TABLA NATIVA: sismaesterceros</para>
        /// <para>CAMPO: Regimen contribuyente</para>
        /// <para>NOMBRE: sis_tipcnt_sitr (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 15</para>
        /// <para>DESCRIPCION:
        /// Tipo de regimen contribuyente para el manejo de retencion:
        /// 1=Regimen comun 2=Simplificado 3=Gran contribuyente 4 = Empresa
        /// del estado
        /// </para>
        /// </summary>
        public String Sis_tipcnt_sitr
        {
            get { return _sis_tipcnt_sitr; }
            set
            {
                if (_sis_tipcnt_sitr == value) return;
                _sis_tipcnt_sitr = value;
                OnPropertyChanged("Sis_tipcnt_sitr");
            }
        }
        #endregion
        #region Sis_relret_sitr: Ralizar retención
        private String _sis_relret_sitr;
        /// <summary>
        /// <para>TABLA: sismaesterceros</para>
        /// <para>TABLA NATIVA: sismaesterceros</para>
        /// <para>CAMPO: Ralizar retención</para>
        /// <para>NOMBRE: sis_relret_sitr (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 16</para>
        /// <para>DESCRIPCION:
        /// Realizacion de retencion 1= Realizar retencion 2= Es autoretenedor
        /// 3= No realizar
        /// </para>
        /// </summary>
        public String Sis_relret_sitr
        {
            get { return _sis_relret_sitr; }
            set
            {
                if (_sis_relret_sitr == value) return;
                _sis_relret_sitr = value;
                OnPropertyChanged("Sis_relret_sitr");
            }
        }
        #endregion
        #region Sis_tipter_tter: Tipo contribuyente
        private String _sis_tipter_tter;
        /// <summary>
        /// <para>TABLA: sismaesterceros</para>
        /// <para>TABLA NATIVA: </para>
        /// <para>CAMPO: Tipo contribuyente</para>
        /// <para>NOMBRE: sis_tipter_tter (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 17</para>
        /// <para>DESCRIPCION:
        /// Tipo de tercero : 1= Cliente 2=Proveedor 3=Empleado 4=contribuyente
        /// 5=Pensionados 6=Otros
        /// </para>
        /// </summary>
        public String Sis_tipter_tter
        {
            get { return _sis_tipter_tter; }
            set
            {
                if (_sis_tipter_tter == value) return;
                _sis_tipter_tter = value;
                OnPropertyChanged("Sis_tipter_tter");
            }
        }
        #endregion
        #region Sis_telefo_sitr: Telefono
        private String _sis_telefo_sitr;
        /// <summary>
        /// <para>TABLA: sismaesterceros</para>
        /// <para>TABLA NATIVA: sismaesterceros</para>
        /// <para>CAMPO: Telefono</para>
        /// <para>NOMBRE: sis_telefo_sitr (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 18</para>
        /// <para>DESCRIPCION:
        ///Numeros de Telefono del tecrcero
        /// </para>
        /// </summary>
        public String Sis_telefo_sitr
        {
            get { return _sis_telefo_sitr; }
            set
            {
                if (_sis_telefo_sitr == value) return;
                _sis_telefo_sitr = value;
                OnPropertyChanged("Sis_telefo_sitr");
            }
        }
        #endregion
        #region Sis_direcc_sitr: Direccion
        private String _sis_direcc_sitr;
        /// <summary>
        /// <para>TABLA: sismaesterceros</para>
        /// <para>TABLA NATIVA: sismaesterceros</para>
        /// <para>CAMPO: Direccion</para>
        /// <para>NOMBRE: sis_direcc_sitr (char:80)</para>
        /// <para>ORDEN VISTA EN TABLA: 19</para>
        /// <para>DESCRIPCION:
        ///Direccion domicilio del tercero
        /// </para>
        /// </summary>
        public String Sis_direcc_sitr
        {
            get { return _sis_direcc_sitr; }
            set
            {
                if (_sis_direcc_sitr == value) return;
                _sis_direcc_sitr = value;
                OnPropertyChanged("Sis_direcc_sitr");
            }
        }
        #endregion
        #region Sis_estreg_esrg: Estado
        private String _sis_estreg_esrg;
        /// <summary>
        /// <para>TABLA: sismaesterceros</para>
        /// <para>TABLA NATIVA: sisestadoregist</para>
        /// <para>CAMPO: Estado</para>
        /// <para>NOMBRE: sis_estreg_esrg (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 20</para>
        /// <para>DESCRIPCION:
        ///Estado del registro  1 =Activo 2=Inactivo
        /// </para>
        /// </summary>
        public String Sis_estreg_esrg
        {
            get { return _sis_estreg_esrg; }
            set
            {
                if (_sis_estreg_esrg == value) return;
                _sis_estreg_esrg = value;
                OnPropertyChanged("Sis_estreg_esrg");
            }
        }
        #endregion
        #region Sis_deside_tido: Descripción tipo Id
        private String _sis_deside_tido;
        /// <summary>
        /// <para>TABLA: sismaesterceros</para>
        /// <para>TABLA NATIVA: sistipidtercer</para>
        /// <para>CAMPO: Descripción tipo Id</para>
        /// <para>NOMBRE: sis_deside_tido (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripción Tipo identificacion tercero contable
        /// </para>
        /// </summary>
        public String Sis_deside_tido
        {
            get { return _sis_deside_tido; }
            set
            {
                if (_sis_deside_tido == value) return;
                _sis_deside_tido = value;
                OnPropertyChanged("Sis_deside_tido");
            }
        }
        #endregion
        #region Sis_nommun_muni: Nombre del Muncipio
        private String _sis_nommun_muni;
        /// <summary>
        /// <para>TABLA: sismaesterceros</para>
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
        /// <para>TABLA: sismaesterceros</para>
        /// <para>TABLA NATIVA: sistabdepartame</para>
        /// <para>CAMPO: Nombre del departamento</para>
        /// <para>NOMBRE: sis_desdep_dpto (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Nombre del departamento
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
        public static String flgAddRegistro(ModeloSisMaestroTerceros tobjModelo)
        {
            var lcrCodigoGen = SysModelo.fcrGenerarNuevoCodigo("SIS-MAESTRO-TERCEROS", "SIS", "Maestro Terceros");
            try
            {
                if (!flgBuscarSismaesterceros(lcrCodigoGen))
                {
                    using (_context = new DbAplicacion())
                    {
                        var lobjRegistro = new EFsismaesterceros
                        {
                            #region cargar Registro
                            sis_idterc_sitr = tobjModelo.Sis_idterc_sitr,
                            sis_tipide_tido = tobjModelo.Sis_tipide_tido,
                            sis_numide_sitr = tobjModelo.Sis_numide_sitr,
                            sis_lugexp_sitr = tobjModelo.Sis_lugexp_sitr,
                            sis_priape_sitr = tobjModelo.Sis_priape_sitr,
                            sis_segape_sitr = tobjModelo.Sis_segape_sitr,
                            sis_prinom_sitr = tobjModelo.Sis_prinom_sitr,
                            sis_segnom_sitr = tobjModelo.Sis_segnom_sitr,
                            sis_razsoc_sitr = tobjModelo.Sis_razsoc_sitr,
                            sis_tipper_sitr = tobjModelo.Sis_tipper_sitr,
                            sis_idemun_muni = tobjModelo.Sis_idemun_muni,
                            sis_codmun_muni = tobjModelo.Sis_codmun_muni,
                            sis_coddep_dpto = tobjModelo.Sis_coddep_dpto,
                            sis_codact_sitr = tobjModelo.Sis_codact_sitr,
                            sis_tipcnt_sitr = tobjModelo.Sis_tipcnt_sitr,
                            sis_relret_sitr = tobjModelo.Sis_relret_sitr,
                            sis_tipter_tter = tobjModelo.Sis_tipter_tter,
                            sis_telefo_sitr = tobjModelo.Sis_telefo_sitr,
                            sis_direcc_sitr = tobjModelo.Sis_direcc_sitr,
                            sis_estreg_esrg = tobjModelo.Sis_estreg_esrg,
                            #endregion
                        };
                        lobjRegistro.sis_idterc_sitr = lcrCodigoGen;
                        _context.AddToSismaesterceros(lobjRegistro);
                        _context.SaveChanges();
                    }
                }
                else
                {
                    lcrCodigoGen = String.Empty;
                    MessageBox.Show("Nuevo codigo Generado esta desactualizado, revisar llave: \n" +
                                "'SIS-MAESTRO-TERCEROS': Maestro Terceros en Maestro Secuenciales.");
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
        public static void fcvActualizar(ModeloSisMaestroTerceros tobjModelo)
        {
            try
            {
                using (_context = new DbAplicacion())
                {
                    var lobjRegistro = _context.Sismaesterceros.FirstOrDefault(p => p.sis_idterc_sitr == tobjModelo.Sis_idterc_sitr);
                    if (lobjRegistro != null)
                    {
                        #region cargar Registro
                        lobjRegistro.sis_idterc_sitr = tobjModelo.Sis_idterc_sitr;
                        lobjRegistro.sis_tipide_tido = tobjModelo.Sis_tipide_tido;
                        lobjRegistro.sis_numide_sitr = tobjModelo.Sis_numide_sitr;
                        lobjRegistro.sis_lugexp_sitr = tobjModelo.Sis_lugexp_sitr;
                        lobjRegistro.sis_priape_sitr = tobjModelo.Sis_priape_sitr;
                        lobjRegistro.sis_segape_sitr = tobjModelo.Sis_segape_sitr;
                        lobjRegistro.sis_prinom_sitr = tobjModelo.Sis_prinom_sitr;
                        lobjRegistro.sis_segnom_sitr = tobjModelo.Sis_segnom_sitr;
                        lobjRegistro.sis_razsoc_sitr = tobjModelo.Sis_razsoc_sitr;
                        lobjRegistro.sis_tipper_sitr = tobjModelo.Sis_tipper_sitr;
                        lobjRegistro.sis_idemun_muni = tobjModelo.Sis_idemun_muni;
                        lobjRegistro.sis_codmun_muni = tobjModelo.Sis_codmun_muni;
                        lobjRegistro.sis_coddep_dpto = tobjModelo.Sis_coddep_dpto;
                        lobjRegistro.sis_codact_sitr = tobjModelo.Sis_codact_sitr;
                        lobjRegistro.sis_tipcnt_sitr = tobjModelo.Sis_tipcnt_sitr;
                        lobjRegistro.sis_relret_sitr = tobjModelo.Sis_relret_sitr;
                        lobjRegistro.sis_tipter_tter = tobjModelo.Sis_tipter_tter;
                        lobjRegistro.sis_telefo_sitr = tobjModelo.Sis_telefo_sitr;
                        lobjRegistro.sis_direcc_sitr = tobjModelo.Sis_direcc_sitr;
                        lobjRegistro.sis_estreg_esrg = tobjModelo.Sis_estreg_esrg;
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
                    var lobjRegistro = _context.Sismaesterceros.FirstOrDefault(p => p.sis_idterc_sitr == tcrCodigo);
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
        #region Buscar SISMAESTERCEROS: Logica
        /// <summary>
        /// <para>TABLA: sismaesterceros</para>
        /// <para>TITULO: Tabla terceros para gestion contable</para>
        /// <para>MODULO: SIS</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Tabla terceros para gestion contable y referencias en otros
        /// modulos del sistema
        /// </para>
        /// </summary>
        public static bool flgBuscarSismaesterceros(String tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Sismaesterceros.FirstOrDefault(p => p.sis_idterc_sitr == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Listar Registros
        public static List<ModeloSisMaestroTerceros> flsListaSismaesterceros(String tcrBuscar)
        {
            using (_context = new DbAplicacion())
            {
                if (String.IsNullOrEmpty(tcrBuscar))
                {
                    var lobConsulta = from sismaesterceros in _context.Sismaesterceros
                                      join sistipidtercer in _context.Sistipidtercer on sismaesterceros.sis_tipide_tido equals sistipidtercer.sis_tipide_tido into tmsistipidtercer
                                      join sistabmunicipio in _context.Sistabmunicipio on sismaesterceros.sis_idemun_muni equals sistabmunicipio.sis_idemun_muni into tmsistabmunicipio
                                      join sistabdepartame in _context.Sistabdepartame on sismaesterceros.sis_coddep_dpto equals sistabdepartame.sis_coddep_dpto into tmsistabdepartame
                                      from tido in tmsistipidtercer.DefaultIfEmpty()
                                      from muni in tmsistabmunicipio.DefaultIfEmpty()
                                      from dpto in tmsistabdepartame.DefaultIfEmpty()
                                      select new ModeloSisMaestroTerceros
                                      {
                                          #region Datos
                                          Sis_idterc_sitr = sismaesterceros.sis_idterc_sitr,
                                          Sis_tipide_tido = sismaesterceros.sis_tipide_tido,
                                          Sis_numide_sitr = sismaesterceros.sis_numide_sitr,
                                          Sis_lugexp_sitr = sismaesterceros.sis_lugexp_sitr,
                                          Sis_priape_sitr = sismaesterceros.sis_priape_sitr,
                                          Sis_segape_sitr = sismaesterceros.sis_segape_sitr,
                                          Sis_prinom_sitr = sismaesterceros.sis_prinom_sitr,
                                          Sis_segnom_sitr = sismaesterceros.sis_segnom_sitr,
                                          Sis_razsoc_sitr = sismaesterceros.sis_razsoc_sitr,
                                          Sis_tipper_sitr = sismaesterceros.sis_tipper_sitr,
                                          Sis_idemun_muni = sismaesterceros.sis_idemun_muni,
                                          Sis_codmun_muni = sismaesterceros.sis_codmun_muni,
                                          Sis_coddep_dpto = sismaesterceros.sis_coddep_dpto,
                                          Sis_codact_sitr = sismaesterceros.sis_codact_sitr,
                                          Sis_tipcnt_sitr = sismaesterceros.sis_tipcnt_sitr,
                                          Sis_relret_sitr = sismaesterceros.sis_relret_sitr,
                                          Sis_tipter_tter = sismaesterceros.sis_tipter_tter,
                                          Sis_telefo_sitr = sismaesterceros.sis_telefo_sitr,
                                          Sis_direcc_sitr = sismaesterceros.sis_direcc_sitr,
                                          Sis_estreg_esrg = sismaesterceros.sis_estreg_esrg,
                                          Sis_deside_tido = tido.sis_deside_tido,
                                          Sis_nommun_muni = muni.sis_nommun_muni,
                                          Sis_desdep_dpto = dpto.sis_desdep_dpto,
                                          #endregion
                                      };
                    return lobConsulta.ToList();
                }
                else
                {
                    var lobConsulta = from sismaesterceros in _context.Sismaesterceros
                                      join sistipidtercer in _context.Sistipidtercer on sismaesterceros.sis_tipide_tido equals sistipidtercer.sis_tipide_tido into tmsistipidtercer
                                      join sistabmunicipio in _context.Sistabmunicipio on sismaesterceros.sis_idemun_muni equals sistabmunicipio.sis_idemun_muni into tmsistabmunicipio
                                      join sistabdepartame in _context.Sistabdepartame on sismaesterceros.sis_coddep_dpto equals sistabdepartame.sis_coddep_dpto into tmsistabdepartame
                                      from tido in tmsistipidtercer.DefaultIfEmpty()
                                      from muni in tmsistabmunicipio.DefaultIfEmpty()
                                      from dpto in tmsistabdepartame.DefaultIfEmpty()
                                      where sismaesterceros.sis_idterc_sitr == tcrBuscar
                                      select new ModeloSisMaestroTerceros
                                      {
                                          #region Datos
                                          Sis_idterc_sitr = sismaesterceros.sis_idterc_sitr,
                                          Sis_tipide_tido = sismaesterceros.sis_tipide_tido,
                                          Sis_numide_sitr = sismaesterceros.sis_numide_sitr,
                                          Sis_lugexp_sitr = sismaesterceros.sis_lugexp_sitr,
                                          Sis_priape_sitr = sismaesterceros.sis_priape_sitr,
                                          Sis_segape_sitr = sismaesterceros.sis_segape_sitr,
                                          Sis_prinom_sitr = sismaesterceros.sis_prinom_sitr,
                                          Sis_segnom_sitr = sismaesterceros.sis_segnom_sitr,
                                          Sis_razsoc_sitr = sismaesterceros.sis_razsoc_sitr,
                                          Sis_tipper_sitr = sismaesterceros.sis_tipper_sitr,
                                          Sis_idemun_muni = sismaesterceros.sis_idemun_muni,
                                          Sis_codmun_muni = sismaesterceros.sis_codmun_muni,
                                          Sis_coddep_dpto = sismaesterceros.sis_coddep_dpto,
                                          Sis_codact_sitr = sismaesterceros.sis_codact_sitr,
                                          Sis_tipcnt_sitr = sismaesterceros.sis_tipcnt_sitr,
                                          Sis_relret_sitr = sismaesterceros.sis_relret_sitr,
                                          Sis_tipter_tter = sismaesterceros.sis_tipter_tter,
                                          Sis_telefo_sitr = sismaesterceros.sis_telefo_sitr,
                                          Sis_direcc_sitr = sismaesterceros.sis_direcc_sitr,
                                          Sis_estreg_esrg = sismaesterceros.sis_estreg_esrg,
                                          Sis_deside_tido = tido.sis_deside_tido,
                                          Sis_nommun_muni = muni.sis_nommun_muni,
                                          Sis_desdep_dpto = dpto.sis_desdep_dpto,
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
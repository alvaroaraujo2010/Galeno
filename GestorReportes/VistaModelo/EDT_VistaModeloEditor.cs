using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Collections;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Data;
using System.Windows.Media;
using System.Text;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.ComponentModel;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Microsoft.Win32;
using Sistema.Utilidades;
using Sistema.Modelo;
using GestorReportes.Utilidades;
using GestorReportes.Modelo;

namespace GestorReportes.VistaModelo
{
    public class VistaModeloEditor : VistaModeloObjetoActivo
    {
        public String gcrIdVistaModeloForm = "HCL001"; // el editor

        //------------------------------------------------
        //GRPMAEPLANTILLA : Maestro de plantillas
        //------------------------------------------------
        #region Notificacion campos: GRPMAEPLANTILLA
        #region G1Grp_idepla_grpl: Código único plantilla
        public const string gcrNomProp_G1Grp_idepla_grpl = "G1Grp_idepla_grpl";
        private string _g1grp_idepla_grpl = string.Empty;
        /// <summary>
        /// <para>TABLA: grpmaeplantilla</para>
        /// <para>TABLA NATIVA: grpmaeplantilla</para>
        /// <para>CAMPO: Código único plantilla</para>
        /// <para>NOMBRE: g1grp_idepla_grpl (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        /// Consecutivo Único de la plantilla (generado por el sistema)
        /// </para>
        /// </summary>
        public string G1Grp_idepla_grpl
        {
            get { return _g1grp_idepla_grpl; }
            set
            {
                if (_g1grp_idepla_grpl == value) return;
                _g1grp_idepla_grpl = value;
                RaisePropertyChanged(gcrNomProp_G1Grp_idepla_grpl);
            }
        }
        #endregion
        #region G1Grp_despla_grpl: Nombre plantilla
        public const string gcrNomProp_G1Grp_despla_grpl = "G1Grp_despla_grpl";
        private string _g1grp_despla_grpl = string.Empty;
        /// <summary>
        /// <para>TABLA: grpmaeplantilla</para>
        /// <para>TABLA NATIVA: grpmaeplantilla</para>
        /// <para>CAMPO: Nombre plantilla</para>
        /// <para>NOMBRE: g1grp_despla_grpl (char:80)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Nombre  o descripcion de la plantilla según su uso
        /// </para>
        /// </summary>
        public string G1Grp_despla_grpl
        {
            get { return _g1grp_despla_grpl; }
            set
            {
                if (_g1grp_despla_grpl == value) return;
                _g1grp_despla_grpl = value;
                RaisePropertyChanged(gcrNomProp_G1Grp_despla_grpl);
            }
        }
        #endregion
        #region G1Grp_hl7for_grpl: Formato HL7
        public const string gcrNomProp_G1Grp_hl7for_grpl = "G1Grp_hl7for_grpl";
        private string _g1grp_hl7for_grpl = string.Empty;
        /// <summary>
        /// <para>TABLA: grpmaeplantilla</para>
        /// <para>TABLA NATIVA: grpmaeplantilla</para>
        /// <para>CAMPO: Formato HL7</para>
        /// <para>NOMBRE: g1grp_hl7for_grpl (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        ///Código del formato HL7 que homologa la plantilla
        /// </para>
        /// </summary>
        public string G1Grp_hl7for_grpl
        {
            get { return _g1grp_hl7for_grpl; }
            set
            {
                if (_g1grp_hl7for_grpl == value) return;
                _g1grp_hl7for_grpl = value;
                RaisePropertyChanged(gcrNomProp_G1Grp_hl7for_grpl);
            }
        }
        #endregion
        #region G1Grp_idegru_grpg: Grupo plantilla
        public const string gcrNomProp_G1Grp_idegru_grpg = "G1Grp_idegru_grpg";
        private string _g1grp_idegru_grpg = string.Empty;
        /// <summary>
        /// <para>TABLA: grpmaeplantilla</para>
        /// <para>TABLA NATIVA: grpgrupoplantil</para>
        /// <para>CAMPO: Grupo plantilla</para>
        /// <para>NOMBRE: g1grp_idegru_grpg (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        ///Codigos Grupos de plantillas (generado por el sistema)
        /// </para>
        /// </summary>
        public string G1Grp_idegru_grpg
        {
            get { return _g1grp_idegru_grpg; }
            set
            {
                if (_g1grp_idegru_grpg == value) return;
                _g1grp_idegru_grpg = value;
                RaisePropertyChanged(gcrNomProp_G1Grp_idegru_grpg);
            }
        }
        #endregion
        #region G1Grp_tipfor_grpl: Tipo formato plantilla
        public const string gcrNomProp_G1Grp_tipfor_grpl = "G1Grp_tipfor_grpl";
        private string _g1grp_tipfor_grpl = string.Empty;
        /// <summary>
        /// <para>TABLA: grpmaeplantilla</para>
        /// <para>TABLA NATIVA: grpmaeplantilla</para>
        /// <para>CAMPO: Tipo plantilla</para>
        /// <para>NOMBRE: g1grp_tipfor_grpl (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        /// Tipo formato:  PLANTILLA, ETIQUETA, REPORTES  y Otros
        /// </para>
        /// </summary>
        public string G1Grp_tipfor_grpl
        {
            get { return _g1grp_tipfor_grpl; }
            set
            {
                if (_g1grp_tipfor_grpl == value) return;
                _g1grp_tipfor_grpl = value;
                RaisePropertyChanged(gcrNomProp_G1Grp_tipfor_grpl);
            }
        }
        #endregion
        #region G1Grc_iderec_grcm: Codigo imagen icono
        public const string gcrNomProp_G1Grc_iderec_grcm = "G1Grc_iderec_grcm";
        private string _g1grc_iderec_grcm = string.Empty;
        /// <summary>
        /// <para>TABLA: grpmaeplantilla</para>
        /// <para>TABLA NATIVA: grcmaesrecursos</para>
        /// <para>CAMPO: Codigo imagen icono</para>
        /// <para>NOMBRE: g1grc_iderec_grcm (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        /// Codigo recurso imagen en la galeria de recursos, que representa
        /// el icono de la plantilla
        /// </para>
        /// </summary>
        public string G1Grc_iderec_grcm
        {
            get { return _g1grc_iderec_grcm; }
            set
            {
                if (_g1grc_iderec_grcm == value) return;
                _g1grc_iderec_grcm = value;
                RaisePropertyChanged(gcrNomProp_G1Grc_iderec_grcm);
            }
        }
        #endregion
        #region G1Grp_conver_grpl: Contador version plantilla
        public const string gcrNomProp_G1Grp_conver_grpl = "G1Grp_conver_grpl";
        private int _g1grp_conver_grpl = 0;
        /// <summary>
        /// <para>TABLA: grpmaeplantilla</para>
        /// <para>TABLA NATIVA: grpmaeplantilla</para>
        /// <para>CAMPO: Contador version plantilla</para>
        /// <para>NOMBRE: g1grp_conver_grpl (int:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        ///Contador para generar versiones plantilla
        /// </para>
        /// </summary>
        public int G1Grp_conver_grpl
        {
            get { return _g1grp_conver_grpl; }
            set
            {
                if (_g1grp_conver_grpl == value) return;
                _g1grp_conver_grpl = value;
                RaisePropertyChanged(gcrNomProp_G1Grp_conver_grpl);
            }
        }
        #endregion
        #region G1Grp_conobj_grpl: Contador generar objetos
        public const string gcrNomProp_G1Grp_conobj_grpl = "G1Grp_conobj_grpl";
        private int _g1grp_conobj_grpl = 0;
        /// <summary>
        /// <para>TABLA: grpmaeplantilla</para>
        /// <para>TABLA NATIVA: grpmaeplantilla</para>
        /// <para>CAMPO: Contador generar objetos</para>
        /// <para>NOMBRE: g1grp_conobj_grpl (int:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        /// Contador para generar Nombres unicos de los objetos en la plantilla
        /// </para>
        /// </summary>
        public int G1Grp_conobj_grpl
        {
            get { return _g1grp_conobj_grpl; }
            set
            {
                if (_g1grp_conobj_grpl == value) return;
                _g1grp_conobj_grpl = value;
                RaisePropertyChanged(gcrNomProp_G1Grp_conobj_grpl);
            }
        }
        #endregion
        #region G1Grp_prefij_grpl: Prefijos para nombres obj
        public const string gcrNomProp_G1Grp_prefij_grpl = "G1Grp_prefij_grpl";
        private string _g1grp_prefij_grpl = string.Empty;
        /// <summary>
        /// <para>TABLA: grpmaeplantilla</para>
        /// <para>TABLA NATIVA: grpmaeplantilla</para>
        /// <para>CAMPO: Prefijos para nombres obj</para>
        /// <para>NOMBRE: g1grp_prefij_grpl (char:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION:
        /// Prefijo para  generar Nombres unicos de los objetos en la plantilla
        /// ejemplo: EX, FR, OBJ …
        /// </para>
        /// </summary>
        public string G1Grp_prefij_grpl
        {
            get { return _g1grp_prefij_grpl; }
            set
            {
                if (_g1grp_prefij_grpl == value) return;
                _g1grp_prefij_grpl = value;
                RaisePropertyChanged(gcrNomProp_G1Grp_prefij_grpl);
            }
        }
        #endregion
        #region G1Grp_idepla_grpv: Codigo version en uso
        public const string gcrNomProp_G1Grp_idepla_grpv = "G1Grp_idepla_grpv";
        private string _g1grp_idepla_grpv = string.Empty;
        /// <summary>
        /// <para>TABLA: grpmaeplantilla</para>
        /// <para>TABLA NATIVA: grpmaeversplant</para>
        /// <para>CAMPO: Codigo version en uso</para>
        /// <para>NOMBRE: g1grp_idepla_grpv (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
        /// <para>DESCRIPCION:
        /// Codigo unico de la version del formato que esta en uso (util
        /// para formatos de Historia clinica que se modifican con el tiempo)
        /// </para>
        /// </summary>
        public string G1Grp_idepla_grpv
        {
            get { return _g1grp_idepla_grpv; }
            set
            {
                if (_g1grp_idepla_grpv == value) return;
                _g1grp_idepla_grpv = value;
                RaisePropertyChanged(gcrNomProp_G1Grp_idepla_grpv);
            }
        }
        #endregion
        #region G1Sis_estreg_esrg: Código Estado Registro
        public const string gcrNomProp_G1Sis_estreg_esrg = "G1Sis_estreg_esrg";
        private string _g1sis_estreg_esrg = string.Empty;
        /// <summary>
        /// <para>TABLA: grpmaeplantilla</para>
        /// <para>TABLA NATIVA: sisestadoregist</para>
        /// <para>CAMPO: Código Estado Registro</para>
        /// <para>NOMBRE: g1sis_estreg_esrg (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 11</para>
        /// <para>DESCRIPCION:
        ///Estado de registros  : 1= Activo 2= Inactivo
        /// </para>
        /// </summary>
        public string G1Sis_estreg_esrg
        {
            get { return _g1sis_estreg_esrg; }
            set
            {
                if (_g1sis_estreg_esrg == value) return;
                _g1sis_estreg_esrg = value;
                RaisePropertyChanged(gcrNomProp_G1Sis_estreg_esrg);
            }
        }
        #endregion
        #region G1Grp_desgru_grpg: Descripción grupo
        public const string gcrNomProp_G1Grp_desgru_grpg = "G1Grp_desgru_grpg";
        private string _g1grp_desgru_grpg = string.Empty;
        /// <summary>
        /// <para>TABLA: grpmaeplantilla</para>
        /// <para>TABLA NATIVA: grpgrupoplantil</para>
        /// <para>CAMPO: Descripción grupo</para>
        /// <para>NOMBRE: g1grp_desgru_grpg (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripción textual  del grupo plantilla
        /// </para>
        /// </summary>
        public string G1Grp_desgru_grpg
        {
            get { return _g1grp_desgru_grpg; }
            set
            {
                if (_g1grp_desgru_grpg == value) return;
                _g1grp_desgru_grpg = value;
                RaisePropertyChanged(gcrNomProp_G1Grp_desgru_grpg);
            }
        }
        #endregion
        #region G1Grc_desrec_grcm: Descripción recurso
        public const string gcrNomProp_G1Grc_desrec_grcm = "G1Grc_desrec_grcm";
        private string _g1grc_desrec_grcm = string.Empty;
        /// <summary>
        /// <para>TABLA: grpmaeplantilla</para>
        /// <para>TABLA NATIVA: grcmaesrecursos</para>
        /// <para>CAMPO: Descripción recurso</para>
        /// <para>NOMBRE: g1grc_desrec_grcm (char:60)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Titulo o descripción textual corta  del recurso  imagen, video,
        /// audio  capturada
        /// </para>
        /// </summary>
        public string G1Grc_desrec_grcm
        {
            get { return _g1grc_desrec_grcm; }
            set
            {
                if (_g1grc_desrec_grcm == value) return;
                _g1grc_desrec_grcm = value;
                RaisePropertyChanged(gcrNomProp_G1Grc_desrec_grcm);
            }
        }
        #endregion
        #region G1Sis_desest_esrg: Decripción estado registro
        public const string gcrNomProp_G1Sis_desest_esrg = "G1Sis_desest_esrg";
        private string _g1sis_desest_esrg = string.Empty;
        /// <summary>
        /// <para>TABLA: grpmaeplantilla</para>
        /// <para>TABLA NATIVA: sisestadoregist</para>
        /// <para>CAMPO: Decripción estado registro</para>
        /// <para>NOMBRE: g1sis_desest_esrg (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Descripcion textual del estado de registro: Activo o Inactivo
        /// </para>
        /// </summary>
        public string G1Sis_desest_esrg
        {
            get { return _g1sis_desest_esrg; }
            set
            {
                if (_g1sis_desest_esrg == value) return;
                _g1sis_desest_esrg = value;
                RaisePropertyChanged(gcrNomProp_G1Sis_desest_esrg);
            }
        }
        #endregion
        #endregion
        //------------------------------------------------
        //GRPMAEVERSPLANT : Maestro versiones de plantillas
        //------------------------------------------------
        #region Notificacion campos: GRPMAEVERSPLANT
        #region G2Grp_idepla_grpv: Código version plantilla
        public const string gcrNomProp_G2Grp_idepla_grpv = "G2Grp_idepla_grpv";
        private string _g2grp_idepla_grpv = string.Empty;
        /// <summary>
        /// <para>TABLA: grpmaeversplant</para>
        /// <para>TABLA NATIVA: grpmaeversplant</para>
        /// <para>CAMPO: Código version plantilla</para>
        /// <para>NOMBRE: g2grp_idepla_grpv (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        /// Codigo Versión plantilla en uso (por defecto) </para>
        /// </summary>
        public string G2Grp_idepla_grpv
        {
            get { return _g2grp_idepla_grpv; }
            set
            {
                if (_g2grp_idepla_grpv == value) return;
                _g2grp_idepla_grpv = value;
                RaisePropertyChanged(gcrNomProp_G2Grp_idepla_grpv);
            }
        }
        #endregion
        #region G2Grp_verpla_grpv: Version plantilla
        public const string gcrNomProp_G2Grp_verpla_grpv = "G2Grp_verpla_grpv";
        private String _g2grp_verpla_grpv = string.Empty;
        /// <summary>
        /// <para>TABLA: grpmaeversplant</para>
        /// <para>TABLA NATIVA: grpmaeversplant</para>
        /// <para>CAMPO: Version plantilla</para>
        /// <para>NOMBRE: g2grp_verpla_grpv (char:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        ///Numero de la Version plantilla ejemplo: 10,11,12…
        /// </para>
        /// </summary>
        public string G2Grp_verpla_grpv
        {
            get { return _g2grp_verpla_grpv; }
            set
            {
                if (_g2grp_verpla_grpv == value) return;
                _g2grp_verpla_grpv = value;
                RaisePropertyChanged(gcrNomProp_G2Grp_verpla_grpv);
            }
        }
        #endregion
        #region G2Grp_xmlpla_grpv: XML Version plantilla
        public const string gcrNomProp_G2Grp_xmlpla_grpv = "G2Grp_xmlpla_grpv";
        private String _g2grp_xmlpla_grpv = string.Empty;
        /// <summary>
        /// <para>TABLA: grpmaeversplant</para>
        /// <para>TABLA NATIVA: grpmaeversplant</para>
        /// <para>CAMPO: XML Version plantilla</para>
        /// <para>NOMBRE: g2grp_xmlpla_grpv (memo:)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        ///Codigo XML formato plantilla
        /// </para>
        /// </summary>
        public String G2Grp_xmlpla_grpv
        {
            get { return _g2grp_xmlpla_grpv; }
            set
            {
                if (_g2grp_xmlpla_grpv == value) return;
                _g2grp_xmlpla_grpv = value;
                RaisePropertyChanged(gcrNomProp_G2Grp_xmlpla_grpv);
            }
        }
        #endregion
        #region G2Grp_xmlplb_grpv: XML Plantilla parte 2
        public const String gcrNomProp_G2Grp_xmlplb_grpv = "G2Grp_xmlplb_grpv";
        private string _g2grp_xmlplb_grpv = String.Empty;
        /// <summary>
        /// <para>TABLA: grpmaeversplant</para>
        /// <para>TABLA NATIVA: grpmaeversplant</para>
        /// <para>CAMPO: XML Plantilla parte 2</para>
        /// <para>NOMBRE: g2grp_xmlplb_grpv (memo:)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        ///Codigo XML formato plantilla continuacion parte 2
        /// </para>
        /// </summary>
        public string G2Grp_xmlplb_grpv
        {
            get { return _g2grp_xmlplb_grpv; }
            set
            {
                if (_g2grp_xmlplb_grpv == value) return;
                _g2grp_xmlplb_grpv = value;
                RaisePropertyChanged(gcrNomProp_G2Grp_xmlplb_grpv);
            }
        }
        #endregion
        #region G2Grp_xmlplc_grpv: XML Plantilla parte 3
        public const String gcrNomProp_G2Grp_xmlplc_grpv = "G2Grp_xmlplc_grpv";
        private string _g2grp_xmlplc_grpv = String.Empty;
        /// <summary>
        /// <para>TABLA: grpmaeversplant</para>
        /// <para>TABLA NATIVA: grpmaeversplant</para>
        /// <para>CAMPO: XML Plantilla parte 3</para>
        /// <para>NOMBRE: g2grp_xmlplc_grpv (memo:)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        ///Codigo XML formato plantilla continuacion parte 3
        /// </para>
        /// </summary>
        public string G2Grp_xmlplc_grpv
        {
            get { return _g2grp_xmlplc_grpv; }
            set
            {
                if (_g2grp_xmlplc_grpv == value) return;
                _g2grp_xmlplc_grpv = value;
                RaisePropertyChanged(gcrNomProp_G2Grp_xmlplc_grpv);
            }
        }
        #endregion
        #region G2Grp_xmlpld_grpv: XML Plantilla parte 4
        public const String gcrNomProp_G2Grp_xmlpld_grpv = "G2Grp_xmlpld_grpv";
        private string _g2grp_xmlpld_grpv = String.Empty;
        /// <summary>
        /// <para>TABLA: grpmaeversplant</para>
        /// <para>TABLA NATIVA: grpmaeversplant</para>
        /// <para>CAMPO: XML Plantilla parte 4</para>
        /// <para>NOMBRE: g2grp_xmlpld_grpv (memo:)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        ///Codigo XML formato plantilla continuacion parte 4
        /// </para>
        /// </summary>
        public string G2Grp_xmlpld_grpv
        {
            get { return _g2grp_xmlpld_grpv; }
            set
            {
                if (_g2grp_xmlpld_grpv == value) return;
                _g2grp_xmlpld_grpv = value;
                RaisePropertyChanged(gcrNomProp_G2Grp_xmlpld_grpv);
            }
        }
        #endregion
        #region G2Grp_numver_grpv: Numero Version plantilla
        public const string gcrNomProp_G2Grp_numver_grpv = "G2Grp_numver_grpv";
        private int _g2grp_numver_grpv = 0;
        /// <summary>
        /// <para>TABLA: grpmaeversplant</para>
        /// <para>TABLA NATIVA: grpmaeversplant</para>
        /// <para>CAMPO: Numero Version plantilla</para>
        /// <para>NOMBRE: g2grp_numver_grpv (int:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        /// Numero (en formato numerico) de la Version plantilla para
        /// organizar en consultas ejemplo: 10,11,12…
        /// </para>
        /// </summary>
        public int G2Grp_numver_grpv
        {
            get { return _g2grp_numver_grpv; }
            set
            {
                if (_g2grp_numver_grpv == value) return;
                _g2grp_numver_grpv = value;
                RaisePropertyChanged(gcrNomProp_G2Grp_numver_grpv);
            }
        }
        #endregion
        #region G2Grp_hojalt_grpv: Alto Hoja
        public const string gcrNomProp_G2Grp_hojalt_grpv = "G2Grp_hojalt_grpv";
        private int _g2grp_hojalt_grpv = 0;
        /// <summary>
        /// <para>TABLA: grpmaeversplant</para>
        /// <para>TABLA NATIVA: grpmaeversplant</para>
        /// <para>CAMPO: Alto Hoja</para>
        /// <para>NOMBRE: g2grp_hojalt_grpv (int:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        ///Alto hojas de la plantilla
        /// </para>
        /// </summary>
        public int G2Grp_hojalt_grpv
        {
            get { return _g2grp_hojalt_grpv; }
            set
            {
                if (_g2grp_hojalt_grpv == value) return;
                _g2grp_hojalt_grpv = value;
                RaisePropertyChanged(gcrNomProp_G2Grp_hojalt_grpv);
            }
        }
        #endregion
        #region G2Grp_hojanc_grpv: Ancho Hoja
        public const string gcrNomProp_G2Grp_hojanc_grpv = "G2Grp_hojanc_grpv";
        private int _g2grp_hojanc_grpv = 0;
        /// <summary>
        /// <para>TABLA: grpmaeversplant</para>
        /// <para>TABLA NATIVA: grpmaeversplant</para>
        /// <para>CAMPO: Ancho Hoja</para>
        /// <para>NOMBRE: g2grp_hojanc_grpv (int:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        ///Ancho Hojas de la plantilla
        /// </para>
        /// </summary>
        public int G2Grp_hojanc_grpv
        {
            get { return _g2grp_hojanc_grpv; }
            set
            {
                if (_g2grp_hojanc_grpv == value) return;
                _g2grp_hojanc_grpv = value;
                RaisePropertyChanged(gcrNomProp_G2Grp_hojanc_grpv);
            }
        }
        #endregion
        #region G2Grp_marver_grpv: Margen vertical
        public const string gcrNomProp_G2Grp_marver_grpv = "G2Grp_marver_grpv";
        private int _g2grp_marver_grpv = 0;
        /// <summary>
        /// <para>TABLA: grpmaeversplant</para>
        /// <para>TABLA NATIVA: grpmaeversplant</para>
        /// <para>CAMPO: Margen vertical</para>
        /// <para>NOMBRE: g2grp_marver_grpv (int:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        ///Margen vertical de la plantilla
        /// </para>
        /// </summary>
        public int G2Grp_marver_grpv
        {
            get { return _g2grp_marver_grpv; }
            set
            {
                if (_g2grp_marver_grpv == value) return;
                _g2grp_marver_grpv = value;
                RaisePropertyChanged(gcrNomProp_G2Grp_marver_grpv);
            }
        }
        #endregion
        #region G2Grp_marhor_grpv: Margen Horizontal
        public const string gcrNomProp_G2Grp_marhor_grpv = "G2Grp_marhor_grpv";
        private int _g2grp_marhor_grpv = 0;
        /// <summary>
        /// <para>TABLA: grpmaeversplant</para>
        /// <para>TABLA NATIVA: grpmaeversplant</para>
        /// <para>CAMPO: Margen Horizontal</para>
        /// <para>NOMBRE: g2grp_marhor_grpv (int:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION:
        ///Margen horizontal de la plantilla
        /// </para>
        /// </summary>
        public int G2Grp_marhor_grpv
        {
            get { return _g2grp_marhor_grpv; }
            set
            {
                if (_g2grp_marhor_grpv == value) return;
                _g2grp_marhor_grpv = value;
                RaisePropertyChanged(gcrNomProp_G2Grp_marhor_grpv);
            }
        }
        #endregion
        #region G2Grp_epapel_grpv: Estilo tamaño del papel
        public const string gcrNomProp_G2Grp_epapel_grpv = "G2Grp_epapel_grpv";
        private string _g2grp_epapel_grpv = string.Empty;
        /// <summary>
        /// <para>TABLA: grpmaeversplant</para>
        /// <para>TABLA NATIVA: grpmaeversplant</para>
        /// <para>CAMPO: Estilo tamaño del papel</para>
        /// <para>NOMBRE: g2grp_epapel_grpv (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
        /// <para>DESCRIPCION:
        /// Nombre de la presentacion estilo del papel: OFICIO, CARTA,
        /// MEDIACARTA, ETIQUETA,PERSONALIZADO
        /// </para>
        /// </summary>
        public string G2Grp_epapel_grpv
        {
            get { return _g2grp_epapel_grpv; }
            set
            {
                if (_g2grp_epapel_grpv == value) return;
                _g2grp_epapel_grpv = value;
                RaisePropertyChanged(gcrNomProp_G2Grp_epapel_grpv);
            }
        }
        #endregion
        #region G2Grp_estilo_grpv: Tema presenenacion Skin
        public const string gcrNomProp_G2Grp_estilo_grpv = "G2Grp_estilo_grpv";
        private string _g2grp_estilo_grpv = string.Empty;
        /// <summary>
        /// <para>TABLA: grpmaeversplant</para>
        /// <para>TABLA NATIVA: grpmaeversplant</para>
        /// <para>CAMPO: Tema presenenacion Skin</para>
        /// <para>NOMBRE: g2grp_estilo_grpv (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 11</para>
        /// <para>DESCRIPCION:
        /// Referenicia al estilo o tema del diseño  y presentacion de
        /// plantilla (para el futuro)
        /// </para>
        /// </summary>
        public string G2Grp_estilo_grpv
        {
            get { return _g2grp_estilo_grpv; }
            set
            {
                if (_g2grp_estilo_grpv == value) return;
                _g2grp_estilo_grpv = value;
                RaisePropertyChanged(gcrNomProp_G2Grp_estilo_grpv);
            }
        }
        #endregion
        #region G2Grp_decima_grpv: Separador decimal
        public const string gcrNomProp_G2Grp_decima_grpv = "G2Grp_decima_grpv";
        private string _g2grp_decima_grpv = string.Empty;
        /// <summary>
        /// <para>TABLA: grpmaeversplant</para>
        /// <para>TABLA NATIVA: grpmaeversplant</para>
        /// <para>CAMPO: Separador decimal</para>
        /// <para>NOMBRE: g2grp_decima_grpv (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 12</para>
        /// <para>DESCRIPCION:
        /// Carácter separador decimal utilizado en el diseño de la plantilla.
        /// </para>
        /// </summary>
        public string G2Grp_decima_grpv
        {
            get { return _g2grp_decima_grpv; }
            set
            {
                if (_g2grp_decima_grpv == value) return;
                _g2grp_decima_grpv = value;
                RaisePropertyChanged(gcrNomProp_G2Grp_decima_grpv);
            }
        }
        #endregion
        #region G2Sis_estreg_esrg: Código Estado Registro
        public const string gcrNomProp_G2Sis_estreg_esrg = "G2Sis_estreg_esrg";
        private string _g2sis_estreg_esrg = string.Empty;
        /// <summary>
        /// <para>TABLA: grpmaeversplant</para>
        /// <para>TABLA NATIVA: sisestadoregist</para>
        /// <para>CAMPO: Código Estado Registro</para>
        /// <para>NOMBRE: g2sis_estreg_esrg (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 13</para>
        /// <para>DESCRIPCION:
        ///Estado de registros  : 1= Activo 2= Inactivo
        /// </para>
        /// </summary>
        public string G2Sis_estreg_esrg
        {
            get { return _g2sis_estreg_esrg; }
            set
            {
                if (_g2sis_estreg_esrg == value) return;
                _g2sis_estreg_esrg = value;
                RaisePropertyChanged(gcrNomProp_G2Sis_estreg_esrg);
            }
        }
        #endregion
        #region G2Sis_desest_esrg: Decripción estado registro
        public const string gcrNomProp_G2Sis_desest_esrg = "G2Sis_desest_esrg";
        private string _g2sis_desest_esrg = string.Empty;
        /// <summary>
        /// <para>TABLA: grpmaeversplant</para>
        /// <para>TABLA NATIVA: sisestadoregist</para>
        /// <para>CAMPO: Decripción estado registro</para>
        /// <para>NOMBRE: g2sis_desest_esrg (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Descripcion textual del estado de registro: Activo o Inactivo
        /// </para>
        /// </summary>
        public string G2Sis_desest_esrg
        {
            get { return _g2sis_desest_esrg; }
            set
            {
                if (_g2sis_desest_esrg == value) return;
                _g2sis_desest_esrg = value;
                RaisePropertyChanged(gcrNomProp_G2Sis_desest_esrg);
            }
        }
        #endregion
        #endregion
        //------------------------------------------------
        // Registro Activo y Lista Browser
        //------------------------------------------------
        #region GRPMAEPLANTILLA: Registro Activo Mestro plantilla
        public const string gcrNomProp_TmpG1RegActivo = "TmpG1RegActivo";
        private ModeloPlantilla _tmpg1regactivo;
        /// <summary>
        ///  Registro activo de la tabla: grpmaeplantilla
        /// </summary>
        public ModeloPlantilla TmpG1RegActivo
        {
            get { return _tmpg1regactivo; }
            set
            {
                if (_tmpg1regactivo == value) return;
                _tmpg1regactivo = value;
                RaisePropertyChanged(gcrNomProp_TmpG1RegActivo);
            }
        }
        #endregion
        #region GRPMAEVERSPLANT: Registro activo tabla version plantilla
        public const string gcrNomProp_TmpG2RegActivo = "TmpG2RegActivo";
        private VersionPlantilla _tmpg2regactivo;
        /// <summary>
        ///  Registro activo de la tabla: grpmaeversplant
        /// </summary>
        public VersionPlantilla TmpG2RegActivo
        {
            get { return _tmpg2regactivo; }
            set
            {
                if (_tmpg2regactivo == value) return;
                _tmpg2regactivo = value;
                RaisePropertyChanged(gcrNomProp_TmpG2RegActivo);
            }
        }
        #endregion
        //-------------------------------------------------
        // Comandos para la gestion de registros
        //-------------------------------------------------
        #region Registro de Comandos para gestion
        //Comandos Activacion botones de guardar y otros
        public RelayCommand CmdEdtGestionGeneral { get; set; }
        //Comandos para agregar Lista de Etiquetas
        public RelayCommand CmdEtiquetaBuscar { get; set; }
        public RelayCommand CmdEtiquetaSave { get; set; }
        public RelayCommand CmdEtiquetaNuevo { get; set; }
        public RelayCommand CmdEtiquetaEliminar { get; set; }
        //Comandos para agregar Lista de imagenes predefinidas
        public RelayCommand CmdImgPredefBuscar { get; set; }
        public RelayCommand CmdImgPredefSave { get; set; }
        public RelayCommand CmdImgPredefNuevo { get; set; }
        public RelayCommand CmdImgPredefEliminar { get; set; }

        #region Comandos para gestion de registros
        /// <summary>
        /// Registrar comandos del modelo vista
        /// </summary>
        public override void fcvRegistrarComandos()
        {
            base.fcvRegistrarComandos();
            // Botones Para activar segun perfil usuario
            CmdEdtGestionGeneral = new RelayCommand(fcvAccBotones, CanEdtPerfilGeneral);

            // Botones Items para Grid Etiquetas
            CmdEtiquetaBuscar   = new RelayCommand(fcvAccBotones, CanEtiquetaBuscar);
            CmdEtiquetaNuevo    = new RelayCommand(fcvAccionEtiquetaNuevo, CanEtiquetaNuevo);
            CmdEtiquetaSave     = new RelayCommand(fcvAccionEtiquetaSave, CanEtiquetaSave);
            CmdEtiquetaEliminar = new RelayCommand(fcvAccionEtiquetaEliminar, CanEtiquetaEliminar);
            // Botones Items para Grid Imagenes predefinidas
            CmdImgPredefBuscar  = new RelayCommand(fcvAccBotones, CanImgPredefBuscar);
            CmdImgPredefNuevo   = new RelayCommand(fcvAccionImgPredefNuevo, CanImgPredefNuevo);
            CmdImgPredefSave    = new RelayCommand(fcvAccionImgPredefSave, CanImgPredefSave);
            CmdImgPredefEliminar= new RelayCommand(fcvAccionImgPredefEliminar, CanImgPredefEliminar);
        }
        #endregion
        #endregion
        //------------------------------------------------
        // Metodo instancia publica clase
        //------------------------------------------------
        public VistaModeloEditor() { }

        //-------------------------------------------------
        // Region Para los Metodos que realizan la funcion
        // de gestion de datos en la tabla
        //-------------------------------------------------
        #region Metodos para Gestion de Edicion Registros
        #region Adicionar Registro
        /// <summary>
        /// Adicionar Registro
        /// </summary>
        public virtual void Adicionar()
        {
            try
            {
                fcvReiniVariables();
                GlgSIS_ModoAdicion = true;
                GlgSIS_ModoEdicion = true;
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: Adicionar");
            }
        }
        #endregion
        #region Guardar Registro
        /// <summary>
        /// Guardar Registro
        /// </summary>
        public virtual void Guardar()
        {
            fcvCargarRegActivoDesdeVariables();
            if (GlgSIS_ModoAdicion == true)
            {
                TmpG1RegActivo.Grp_idepla_grpl = ModeloPlantilla.flgAddRegistro(TmpG1RegActivo);
                G1Grp_idepla_grpl = TmpG1RegActivo.Grp_idepla_grpl;

                // Plantilla base 
                TmpG1RegActivo.Grp_conver_grpl = 10;
                //VersionPlantilla
                TmpG2RegActivo.Grp_idepla_grpl = G1Grp_idepla_grpl;
                TmpG2RegActivo.Grp_numver_grpv = 10;
                TmpG2RegActivo.Grp_verpla_grpv = "10";
                TmpG2RegActivo.Grp_idepla_grpv = G1Grp_idepla_grpl + "V10";         // 10 es la primera version
                TmpG1RegActivo.Grp_idepla_grpv = TmpG2RegActivo.Grp_idepla_grpv;    // Versión uso por defecto en la plantilla
                VersionPlantilla.flgAddRegistro(TmpG2RegActivo);

                fcvCargarVariablesDesdeRegActivo();
            }
            else
            {
                ModeloPlantilla.fcvActualizar(TmpG1RegActivo);
                VersionPlantilla.fcvActualizar(TmpG2RegActivo);
            }
            GlgSIS_ModoAdicion = false;
        }
        #endregion
        #region Filtro
        /// <summary>
        /// Filtrar registros desde plantilla, carga version configurada por defecto
        /// </summary>
        public virtual void Filtro(String tcrCodigoPlantilla)
        {
            try
            {
                List<ModeloPlantilla> TmpG1ListaBrow = ModeloPlantilla.flsListaGrpmaeplantilla(tcrCodigoPlantilla);
                if (TmpG1ListaBrow.Count > 0)
                {
                    TmpG1RegActivo = TmpG1ListaBrow.FirstOrDefault();

                    List<VersionPlantilla> TmpG2ListaBrow = VersionPlantilla.flsBuscarVersionPlantilla(TmpG1RegActivo.Grp_idepla_grpv);
                    if (TmpG2ListaBrow.Count > 0)
                    {
                        TmpG2RegActivo = (VersionPlantilla)TmpG2ListaBrow[0];
                        fcvCargarVariablesDesdeRegActivo();
                    }
                }

            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: Filtro");
            }
        }
        #endregion
        #region FiltroVersion
        /// <summary>
        /// Cargar Version plantilla segun codigo version dado en paremtro
        /// </summary>
        public virtual void FiltroVersion(String tcrCodigoVersion)
        {
            try
            {
                var TmpG2ListaBrow = VersionPlantilla.flsBuscarVersionPlantilla(tcrCodigoVersion);
                if (TmpG2ListaBrow.Count > 0)
                {
                    TmpG2RegActivo = TmpG2ListaBrow.FirstOrDefault();

                    var TmpG1ListaBrow = ModeloPlantilla.flsListaGrpmaeplantilla(TmpG2RegActivo.Grp_idepla_grpl);
                    if (TmpG1ListaBrow.Count > 0)
                    {
                        TmpG1RegActivo = TmpG1ListaBrow.FirstOrDefault();
                        fcvCargarVariablesDesdeRegActivo();
                    }
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: FiltroVersion");
            }
        }
        #endregion

        //- Gestion Adicionar Items para Etiquetas
        #region fcvAccionEtiquetaNuevo: Adicionar Item para Etiquetas
        /// <summary>
        /// Adicionar Item para Etiquetas
        /// </summary>
        public void fcvAccionEtiquetaNuevo()
        {
            try
            {
                fcvGridReiniVariables("E");
                regEtiquetaItems = new XmlEntorno.ClassXmlItemEtiquetas();
                regEtiquetaItems.Imaen = "A";
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: fcvAccionEtiquetaNuevo");
            }
        }
        #endregion
        #region fcvAccionEtiquetaSave: Guardar en temporal item para Etiquetas
        /// <summary>
        /// Guardar en temporal item para Etiquetas
        /// </summary>
        public void fcvAccionEtiquetaSave()
        {
            try
            {
                // Cuando es un nuevo registro
                if (String.IsNullOrEmpty(PropEtiqTxtIndice))
                {
                    PropEtiqIntIndice = fnuAccionEtiquetaGenSecuencial();
                    PropEtiqTxtIndice = PropEtiqIntIndice.ToString().Trim();
                }
                regEtiquetaItems.Imaen = String.IsNullOrEmpty(regEtiquetaItems.Imaen) ? "A" : regEtiquetaItems.Imaen;

                if (regEtiquetaItems.Imaen != "A") { regEtiquetaItems.Imaen = "M"; } // es modificado
                fcvGridCargarRegActivoDesdeVariables("E");
                fcvAccionEtiquetaSaveEx(regEtiquetaItems);

                //- Preparar para Adicionar otro
                fcvAccionEtiquetaNuevo();
                PropNotifCambioListView = "ETIQUETAS";
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: fcvAccionEtiquetaSave");
            }
        }
        #endregion
        #region fcvAccionEtiquetaEliminar: Eliminar datos en temporal Item Etiquetas
        /// <summary>
        /// Eliminar datos en temporal Item Etiquetas
        /// </summary>
        public void fcvAccionEtiquetaEliminar()
        {
            try
            {
                if (!String.IsNullOrEmpty(PropEtiqTxtIndice) && regEtiquetaItems != null)
                {
                    regEtiquetaItems.Imaen = "I"; // eliminar 
                    fcvAccionEtiquetaSaveEx(regEtiquetaItems);
                    fcvAccionComboItemNuevo();
                    PropNotifCambioListView = "ETIQUETAS";
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: fcvAccionEtiquetaEliminar");
            }
        }
        #endregion
        #region fcvAccionEtiquetaSaveEx: Guardar los datos en temporal Item Etiquetas
        /// <summary>
        /// Guardar los datos en temporal Item Etiquetas
        /// </summary>
        public void fcvAccionEtiquetaSaveEx(XmlEntorno.ClassXmlItemEtiquetas tobRegistro)
        {
            tmpEtiquetaItems.Remove(tobRegistro);
            //- Actualizar en  temporales
            if (tobRegistro.Imaen == "A" || tobRegistro.Imaen == "M")
            {
                tmpEtiquetaItems.Add(tobRegistro);
            }
        }
        #endregion
        #region fnuAccionEtiquetaGenSecuencial: Organizar y generar nuevo secuencial item Etiquetas
        /// <summary>
        /// <para>Organiza y genera los nuevos secuenciales para el temporal de Etiquetas</para>
        /// </summary>
        public int fnuAccionEtiquetaGenSecuencial()
        {
            var lnuValor = 1;
            foreach (XmlEntorno.ClassXmlItemEtiquetas lobReg in tmpEtiquetaItems)
            {
                lobReg.IntIndice = lnuValor;
                lnuValor++;
            }
            return lnuValor;
        }
        #endregion
        //- Gestion Adicionar Imagen predefinida
        #region fcvAccionImgPredefNuevo: Adicionar Item para imagenes predefinidas
        /// <summary>
        /// <para>Adicionar Item para imagenes predefinidas</para>
        /// </summary>
        public void fcvAccionImgPredefNuevo()
        {
            try
            {
                fcvGridReiniVariables("G");
                regImgPredefItems = new XmlEntorno.ClassXmlImgPredefinidas();
                regImgPredefItems.Imaen = "A";
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: fcvAccionImgPredefNuevo");
            }
        }
        #endregion
        #region fcvAccionImgPredefSave: Guardar en temporal item para imagenes predefinidas
        /// <summary>
        /// <para>Guardar en temporal item imagenes predefinidas</para>
        /// </summary>
        public void fcvAccionImgPredefSave()
        {
            try
            {
                // Cuando es un nuevo registro
                if (String.IsNullOrEmpty(PropGalTxtCodigo))
                {
                    PropGalIntCodigo = fnuAccionImgPredefGenSecuencial();
                    PropGalTxtCodigo = PropGalIntCodigo.ToString().Trim();
                }
                regImgPredefItems.Imaen = String.IsNullOrEmpty(regImgPredefItems.Imaen) ? "A" : regImgPredefItems.Imaen;

                if (regImgPredefItems.Imaen != "A") { regImgPredefItems.Imaen = "M"; } // es modificado
                fcvGridCargarRegActivoDesdeVariables("G");
                fcvAccionImgPredefSaveEx(regImgPredefItems);

                //- Preparar para Adicionar otro
                fcvAccionImgPredefNuevo();
                PropNotifCambioListView = "IMG-PREDEF";
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: fcvAccionImgPredefSave");
            }
        }
        #endregion
        #region fcvAccionImgPredefEliminar: Eliminar datos en temporal imagenes predefinidas
        /// <summary>
        /// Eliminar datos en temporal imagenes predefinidas
        /// </summary>
        public void fcvAccionImgPredefEliminar()
        {
            try
            {
                if (!String.IsNullOrEmpty(PropGalTxtCodigo) && regImgPredefItems != null)
                {
                    regImgPredefItems.Imaen = "I"; // eliminar 
                    fcvAccionImgPredefSaveEx(regImgPredefItems);
                    fcvAccionImgPredefNuevo();
                    PropNotifCambioListView = "IMG-PREDEF";
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: fcvAccionEtiquetaEliminar");
            }
        }
        #endregion
        #region fcvAccionImgPredefSaveEx: Guardar los datos en temporal imagenes predefinidas
        /// <summary>
        /// <para>Guardar los datos en temporal imagenes predefinidas</para>
        /// </summary>
        public void fcvAccionImgPredefSaveEx(XmlEntorno.ClassXmlImgPredefinidas tobRegistro)
        {
            tmpImgPredefItems.Remove(tobRegistro);
            //- Actualizar en  temporales
            if (tobRegistro.Imaen == "A" || tobRegistro.Imaen == "M")
            {
                if (!String.IsNullOrWhiteSpace(PropGalTxtRutayArchivoOrigen))
                {
                    //String lcrArchivoOrigen = System.IO.Path.Combine(PropGalTxtRutayArchivoOrigen);
                    String lcrArchivoOrigen = PropGalTxtRutayArchivoOrigen;
                    //String lcrArchivoDestino = System.IO.Path.Combine(lcrRutaDestino, lcrNombreArchivo); ojo esta ya estaba desactiva 
                    //if (!File.Exists(PropGalTxtRutayArchivoDestino))
                    //{
                        System.IO.File.Copy(lcrArchivoOrigen, PropGalTxtRutayArchivoDestino, true);
                    //}
                    PropGalTxtRutayArchivoOrigen = String.Empty;
                    PropGalTxtRutayArchivoDestino = String.Empty;
                }

                tmpImgPredefItems.Add(tobRegistro);
            }
        }
        #endregion
        #region fnuAccionImgPredefGenSecuencial: Organizar y generar nuevo secuencial imagenes predefinidas
        /// <summary>
        /// <para>Organiza y genera los nuevos secuenciales para el temporal imagenes predefinidas</para>
        /// </summary>
        public int fnuAccionImgPredefGenSecuencial()
        {
            var lnuValor = 1;
            foreach (XmlEntorno.ClassXmlImgPredefinidas lobReg in tmpImgPredefItems)
            {
                lobReg.IntCodigo = lnuValor;
                lobReg.Codigo = lnuValor.ToString();
                lnuValor++;
            }
            return lnuValor;
        }
        #endregion
        #endregion
        #region Comandos de activacion Botones gestion Etiquetas
        #region CanEtiquetaBuscar
        /// <summary>
        /// Activar buscar nuevo item para lista de Etiquetas 
        /// </summary>
        public bool CanEtiquetaBuscar()
        {
            bool llgReturn = false;
            try
            {
                glgPuedeEditarItemsEtiqueta = false;
                if (GlgSIS_ModoEdicion == true && G1Grp_tipfor_grpl == "PLANTILLA")
                {
                    llgReturn = true;
                    glgPuedeEditarItemsEtiqueta = true;
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: CanEtiquetaBuscar");
            }
            return llgReturn;
        }
        #endregion
        #region CanEtiquetaNuevo
        /// <summary>
        /// Activar Adicionar nuevo item a lista de Etiquetas 
        /// </summary>
        public bool CanEtiquetaNuevo()
        {
            bool llgReturn = false;
            try
            {
                glgPuedeEditarItemsEtiqueta = false;
                if (GlgSIS_ModoEdicion == true && G1Grp_tipfor_grpl == "PLANTILLA")
                {
                    llgReturn = true;
                    glgPuedeEditarItemsEtiqueta = true;
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: CanEtiquetaNuevo");
            }
            return llgReturn;
        }
        #endregion
        #region CanEtiquetaSave
        /// <summary>
        /// Activar Guardar nuevo item a lista de combobox 
        /// </summary>
        public bool CanEtiquetaSave()
        {
            bool llgReturn = false;
            try
            {
                if (GlgSIS_ModoEdicion == true && G1Grp_tipfor_grpl == "PLANTILLA")
                {
                    #region Valores Variables
                    /*
                    llgReturn = String.IsNullOrEmpty(fcrValidacion("PropEtiqTxtCodigo")) &&
                                String.IsNullOrEmpty(fcrValidacion("PropEtiqTxtIcono")) &&
                                String.IsNullOrEmpty(fcrValidacion("PropEtiqTxtDescripcion"));
                    */
                    llgReturn = String.IsNullOrEmpty(fcrValidacion("PropEtiqTxtCodigo"));
                    #endregion
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: CanEtiquetaSave");
            }
            return llgReturn;
        }
        #endregion
        #region CanEtiquetaEliminar
        /// <summary>
        /// Activar Eliminar item en lista de Etiqueta
        /// </summary>
        public bool CanEtiquetaEliminar()
        {
            bool llgReturn = false;
            try
            {
                if (GlgSIS_ModoEdicion == true && G1Grp_tipfor_grpl == "PLANTILLA")
                {
                    llgReturn = regEtiquetaItems != null ? true : false;
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: CanEtiquetaEliminar");
            }
            return llgReturn;
        }
        #endregion
        #region CanEdtPerfilGeneral
        /// <summary>
        ///Validación para saber si se permite
        ///activar los botones de guaradr y otros segun perfil usuario
        /// </summary>
        public bool CanEdtPerfilGeneral()
        {
            bool llgReturn = false;
            try
            {
                    // verificar si el perfil tiene permiso
                    if (string.IsNullOrEmpty(gcrSIS_PerfilCmdEDT))
                    {
                        gcrSIS_PerfilCmdEDT = SysModelo.fcrValidarAcccionPerfil(oApp.gcrUsuCodigoPerfil, gcrIdVistaModeloForm + "-CMDMODIFICAR-EDT", "EDT");
                    }
                    if (gcrSIS_PerfilCmdEDT == "OK") { llgReturn = true; } else { llgReturn = false; }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: CanEDT");
            }
            return llgReturn;
        }
        #endregion
        #endregion
        #region Comandos de activacion Botones gestion imagenes predefinidas
        #region CanImgPredefBuscar
        /// <summary>
        /// Activar buscar nuevo item para lista de imagenes predefinidas
        /// </summary>
        public bool CanImgPredefBuscar()
        {
            bool llgReturn = false;
            try
            {
                glgPuedeEditarImgPredefinidas = false;
                if (GlgSIS_ModoEdicion == true && G1Grp_tipfor_grpl == "PLANTILLA")
                {
                    llgReturn = true;
                    glgPuedeEditarImgPredefinidas = true;
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: CanImgPredefBuscar");
            }
            return llgReturn;
        }
        #endregion
        #region CanImgPredefNuevo
        /// <summary>
        /// Activar Adicionar nuevo item a lista de imagenes predefinidas
        /// </summary>
        public bool CanImgPredefNuevo()
        {
            bool llgReturn = false;
            try
            {
                glgPuedeEditarImgPredefinidas = false;
                if (GlgSIS_ModoEdicion == true && G1Grp_tipfor_grpl == "PLANTILLA")
                {
                    llgReturn = true;
                    glgPuedeEditarImgPredefinidas = true;
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: CanImgPredefNuevo");
            }
            return llgReturn;
        }
        #endregion
        #region CanImgPredefSave
        /// <summary>
        /// Activar Guardar nuevo item a lista de imagenes predefinidas
        /// </summary>
        public bool CanImgPredefSave()
        {
            bool llgReturn = false;
            try
            {
                if (GlgSIS_ModoEdicion == true && G1Grp_tipfor_grpl == "PLANTILLA")
                {
                    #region Valores Variables
                    llgReturn = String.IsNullOrEmpty(fcrValidacion("PropGalTxtTitulo")) &&
                                String.IsNullOrEmpty(fcrValidacion("PropGalTxtHeight")) &&
                                String.IsNullOrEmpty(fcrValidacion("PropGalTxtWidth"));
                    #endregion
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: CanImgPredefSave");
            }
            return llgReturn;
        }
        #endregion
        #region CanImgPredefEliminar
        /// <summary>
        /// Activar Eliminar item en lista de imagenes predefinidas
        /// </summary>
        public bool CanImgPredefEliminar()
        {
            bool llgReturn = false;
            try
            {
                if (GlgSIS_ModoEdicion == true && G1Grp_tipfor_grpl == "PLANTILLA")
                {
                    llgReturn = regImgPredefItems != null ? true : false;
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: CanImgPredefEliminar");
            }
            return llgReturn;
        }
        #endregion
        #endregion
        //-------------------------------------------------
        // Region Para los Metodos Cargan los valores desde
        // variables al registro activo o lo contrario
        //-------------------------------------------------
        #region Iniciar Valores de Variables
        #region Reiniciar Variables
        /// <summary>
        /// Reiniciar Variables
        /// </summary>
        public virtual void fcvReiniVariables()
        {
            try
            {
                #region Valores Variables maestro plantillas
                G1Grp_idepla_grpl = String.Empty;
                G1Grp_despla_grpl = String.Empty;
                G1Grp_hl7for_grpl = String.Empty;
                G1Grp_idegru_grpg = String.Empty;
                G1Grp_tipfor_grpl = String.Empty;
                G1Grc_iderec_grcm = String.Empty;
                G1Grp_conver_grpl = 0;
                G1Grp_conobj_grpl = 0;
                G1Grp_prefij_grpl = String.Empty;
                G1Grp_idepla_grpv = String.Empty;
                G1Sis_estreg_esrg = "1";
                G1Grp_desgru_grpg = String.Empty;
                G1Grc_desrec_grcm = String.Empty;
                G1Sis_desest_esrg = String.Empty;
                TmpG1RegActivo = new ModeloPlantilla();
                #endregion
                #region Valores Variables Version plantilla
                G2Grp_idepla_grpv = String.Empty;
                G2Grp_verpla_grpv = String.Empty;
                G2Grp_xmlpla_grpv = String.Empty;
                G2Grp_xmlplb_grpv = String.Empty;
                G2Grp_xmlplc_grpv = String.Empty;
                G2Grp_xmlpld_grpv = String.Empty;
                G2Grp_numver_grpv = 0;
                G2Grp_hojalt_grpv = 0;
                G2Grp_hojanc_grpv = 0;
                G2Grp_marver_grpv = 0;
                G2Grp_marhor_grpv = 0;
                G2Grp_epapel_grpv = String.Empty;
                G2Grp_estilo_grpv = "NA";           // por ahora
                G2Grp_decima_grpv = gcrSeparadorDecimal;
                G2Sis_estreg_esrg = "1";
                G2Sis_desest_esrg = String.Empty;

                TmpG2RegActivo  = new VersionPlantilla();
                #endregion
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: ReiniVariables");
            }
        }
        #endregion
        #region Cargar Registro activo desde Variables
        /// <summary>
        /// Cargar Registro activo desde Variables
        /// </summary>
        public virtual void fcvCargarRegActivoDesdeVariables()
        {
            try
            {
                #region Valores Variables maestro plantillas
                TmpG1RegActivo.Grp_idepla_grpl = G1Grp_idepla_grpl;
                TmpG1RegActivo.Grp_despla_grpl = G1Grp_despla_grpl;
                TmpG1RegActivo.Grp_hl7for_grpl = G1Grp_hl7for_grpl;
                TmpG1RegActivo.Grp_idegru_grpg = G1Grp_idegru_grpg;
                TmpG1RegActivo.Grp_tipfor_grpl = G1Grp_tipfor_grpl;
                TmpG1RegActivo.Grc_iderec_grcm = G1Grc_iderec_grcm;
                TmpG1RegActivo.Grp_conver_grpl = G1Grp_conver_grpl;
                TmpG1RegActivo.Grp_conobj_grpl = G1Grp_conobj_grpl;
                TmpG1RegActivo.Grp_prefij_grpl = G1Grp_prefij_grpl;
                TmpG1RegActivo.Grp_idepla_grpv = G1Grp_idepla_grpv;
                TmpG1RegActivo.Sis_estreg_esrg = G1Sis_estreg_esrg;
                TmpG1RegActivo.Grp_desgru_grpg = G1Grp_desgru_grpg;
                TmpG1RegActivo.Grc_desrec_grcm = G1Grc_desrec_grcm;
                TmpG1RegActivo.Sis_desest_esrg = G1Sis_desest_esrg;
                #endregion
                #region Valores Variables versión plantilla
                TmpG2RegActivo.Grp_idepla_grpv = G2Grp_idepla_grpv;
                TmpG2RegActivo.Grp_idepla_grpl = G1Grp_idepla_grpl;
                TmpG2RegActivo.Grp_verpla_grpv = G2Grp_verpla_grpv;
                TmpG2RegActivo.Grp_xmlpla_grpv = G2Grp_xmlpla_grpv;
                TmpG2RegActivo.Grp_xmlplb_grpv = G2Grp_xmlplb_grpv;
                TmpG2RegActivo.Grp_xmlplc_grpv = G2Grp_xmlplc_grpv;
                TmpG2RegActivo.Grp_xmlpld_grpv = G2Grp_xmlpld_grpv;
                TmpG2RegActivo.Grp_numver_grpv = G2Grp_numver_grpv;
                TmpG2RegActivo.Grp_hojalt_grpv = G2Grp_hojalt_grpv;
                TmpG2RegActivo.Grp_hojanc_grpv = G2Grp_hojanc_grpv;
                TmpG2RegActivo.Grp_marver_grpv = G2Grp_marver_grpv;
                TmpG2RegActivo.Grp_marhor_grpv = G2Grp_marhor_grpv;
                TmpG2RegActivo.Grp_epapel_grpv = G2Grp_epapel_grpv;
                TmpG2RegActivo.Grp_estilo_grpv = G2Grp_estilo_grpv;
                TmpG2RegActivo.Grp_decima_grpv = G2Grp_decima_grpv;
                TmpG2RegActivo.Sis_estreg_esrg = G2Sis_estreg_esrg;
                TmpG2RegActivo.Grp_despla_grpl = G1Grp_despla_grpl;
                TmpG2RegActivo.Sis_desest_esrg = G2Sis_desest_esrg;
                #endregion
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: fcvCargarVariablesEnRegActivo");
            }
        }
        #endregion
        #region Cargar Variables desde Registro activo
        /// <summary>
        /// Cargar Variables desde Registro activo
        /// </summary>
        public virtual void fcvCargarVariablesDesdeRegActivo()
        {
            try
            {
                #region Valores Variables maestro plantillas
                G1Grp_idepla_grpl = TmpG1RegActivo.Grp_idepla_grpl;
                G1Grp_despla_grpl = TmpG1RegActivo.Grp_despla_grpl;
                G1Grp_hl7for_grpl = TmpG1RegActivo.Grp_hl7for_grpl;
                G1Grp_idegru_grpg = TmpG1RegActivo.Grp_idegru_grpg;
                G1Grp_tipfor_grpl = TmpG1RegActivo.Grp_tipfor_grpl;
                G1Grc_iderec_grcm = TmpG1RegActivo.Grc_iderec_grcm;
                G1Grp_conver_grpl = TmpG1RegActivo.Grp_conver_grpl;
                G1Grp_conobj_grpl = TmpG1RegActivo.Grp_conobj_grpl;
                G1Grp_prefij_grpl = TmpG1RegActivo.Grp_prefij_grpl;
                G1Grp_idepla_grpv = TmpG1RegActivo.Grp_idepla_grpv;
                G1Sis_estreg_esrg = TmpG1RegActivo.Sis_estreg_esrg;
                G1Grp_desgru_grpg = TmpG1RegActivo.Grp_desgru_grpg;
                G1Grc_desrec_grcm = TmpG1RegActivo.Grc_desrec_grcm;
                G1Sis_desest_esrg = TmpG1RegActivo.Sis_desest_esrg;
                #endregion
                #region Valores Variables versión plantilla
                G2Grp_idepla_grpv = TmpG2RegActivo.Grp_idepla_grpv;
                G2Grp_verpla_grpv = TmpG2RegActivo.Grp_verpla_grpv;
                G2Grp_xmlpla_grpv = TmpG2RegActivo.Grp_xmlpla_grpv;
                G2Grp_xmlplb_grpv = TmpG2RegActivo.Grp_xmlplb_grpv;
                G2Grp_xmlplc_grpv = TmpG2RegActivo.Grp_xmlplc_grpv;
                G2Grp_xmlpld_grpv = TmpG2RegActivo.Grp_xmlpld_grpv;
                G2Grp_numver_grpv = TmpG2RegActivo.Grp_numver_grpv;
                G2Grp_hojalt_grpv = TmpG2RegActivo.Grp_hojalt_grpv;
                G2Grp_hojanc_grpv = TmpG2RegActivo.Grp_hojanc_grpv;
                G2Grp_marver_grpv = TmpG2RegActivo.Grp_marver_grpv;
                G2Grp_marhor_grpv = TmpG2RegActivo.Grp_marhor_grpv;
                G2Grp_epapel_grpv = TmpG2RegActivo.Grp_epapel_grpv;
                G2Grp_estilo_grpv = TmpG2RegActivo.Grp_estilo_grpv;
                G2Grp_decima_grpv = TmpG2RegActivo.Grp_decima_grpv;
                G2Sis_estreg_esrg = TmpG2RegActivo.Sis_estreg_esrg;
                G2Sis_desest_esrg = TmpG2RegActivo.Sis_desest_esrg;
                #endregion
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: fcvCargarVariablesDesdeRegActivo");
            }
        }
        #endregion
        #endregion
    }
}

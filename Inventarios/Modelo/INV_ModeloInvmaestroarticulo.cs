//- MARMOTA-GENCODE: VERSION 2.0 - 07/11/2016 10:49:34 AM
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
    /// Descripcion para la Vista de  la tabla: invmaearticulos
    /// </summary>
    public class ModeloInvmaestroarticulo : clBaseInpc
    {
        #region Modelo Attributos
        private static DbAplicacion _context;
        #region Modelo Propiedades Notificacion
        #region Inv_secart_inar: Secuencial Unico
        private String _inv_secart_inar;
        /// <summary>
        /// <para>TABLA: invmaearticulos</para>
        /// <para>TABLA NATIVA: invmaearticulos</para>
        /// <para>CAMPO: Secuencial Unico</para>
        /// <para>NOMBRE: inv_secart_inar (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        ///Secuencial de articulo generado por el sistema
        /// </para>
        /// </summary>
        public String Inv_secart_inar
        {
            get { return _inv_secart_inar; }
            set
            {
                if (_inv_secart_inar == value) return;
                _inv_secart_inar = value;
                OnPropertyChanged("Inv_secart_inar");
            }
        }
        #endregion
        #region Inv_tipart_inar: Tipo articulo
        private String _inv_tipart_inar;
        /// <summary>
        /// <para>TABLA: invmaearticulos</para>
        /// <para>TABLA NATIVA: invmaearticulos</para>
        /// <para>CAMPO: Tipo articulo</para>
        /// <para>NOMBRE: inv_tipart_inar (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Tipo de articulo: 1=Suministro 2=Medicamentos
        /// </para>
        /// </summary>
        public String Inv_tipart_inar
        {
            get { return _inv_tipart_inar; }
            set
            {
                if (_inv_tipart_inar == value) return;
                _inv_tipart_inar = value;
                OnPropertyChanged("Inv_tipart_inar");
            }
        }
        #endregion
        #region Inv_codgru_ingr: Grupo Clasificación
        private String _inv_codgru_ingr;
        /// <summary>
        /// <para>TABLA: invmaearticulos</para>
        /// <para>TABLA NATIVA: invinventgrupos</para>
        /// <para>CAMPO: Grupo Clasificación</para>
        /// <para>NOMBRE: inv_codgru_ingr (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        /// Grupo de articulos para gestion contable y clasificacion de
        /// inventarios
        /// </para>
        /// </summary>
        public String Inv_codgru_ingr
        {
            get { return _inv_codgru_ingr; }
            set
            {
                if (_inv_codgru_ingr == value) return;
                _inv_codgru_ingr = value;
                OnPropertyChanged("Inv_codgru_ingr");
            }
        }
        #endregion
        #region Inv_codsub_insg: Subgrupo Clasificación
        private String _inv_codsub_insg;
        /// <summary>
        /// <para>TABLA: invmaearticulos</para>
        /// <para>TABLA NATIVA: invinventsubgru</para>
        /// <para>CAMPO: Subgrupo Clasificación</para>
        /// <para>NOMBRE: inv_codsub_insg (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        /// Codigo subgrupo de articulos para gestion contable y clasificacion
        /// de inventarios
        /// </para>
        /// </summary>
        public String Inv_codsub_insg
        {
            get { return _inv_codsub_insg; }
            set
            {
                if (_inv_codsub_insg == value) return;
                _inv_codsub_insg = value;
                OnPropertyChanged("Inv_codsub_insg");
            }
        }
        #endregion
        #region Inv_codaux_inar: Código Auxiliar
        private String _inv_codaux_inar;
        /// <summary>
        /// <para>TABLA: invmaearticulos</para>
        /// <para>TABLA NATIVA: invmaearticulos</para>
        /// <para>CAMPO: Código Auxiliar</para>
        /// <para>NOMBRE: inv_codaux_inar (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        /// Código Auxiliar del articulo puede ser digitado por el usuario
        /// </para>
        /// </summary>
        public String Inv_codaux_inar
        {
            get { return _inv_codaux_inar; }
            set
            {
                if (_inv_codaux_inar == value) return;
                _inv_codaux_inar = value;
                OnPropertyChanged("Inv_codaux_inar");
            }
        }
        #endregion
        #region Inv_codbar_inar: Código Barra
        private String _inv_codbar_inar;
        /// <summary>
        /// <para>TABLA: invmaearticulos</para>
        /// <para>TABLA NATIVA: invmaearticulos</para>
        /// <para>CAMPO: Código Barra</para>
        /// <para>NOMBRE: inv_codbar_inar (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        ///Código de Barra Artículo
        /// </para>
        /// </summary>
        public String Inv_codbar_inar
        {
            get { return _inv_codbar_inar; }
            set
            {
                if (_inv_codbar_inar == value) return;
                _inv_codbar_inar = value;
                OnPropertyChanged("Inv_codbar_inar");
            }
        }
        #endregion
        #region Inv_lotref_inar: Lote o Referencia
        private String _inv_lotref_inar;
        /// <summary>
        /// <para>TABLA: invmaearticulos</para>
        /// <para>TABLA NATIVA: invmaearticulos</para>
        /// <para>CAMPO: Lote o Referencia</para>
        /// <para>NOMBRE: inv_lotref_inar (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        ///Lote o Referencia del articulo Artículo
        /// </para>
        /// </summary>
        public String Inv_lotref_inar
        {
            get { return _inv_lotref_inar; }
            set
            {
                if (_inv_lotref_inar == value) return;
                _inv_lotref_inar = value;
                OnPropertyChanged("Inv_lotref_inar");
            }
        }
        #endregion
        #region Inv_regsan_inar: Registro sanitario
        private String _inv_regsan_inar;
        /// <summary>
        /// <para>TABLA: invmaearticulos</para>
        /// <para>TABLA NATIVA: invmaearticulos</para>
        /// <para>CAMPO: Registro sanitario</para>
        /// <para>NOMBRE: inv_regsan_inar (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        ///Registro sanitario (IMVIMA)
        /// </para>
        /// </summary>
        public String Inv_regsan_inar
        {
            get { return _inv_regsan_inar; }
            set
            {
                if (_inv_regsan_inar == value) return;
                _inv_regsan_inar = value;
                OnPropertyChanged("Inv_regsan_inar");
            }
        }
        #endregion
        #region Inv_nomart_inar: Nombre artículo
        private String _inv_nomart_inar;
        /// <summary>
        /// <para>TABLA: invmaearticulos</para>
        /// <para>TABLA NATIVA: invmaearticulos</para>
        /// <para>CAMPO: Nombre artículo</para>
        /// <para>NOMBRE: inv_nomart_inar (char:80)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION:
        ///Nombre del artículo para vista en informes y gestion
        /// </para>
        /// </summary>
        public String Inv_nomart_inar
        {
            get { return _inv_nomart_inar; }
            set
            {
                if (_inv_nomart_inar == value) return;
                _inv_nomart_inar = value;
                OnPropertyChanged("Inv_nomart_inar");
            }
        }
        #endregion
        #region Inv_desart_inar: Descripción Artículo
        private String _inv_desart_inar;
        /// <summary>
        /// <para>TABLA: invmaearticulos</para>
        /// <para>TABLA NATIVA: invmaearticulos</para>
        /// <para>CAMPO: Descripción Artículo</para>
        /// <para>NOMBRE: inv_desart_inar (char:250)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
        /// <para>DESCRIPCION:
        ///Descripción del larga del artículo 250 caracteres
        /// </para>
        /// </summary>
        public String Inv_desart_inar
        {
            get { return _inv_desart_inar; }
            set
            {
                if (_inv_desart_inar == value) return;
                _inv_desart_inar = value;
                OnPropertyChanged("Inv_desart_inar");
            }
        }
        #endregion
        #region Inv_secimg_inaj: Código imagen JPG PNG
        private String _inv_secimg_inaj;
        /// <summary>
        /// <para>TABLA: invmaearticulos</para>
        /// <para>TABLA NATIVA: invmaeartimagen</para>
        /// <para>CAMPO: Código imagen JPG PNG</para>
        /// <para>NOMBRE: inv_secimg_inaj (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 11</para>
        /// <para>DESCRIPCION:
        /// Codgo imagen JPG o PNG que representa la grafica del articulo
        /// en vista por defecto
        /// </para>
        /// </summary>
        public String Inv_secimg_inaj
        {
            get { return _inv_secimg_inaj; }
            set
            {
                if (_inv_secimg_inaj == value) return;
                _inv_secimg_inaj = value;
                OnPropertyChanged("Inv_secimg_inaj");
            }
        }
        #endregion
        #region Inv_simcrt_inar: Medicamento de control
        private String _inv_simcrt_inar;
        /// <summary>
        /// <para>TABLA: invmaearticulos</para>
        /// <para>TABLA NATIVA: invmaearticulos</para>
        /// <para>CAMPO: Medicamento de control</para>
        /// <para>NOMBRE: inv_simcrt_inar (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 12</para>
        /// <para>DESCRIPCION:
        /// Activar si el medicamento es de control: 1=Medicamento Es de
        /// control 2=Medicamento no es de control 3=No es medicamento
        /// </para>
        /// </summary>
        public String Inv_simcrt_inar
        {
            get { return _inv_simcrt_inar; }
            set
            {
                if (_inv_simcrt_inar == value) return;
                _inv_simcrt_inar = value;
                OnPropertyChanged("Inv_simcrt_inar");
            }
        }
        #endregion
        #region Far_forfar_fama: Forma Farmaceutica
        private String _far_forfar_fama;
        /// <summary>
        /// <para>TABLA: invmaearticulos</para>
        /// <para>TABLA NATIVA: invmaearticulos</para>
        /// <para>CAMPO: Forma Farmaceutica</para>
        /// <para>NOMBRE: far_forfar_fama (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 13</para>
        /// <para>DESCRIPCION:
        ///Forma farmaceutica del medicamento para RIPS
        /// </para>
        /// </summary>
        public String Far_forfar_fama
        {
            get { return _far_forfar_fama; }
            set
            {
                if (_far_forfar_fama == value) return;
                _far_forfar_fama = value;
                OnPropertyChanged("Far_forfar_fama");
            }
        }
        #endregion
        #region Far_concen_fama: Concentracion medicamento
        private String _far_concen_fama;
        /// <summary>
        /// <para>TABLA: invmaearticulos</para>
        /// <para>TABLA NATIVA: invmaearticulos</para>
        /// <para>CAMPO: Concentracion medicamento</para>
        /// <para>NOMBRE: far_concen_fama (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 14</para>
        /// <para>DESCRIPCION:
        ///Concentracion del medicamento para RIPS
        /// </para>
        /// </summary>
        public String Far_concen_fama
        {
            get { return _far_concen_fama; }
            set
            {
                if (_far_concen_fama == value) return;
                _far_concen_fama = value;
                OnPropertyChanged("Far_concen_fama");
            }
        }
        #endregion
        #region Far_unimed_fama: Descripcion Unidad medida
        private String _far_unimed_fama;
        /// <summary>
        /// <para>TABLA: invmaearticulos</para>
        /// <para>TABLA NATIVA: farexpedmedicma</para>
        /// <para>CAMPO: Descripcion Unidad medida</para>
        /// <para>NOMBRE: far_unimed_fama (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 15</para>
        /// <para>DESCRIPCION:
        ///Descripcion Unidad medida del medicamento para RIPS
        /// </para>
        /// </summary>
        public String Far_unimed_fama
        {
            get { return _far_unimed_fama; }
            set
            {
                if (_far_unimed_fama == value) return;
                _far_unimed_fama = value;
                OnPropertyChanged("Far_unimed_fama");
            }
        }
        #endregion
        #region Far_codcum_famd: Código CUM
        private String _far_codcum_famd;
        /// <summary>
        /// <para>TABLA: invmaearticulos</para>
        /// <para>TABLA NATIVA: invmaearticulos</para>
        /// <para>CAMPO: Código CUM</para>
        /// <para>NOMBRE: far_codcum_famd (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 16</para>
        /// <para>DESCRIPCION:
        /// Codigo CUM del medicamento (clasificacion unica de medicamentos)
        /// </para>
        /// </summary>
        public String Far_codcum_famd
        {
            get { return _far_codcum_famd; }
            set
            {
                if (_far_codcum_famd == value) return;
                _far_codcum_famd = value;
                OnPropertyChanged("Far_codcum_famd");
            }
        }
        #endregion
        #region Inv_gesips_inar: Activar servicio IPS
        private String _inv_gesips_inar;
        /// <summary>
        /// <para>TABLA: invmaearticulos</para>
        /// <para>TABLA NATIVA: invmaearticulos</para>
        /// <para>CAMPO: Activar servicio IPS</para>
        /// <para>NOMBRE: inv_gesips_inar (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 17</para>
        /// <para>DESCRIPCION:
        /// Activar gestion de servicios IPS, para enlace con manuales
        /// tarifarios y facturacion: 1= Activar referencia a servicio
        /// IPS 2= Inactivar referencia a servicio IPS
        /// </para>
        /// </summary>
        public String Inv_gesips_inar
        {
            get { return _inv_gesips_inar; }
            set
            {
                if (_inv_gesips_inar == value) return;
                _inv_gesips_inar = value;
                OnPropertyChanged("Inv_gesips_inar");
            }
        }
        #endregion
        #region Fcm_idesec_sips: Servicio IPS
        private String _fcm_idesec_sips;
        /// <summary>
        /// <para>TABLA: invmaearticulos</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Servicio IPS</para>
        /// <para>NOMBRE: fcm_idesec_sips (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 18</para>
        /// <para>DESCRIPCION:</para>
        /// <para>Codigo unico secuencial del servicio IPS para referencia a gestion con modulo facturacion medica, 
        /// Cuando no aplique el valor es NA y el campo de activacion INV_GESIPS_INAR = 2
        /// </para>
        /// </summary>
        public String Fcm_idesec_sips
        {
            get { return _fcm_idesec_sips; }
            set
            {
                if (_fcm_idesec_sips == value) return;
                _fcm_idesec_sips = value;
                OnPropertyChanged("Fcm_idesec_sips");
            }
        }
        #endregion
        #region Fcm_coddig_mant: Código digitación servicio
        private String _fcm_coddig_mant;
        /// <summary>
        /// <para>TABLA: temporal</para>
        /// <para>TABLA NATIVA: fcmmanservicios</para>
        /// <para>CAMPO: Código digitación servicio</para>
        /// <para>NOMBRE: fcm_coddig_mant (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        /// Codigo para facilitar la digitacion del servicio en facturacion
        /// (pude ser el codigo en el tarifario) es un codigo auxiliar
        /// creado por el usuario administrador y unico en la tabla
        /// </para>
        /// </summary>
        public String Fcm_coddig_mant
        {
            get { return _fcm_coddig_mant; }
            set
            {
                if (_fcm_coddig_mant == value) return;
                _fcm_coddig_mant = value;
                OnPropertyChanged("Fcm_coddig_mant");
            }
        }
        #endregion
        #region Fcm_codser_sips: Código servicio en tarifario
        private String _fcm_codser_sips;
        /// <summary>
        /// <para>TABLA: temporal</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Código servicio en tarifario</para>
        /// <para>NOMBRE: fcm_codser_sips (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Codigo del servicio para venta y RIPS, pude ser codigo SOAT
        /// ISS o CUPS (es modificable en configuración)
        /// </para>
        /// </summary>
        public String Fcm_codser_sips
        {
            get { return _fcm_codser_sips; }
            set
            {
                if (_fcm_codser_sips == value) return;
                _fcm_codser_sips = value;
                OnPropertyChanged("Fcm_codser_sips");
            }
        }
        #endregion
        #region Far_grufar_fagf: Grupo farmaceutico
        private String _far_grufar_fagf;
        /// <summary>
        /// <para>TABLA: invmaearticulos</para>
        /// <para>TABLA NATIVA: fargrufarmacoma</para>
        /// <para>CAMPO: Grupo farmaceutico</para>
        /// <para>NOMBRE: far_grufar_fagf (char:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 19</para>
        /// <para>DESCRIPCION:
        /// Grupo farmaceutico cuando el articulos es un medicamento, NA
        /// Cuando no no aplique
        /// </para>
        /// </summary>
        public String Far_grufar_fagf
        {
            get { return _far_grufar_fagf; }
            set
            {
                if (_far_grufar_fagf == value) return;
                _far_grufar_fagf = value;
                OnPropertyChanged("Far_grufar_fagf");
            }
        }
        #endregion
        #region Far_sugfar_fasg: Subgrupo farmaceutico
        private String _far_sugfar_fasg;
        /// <summary>
        /// <para>TABLA: invmaearticulos</para>
        /// <para>TABLA NATIVA: fargrufarmacomd</para>
        /// <para>CAMPO: Subgrupo farmaceutico</para>
        /// <para>NOMBRE: far_sugfar_fasg (char:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 20</para>
        /// <para>DESCRIPCION:
        /// Subgrupo farmacologico del medicamento, NA cuando no aplique
        /// </para>
        /// </summary>
        public String Far_sugfar_fasg
        {
            get { return _far_sugfar_fasg; }
            set
            {
                if (_far_sugfar_fasg == value) return;
                _far_sugfar_fasg = value;
                OnPropertyChanged("Far_sugfar_fasg");
            }
        }
        #endregion
        #region Sis_codgme_sigr: Patrón medida
        private String _sis_codgme_sigr;
        /// <summary>
        /// <para>TABLA: invmaearticulos</para>
        /// <para>TABLA NATIVA: sisgrupomedidas</para>
        /// <para>CAMPO: Patrón medida</para>
        /// <para>NOMBRE: sis_codgme_sigr (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 21</para>
        /// <para>DESCRIPCION:
        /// Codigo Tipo de Unidad de Medida (Unidades,volumen,masa,etc..)
        /// </para>
        /// </summary>
        public String Sis_codgme_sigr
        {
            get { return _sis_codgme_sigr; }
            set
            {
                if (_sis_codgme_sigr == value) return;
                _sis_codgme_sigr = value;
                OnPropertyChanged("Sis_codgme_sigr");
            }
        }
        #endregion
        #region Sis_codume_sium: Medida Almacenamiento
        private String _sis_codume_sium;
        /// <summary>
        /// <para>TABLA: invmaearticulos</para>
        /// <para>TABLA NATIVA: sisunidadmedida</para>
        /// <para>CAMPO: Medida Almacenamiento</para>
        /// <para>NOMBRE: sis_codume_sium (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 22</para>
        /// <para>DESCRIPCION:
        /// Tipo Unidad de Medida para almacenamiento y consumo: Unidades,Milimetros,
        /// Litros,Gramos y otros
        /// </para>
        /// </summary>
        public String Sis_codume_sium
        {
            get { return _sis_codume_sium; }
            set
            {
                if (_sis_codume_sium == value) return;
                _sis_codume_sium = value;
                OnPropertyChanged("Sis_codume_sium");
            }
        }
        #endregion
        #region Inv_codctn_intc: Contenedor de gestion
        private String _inv_codctn_intc;
        /// <summary>
        /// <para>TABLA: invmaearticulos</para>
        /// <para>TABLA NATIVA: invcontenedores</para>
        /// <para>CAMPO: Contenedor de gestion</para>
        /// <para>NOMBRE: inv_codctn_intc (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 23</para>
        /// <para>DESCRIPCION:
        /// Tipo de Contenedor para gestion entradas y salidas del Inventario
        /// </para>
        /// </summary>
        public String Inv_codctn_intc
        {
            get { return _inv_codctn_intc; }
            set
            {
                if (_inv_codctn_intc == value) return;
                _inv_codctn_intc = value;
                OnPropertyChanged("Inv_codctn_intc");
            }
        }
        #endregion
        #region Inv_valing_inar: Costo Unidad ingreso
        private float _inv_valing_inar;
        /// <summary>
        /// <para>TABLA: invmaearticulos</para>
        /// <para>TABLA NATIVA: invmaearticulos</para>
        /// <para>CAMPO: Costo Unidad ingreso</para>
        /// <para>NOMBRE: inv_valing_inar (float:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 24</para>
        /// <para>DESCRIPCION:
        ///Valor  al Ingreso a Inventario o costo de compra unidad
        /// </para>
        /// </summary>
        public float Inv_valing_inar
        {
            get { return _inv_valing_inar; }
            set
            {
                if (_inv_valing_inar == value) return;
                _inv_valing_inar = value;
                OnPropertyChanged("Inv_valing_inar");
            }
        }
        #endregion
        #region Inv_uvalin_inar: Ultimo costo unidad
        private float _inv_uvalin_inar;
        /// <summary>
        /// <para>TABLA: invmaearticulos</para>
        /// <para>TABLA NATIVA: invmaearticulos</para>
        /// <para>CAMPO: Ultimo costo unidad</para>
        /// <para>NOMBRE: inv_uvalin_inar (float:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 25</para>
        /// <para>DESCRIPCION:
        /// Ultimo valor costo de ingreso por compra (costo inmediatamente
        /// anterior)
        /// </para>
        /// </summary>
        public float Inv_uvalin_inar
        {
            get { return _inv_uvalin_inar; }
            set
            {
                if (_inv_uvalin_inar == value) return;
                _inv_uvalin_inar = value;
                OnPropertyChanged("Inv_uvalin_inar");
            }
        }
        #endregion
        #region Inv_porive_inar: Porcentaje Incremento
        private float _inv_porive_inar;
        /// <summary>
        /// <para>TABLA: invmaearticulos</para>
        /// <para>TABLA NATIVA: invmaearticulos</para>
        /// <para>CAMPO: Porcentaje Incremento</para>
        /// <para>NOMBRE: inv_porive_inar (float:52)</para>
        /// <para>ORDEN VISTA EN TABLA: 26</para>
        /// <para>DESCRIPCION:
        /// Porcentaje de Incremento para Generar Precio de Venta (con
        /// Base  en Precio de Compra)
        /// </para>
        /// </summary>
        public float Inv_porive_inar
        {
            get { return _inv_porive_inar; }
            set
            {
                if (_inv_porive_inar == value) return;
                _inv_porive_inar = value;
                OnPropertyChanged("Inv_porive_inar");
            }
        }
        #endregion
        #region Inv_valmov_inar: Valor Unidad Salida
        private float _inv_valmov_inar;
        /// <summary>
        /// <para>TABLA: invmaearticulos</para>
        /// <para>TABLA NATIVA: invmaearticulos</para>
        /// <para>CAMPO: Valor Unidad Salida</para>
        /// <para>NOMBRE: inv_valmov_inar (float:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 27</para>
        /// <para>DESCRIPCION:
        /// Valor al Movimiento o venta este valor puede incluir porcentaje
        /// de incremento venta
        /// </para>
        /// </summary>
        public float Inv_valmov_inar
        {
            get { return _inv_valmov_inar; }
            set
            {
                if (_inv_valmov_inar == value) return;
                _inv_valmov_inar = value;
                OnPropertyChanged("Inv_valmov_inar");
            }
        }
        #endregion
        #region Sis_codiva_tiva: Codigo Valor I.V.A
        private String _sis_codiva_tiva;
        /// <summary>
        /// <para>TABLA: invmaearticulos</para>
        /// <para>TABLA NATIVA: sistablaiva</para>
        /// <para>CAMPO: Codigo Valor I.V.A</para>
        /// <para>NOMBRE: sis_codiva_tiva (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 28</para>
        /// <para>DESCRIPCION:
        ///Código de IVA aplicable al Artículo
        /// </para>
        /// </summary>
        public String Sis_codiva_tiva
        {
            get { return _sis_codiva_tiva; }
            set
            {
                if (_sis_codiva_tiva == value) return;
                _sis_codiva_tiva = value;
                OnPropertyChanged("Sis_codiva_tiva");
            }
        }
        #endregion
        #region Inv_sistok_inar: Maneja stock minimo
        private String _inv_sistok_inar;
        /// <summary>
        /// <para>TABLA: invmaearticulos</para>
        /// <para>TABLA NATIVA: invmaearticulos</para>
        /// <para>CAMPO: Maneja stock minimo</para>
        /// <para>NOMBRE: inv_sistok_inar (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 29</para>
        /// <para>DESCRIPCION:
        /// Activar si el articulo maneja stock minimo y maximo: 1=Maneja
        /// stock minimo y maximo 2=No maneja stock minimo y maximo
        /// </para>
        /// </summary>
        public String Inv_sistok_inar
        {
            get { return _inv_sistok_inar; }
            set
            {
                if (_inv_sistok_inar == value) return;
                _inv_sistok_inar = value;
                OnPropertyChanged("Inv_sistok_inar");
            }
        }
        #endregion
        #region Inv_stkmin_inar: Stock minimo
        private int _inv_stkmin_inar;
        /// <summary>
        /// <para>TABLA: invmaearticulos</para>
        /// <para>TABLA NATIVA: invmaearticulos</para>
        /// <para>CAMPO: Stock minimo</para>
        /// <para>NOMBRE: inv_stkmin_inar (int:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 30</para>
        /// <para>DESCRIPCION:
        /// cantidad Stock minimo del articulo en inventario, 1=Manejar
        /// Stock minimo 2=No manejar Stock minimo
        /// </para>
        /// </summary>
        public int Inv_stkmin_inar
        {
            get { return _inv_stkmin_inar; }
            set
            {
                if (_inv_stkmin_inar == value) return;
                _inv_stkmin_inar = value;
                OnPropertyChanged("Inv_stkmin_inar");
            }
        }
        #endregion
        #region Inv_stkmax_inar: Stock maximo
        private int _inv_stkmax_inar;
        /// <summary>
        /// <para>TABLA: invmaearticulos</para>
        /// <para>TABLA NATIVA: invmaearticulos</para>
        /// <para>CAMPO: Stock maximo</para>
        /// <para>NOMBRE: inv_stkmax_inar (int:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 31</para>
        /// <para>DESCRIPCION:
        ///Cantidad Stock maximo del articulo en inventario
        /// </para>
        /// </summary>
        public int Inv_stkmax_inar
        {
            get { return _inv_stkmax_inar; }
            set
            {
                if (_inv_stkmax_inar == value) return;
                _inv_stkmax_inar = value;
                OnPropertyChanged("Inv_stkmax_inar");
            }
        }
        #endregion
        #region Inv_stkntf_inar: Unidades notificar stock
        private int _inv_stkntf_inar;
        /// <summary>
        /// <para>TABLA: invmaearticulos</para>
        /// <para>TABLA NATIVA: invmaearticulos</para>
        /// <para>CAMPO: Unidades notificar stock</para>
        /// <para>NOMBRE: inv_stkntf_inar (int:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 32</para>
        /// <para>DESCRIPCION:
        /// Numero de unidades para generar notificacion  antes de llegar
        /// a cantidad stock minimo ejemplo:  20 unidades antes
        /// </para>
        /// </summary>
        public int Inv_stkntf_inar
        {
            get { return _inv_stkntf_inar; }
            set
            {
                if (_inv_stkntf_inar == value) return;
                _inv_stkntf_inar = value;
                OnPropertyChanged("Inv_stkntf_inar");
            }
        }
        #endregion
        #region Inv_conreg_inar: Contador items
        private int _inv_conreg_inar;
        /// <summary>
        /// <para>TABLA: invmaearticulos</para>
        /// <para>TABLA NATIVA: invmaearticulos</para>
        /// <para>CAMPO: Contador items</para>
        /// <para>NOMBRE: inv_conreg_inar (int:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 33</para>
        /// <para>DESCRIPCION:
        /// Contador para generar el secuencial unico de registros en detalle
        /// (gestion interna)
        /// </para>
        /// </summary>
        public int Inv_conreg_inar
        {
            get { return _inv_conreg_inar; }
            set
            {
                if (_inv_conreg_inar == value) return;
                _inv_conreg_inar = value;
                OnPropertyChanged("Inv_conreg_inar");
            }
        }
        #endregion
        #region Inv_estart_inar: Estado Artículo
        private String _inv_estart_inar;
        /// <summary>
        /// <para>TABLA: invmaearticulos</para>
        /// <para>TABLA NATIVA: invmaearticulos</para>
        /// <para>CAMPO: Estado Artículo</para>
        /// <para>NOMBRE: inv_estart_inar (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 34</para>
        /// <para>DESCRIPCION:
        ///Estado Artículo 1=Activo 2=Inactivo
        /// </para>
        /// </summary>
        public String Inv_estart_inar
        {
            get { return _inv_estart_inar; }
            set
            {
                if (_inv_estart_inar == value) return;
                _inv_estart_inar = value;
                OnPropertyChanged("Inv_estart_inar");
            }
        }
        #endregion
        #region Inv_desgru_ingr: Descripcion Grupo
        private String _inv_desgru_ingr;
        /// <summary>
        /// <para>TABLA: invmaearticulos</para>
        /// <para>TABLA NATIVA: invinventgrupos</para>
        /// <para>CAMPO: Descripcion Grupo</para>
        /// <para>NOMBRE: inv_desgru_ingr (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Descripcion grupo de articulos para gestion contable y clasificacion
        /// de inventarios
        /// </para>
        /// </summary>
        public String Inv_desgru_ingr
        {
            get { return _inv_desgru_ingr; }
            set
            {
                if (_inv_desgru_ingr == value) return;
                _inv_desgru_ingr = value;
                OnPropertyChanged("Inv_desgru_ingr");
            }
        }
        #endregion
        #region Inv_dessub_insg: Descripcion Subgrupo
        private String _inv_dessub_insg;
        /// <summary>
        /// <para>TABLA: invmaearticulos</para>
        /// <para>TABLA NATIVA: invinventsubgru</para>
        /// <para>CAMPO: Descripcion Subgrupo</para>
        /// <para>NOMBRE: inv_dessub_insg (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        /// Descripcion subgrupo de articulos para gestion contable y clasificacion
        /// de inventarios
        /// </para>
        /// </summary>
        public String Inv_dessub_insg
        {
            get { return _inv_dessub_insg; }
            set
            {
                if (_inv_dessub_insg == value) return;
                _inv_dessub_insg = value;
                OnPropertyChanged("Inv_dessub_insg");
            }
        }
        #endregion
        #region Inv_nomimg_inaj: Archivo imagen
        private String _inv_nomimg_inaj;
        /// <summary>
        /// <para>TABLA: invmaearticulos</para>
        /// <para>TABLA NATIVA: invmaeartimagen</para>
        /// <para>CAMPO: Archivo imagen</para>
        /// <para>NOMBRE: inv_nomimg_inaj (char:50)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        /// Nombre completo de la imagene con extencion ejemplo: A453_ARTICULO_2.PNG
        /// </para>
        /// </summary>
        public String Inv_nomimg_inaj
        {
            get { return _inv_nomimg_inaj; }
            set
            {
                if (_inv_nomimg_inaj == value) return;
                _inv_nomimg_inaj = value;
                OnPropertyChanged("Inv_nomimg_inaj");
            }
        }
        #endregion
        #region Fcm_desser_sips: Nombre servicio
        private String _fcm_desser_sips;
        /// <summary>
        /// <para>TABLA: invmaearticulos</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Nombre servicio</para>
        /// <para>NOMBRE: fcm_desser_sips (char:250)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        ///Descripción textual del servicio IPS
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
        #region Far_desgru_fagf: Descripcion Grupo
        private String _far_desgru_fagf;
        /// <summary>
        /// <para>TABLA: invmaearticulos</para>
        /// <para>TABLA NATIVA: fargrufarmacoma</para>
        /// <para>CAMPO: Descripcion Grupo</para>
        /// <para>NOMBRE: far_desgru_fagf (char:100)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        ///Descripcion grupo farmacologico del medicamento
        /// </para>
        /// </summary>
        public String Far_desgru_fagf
        {
            get { return _far_desgru_fagf; }
            set
            {
                if (_far_desgru_fagf == value) return;
                _far_desgru_fagf = value;
                OnPropertyChanged("Far_desgru_fagf");
            }
        }
        #endregion
        #region Far_desgru_fasg: Descripcion Subgrupo
        private String _far_desgru_fasg;
        /// <summary>
        /// <para>TABLA: invmaearticulos</para>
        /// <para>TABLA NATIVA: fargrufarmacomd</para>
        /// <para>CAMPO: Descripcion Subgrupo</para>
        /// <para>NOMBRE: far_desgru_fasg (char:150)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        ///Descripcion del subgrupo farmacologico del medicamento
        /// </para>
        /// </summary>
        public String Far_desgru_fasg
        {
            get { return _far_desgru_fasg; }
            set
            {
                if (_far_desgru_fasg == value) return;
                _far_desgru_fasg = value;
                OnPropertyChanged("Far_desgru_fasg");
            }
        }
        #endregion
        #region Sis_desgme_sigr: Descripción Grupo medida
        private String _sis_desgme_sigr;
        /// <summary>
        /// <para>TABLA: invmaearticulos</para>
        /// <para>TABLA NATIVA: sisgrupomedidas</para>
        /// <para>CAMPO: Descripción Grupo medida</para>
        /// <para>NOMBRE: sis_desgme_sigr (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripción del Grupo de Medidas
        /// </para>
        /// </summary>
        public String Sis_desgme_sigr
        {
            get { return _sis_desgme_sigr; }
            set
            {
                if (_sis_desgme_sigr == value) return;
                _sis_desgme_sigr = value;
                OnPropertyChanged("Sis_desgme_sigr");
            }
        }
        #endregion
        #region Sis_desume_sium: Descripción unidad medida
        private String _sis_desume_sium;
        /// <summary>
        /// <para>TABLA: invmaearticulos</para>
        /// <para>TABLA NATIVA: sisunidadmedida</para>
        /// <para>CAMPO: Descripción unidad medida</para>
        /// <para>NOMBRE: sis_desume_sium (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripción de la unidad de Medida
        /// </para>
        /// </summary>
        public String Sis_desume_sium
        {
            get { return _sis_desume_sium; }
            set
            {
                if (_sis_desume_sium == value) return;
                _sis_desume_sium = value;
                OnPropertyChanged("Sis_desume_sium");
            }
        }
        #endregion
        #region Inv_desctn_intc: Descripción Contenedor
        private String _inv_desctn_intc;
        /// <summary>
        /// <para>TABLA: invmaearticulos</para>
        /// <para>TABLA NATIVA: invcontenedores</para>
        /// <para>CAMPO: Descripción Contenedor</para>
        /// <para>NOMBRE: inv_desctn_intc (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripción del contenedor de Artículo o presentación
        /// </para>
        /// </summary>
        public String Inv_desctn_intc
        {
            get { return _inv_desctn_intc; }
            set
            {
                if (_inv_desctn_intc == value) return;
                _inv_desctn_intc = value;
                OnPropertyChanged("Inv_desctn_intc");
            }
        }
        #endregion
        #region Sis_desiva_tiva: Descripción del I.V.A
        private String _sis_desiva_tiva;
        /// <summary>
        /// <para>TABLA: invmaearticulos</para>
        /// <para>TABLA NATIVA: sistablaiva</para>
        /// <para>CAMPO: Descripción del I.V.A</para>
        /// <para>NOMBRE: sis_desiva_tiva (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripción del I.V.A Ejemplo 16%
        /// </para>
        /// </summary>
        public String Sis_desiva_tiva
        {
            get { return _sis_desiva_tiva; }
            set
            {
                if (_sis_desiva_tiva == value) return;
                _sis_desiva_tiva = value;
                OnPropertyChanged("Sis_desiva_tiva");
            }
        }
        #endregion
        #endregion
        #endregion
        #region Metodos para edicion de registros
        #region Adicionar Registro
        public static String flgAddRegistro(ModeloInvmaestroarticulo tobjModelo)
        {
            var lcrCodigoGen = SysModelo.fcrGenerarNuevoCodigo("INV-MAE-ART", "INV", "Maestro de Articulos");
            try
            {
                if (!flgBuscarInvmaearticulos(lcrCodigoGen))
                {
                    using (_context = new DbAplicacion())
                    {
                        var lobjRegistro = new EFinvmaearticulos
                        {
                            #region cargar Registro
                            inv_secart_inar = tobjModelo.Inv_secart_inar,
                            inv_tipart_inar = tobjModelo.Inv_tipart_inar,
                            inv_codgru_ingr = tobjModelo.Inv_codgru_ingr,
                            inv_codsub_insg = tobjModelo.Inv_codsub_insg,
                            inv_codaux_inar = tobjModelo.Inv_codaux_inar,
                            inv_codbar_inar = tobjModelo.Inv_codbar_inar,
                            inv_lotref_inar = tobjModelo.Inv_lotref_inar,
                            inv_regsan_inar = tobjModelo.Inv_regsan_inar,
                            inv_nomart_inar = tobjModelo.Inv_nomart_inar,
                            inv_desart_inar = tobjModelo.Inv_desart_inar,
                            inv_secimg_inaj = tobjModelo.Inv_secimg_inaj,
                            inv_simcrt_inar = tobjModelo.Inv_simcrt_inar,
                            far_forfar_fama = tobjModelo.Far_forfar_fama,
                            far_concen_fama = tobjModelo.Far_concen_fama,
                            far_unimed_fama = tobjModelo.Far_unimed_fama,
                            far_codcum_famd = tobjModelo.Far_codcum_famd,
                            inv_gesips_inar = tobjModelo.Inv_gesips_inar,
                            fcm_idesec_sips = tobjModelo.Fcm_idesec_sips,
                            fcm_coddig_mant = tobjModelo.Fcm_coddig_mant,
                            far_grufar_fagf = tobjModelo.Far_grufar_fagf,
                            far_sugfar_fasg = tobjModelo.Far_sugfar_fasg,
                            sis_codgme_sigr = tobjModelo.Sis_codgme_sigr,
                            sis_codume_sium = tobjModelo.Sis_codume_sium,
                            inv_codctn_intc = tobjModelo.Inv_codctn_intc,
                            inv_valing_inar = tobjModelo.Inv_valing_inar,
                            inv_uvalin_inar = tobjModelo.Inv_uvalin_inar,
                            inv_porive_inar = tobjModelo.Inv_porive_inar,
                            inv_valmov_inar = tobjModelo.Inv_valmov_inar,
                            sis_codiva_tiva = tobjModelo.Sis_codiva_tiva,
                            inv_sistok_inar = tobjModelo.Inv_sistok_inar,
                            inv_stkmin_inar = tobjModelo.Inv_stkmin_inar,
                            inv_stkmax_inar = tobjModelo.Inv_stkmax_inar,
                            inv_stkntf_inar = tobjModelo.Inv_stkntf_inar,
                            inv_conreg_inar = tobjModelo.Inv_conreg_inar,
                            inv_estart_inar = tobjModelo.Inv_estart_inar,

                            #endregion
                        };
                        lobjRegistro.inv_secart_inar = lcrCodigoGen;
                        _context.AddToInvmaearticulos(lobjRegistro);
                        _context.SaveChanges();
                    }
                }
                else
                {
                    lcrCodigoGen = String.Empty;
                    MessageBox.Show("Nuevo codigo Generado esta desactualizado, revisar llave: \n" +
                                "'INV-MAE-ART': Maestro de Articulos en Maestro Secuenciales.");
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
        public static void fcvActualizar(ModeloInvmaestroarticulo tobjModelo)
        {
            try
            {
                using (_context = new DbAplicacion())
                {
                    var lobjRegistro = _context.Invmaearticulos.FirstOrDefault(p => p.inv_secart_inar == tobjModelo.Inv_secart_inar);
                    if (lobjRegistro != null)
                    {
                        #region cargar Registro
                        lobjRegistro.inv_secart_inar = tobjModelo.Inv_secart_inar;
                        lobjRegistro.inv_tipart_inar = tobjModelo.Inv_tipart_inar;
                        lobjRegistro.inv_codgru_ingr = tobjModelo.Inv_codgru_ingr;
                        lobjRegistro.inv_codsub_insg = tobjModelo.Inv_codsub_insg;
                        lobjRegistro.inv_codaux_inar = tobjModelo.Inv_codaux_inar;
                        lobjRegistro.inv_codbar_inar = tobjModelo.Inv_codbar_inar;
                        lobjRegistro.inv_lotref_inar = tobjModelo.Inv_lotref_inar;
                        lobjRegistro.inv_regsan_inar = tobjModelo.Inv_regsan_inar;
                        lobjRegistro.inv_nomart_inar = tobjModelo.Inv_nomart_inar;
                        lobjRegistro.inv_desart_inar = tobjModelo.Inv_desart_inar;
                        lobjRegistro.inv_secimg_inaj = tobjModelo.Inv_secimg_inaj;
                        lobjRegistro.inv_simcrt_inar = tobjModelo.Inv_simcrt_inar;
                        lobjRegistro.far_forfar_fama = tobjModelo.Far_forfar_fama;
                        lobjRegistro.far_concen_fama = tobjModelo.Far_concen_fama;
                        lobjRegistro.far_unimed_fama = tobjModelo.Far_unimed_fama;
                        lobjRegistro.far_codcum_famd = tobjModelo.Far_codcum_famd;
                        lobjRegistro.inv_gesips_inar = tobjModelo.Inv_gesips_inar;
                        lobjRegistro.fcm_idesec_sips = tobjModelo.Fcm_idesec_sips;
                        lobjRegistro.fcm_coddig_mant = tobjModelo.Fcm_coddig_mant;
                        lobjRegistro.far_grufar_fagf = tobjModelo.Far_grufar_fagf;
                        lobjRegistro.far_sugfar_fasg = tobjModelo.Far_sugfar_fasg;
                        lobjRegistro.sis_codgme_sigr = tobjModelo.Sis_codgme_sigr;
                        lobjRegistro.sis_codume_sium = tobjModelo.Sis_codume_sium;
                        lobjRegistro.inv_codctn_intc = tobjModelo.Inv_codctn_intc;
                        lobjRegistro.inv_valing_inar = (float)tobjModelo.Inv_valing_inar;
                        lobjRegistro.inv_uvalin_inar = (float)tobjModelo.Inv_uvalin_inar;
                        lobjRegistro.inv_porive_inar = (float)tobjModelo.Inv_porive_inar;
                        lobjRegistro.inv_valmov_inar = (float)tobjModelo.Inv_valmov_inar;
                        lobjRegistro.sis_codiva_tiva = tobjModelo.Sis_codiva_tiva;
                        lobjRegistro.inv_sistok_inar = tobjModelo.Inv_sistok_inar;
                        lobjRegistro.inv_stkmin_inar = (int)tobjModelo.Inv_stkmin_inar;
                        lobjRegistro.inv_stkmax_inar = (int)tobjModelo.Inv_stkmax_inar;
                        lobjRegistro.inv_stkntf_inar = (int)tobjModelo.Inv_stkntf_inar;
                        lobjRegistro.inv_conreg_inar = (int)tobjModelo.Inv_conreg_inar;
                        lobjRegistro.inv_estart_inar = tobjModelo.Inv_estart_inar;
                        #endregion
                        _context.SaveChanges();
                    }
                }
            }
            catch (NotImplementedException ex)
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
                    var lobjRegistro = _context.Invmaearticulos.FirstOrDefault(p => p.inv_secart_inar == tcrCodigo);
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
        #region Buscar INVMAEARTICULOS: Logica
        /// <summary>
        /// <para>TABLA: invmaearticulos</para>
        /// <para>TITULO: Tabla Maestro Artículos</para>
        /// <para>MODULO: INV</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Contiene el manual de artículos, los cuales alimentaran el
        /// inventario en la tabla maestro de inventario.
        /// </para>
        /// </summary>
        public static bool flgBuscarInvmaearticulos(String tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Invmaearticulos.FirstOrDefault(p => p.inv_secart_inar == tcrCodigo);
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
        /// 
        /// </summary>
        /// <param name="tcrBuscar">Texto a buscar</param>
        /// <param name="tcrTipoFiltro">"1"=Articulos o Suministros "2"=Medicamentos "3"=Todos</param>
        /// <returns></returns>
        public static List<ModeloInvmaestroarticulo> flsListaInvmaearticulos(String tcrBuscar, String tcrTipoFiltro)
        {
            using (_context = new DbAplicacion())
            {
                var lcrValor1 = tcrTipoFiltro;
                var lcrValor2 = tcrTipoFiltro;
                if (tcrTipoFiltro == "3")
                {
                    lcrValor1 = "1";
                    lcrValor2 = "2";
                }

                if (String.IsNullOrEmpty(tcrBuscar))
                {
                    var lobConsulta = from invmaearticulos in _context.Invmaearticulos
                                      join invinventgrupos in _context.Invinventgrupos on invmaearticulos.inv_codgru_ingr equals invinventgrupos.inv_codgru_ingr into tminvinventgrupos
                                      join invinventsubgru in _context.Invinventsubgru on invmaearticulos.inv_codsub_insg equals invinventsubgru.inv_codsub_insg into tminvinventsubgru
                                      join fcmmanservicips in _context.Fcmmanservicips on invmaearticulos.fcm_idesec_sips equals fcmmanservicips.fcm_idesec_sips into tmfcmmanservicips
                                      from ingr in tminvinventgrupos.DefaultIfEmpty()
                                      from insg in tminvinventsubgru.DefaultIfEmpty()
                                      from sips in tmfcmmanservicips.DefaultIfEmpty()
                                      where invmaearticulos.inv_tipart_inar == lcrValor1 ||
                                            invmaearticulos.inv_tipart_inar == lcrValor2
                                      select new ModeloInvmaestroarticulo
                                      {
                                          #region Datos
                                          Inv_secart_inar = invmaearticulos.inv_secart_inar,
                                          Inv_tipart_inar = invmaearticulos.inv_tipart_inar,
                                          Inv_codgru_ingr = invmaearticulos.inv_codgru_ingr,
                                          Inv_codsub_insg = invmaearticulos.inv_codsub_insg,
                                          Inv_codaux_inar = invmaearticulos.inv_codaux_inar,
                                          Inv_codbar_inar = invmaearticulos.inv_codbar_inar,
                                          Inv_lotref_inar = invmaearticulos.inv_lotref_inar,
                                          Inv_regsan_inar = invmaearticulos.inv_regsan_inar,
                                          Inv_nomart_inar = invmaearticulos.inv_nomart_inar,
                                          Inv_desart_inar = invmaearticulos.inv_desart_inar,
                                          Inv_secimg_inaj = invmaearticulos.inv_secimg_inaj,
                                          Inv_simcrt_inar = invmaearticulos.inv_simcrt_inar,
                                          Far_forfar_fama = invmaearticulos.far_forfar_fama,
                                          Far_concen_fama = invmaearticulos.far_concen_fama,
                                          Far_unimed_fama = invmaearticulos.far_unimed_fama,
                                          Far_codcum_famd = invmaearticulos.far_codcum_famd,
                                          Inv_gesips_inar = invmaearticulos.inv_gesips_inar,
                                          Fcm_idesec_sips = invmaearticulos.fcm_idesec_sips,
                                          Far_grufar_fagf = invmaearticulos.far_grufar_fagf,
                                          Far_sugfar_fasg = invmaearticulos.far_sugfar_fasg,
                                          Sis_codgme_sigr = invmaearticulos.sis_codgme_sigr,
                                          Sis_codume_sium = invmaearticulos.sis_codume_sium,
                                          Inv_codctn_intc = invmaearticulos.inv_codctn_intc,
                                          Inv_valing_inar = (float)invmaearticulos.inv_valing_inar,
                                          Inv_uvalin_inar = (float)invmaearticulos.inv_uvalin_inar,
                                          Inv_porive_inar = (float)invmaearticulos.inv_porive_inar,
                                          Inv_valmov_inar = (float)invmaearticulos.inv_valmov_inar,
                                          Sis_codiva_tiva = invmaearticulos.sis_codiva_tiva,
                                          Inv_sistok_inar = invmaearticulos.inv_sistok_inar,
                                          Inv_stkmin_inar = (int)invmaearticulos.inv_stkmin_inar,
                                          Inv_stkmax_inar = (int)invmaearticulos.inv_stkmax_inar,
                                          Inv_stkntf_inar = (int)invmaearticulos.inv_stkntf_inar,
                                          Inv_conreg_inar = (int)invmaearticulos.inv_conreg_inar,
                                          Inv_estart_inar = invmaearticulos.inv_estart_inar,
                                          Inv_desgru_ingr = ingr.inv_desgru_ingr,
                                          Inv_dessub_insg = insg.inv_dessub_insg,
                                          Fcm_desser_sips = sips.fcm_desser_sips,
                                          Fcm_codser_sips = sips.fcm_codser_sips,
                                          Fcm_coddig_mant = sips.fcm_coddig_mant,
                                          Inv_nomimg_inaj = _context.Invmaeartimagen.FirstOrDefault(x => x.inv_secimg_inaj == invmaearticulos.inv_secimg_inaj).inv_nomimg_inaj,
                                          Far_desgru_fagf = _context.Fargrufarmacoma.FirstOrDefault(x => x.far_grufar_fagf == invmaearticulos.far_grufar_fagf).far_desgru_fagf,
                                          Far_desgru_fasg = _context.Fargrufarmacomd.FirstOrDefault(x => x.far_sugfar_fasg == invmaearticulos.far_sugfar_fasg).far_desgru_fasg,
                                          Sis_desgme_sigr = _context.Sisgrupomedidas.FirstOrDefault(x => x.sis_codgme_sigr == invmaearticulos.sis_codgme_sigr).sis_desgme_sigr,
                                          Sis_desume_sium = _context.Sisunidadmedida.FirstOrDefault(x => x.sis_codume_sium == invmaearticulos.sis_codume_sium).sis_desume_sium,
                                          Inv_desctn_intc = _context.Invcontenedores.FirstOrDefault(x => x.inv_codctn_intc == invmaearticulos.inv_codctn_intc).inv_desctn_intc,
                                          Sis_desiva_tiva = _context.Sistablaiva.FirstOrDefault(x => x.sis_codiva_tiva == invmaearticulos.sis_codiva_tiva).sis_desiva_tiva,
                                          #endregion
                                      };
                    return lobConsulta.Take(300).ToList();
                }
                else
                {
                    var lobConsulta = from invmaearticulos in _context.Invmaearticulos
                                      join invinventgrupos in _context.Invinventgrupos on invmaearticulos.inv_codgru_ingr equals invinventgrupos.inv_codgru_ingr into tminvinventgrupos
                                      join invinventsubgru in _context.Invinventsubgru on invmaearticulos.inv_codsub_insg equals invinventsubgru.inv_codsub_insg into tminvinventsubgru
                                      join fcmmanservicips in _context.Fcmmanservicips on invmaearticulos.fcm_idesec_sips equals fcmmanservicips.fcm_idesec_sips into tmfcmmanservicips
                                      from ingr in tminvinventgrupos.DefaultIfEmpty()
                                      from insg in tminvinventsubgru.DefaultIfEmpty()
                                      from sips in tmfcmmanservicips.DefaultIfEmpty()
                                      where (invmaearticulos.inv_tipart_inar == lcrValor1 || invmaearticulos.inv_tipart_inar == lcrValor2) &&
                                            (invmaearticulos.inv_secart_inar.Contains(tcrBuscar) ||
                                            invmaearticulos.inv_codbar_inar.Contains(tcrBuscar) ||
                                            invmaearticulos.inv_codaux_inar.Contains(tcrBuscar) ||
                                            invmaearticulos.inv_regsan_inar.Contains(tcrBuscar) ||
                                            invmaearticulos.inv_lotref_inar.Contains(tcrBuscar) ||
                                            invmaearticulos.inv_nomart_inar.Contains(tcrBuscar))
                                      select new ModeloInvmaestroarticulo
                                      {
                                          #region Datos
                                          Inv_secart_inar = invmaearticulos.inv_secart_inar,
                                          Inv_tipart_inar = invmaearticulos.inv_tipart_inar,
                                          Inv_codgru_ingr = invmaearticulos.inv_codgru_ingr,
                                          Inv_codsub_insg = invmaearticulos.inv_codsub_insg,
                                          Inv_codaux_inar = invmaearticulos.inv_codaux_inar,
                                          Inv_codbar_inar = invmaearticulos.inv_codbar_inar,
                                          Inv_lotref_inar = invmaearticulos.inv_lotref_inar,
                                          Inv_regsan_inar = invmaearticulos.inv_regsan_inar,
                                          Inv_nomart_inar = invmaearticulos.inv_nomart_inar,
                                          Inv_desart_inar = invmaearticulos.inv_desart_inar,
                                          Inv_secimg_inaj = invmaearticulos.inv_secimg_inaj,
                                          Inv_simcrt_inar = invmaearticulos.inv_simcrt_inar,
                                          Far_forfar_fama = invmaearticulos.far_forfar_fama,
                                          Far_concen_fama = invmaearticulos.far_concen_fama,
                                          Far_unimed_fama = invmaearticulos.far_unimed_fama,
                                          Far_codcum_famd = invmaearticulos.far_codcum_famd,
                                          Inv_gesips_inar = invmaearticulos.inv_gesips_inar,
                                          Fcm_idesec_sips = invmaearticulos.fcm_idesec_sips,
                                          Far_grufar_fagf = invmaearticulos.far_grufar_fagf,
                                          Far_sugfar_fasg = invmaearticulos.far_sugfar_fasg,
                                          Sis_codgme_sigr = invmaearticulos.sis_codgme_sigr,
                                          Sis_codume_sium = invmaearticulos.sis_codume_sium,
                                          Inv_codctn_intc = invmaearticulos.inv_codctn_intc,
                                          Inv_valing_inar = (float)invmaearticulos.inv_valing_inar,
                                          Inv_uvalin_inar = (float)invmaearticulos.inv_uvalin_inar,
                                          Inv_porive_inar = (float)invmaearticulos.inv_porive_inar,
                                          Inv_valmov_inar = (float)invmaearticulos.inv_valmov_inar,
                                          Sis_codiva_tiva = invmaearticulos.sis_codiva_tiva,
                                          Inv_sistok_inar = invmaearticulos.inv_sistok_inar,
                                          Inv_stkmin_inar = (int)invmaearticulos.inv_stkmin_inar,
                                          Inv_stkmax_inar = (int)invmaearticulos.inv_stkmax_inar,
                                          Inv_stkntf_inar = (int)invmaearticulos.inv_stkntf_inar,
                                          Inv_conreg_inar = (int)invmaearticulos.inv_conreg_inar,
                                          Inv_estart_inar = invmaearticulos.inv_estart_inar,
                                          Inv_desgru_ingr = ingr.inv_desgru_ingr,
                                          Inv_dessub_insg = insg.inv_dessub_insg,
                                          Fcm_desser_sips = sips.fcm_desser_sips,
                                          Fcm_codser_sips = sips.fcm_codser_sips,
                                          Fcm_coddig_mant = sips.fcm_coddig_mant,
                                          Inv_nomimg_inaj = _context.Invmaeartimagen.FirstOrDefault(x => x.inv_secimg_inaj == invmaearticulos.inv_secimg_inaj).inv_nomimg_inaj,
                                          Far_desgru_fagf = _context.Fargrufarmacoma.FirstOrDefault(x => x.far_grufar_fagf == invmaearticulos.far_grufar_fagf).far_desgru_fagf,
                                          Far_desgru_fasg = _context.Fargrufarmacomd.FirstOrDefault(x => x.far_sugfar_fasg == invmaearticulos.far_sugfar_fasg).far_desgru_fasg,
                                          Sis_desgme_sigr = _context.Sisgrupomedidas.FirstOrDefault(x => x.sis_codgme_sigr == invmaearticulos.sis_codgme_sigr).sis_desgme_sigr,
                                          Sis_desume_sium = _context.Sisunidadmedida.FirstOrDefault(x => x.sis_codume_sium == invmaearticulos.sis_codume_sium).sis_desume_sium,
                                          Inv_desctn_intc = _context.Invcontenedores.FirstOrDefault(x => x.inv_codctn_intc == invmaearticulos.inv_codctn_intc).inv_desctn_intc,
                                          Sis_desiva_tiva = _context.Sistablaiva.FirstOrDefault(x => x.sis_codiva_tiva == invmaearticulos.sis_codiva_tiva).sis_desiva_tiva,
                                          #endregion
                                      };
                    return lobConsulta.Take(300).ToList();
                }
            }
        }
        #endregion
        #endregion
    }
}
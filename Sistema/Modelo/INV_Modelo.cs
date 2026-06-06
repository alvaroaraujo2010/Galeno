using System;
using System.Windows;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Datos.Modelos;
using Sistema.Clases;
using Sistema.Utilidades;

namespace Sistema.Modelo
{
    #region Modelo Maestro Kardex
    /// <summary>
    /// <para>Tabla invkardexmaestr: Maestro kardex movimientos de entradas y salidas resumen general</para>
    /// <para>en historico de todos los proceso de gestion de inventario</para>
    /// </summary>
    public class ModeloInvKardexMaestro : clBaseInpc
    {
        #region Modelo Attributos
        private static DbAplicacion _context;
        #region Modelo Propiedades Notificacion
        #region Inv_seckar_inka: Codigo registro
        /// <summary>
        /// <para>TABLA: invkardexmaestr</para>
        /// <para>TABLA NATIVA: invkardexmaestr</para>
        /// <para>CAMPO: Codigo registro</para>
        /// <para>NOMBRE: inv_seckar_inka (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        /// Secuencial unico para cada registro detalle de la tabla (generado
        /// por el sistema)
        /// </para>
        /// </summary>
        public String Inv_seckar_inka = String.Empty;
        #endregion
        #region Inv_codalm_inal: Código Almacén
        /// <summary>
        /// <para>TABLA: invkardexmaestr</para>
        /// <para>TABLA NATIVA: invalmacenmaest</para>
        /// <para>CAMPO: Código Almacén</para>
        /// <para>NOMBRE: inv_codalm_inal (char:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Código del Almacén que realiza el movimiento
        /// </para>
        /// </summary>
        public String Inv_codalm_inal = String.Empty;
        #endregion
        #region Inv_codper_inpe: Código periodo
        /// <summary>
        /// <para>TABLA: invkardexmaestr</para>
        /// <para>TABLA NATIVA: invperiodomaest</para>
        /// <para>CAMPO: Código periodo</para>
        /// <para>NOMBRE: inv_codper_inpe (char:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        /// Perido gestion datos (suma año + mes) ejemplo:  año 2016 mes
        /// febrero = 201602
        /// </para>
        /// </summary>
        public String Inv_codper_inpe = String.Empty;
        #endregion
        #region Inv_llavkr_inka: llave gestion
        /// <summary>
        /// <para>TABLA: invkardexmaestr</para>
        /// <para>TABLA NATIVA: invkardexmaestr</para>
        /// <para>CAMPO: llave gestion</para>
        /// <para>NOMBRE: inv_llavkr_inka (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        ///Llave gestion del registro kardex, suma: Almacen+P+Periodo
        /// </para>
        /// </summary>
        public String Inv_llavkr_inka = String.Empty;
        #endregion
        #region Inv_tiparc_inag: Tipo archivo gestion
        /// <summary>
        /// <para>TABLA: invkardexmaestr</para>
        /// <para>TABLA NATIVA: invtiparchigest</para>
        /// <para>CAMPO: Tipo archivo gestion</para>
        /// <para>NOMBRE: inv_tiparc_inag (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        /// Tipo archivo gestion origen del movimiento en maestro kardex:
        /// 01=Registro Inventario inicial 02=Saldo Diario Articulo 03=Gestion
        /// compras 04=Movimiento diario (traslado/gasto interno y otros)
        /// 05=Entrega medicamento 06=Ajuste inventario 07=Otros
        /// </para>
        /// </summary>
        public String Inv_tiparc_inag = String.Empty;
        #endregion
        #region Inv_fecges_inka: Fecha movimiento
        /// <summary>
        /// <para>TABLA: invkardexmaestr</para>
        /// <para>TABLA NATIVA: invkardexmaestr</para>
        /// <para>CAMPO: Fecha movimiento</para>
        /// <para>NOMBRE: inv_fecges_inka (fecha:)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        ///Fecha gestion registro o Movimiento
        /// </para>
        /// </summary>
        public DateTime Inv_fecges_inka = DateTime.Parse("01/01/0001");
        #endregion
        #region Inv_numdoc_inka: Numero documento
        /// <summary>
        /// <para>TABLA: invkardexmaestr</para>
        /// <para>TABLA NATIVA: invkardexmaestr</para>
        /// <para>CAMPO: Numero documento</para>
        /// <para>NOMBRE: inv_numdoc_inka (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        /// Numero Registro/documento de gestion movimiento (numero registro
        /// entradas por compra, Registro entrega medicamentos a pacientes
        /// en farmacia y otros) debe ser el reigstro maestro en cada proceso</para>
        /// </summary>
        public String Inv_numdoc_inka = String.Empty;
        #endregion
        #region Inv_refkar_inka: Referencia registro
        /// <summary>
        /// <para>TABLA: invkardexmaestr</para>
        /// <para>TABLA NATIVA: invkardexmaestr</para>
        /// <para>CAMPO: Referencia registro</para>
        /// <para>NOMBRE: inv_refkar_inka (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        /// Referencia (en esta misma tabla) a registro INV_SECKAR_INKA
        /// en existencias de articulo de donde se toman las unidades para
        /// llevarlas a registros de entradas/salida, NA= Cuando no aplica.
        /// </para>
        /// </summary>
        public String Inv_refkar_inka = String.Empty;
        #endregion
        #region Inv_tipreg_inka: Tipo reg gestion
        /// <summary>
        /// <para>TABLA: invkardexmaestr</para>
        /// <para>TABLA NATIVA: invkardexmaestr</para>
        /// <para>CAMPO: Tipo reg gestion</para>
        /// <para>NOMBRE: inv_tipreg_inka (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION:
        /// Tipo registro gestion kardex: 1=Saldo inicial inventario (antes de esto no hay ningun dato) 2= Movimientos de entradas o salidas</para>
        /// </summary>
        public String Inv_tipreg_inka = String.Empty;
        #endregion
        #region Inv_tipmov_intr: Tipo movimiento
        /// <summary>
        /// <para>TABLA: invkardexmaestr</para>
        /// <para>TABLA NATIVA: invtiporegimovi</para>
        /// <para>CAMPO: Tipo movimiento</para>
        /// <para>NOMBRE: inv_tipmov_intr (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
        /// <para>DESCRIPCION:
        /// Tipo registro movimiento inventarios: 1= Entradas 2= Salidas
        /// desde tabla: INVTIPOREGIMOVI
        /// </para>
        /// </summary>
        public String Inv_tipmov_intr = String.Empty;
        #endregion
        #region Inv_conmov_incm: Concepto Movimiento
        /// <summary>
        /// <para>TABLA: invkardexmaestr</para>
        /// <para>TABLA NATIVA: invtipoconcemov</para>
        /// <para>CAMPO: Concepto Movimiento</para>
        /// <para>NOMBRE: inv_conmov_incm (char:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 11</para>
        /// <para>DESCRIPCION:</para>
        /// <para>Concepto movimiento diario: E11 =Entrada saldo inicial inventario del mes E12= Entradas compras...</para>
        /// <para>S21= Salidas Ventas 22= Salidas Traslado S23= Salidas Otras Áreas Empresa S24= Salida entrega formula ... </para>
        /// </summary>
        public String Inv_conmov_incm = String.Empty;
        #endregion
        #region Inv_secart_inar: Secuencial  Articulo
        /// <summary>
        /// <para>TABLA: invkardexmaestr</para>
        /// <para>TABLA NATIVA: invmaearticulos</para>
        /// <para>CAMPO: Secuencial  Articulo</para>
        /// <para>NOMBRE: inv_secart_inar (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 12</para>
        /// <para>DESCRIPCION:
        /// Secuencial de articulo generado por el sistema viene de la
        /// tabla Maestro de Articulos
        /// </para>
        /// </summary>
        public String Inv_secart_inar = String.Empty;
        #endregion
        #region Inv_codaux_inar: Código Auxiliar Articulo
        /// <summary>
        /// <para>TABLA: invkardexmaestr</para>
        /// <para>TABLA NATIVA: invmaearticulos</para>
        /// <para>CAMPO: Código Auxiliar Articulo</para>
        /// <para>NOMBRE: inv_codaux_inar (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 13</para>
        /// <para>DESCRIPCION:
        /// Código Auxiliar del articulo puede ser digitado por el usuario
        /// </para>
        /// </summary>
        public String Inv_codaux_inar = String.Empty;
        #endregion
        #region Inv_codbar_inar: Código Barras Articulo
        /// <summary>
        /// <para>TABLA: invkardexmaestr</para>
        /// <para>TABLA NATIVA: invmaearticulos</para>
        /// <para>CAMPO: Código Barras Articulo</para>
        /// <para>NOMBRE: inv_codbar_inar (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 13</para>
        /// <para>DESCRIPCION:
        /// Código de barras del articulo
        /// </para>
        /// </summary>
        public String Inv_codbar_inar = String.Empty;
        #endregion
        #region Inv_codctn_intc: Código Contenedor
        /// <summary>
        /// <para>TABLA: invkardexmaestr</para>
        /// <para>TABLA NATIVA: invcontenedores</para>
        /// <para>CAMPO: Código de Contenedor</para>
        /// <para>NOMBRE: inv_codctn_intc (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Código tipo de contenedor o presentacion
        /// </para>
        /// </summary>
        public String Inv_codctn_intc = String.Empty;
        #endregion
        #region Inv_lotref_inar: Lote o Referencia
        /// <summary>
        /// <para>TABLA: invkardexmaestr</para>
        /// <para>TABLA NATIVA: invmaearticulos</para>
        /// <para>CAMPO: Lote o Referencia</para>
        /// <para>NOMBRE: inv_lotref_inar (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 14</para>
        /// <para>DESCRIPCION:
        ///Lote o Referencia del articulo Artículo
        /// </para>
        /// </summary>
        public String Inv_lotref_inar = String.Empty;
        #endregion
        #region Inv_fecven_inka: Fecha vencimiento
        /// <summary>
        /// <para>TABLA: invkardexmaestr</para>
        /// <para>TABLA NATIVA: invkardexmaestr</para>
        /// <para>CAMPO: Fecha vencimiento</para>
        /// <para>NOMBRE: inv_fecven_inka (fecha:8)</para>
        /// <para>ORDEN VISTA EN TABLA: 15</para>
        /// <para>DESCRIPCION:
        /// Fecha vencimiento del producto, cuando sea perecedero (Verdura/Medicament
        /// os y otros)
        /// </para>
        /// </summary>
        public DateTime Inv_fecven_inka = DateTime.Parse("01/01/0001");
        #endregion
        #region Sis_codgme_sigr: Patrón medida
        /// <summary>
        /// <para>TABLA: invkardexmaestr</para>
        /// <para>TABLA NATIVA: sisgrupomedidas</para>
        /// <para>CAMPO: Patrón medida</para>
        /// <para>NOMBRE: sis_codgme_sigr (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 16</para>
        /// <para>DESCRIPCION:
        /// Codigo Tipo de Unidad de Medida (Unidades,volumen,masa,etc..)
        /// </para>
        /// </summary>
        public String Sis_codgme_sigr = String.Empty;
        #endregion
        #region Sis_codume_sium: Medida Almacenamiento
        /// <summary>
        /// <para>TABLA: invkardexmaestr</para>
        /// <para>TABLA NATIVA: sisunidadmedida</para>
        /// <para>CAMPO: Medida Almacenamiento</para>
        /// <para>NOMBRE: sis_codume_sium (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 17</para>
        /// <para>DESCRIPCION:
        /// Tipo Unidad de Medida para almacenamiento y consumo: Unidades,Milimetros,
        /// Litros,Gramos y otros
        /// </para>
        /// </summary>
        public String Sis_codume_sium = String.Empty;
        #endregion
        #region Inv_totuni_inex: Unidades existencias
        /// <summary>
        /// <para>TABLA: invkardexmaestr</para>
        /// <para>TABLA NATIVA: invalmacexisten</para>
        /// <para>CAMPO: Unidades existencias</para>
        /// <para>NOMBRE: inv_totuni_inex (int:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 18</para>
        /// <para>DESCRIPCION:
        /// TOTAL UNIDADES EXISTENCIAS, cantidad de unidades en existencias
        /// en los movimientos de ingreso, se disminuyen hasta cero para
        /// cuando hay salidas
        /// </para>
        /// </summary>
        public int Inv_totuni_inex = 0;
        #endregion
        #region Inv_tottra_inex: Unidades transaccion
        /// <summary>
        /// <para>TABLA: invkardexmaestr</para>
        /// <para>TABLA NATIVA: invalmacexisten</para>
        /// <para>CAMPO: Unidades transaccion</para>
        /// <para>NOMBRE: inv_tottra_inex (int:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 19</para>
        /// <para>DESCRIPCION:
        /// TOTAL UNIDADES TRANSACCION, en transacciones en general del
        /// movimiento Entrada/Salida
        /// </para>
        /// </summary>
        public int Inv_tottra_inex = 0;
        #endregion
        #region Inv_valing_inar: Valor  Ingreso unidad
        /// <summary>
        /// <para>TABLA: invkardexmaestr</para>
        /// <para>TABLA NATIVA: invmaearticulos</para>
        /// <para>CAMPO: Valor  Ingreso unidad</para>
        /// <para>NOMBRE: inv_valing_inar (float:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 20</para>
        /// <para>DESCRIPCION:
        /// VALOR INGRESO EN COMPRAS, valor Ingreso unidad por compras
        /// de articulos en inventario
        /// </para>
        /// </summary>
        public float Inv_valing_inar = 0;
        #endregion
        #region Inv_valmov_inar: Valor salida unidad
        /// <summary>
        /// <para>TABLA: invkardexmaestr</para>
        /// <para>TABLA NATIVA: invmaearticulos</para>
        /// <para>CAMPO: Valor salida unidad</para>
        /// <para>NOMBRE: inv_valmov_inar (float:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 21</para>
        /// <para>DESCRIPCION:
        /// VALOR EN SALIDA VENTA, valor Movimiento de salida (valor venta)
        /// cada unidad
        /// </para>
        /// </summary>
        public float Inv_valmov_inar = 0;
        #endregion
        #region Sys_codusu_usux: Código Usuario
        /// <summary>
        /// <para>TABLA: invkardexmaestr</para>
        /// <para>TABLA NATIVA: sysusuarios</para>
        /// <para>CAMPO: Código Usuario</para>
        /// <para>NOMBRE: sys_codusu_usux (char:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 22</para>
        /// <para>DESCRIPCION:
        ///Código del usuario que realiza el ajuste
        /// </para>
        /// </summary>
        public String Sys_codusu_usux = String.Empty;
        #endregion
        #region Sis_estpro_espr: Estado Registro
        /// <summary>
        /// <para>TABLA: invkardexmaestr</para>
        /// <para>TABLA NATIVA: sisestadoproces</para>
        /// <para>CAMPO: Estado Registro</para>
        /// <para>NOMBRE: sis_estpro_espr (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 23</para>
        /// <para>DESCRIPCION:
        ///Estado del registro: 1=Abierto 2=Confirmado 3=Anulado
        /// </para>
        /// </summary>
        public String Sis_estpro_espr = String.Empty;
        #endregion
        #region Inv_desalm_inal: Descripción Almacén
        /// <summary>
        /// <para>TABLA: invkardexmaestr</para>
        /// <para>TABLA NATIVA: invalmacenmaest</para>
        /// <para>CAMPO: Descripción Almacén</para>
        /// <para>NOMBRE: inv_desalm_inal (char:60)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripción del almacén
        /// </para>
        /// </summary>
        public String Inv_desalm_inal = String.Empty;
        #endregion
        #region Inv_desper_inpe: Descripcion
        /// <summary>
        /// <para>TABLA: invkardexmaestr</para>
        /// <para>TABLA NATIVA: invperiodomaest</para>
        /// <para>CAMPO: Descripcion</para>
        /// <para>NOMBRE: inv_desper_inpe (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        ///Descripcion textual del periodo
        /// </para>
        /// </summary>
        public String Inv_desper_inpe = String.Empty;
        #endregion
        #region Inv_desarc_inag: Descripción archivo
        /// <summary>
        /// <para>TABLA: invkardexmaestr</para>
        /// <para>TABLA NATIVA: invtiparchigest</para>
        /// <para>CAMPO: Descripción archivo</para>
        /// <para>NOMBRE: inv_desarc_inag (char:50)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Descripción tipo archivo de gestion que genera movimientos
        /// en el kardex diario
        /// </para>
        /// </summary>
        public String Inv_desarc_inag = String.Empty;
        #endregion
        #region Inv_desreg_intr: Descripción tipo movimiento
        /// <summary>
        /// <para>TABLA: invkardexmaestr</para>
        /// <para>TABLA NATIVA: invtiporegimovi</para>
        /// <para>CAMPO: Descripción tipo movimiento</para>
        /// <para>NOMBRE: inv_desreg_intr (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripción tipo registro
        /// </para>
        /// </summary>
        public String Inv_desreg_intr = String.Empty;
        #endregion
        #region Inv_descon_incm: Descripción concepto
        /// <summary>
        /// <para>TABLA: invkardexmaestr</para>
        /// <para>TABLA NATIVA: invtipoconcemov</para>
        /// <para>CAMPO: Descripción concepto</para>
        /// <para>NOMBRE: inv_descon_incm (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripción concepto movimiento diario
        /// </para>
        /// </summary>
        public String Inv_descon_incm = String.Empty;
        #endregion
        #region Inv_nomart_inar: Nombre artículo
        /// <summary>
        /// <para>TABLA: invkardexmaestr</para>
        /// <para>TABLA NATIVA: invmaearticulos</para>
        /// <para>CAMPO: Nombre artículo</para>
        /// <para>NOMBRE: inv_nomart_inar (char:80)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION:
        ///Nombre del artículo para vista en informes y gestion
        /// </para>
        /// </summary>
        public String Inv_nomart_inar = String.Empty;
        #endregion
        #region Sis_desgme_sigr: Descripción Grupo medida
        /// <summary>
        /// <para>TABLA: invkardexmaestr</para>
        /// <para>TABLA NATIVA: sisgrupomedidas</para>
        /// <para>CAMPO: Descripción Grupo medida</para>
        /// <para>NOMBRE: sis_desgme_sigr (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripción del Grupo de Medidas
        /// </para>
        /// </summary>
        public String Sis_desgme_sigr = String.Empty;
        #endregion
        #region Sis_desume_sium: Descripción unidad medida
        /// <summary>
        /// <para>TABLA: invkardexmaestr</para>
        /// <para>TABLA NATIVA: sisunidadmedida</para>
        /// <para>CAMPO: Descripción unidad medida</para>
        /// <para>NOMBRE: sis_desume_sium (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripción de la unidad de Medida
        /// </para>
        /// </summary>
        public String Sis_desume_sium = String.Empty;
        #endregion
        #region Sys_nomusu_usux: Nombre Usuario
        /// <summary>
        /// <para>TABLA: invkardexmaestr</para>
        /// <para>TABLA NATIVA: sysusuarios</para>
        /// <para>CAMPO: Nombre Usuario</para>
        /// <para>NOMBRE: sys_nomusu_usux (char:50)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        ///Nombre Completo del  usuario
        /// </para>
        /// </summary>
        public String Sys_nomusu_usux = String.Empty;
        #endregion
        #region Sis_despro_espr: Decripción estado proceso
        /// <summary>
        /// <para>TABLA: invkardexmaestr</para>
        /// <para>TABLA NATIVA: sisestadoproces</para>
        /// <para>CAMPO: Decripción estado proceso</para>
        /// <para>NOMBRE: sis_despro_espr (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Descripcion textual del estado de proceso Abierto(a), Cerrado(a)
        /// Y Anulado(a)
        /// </para>
        /// </summary>
        public String Sis_despro_espr = String.Empty;
        #endregion
        #region Inv_codest_ines: Código Estante
        /// <summary>
        /// <para>TABLA: temporal</para>
        /// <para>TABLA NATIVA: invalmacenestan</para>
        /// <para>CAMPO: Código Estante</para>
        /// <para>NOMBRE: inv_codest_ines (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 11</para>
        /// <para>DESCRIPCION:
        /// Codgo del estante para cada almacen: Ejemplo E01-Estante Medicamentos
        /// de control
        /// </para>
        /// </summary>
        public String Inv_codest_ines = String.Empty;
        #endregion
        #region Inv_seccio_ines: Secciones
        /// <summary>
        /// <para>TABLA: temporal</para>
        /// <para>TABLA NATIVA: invalmacenestan</para>
        /// <para>CAMPO: Secciones</para>
        /// <para>NOMBRE: inv_seccio_ines (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 12</para>
        /// <para>DESCRIPCION:
        /// Lista de secciones del estante para validacion (generada por
        /// el sistema) ejemplo: S01,S02,S03,S04 según el numero de secciones
        /// que contenga el estante
        /// </para>
        /// </summary>
        public String Inv_seccio_ines = String.Empty;
        #endregion
        #region Inv_estant_ines: Vista estante
        /// <summary>
        /// <para>TABLA: temporal</para>
        /// <para>TABLA NATIVA: invalmacenestan</para>
        /// <para>CAMPO: Vista estante</para>
        /// <para>NOMBRE: inv_estant_ines (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 13</para>
        /// <para>DESCRIPCION:
        /// Codigo del estante sumado con la seccion, para llave de organización
        /// vista ejemplo: Estante = E01  y Seccion = S05  queda asi: E01S05
        /// </para>
        /// </summary>
        public String Inv_estant_ines = String.Empty;
        #endregion
        #region Sis_auxiliar_espr: gestion auxiliar de algun proceso
        /// <summary>
        /// <para>TABLA: temporal</para>
        /// <para>TABLA NATIVA: temporal</para>
        /// <para>CAMPO: Campo para gestion auxiliar de algun proceso</para>
        /// <para>NOMBRE: Sis_auxiliar_espr (char)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION: Campo para gestion auxiliar de algun proceso</para>
        /// </summary>
        public String Sis_auxiliar_espr = String.Empty;
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
        #region RefObjeto: Referencia objeto instancia en la vista 
        /// <summary>
        /// Referencia objeto instancia en la vista
        /// </summary>
        public FrameworkElement RefObjeto { get; set; }
        #endregion
        #endregion
        #endregion
        #region Metodos para edicion de registros
        #region Adicionar Registro
        public static String flgAddRegistro(ModeloInvKardexMaestro tobjModelo)
        {
            var lcrCodigoGen = SysModelo.fcrGenerarNuevoCodigo("INV-MAESTRO-KARDEX-DIARIO", "INV", "Maestro kardex de entradas y salidas");
            try
            {
                if (!flgBuscarInvkardexmaestr(lcrCodigoGen))
                {
                    using (_context = new DbAplicacion())
                    {
                        var lobjRegistro = new EFinvkardexmaestr
                        {
                            #region cargar Registro
                            inv_seckar_inka = tobjModelo.Inv_seckar_inka,
                            inv_codalm_inal = tobjModelo.Inv_codalm_inal,
                            inv_codper_inpe = tobjModelo.Inv_codper_inpe,
                            inv_llavkr_inka = tobjModelo.Inv_llavkr_inka,
                            inv_tiparc_inag = tobjModelo.Inv_tiparc_inag,
                            inv_fecges_inka = tobjModelo.Inv_fecges_inka,
                            inv_numdoc_inka = tobjModelo.Inv_numdoc_inka,
                            inv_refkar_inka = tobjModelo.Inv_refkar_inka,
                            inv_tipreg_inka = tobjModelo.Inv_tipreg_inka,
                            inv_tipmov_intr = tobjModelo.Inv_tipmov_intr,
                            inv_conmov_incm = tobjModelo.Inv_conmov_incm,
                            inv_secart_inar = tobjModelo.Inv_secart_inar,
                            inv_codaux_inar = tobjModelo.Inv_codaux_inar,
                            inv_lotref_inar = tobjModelo.Inv_lotref_inar,
                            inv_fecven_inka = tobjModelo.Inv_fecven_inka,
                            sis_codgme_sigr = tobjModelo.Sis_codgme_sigr,
                            sis_codume_sium = tobjModelo.Sis_codume_sium,
                            inv_totuni_inex = tobjModelo.Inv_totuni_inex,
                            inv_tottra_inex = tobjModelo.Inv_tottra_inex,
                            inv_valing_inar = tobjModelo.Inv_valing_inar,
                            inv_valmov_inar = tobjModelo.Inv_valmov_inar,
                            sys_codusu_usux = tobjModelo.Sys_codusu_usux,
                            sis_estpro_espr = tobjModelo.Sis_estpro_espr,
                            #endregion
                        };
                        lobjRegistro.inv_seckar_inka = lcrCodigoGen;
                        _context.AddToInvkardexmaestr(lobjRegistro);
                        _context.SaveChanges();
                    }
                }
                else
                {
                    lcrCodigoGen = String.Empty;
                    MessageBox.Show("Nuevo codigo Generado esta desactualizado, revisar llave: \n" +
                                "'INV-MAESTRO-KARDEX-DIARIO': Maestro kardex de entradas y salidas en Maestro Secuenciales.");
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
        public static void fcvActualizar(ModeloInvKardexMaestro tobjModelo)
        {
            try
            {
                using (_context = new DbAplicacion())
                {
                    var lobjRegistro = _context.Invkardexmaestr.FirstOrDefault(p => p.inv_seckar_inka == tobjModelo.Inv_seckar_inka);
                    if (lobjRegistro != null)
                    {
                        #region cargar Registro
                        lobjRegistro.inv_seckar_inka = tobjModelo.Inv_seckar_inka;
                        lobjRegistro.inv_codalm_inal = tobjModelo.Inv_codalm_inal;
                        lobjRegistro.inv_codper_inpe = tobjModelo.Inv_codper_inpe;
                        lobjRegistro.inv_llavkr_inka = tobjModelo.Inv_llavkr_inka;
                        lobjRegistro.inv_tiparc_inag = tobjModelo.Inv_tiparc_inag;
                        lobjRegistro.inv_fecges_inka = (DateTime)tobjModelo.Inv_fecges_inka;
                        lobjRegistro.inv_numdoc_inka = tobjModelo.Inv_numdoc_inka;
                        lobjRegistro.inv_refkar_inka = tobjModelo.Inv_refkar_inka;
                        lobjRegistro.inv_tipreg_inka = tobjModelo.Inv_tipreg_inka;
                        lobjRegistro.inv_tipmov_intr = tobjModelo.Inv_tipmov_intr;
                        lobjRegistro.inv_conmov_incm = tobjModelo.Inv_conmov_incm;
                        lobjRegistro.inv_secart_inar = tobjModelo.Inv_secart_inar;
                        lobjRegistro.inv_codaux_inar = tobjModelo.Inv_codaux_inar;
                        lobjRegistro.inv_lotref_inar = tobjModelo.Inv_lotref_inar;
                        lobjRegistro.inv_fecven_inka = (DateTime)tobjModelo.Inv_fecven_inka;
                        lobjRegistro.sis_codgme_sigr = tobjModelo.Sis_codgme_sigr;
                        lobjRegistro.sis_codume_sium = tobjModelo.Sis_codume_sium;
                        lobjRegistro.inv_totuni_inex = (int)tobjModelo.Inv_totuni_inex;
                        lobjRegistro.inv_tottra_inex = (int)tobjModelo.Inv_tottra_inex;
                        lobjRegistro.inv_valing_inar = (float)tobjModelo.Inv_valing_inar;
                        lobjRegistro.inv_valmov_inar = (float)tobjModelo.Inv_valmov_inar;
                        lobjRegistro.sys_codusu_usux = tobjModelo.Sys_codusu_usux;
                        lobjRegistro.sis_estpro_espr = tobjModelo.Sis_estpro_espr;
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
                    var lobjRegistro = _context.Invkardexmaestr.FirstOrDefault(p => p.inv_seckar_inka == tcrCodigo);
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
        #region Buscar INVKARDEXMAESTR: Logica
        /// <summary>
        /// <para>TABLA: invkardexmaestr</para>
        /// <para>TITULO: Maestro kardex de entradas y salidas</para>
        /// <para>MODULO: INV</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro kardex movimientos de entradas y salidas resumen generar
        /// e historico de todos los proceso de gestion de inventario
        /// </para>
        /// </summary>
        public static bool flgBuscarInvkardexmaestr(String tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Invkardexmaestr.FirstOrDefault(p => p.inv_seckar_inka == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region flsListaInvkardexMovArticulo: Listar registros periodo y almacen y articulo
        /// <summary>
        /// devuelve una lista de movimientos del articulo para un periodo dado en un almacen 
        /// </summary>
        /// <param name="tcrCodigoArticulo">Codigo del articulo solicitado</param>
        /// <param name="tcrCodigoPeriodo">Codigo del periodo gestion a consultar ejemplo Marzo de 2016 -> 201603</param>
        /// <param name="tcrCodigoAlmacen">Codigo del almacen</param>
        /// <returns>Lista de registros movimientos del articulo en un periodo</returns>
        public static List<ModeloInvKardexMaestro> flsListaInvkardexMovArticulo(String tcrCodigoArticulo, String tcrCodigoPeriodo, String tcrCodigoAlmacen)
        {
            using (_context = new DbAplicacion())
            {
                var lobConsulta = from invkardexmaestr in _context.Invkardexmaestr
                                  join invalmacenmaest in _context.Invalmacenmaest on invkardexmaestr.inv_codalm_inal equals invalmacenmaest.inv_codalm_inal into tminvalmacenmaest
                                  join invperiodomaest in _context.Invperiodomaest on invkardexmaestr.inv_codper_inpe equals invperiodomaest.inv_codper_inpe into tminvperiodomaest
                                  join invtipoconcemov in _context.Invtipoconcemov on invkardexmaestr.inv_conmov_incm equals invtipoconcemov.inv_conmov_incm into tminvtipoconcemov
                                  join invmaearticulos in _context.Invmaearticulos on invkardexmaestr.inv_secart_inar equals invmaearticulos.inv_secart_inar into tminvmaearticulos
                                  from inal in tminvalmacenmaest.DefaultIfEmpty()
                                  from inpe in tminvperiodomaest.DefaultIfEmpty()
                                  from incm in tminvtipoconcemov.DefaultIfEmpty()
                                  from inar in tminvmaearticulos.DefaultIfEmpty()
                                  where invkardexmaestr.inv_secart_inar == tcrCodigoArticulo &&
                                        invkardexmaestr.inv_codper_inpe == tcrCodigoPeriodo &&
                                        invkardexmaestr.inv_codalm_inal == tcrCodigoAlmacen
                                  select new ModeloInvKardexMaestro
                                  {
                                      #region Datos
                                      Inv_seckar_inka = invkardexmaestr.inv_seckar_inka,
                                      Inv_codalm_inal = invkardexmaestr.inv_codalm_inal,
                                      Inv_codper_inpe = invkardexmaestr.inv_codper_inpe,
                                      Inv_llavkr_inka = invkardexmaestr.inv_llavkr_inka,
                                      Inv_tiparc_inag = invkardexmaestr.inv_tiparc_inag,
                                      Inv_fecges_inka = (DateTime)invkardexmaestr.inv_fecges_inka,
                                      Inv_numdoc_inka = invkardexmaestr.inv_numdoc_inka,
                                      Inv_refkar_inka = invkardexmaestr.inv_refkar_inka,
                                      Inv_tipreg_inka = invkardexmaestr.inv_tipreg_inka,
                                      Inv_tipmov_intr = invkardexmaestr.inv_tipmov_intr,
                                      Inv_conmov_incm = invkardexmaestr.inv_conmov_incm,
                                      Inv_secart_inar = invkardexmaestr.inv_secart_inar,
                                      Inv_codaux_inar = invkardexmaestr.inv_codaux_inar,
                                      Inv_lotref_inar = invkardexmaestr.inv_lotref_inar,
                                      Inv_fecven_inka = (DateTime)invkardexmaestr.inv_fecven_inka,
                                      Sis_codgme_sigr = invkardexmaestr.sis_codgme_sigr,
                                      Sis_codume_sium = invkardexmaestr.sis_codume_sium,
                                      Inv_totuni_inex = (int)invkardexmaestr.inv_totuni_inex,
                                      Inv_tottra_inex = (int)invkardexmaestr.inv_tottra_inex,
                                      Inv_valing_inar = (float)invkardexmaestr.inv_valing_inar,
                                      Inv_valmov_inar = (float)invkardexmaestr.inv_valmov_inar,
                                      Sys_codusu_usux = invkardexmaestr.sys_codusu_usux,
                                      Sis_estpro_espr = invkardexmaestr.sis_estpro_espr,
                                      Inv_desalm_inal = inal.inv_desalm_inal,
                                      Inv_desper_inpe = inpe.inv_desper_inpe,
                                      Inv_desreg_intr = invkardexmaestr.inv_tipmov_intr == "1" ? "ENTRADAS" : "SALIDAS",
                                      Inv_descon_incm = incm.inv_descon_incm,
                                      Inv_nomart_inar = inar.inv_nomart_inar,
                                      Sis_desgme_sigr = _context.Sisgrupomedidas.FirstOrDefault(rxp => rxp.sis_codgme_sigr == invkardexmaestr.sis_codgme_sigr).sis_desgme_sigr,
                                      Sis_desume_sium = _context.Sisunidadmedida.FirstOrDefault(rxp => rxp.sis_codume_sium == invkardexmaestr.sis_codume_sium).sis_desume_sium,
                                      Inv_desarc_inag = _context.Invtiparchigest.FirstOrDefault(rxp => rxp.inv_tiparc_inag == invkardexmaestr.inv_tiparc_inag).inv_desarc_inag,
                                      Sis_despro_espr = _context.Sisestadoproces.FirstOrDefault(rxp => rxp.sis_estpro_espr == invkardexmaestr.sis_estpro_espr).sis_despro_espr,
                                      Sys_nomusu_usux = _context.Sysusuarios.FirstOrDefault(rxp => rxp.sys_codusu_usux == invkardexmaestr.sys_codusu_usux).sys_nomusu_usux,

                                      #endregion
                                  };
                return lobConsulta.ToList();
            }
        }
        #endregion
        #region Listar Registros
        /// <summary>
        /// //Modelo Maestro Kardex: Lista de Registros
        /// </summary>
        /// <param name="tcrBuscar"></param>
        /// <returns></returns>
        public static List<ModeloInvKardexMaestro> flsListaInvkardexMaestro(String tcrBuscar)
        {
            using (_context = new DbAplicacion())
            {
                var lobConsulta = from invkardexmaestr in _context.Invkardexmaestr
                                  join invalmacenmaest in _context.Invalmacenmaest on invkardexmaestr.inv_codalm_inal equals invalmacenmaest.inv_codalm_inal into tminvalmacenmaest
                                  join invperiodomaest in _context.Invperiodomaest on invkardexmaestr.inv_codper_inpe equals invperiodomaest.inv_codper_inpe into tminvperiodomaest
                                  join invtipoconcemov in _context.Invtipoconcemov on invkardexmaestr.inv_conmov_incm equals invtipoconcemov.inv_conmov_incm into tminvtipoconcemov
                                  join invmaearticulos in _context.Invmaearticulos on invkardexmaestr.inv_secart_inar equals invmaearticulos.inv_secart_inar into tminvmaearticulos
                                  from inal in tminvalmacenmaest.DefaultIfEmpty()
                                  from inpe in tminvperiodomaest.DefaultIfEmpty()
                                  from incm in tminvtipoconcemov.DefaultIfEmpty()
                                  from inar in tminvmaearticulos.DefaultIfEmpty()
                                  where invkardexmaestr.inv_seckar_inka == tcrBuscar
                                  select new ModeloInvKardexMaestro
                                  {
                                      #region Datos
                                      Inv_seckar_inka = invkardexmaestr.inv_seckar_inka,
                                      Inv_codalm_inal = invkardexmaestr.inv_codalm_inal,
                                      Inv_codper_inpe = invkardexmaestr.inv_codper_inpe,
                                      Inv_llavkr_inka = invkardexmaestr.inv_llavkr_inka,
                                      Inv_tiparc_inag = invkardexmaestr.inv_tiparc_inag,
                                      Inv_fecges_inka = (DateTime)invkardexmaestr.inv_fecges_inka,
                                      Inv_numdoc_inka = invkardexmaestr.inv_numdoc_inka,
                                      Inv_refkar_inka = invkardexmaestr.inv_refkar_inka,
                                      Inv_tipreg_inka = invkardexmaestr.inv_tipreg_inka,
                                      Inv_tipmov_intr = invkardexmaestr.inv_tipmov_intr,
                                      Inv_conmov_incm = invkardexmaestr.inv_conmov_incm,
                                      Inv_secart_inar = invkardexmaestr.inv_secart_inar,
                                      Inv_codaux_inar = invkardexmaestr.inv_codaux_inar,
                                      Inv_lotref_inar = invkardexmaestr.inv_lotref_inar,
                                      Inv_fecven_inka = (DateTime)invkardexmaestr.inv_fecven_inka,
                                      Sis_codgme_sigr = invkardexmaestr.sis_codgme_sigr,
                                      Sis_codume_sium = invkardexmaestr.sis_codume_sium,
                                      Inv_totuni_inex = (int)invkardexmaestr.inv_totuni_inex,
                                      Inv_tottra_inex = (int)invkardexmaestr.inv_tottra_inex,
                                      Inv_valing_inar = (float)invkardexmaestr.inv_valing_inar,
                                      Inv_valmov_inar = (float)invkardexmaestr.inv_valmov_inar,
                                      Sys_codusu_usux = invkardexmaestr.sys_codusu_usux,
                                      Sis_estpro_espr = invkardexmaestr.sis_estpro_espr,
                                      Inv_desalm_inal = inal.inv_desalm_inal,
                                      Inv_desper_inpe = inpe.inv_desper_inpe,
                                      Inv_desreg_intr = invkardexmaestr.inv_tipmov_intr == "1" ? "ENTRADAS" : "SALIDAS",
                                      Inv_descon_incm = incm.inv_descon_incm,
                                      Inv_nomart_inar = inar.inv_nomart_inar,
                                      Sis_desgme_sigr = _context.Sisgrupomedidas.FirstOrDefault(rxp => rxp.sis_codgme_sigr == invkardexmaestr.sis_codgme_sigr).sis_desgme_sigr,
                                      Sis_desume_sium = _context.Sisunidadmedida.FirstOrDefault(rxp => rxp.sis_codume_sium == invkardexmaestr.sis_codume_sium).sis_desume_sium,
                                      Inv_desarc_inag = _context.Invtiparchigest.FirstOrDefault(rxp => rxp.inv_tiparc_inag == invkardexmaestr.inv_tiparc_inag).inv_desarc_inag,
                                      Sis_despro_espr = _context.Sisestadoproces.FirstOrDefault(rxp => rxp.sis_estpro_espr == invkardexmaestr.sis_estpro_espr).sis_despro_espr,
                                      Sys_nomusu_usux = _context.Sysusuarios.FirstOrDefault(rxp => rxp.sys_codusu_usux == invkardexmaestr.sys_codusu_usux).sys_nomusu_usux,

                                      #endregion
                                  };
                return lobConsulta.ToList();
            }
        }
        #endregion
        #region Temporal con datos agrupados por lotes de articulos
        /// <summary>
        /// //Modelo Maestro Kardex: Temporal con datos agrupados por lotes de articulos
        /// </summary>
        /// <param name="tcrBuscar"></param>
        /// <returns></returns>
        public static List<ModeloInvKardexMaestro> flsListaInvkardexMaestroRpt(String tcrBuscar)
        {
            using (_context = new DbAplicacion())
            {
                var lobConsulta = from invkardexmaestr in _context.Invkardexmaestr
                                  //join invalmacenmaest in _context.Invalmacenmaest on invkardexmaestr.inv_codalm_inal equals invalmacenmaest.inv_codalm_inal into tminvalmacenmaest
                                  //join invperiodomaest in _context.Invperiodomaest on invkardexmaestr.inv_codper_inpe equals invperiodomaest.inv_codper_inpe into tminvperiodomaest
                                  join invtipoconcemov in _context.Invtipoconcemov on invkardexmaestr.inv_conmov_incm equals invtipoconcemov.inv_conmov_incm into tminvtipoconcemov
                                  join invmaearticulos in _context.Invmaearticulos on invkardexmaestr.inv_secart_inar equals invmaearticulos.inv_secart_inar into tminvmaearticulos
                                  //from inal in tminvalmacenmaest.DefaultIfEmpty()
                                  //from inpe in tminvperiodomaest.DefaultIfEmpty()
                                  from incm in tminvtipoconcemov.DefaultIfEmpty()
                                  from inar in tminvmaearticulos.DefaultIfEmpty()
                                  where invkardexmaestr.inv_numdoc_inka == tcrBuscar
                                  && invkardexmaestr.inv_tipmov_intr == "2"
                                  orderby inar.inv_secart_inar
                                  select new ModeloInvKardexMaestro
                                  {
                                      #region Datos
                                      Inv_seckar_inka = invkardexmaestr.inv_seckar_inka,
                                      Inv_codalm_inal = invkardexmaestr.inv_codalm_inal,
                                      Inv_codper_inpe = invkardexmaestr.inv_codper_inpe,
                                      Inv_llavkr_inka = invkardexmaestr.inv_llavkr_inka,
                                      Inv_tiparc_inag = invkardexmaestr.inv_tiparc_inag,
                                      Inv_fecges_inka = (DateTime)invkardexmaestr.inv_fecges_inka,
                                      Inv_numdoc_inka = invkardexmaestr.inv_numdoc_inka,
                                      Inv_refkar_inka = invkardexmaestr.inv_refkar_inka,
                                      Inv_tipreg_inka = invkardexmaestr.inv_tipreg_inka,
                                      Inv_tipmov_intr = invkardexmaestr.inv_tipmov_intr,
                                      Inv_conmov_incm = invkardexmaestr.inv_conmov_incm,
                                      Inv_secart_inar = invkardexmaestr.inv_secart_inar,
                                      Inv_codaux_inar = invkardexmaestr.inv_codaux_inar,
                                      Inv_lotref_inar = invkardexmaestr.inv_lotref_inar,
                                      Inv_fecven_inka = (DateTime)invkardexmaestr.inv_fecven_inka,
                                      Sis_codgme_sigr = invkardexmaestr.sis_codgme_sigr,
                                      Sis_codume_sium = invkardexmaestr.sis_codume_sium,
                                      Inv_totuni_inex = (int)invkardexmaestr.inv_totuni_inex,
                                      Inv_tottra_inex = (int)invkardexmaestr.inv_tottra_inex,
                                      Inv_valing_inar = (float)invkardexmaestr.inv_valing_inar,
                                      Inv_valmov_inar = (float)invkardexmaestr.inv_valmov_inar,
                                      Sys_codusu_usux = invkardexmaestr.sys_codusu_usux,
                                      Sis_estpro_espr = invkardexmaestr.sis_estpro_espr,
                                      //Inv_desalm_inal = inal.inv_desalm_inal,
                                      //Inv_desper_inpe = inpe.inv_desper_inpe,
                                      //Inv_desreg_intr = invkardexmaestr.inv_tipmov_intr == "1" ? "ENTRADAS" : "SALIDAS",
                                      Inv_descon_incm = incm.inv_descon_incm,
                                      Inv_nomart_inar = inar.inv_nomart_inar,
                                      //Sis_desgme_sigr = _context.Sisgrupomedidas.FirstOrDefault(rxp => rxp.sis_codgme_sigr == invkardexmaestr.sis_codgme_sigr).sis_desgme_sigr,
                                      //Sis_desume_sium = _context.Sisunidadmedida.FirstOrDefault(rxp => rxp.sis_codume_sium == invkardexmaestr.sis_codume_sium).sis_desume_sium,
                                      //Inv_desarc_inag = _context.Invtiparchigest.FirstOrDefault(rxp => rxp.inv_tiparc_inag == invkardexmaestr.inv_tiparc_inag).inv_desarc_inag,
                                      //Sis_despro_espr = _context.Sisestadoproces.FirstOrDefault(rxp => rxp.sis_estpro_espr == invkardexmaestr.sis_estpro_espr).sis_despro_espr,
                                      //Sys_nomusu_usux = _context.Sysusuarios.FirstOrDefault(rxp => rxp.sys_codusu_usux == invkardexmaestr.sys_codusu_usux).sys_nomusu_usux,

                                      #endregion
                                  };
                return lobConsulta.ToList();
            }
        }
        #endregion
        #region Temporal con datos agrupados por lotes de articulos de existencias
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tcrBuscar"></param>
        /// <returns></returns>
        public static List<ModeloInvKardexMaestro> flsListaInvkardexMaestroRptAlm(String tcrBuscar)
        {
            using (_context = new DbAplicacion())
            {
                var lobConsulta = from invkardexmaestr in _context.Invkardexmaestr
                                  join invalmacenmaest in _context.Invalmacenmaest on invkardexmaestr.inv_codalm_inal equals invalmacenmaest.inv_codalm_inal into tminvalmacenmaest
                                  join invmaearticulos in _context.Invmaearticulos on invkardexmaestr.inv_secart_inar equals invmaearticulos.inv_secart_inar into tminvmaearticulos
                                  join invalmacexisten in _context.Invalmacexisten on invkardexmaestr.inv_secart_inar equals invalmacexisten.inv_secart_inar into tminvalmacexisten
                                  where (invkardexmaestr.inv_codalm_inal == tcrBuscar) &&
                                        (invkardexmaestr.inv_tipmov_intr == "1") &&
                                        (invkardexmaestr.inv_totuni_inex > 0)
                                  select new ModeloInvKardexMaestro
                                  {
                                      #region Datos
                                      Inv_seckar_inka = invkardexmaestr.inv_seckar_inka,
                                      Inv_codalm_inal = invkardexmaestr.inv_codalm_inal,
                                      Inv_codper_inpe = invkardexmaestr.inv_codper_inpe,
                                      Inv_llavkr_inka = invkardexmaestr.inv_llavkr_inka,
                                      Inv_tiparc_inag = invkardexmaestr.inv_tiparc_inag,
                                      Inv_fecges_inka = (DateTime)invkardexmaestr.inv_fecges_inka,
                                      Inv_numdoc_inka = invkardexmaestr.inv_numdoc_inka,
                                      Inv_refkar_inka = invkardexmaestr.inv_refkar_inka,
                                      Inv_tipreg_inka = invkardexmaestr.inv_tipreg_inka,
                                      Inv_tipmov_intr = invkardexmaestr.inv_tipmov_intr,
                                      Inv_conmov_incm = invkardexmaestr.inv_conmov_incm,
                                      Inv_secart_inar = invkardexmaestr.inv_secart_inar,
                                      Inv_codaux_inar = invkardexmaestr.inv_codaux_inar,
                                      Inv_lotref_inar = invkardexmaestr.inv_lotref_inar,
                                      Inv_fecven_inka = (DateTime)invkardexmaestr.inv_fecven_inka,
                                      Sis_codgme_sigr = invkardexmaestr.sis_codgme_sigr,
                                      Sis_codume_sium = invkardexmaestr.sis_codume_sium,
                                      Inv_totuni_inex = (int)invkardexmaestr.inv_totuni_inex,
                                      Inv_tottra_inex = (int)invkardexmaestr.inv_tottra_inex,
                                      Inv_valing_inar = (float)invkardexmaestr.inv_valing_inar,
                                      Inv_valmov_inar = (float)invkardexmaestr.inv_valmov_inar,
                                      Sys_codusu_usux = invkardexmaestr.sys_codusu_usux,
                                      Sis_estpro_espr = invkardexmaestr.sis_estpro_espr,
                                      Sis_estado_imaen = "I",
                                      #endregion
                                  };
                return lobConsulta.ToList();
            }
        }
        #endregion                
        #region Temporal grilla lotes
        /// <summary>
        /// //Modelo Maestro Kardex: Temporal grilla lotes
        /// </summary>
        /// <param name="tcrBuscar"></param>
        /// <returns></returns>
        public static List<ModeloInvKardexMaestro> flsListaInvkardexMaestroLot(String tcrCodigoAlmacen, String tcrCodigoArticulo)
        {
            using (_context = new DbAplicacion())
            {
                var lobConsulta = from invkardexmaestr in _context.Invkardexmaestr
                                  join invalmacenmaest in _context.Invalmacenmaest on invkardexmaestr.inv_codalm_inal equals invalmacenmaest.inv_codalm_inal into tminvalmacenmaest
                                  join invmaearticulos in _context.Invmaearticulos on invkardexmaestr.inv_secart_inar equals invmaearticulos.inv_secart_inar into tminvmaearticulos
                                  from inal in tminvalmacenmaest.DefaultIfEmpty()
                                  from inar in tminvmaearticulos.DefaultIfEmpty()
                                  where invkardexmaestr.inv_codalm_inal == tcrCodigoAlmacen &&
                                        invkardexmaestr.inv_secart_inar == tcrCodigoArticulo                                      
                                  select new ModeloInvKardexMaestro
                                  {
                                      #region Datos
                                      Inv_seckar_inka = invkardexmaestr.inv_seckar_inka,
                                      Inv_codalm_inal = invkardexmaestr.inv_codalm_inal,
                                      Inv_codper_inpe = invkardexmaestr.inv_codper_inpe,
                                      Inv_llavkr_inka = invkardexmaestr.inv_llavkr_inka,
                                      Inv_tiparc_inag = invkardexmaestr.inv_tiparc_inag,
                                      Inv_fecges_inka = (DateTime)invkardexmaestr.inv_fecges_inka,
                                      Inv_numdoc_inka = invkardexmaestr.inv_numdoc_inka,
                                      Inv_refkar_inka = invkardexmaestr.inv_refkar_inka,
                                      Inv_tipreg_inka = invkardexmaestr.inv_tipreg_inka,
                                      Inv_tipmov_intr = invkardexmaestr.inv_tipmov_intr,
                                      Inv_conmov_incm = invkardexmaestr.inv_conmov_incm,
                                      Inv_secart_inar = invkardexmaestr.inv_secart_inar,
                                      Inv_codaux_inar = invkardexmaestr.inv_codaux_inar,
                                      Inv_lotref_inar = invkardexmaestr.inv_lotref_inar,
                                      Inv_fecven_inka = (DateTime)invkardexmaestr.inv_fecven_inka,
                                      Sis_codgme_sigr = invkardexmaestr.sis_codgme_sigr,
                                      Sis_codume_sium = invkardexmaestr.sis_codume_sium,
                                      Inv_totuni_inex = (int)invkardexmaestr.inv_totuni_inex,
                                      Inv_tottra_inex = (int)invkardexmaestr.inv_tottra_inex,
                                      Inv_valing_inar = (float)invkardexmaestr.inv_valing_inar,
                                      Inv_valmov_inar = (float)invkardexmaestr.inv_valmov_inar,
                                      Sys_codusu_usux = invkardexmaestr.sys_codusu_usux,
                                      Sis_estpro_espr = invkardexmaestr.sis_estpro_espr,
                                      Inv_desalm_inal = inal.inv_desalm_inal,
                                      Inv_desreg_intr = invkardexmaestr.inv_tipmov_intr == "1" ? "ENTRADAS" : "SALIDAS",
                                      Inv_nomart_inar = inar.inv_nomart_inar,
                                      Sis_desgme_sigr = _context.Sisgrupomedidas.FirstOrDefault(rxp => rxp.sis_codgme_sigr == invkardexmaestr.sis_codgme_sigr).sis_desgme_sigr,
                                      Sis_desume_sium = _context.Sisunidadmedida.FirstOrDefault(rxp => rxp.sis_codume_sium == invkardexmaestr.sis_codume_sium).sis_desume_sium,
                                      Inv_desarc_inag = _context.Invtiparchigest.FirstOrDefault(rxp => rxp.inv_tiparc_inag == invkardexmaestr.inv_tiparc_inag).inv_desarc_inag,
                                      Sis_despro_espr = _context.Sisestadoproces.FirstOrDefault(rxp => rxp.sis_estpro_espr == invkardexmaestr.sis_estpro_espr).sis_despro_espr,
                                      Sys_nomusu_usux = _context.Sysusuarios.FirstOrDefault(rxp => rxp.sys_codusu_usux == invkardexmaestr.sys_codusu_usux).sys_nomusu_usux,

                                      #endregion
                                  };
                return lobConsulta.ToList();
            }
        }   
        #endregion
        #endregion
        //-------------------------------------------
        // PROCESOS GESTION KARDEX Y MOVIMIENTOS
        //-------------------------------------------
        #region Gestion Kardex y movimientos almacen
        #region flgInvMaesKardexMovEntradas: Movimiento Maestro entrada en Kardex
        /// <summary>
        /// <para>Movimiento Maestro entrada en Kardex, procedimiento que es llamado desde los diferentes modulos</para>
        /// <para>de movimiento de inventario.</para>
        /// </summary>
        /// <param name="tcrCodigoAlmacen">Codigo del almacen para el cual se realizara la transaccion</param>
        /// <param name="tmpListaKardex">Lista en formato "List(ModeloInvKardexMaestro)" de registros a cargar en almacen</param>
        /// <returns>Retorna true/false para indicar si la operacion tuvo exito.</returns>
        public static bool flgInvMaesKardexMovEntradas(String tcrCodigoAlmacen, List<ModeloInvKardexMaestro> tmpListaKardex)
        {
            var llgReturn = false;
            try
            {
                if (flgInvGestKardexMovAddEntradas(tcrCodigoAlmacen, tmpListaKardex))
                {
                    llgReturn = ModeloInvAlmacenExistencias.flgInvGestKardexMovAddExistencias(tcrCodigoAlmacen, tmpListaKardex);
                }
            }
            catch (Exception ex)
            {
                Funciones.fcvVistaErroresEjecucion(ref ex, "Modelo Error Metodo: flgInvMaesKardexMovEntradas");
            }
            return llgReturn;
        }
        #endregion
        #region flgInvGestKardexMovAddEntradas: Adicionar nuevos Registros en kardex diario
        /// <summary>
        /// Adicionar nuevos Registros en kardex diario
        /// </summary>
        /// <param name="tcrCodigoAlmacen">Codigo del almacen para el cual se realizara la transaccion</param>
        /// <param name="tmpListaKardex">Lista en formato "List(ModeloInvKardexMaestro)" de registros a cargar en almacen</param>
        /// <returns>Retorna true/false para indicar si la operacion tuvo exito.</returns>
        public static bool flgInvGestKardexMovAddEntradas(String tcrCodigoAlmacen, List<ModeloInvKardexMaestro> tmpListaKardex)
        {
            var llgReturn = false;
            try
            {
                var lnuTotalReg = tmpListaKardex.Count;
                var lnuRangoRegistros = SysModelo.fnuActualizar("1", "INV-MAESTRO-KARDEX-DIARIO", lnuTotalReg + 1); // Reservar el rango a usuar
                var lnuContador = lnuRangoRegistros - lnuTotalReg;
                var lobReSecuencial = SYSValidarCodigo.fobRegBuscarSysgeneradorcod("INV-MAESTRO-KARDEX-DIARIO");

                if (lnuRangoRegistros > 0)
                {
                    using (_context = new DbAplicacion())
                    {
                        var lcrLlaveRegistro = String.Empty;

                        foreach (var lobReg in tmpListaKardex)
                        {
                            lcrLlaveRegistro = SysModelo.fcrGenFormatoSecuencial(lobReSecuencial, lnuContador);

                            var lobjRegistro = new EFinvkardexmaestr
                            {
                                #region cargar Registro
                                inv_seckar_inka = lcrLlaveRegistro,
                                inv_codalm_inal = tcrCodigoAlmacen,
                                inv_codper_inpe = lobReg.Inv_codper_inpe,
                                inv_llavkr_inka = lobReg.Inv_llavkr_inka,
                                inv_tiparc_inag = lobReg.Inv_tiparc_inag,
                                inv_fecges_inka = lobReg.Inv_fecges_inka,
                                inv_numdoc_inka = lobReg.Inv_numdoc_inka,
                                inv_refkar_inka = lobReg.Inv_refkar_inka,
                                inv_tipreg_inka = lobReg.Inv_tipreg_inka,
                                inv_tipmov_intr = lobReg.Inv_tipmov_intr,
                                inv_conmov_incm = lobReg.Inv_conmov_incm,
                                inv_secart_inar = lobReg.Inv_secart_inar,
                                inv_codaux_inar = lobReg.Inv_codaux_inar,
                                inv_lotref_inar = lobReg.Inv_lotref_inar,
                                inv_fecven_inka = lobReg.Inv_fecven_inka,
                                sis_codgme_sigr = lobReg.Sis_codgme_sigr,
                                sis_codume_sium = lobReg.Sis_codume_sium,
                                inv_totuni_inex = lobReg.Inv_totuni_inex,
                                inv_tottra_inex = lobReg.Inv_tottra_inex,
                                inv_valing_inar = lobReg.Inv_valing_inar,
                                inv_valmov_inar = lobReg.Inv_valmov_inar,
                                sys_codusu_usux = lobReg.Sys_codusu_usux,
                                sis_estpro_espr = lobReg.Sis_estpro_espr,
                                #endregion
                            };
                            _context.AddToInvkardexmaestr(lobjRegistro);
                            lnuContador++;
                        }
                        _context.SaveChanges();
                        llgReturn = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Funciones.fcvVistaErroresEjecucion(ref ex, "Modelo Error Metodo: flgInvGestKardexMovAddEntradas");
            }
            return llgReturn;
        }
        #endregion
        // Gestion Salidas
        #region flgInvGestKardexMovSalidas: Adicionar nuevos Registros en kardex diario
        /// <summary>
        /// Adicionar nuevos Registros en kardex diario
        /// </summary>
        /// <param name="tcrTipoSalida">Tipos de salida: S21=Ventas S22=Traslado S23=Otras areas o consumo interno S24=Ventas entrega formula 
        /// S25=Suministro a pacientes hospitalizacion S26=Ajuste inventario S27=Devolucion S28=Deterioro</param>
        /// <param name="tcrCodigoAlmacen">Codigo del almacen para el cual se realizara la transaccion</param>
        /// <param name="tcrCodigoAlmacenDestino">Codigo del almacen destino cuando la salida es un traslado</param>
        /// <param name="tmpListaKardex">Lista en formato "List(ModeloInvKardexMaestro)" de registros a cargar en almacen</param>
        /// <returns>Retorna true/false para indicar si la operacion tuvo exito.</returns>
        public static bool flgInvGestKardexMovSalidas(String tcrTipoSalida, String tcrCodigoAlmacen,
                                                      String tcrCodigoAlmacenDestino, List<ModeloInvKardexMaestro> tmpListaKardex)
        {
            var llgReturn = false;
            try
            {
                var tmpDescargue = flsInvGestConsolidarDesCargueKardex(tcrCodigoAlmacen, tmpListaKardex);
                List<ModeloInvKardexMaestro> tmpTransacciones = new List<ModeloInvKardexMaestro>();

                // Generar Registros transacciones para descargas y actualizar Kardex
                if (flgInvGestKardexMovTransacciones(ref tmpDescargue, ref tmpTransacciones))
                {

                    var lnuTotalReg = tmpTransacciones.Count;
                    var lnuRangoRegistros = SysModelo.fnuActualizar("1", "INV-MAESTRO-KARDEX-DIARIO", lnuTotalReg + 1); // Reservar el rango a usuar
                    var lnuContador = lnuRangoRegistros - lnuTotalReg;
                    var lobReSecuencial = SYSValidarCodigo.fobRegBuscarSysgeneradorcod("INV-MAESTRO-KARDEX-DIARIO");
                    var lcrLlaveRegistro = String.Empty;
                    EFinvkardexmaestr lobRegNew = null;

                    //-----------------------------------------
                    // Actualizar en maestro Kardex
                    //-----------------------------------------
                    #region Generar transacciones en maestro Kardex
                    using (_context = new DbAplicacion())
                    {
                        foreach (var lobReg in tmpTransacciones)
                        {
                            //--------------------------------------------------
                            // Modificar el registro de existencias
                            #region Modificar registro de existencias
                            var lobjRegKardex = _context.Invkardexmaestr.FirstOrDefault(p => p.inv_seckar_inka == lobReg.Inv_seckar_inka);
                            if (lobjRegKardex != null)
                            {
                                // restar del registro la unidades salientes de la transaccion
                                lobjRegKardex.inv_totuni_inex = lobjRegKardex.inv_totuni_inex - lobReg.Inv_tottra_inex;
                            }
                            #endregion
                            //--------------------------------------------------
                            // Agregar registro nuevo de la transaccion de salida
                            #region Agregar registro transaccion de salida

                            lcrLlaveRegistro = SysModelo.fcrGenFormatoSecuencial(lobReSecuencial, lnuContador);
                            lobRegNew = fobInvGenNuevoRegTmpKardex(lobReg);
                            lobRegNew.inv_seckar_inka = lcrLlaveRegistro;
                            lobRegNew.inv_totuni_inex = 0;      // las salidas llevan este campo en cero

                            _context.AddToInvkardexmaestr(lobRegNew);
                            lnuContador++;
                            #endregion
                        }
                        _context.SaveChanges();
                        llgReturn = true;
                    }
                    #endregion
                    //-----------------------------------------
                    // Actualizar en maestro existencias
                    //-----------------------------------------
                    #region Actualizar en maestro existencias
                    using (_context = new DbAplicacion())
                    {
                        foreach (var lobReg in tmpDescargue)
                        {
                            // Actualizar existencias en maestro 
                            var lobRegAux = _context.Invalmacexisten.FirstOrDefault(p => p.inv_secart_inar == lobReg.Inv_secart_inar &&
                                                                                            p.inv_codalm_inal == lobReg.Inv_codalm_inal);
                            if (lobRegAux != null)
                            {
                                // actualizar existente y sumar unidades
                                lobRegAux.inv_totuni_inex = lobReg.Inv_totuni_inex;
                            }
                        }
                        _context.SaveChanges();
                        llgReturn = true;
                    }
                    #endregion
                    //-----------------------------------------
                    // Cuando es salida por traslado 
                    //-----------------------------------------
                    #region Generar ingreos en almacen destino
                    if (tcrTipoSalida == "S22")
                    {
                        // Generar el registro de ingreso
                        foreach (var lobReg in tmpTransacciones)
                        {
                            // Complementar datos para registro de nueva transaccion salida - se transforman los valores en registro salida
                            #region Complementar datos
                            lobReg.Inv_codalm_inal = tcrCodigoAlmacenDestino;
                            lobReg.Inv_tipmov_intr = "1";
                            lobReg.Inv_conmov_incm = "E13"; // E13= Entrads por traslados
                            lobReg.Inv_totuni_inex = lobReg.Inv_tottra_inex; // unidades de la transaccion salida se convierten en unidades de ingreso
                            #endregion
                        }
                        llgReturn = flgInvMaesKardexMovEntradas(tcrCodigoAlmacenDestino, tmpTransacciones);
                    }
                    #endregion
                }
            }
            catch (Exception ex)
            {
                Funciones.fcvVistaErroresEjecucion(ref ex, "Modelo Error Metodo: flgInvGestKardexMovSalidas");
            }
            return llgReturn;
        }
        #endregion
        #region flgInvGestKardexMovTransacciones: Generar registros transacciones de salida
        /// <summary>
        /// Generar registros para transacciones que se adicionan como nuevos Registros de salida en kardex diario
        /// </summary>
        /// <param name="tmpListaCargue">Lista en formato "List(ModeloInvKardexMaestro)" de registros a cargar en almacen</param>
        /// <returns>Retorna true/false para indicar si la operacion tuvo exito.</returns>
        public static bool flgInvGestKardexMovTransacciones(ref List<ModeloInvKardexMaestro> tmpDescargue, ref List<ModeloInvKardexMaestro> tmpTransacciones)
        {
            var llgReturn = false;
            try
            {
                var lnuUnitPendientes = 0;
                var lnuUnitTransaccion = 0;
                List<ModeloInvKardexMaestro> tmpExistencias = null;

                //----------------------------------------------------
                // Generar Registros transacciones para descargas
                //----------------------------------------------------
                #region Generar Registros
                foreach (var lobRegDescar in tmpDescargue)
                {
                    // Unidades para gestion
                    lnuUnitPendientes  = lobRegDescar.Inv_tottra_inex;
                    lnuUnitTransaccion = lobRegDescar.Inv_tottra_inex;

                    // Debe conservar el valor del campo Inv_seckar_inka  para usarlo al actualizar las existencias 
                    // el campo Inv_tottra_inex maneja las unidades salientes 
                    // el registro "lobRegExisten" se transforma en nuevo registro para transaccion salida en Kardex

                    // Lista de registros que contienen unidades existencias del articulo en Kardex 
                    tmpExistencias = flsInvGestKardexExistencias(lobRegDescar.Inv_secart_inar, lobRegDescar.Inv_codalm_inal);

                    if (tmpExistencias.Count > 0)
                    {
                        llgReturn = true;
                        lobRegDescar.Inv_totuni_inex = 0;

                        #region Generar Registros transacciones
                        foreach (var lobRegExisten in tmpExistencias)
                        {
                            if (lnuUnitPendientes > 0)
                            {
                                // Complementar datos para registro de nueva transaccion salida - se transforman los valores en registro salida
                                #region Complementar datos
                                lobRegExisten.Inv_refkar_inka = lobRegExisten.Inv_seckar_inka;
                                lobRegExisten.Inv_codalm_inal = lobRegDescar.Inv_codalm_inal;
                                lobRegExisten.Inv_codper_inpe = lobRegDescar.Inv_codper_inpe;
                                lobRegExisten.Inv_llavkr_inka = lobRegDescar.Inv_llavkr_inka;
                                lobRegExisten.Inv_tiparc_inag = lobRegDescar.Inv_tiparc_inag;
                                lobRegExisten.Inv_fecges_inka = lobRegDescar.Inv_fecges_inka;
                                lobRegExisten.Inv_numdoc_inka = lobRegDescar.Inv_numdoc_inka;
                                lobRegExisten.Inv_tipmov_intr = "2";
                                lobRegExisten.Inv_conmov_incm = lobRegDescar.Inv_conmov_incm;
                                //lobRegExisten.Inv_valing_inar = lobRegDescar.Inv_valing_inar;
                                //lobRegExisten.Inv_valmov_inar = lobRegDescar.Inv_valmov_inar;
                                lobRegExisten.Sys_codusu_usux = lobRegDescar.Sys_codusu_usux;
                                #endregion
                                //----------------------------------------------------
                                // Buscar el registro real en Kardex
                                if (lobRegExisten.Inv_totuni_inex >= lnuUnitPendientes)
                                {
                                    lobRegExisten.Inv_tottra_inex = lnuUnitPendientes;     // la transaccion es unidades que se tomaron del registro
                                    lobRegExisten.Inv_totuni_inex = lobRegExisten.Inv_totuni_inex - lnuUnitPendientes; // unidades que todavia quedan
                                    lnuUnitPendientes = 0;
                                }
                                else
                                {
                                    //----------------------------------------------------
                                    // Actualizar datos para procesos de actualizacion
                                    lobRegExisten.Inv_tottra_inex = lobRegExisten.Inv_totuni_inex; // la transaccion es unidades que se tomaron del registro

                                    lnuUnitPendientes = lnuUnitPendientes - lobRegExisten.Inv_totuni_inex;
                                    lobRegExisten.Inv_totuni_inex = 0;                               // el registro queda vacio  
                                }

                                //  agregar el registro para transaccion
                                tmpTransacciones.Add(lobRegExisten);
                            }
                            // Para actualizar existencias en Maestro existencias del articulo mas adelante
                            lobRegDescar.Inv_totuni_inex = lobRegDescar.Inv_totuni_inex + lobRegExisten.Inv_totuni_inex;
                        }
                        #endregion
                    }
                }
                #endregion
            }
            catch (Exception ex)
            {
                Funciones.fcvVistaErroresEjecucion(ref ex, "Modelo Error Metodo: flgInvGestKardexMovTransacciones");
            }
            return llgReturn;
        }
        #endregion
        #region flsInvGestConsolidarDesCargueKardex: Consolidar registros de entradas/salidas formato Kardex
        /// <summary>
        /// <para>consolidar registros de entradas/Salidas en registros unicos para evitar duplicidades al descargar en "Maestros Kardex"</para>
        /// <para>este procedimiento suma en uno solo, cuando existen dos o mas registros de un mismo articulo en Kardex (se ignoran codigo de lote diferente).</para>
        /// </summary>
        /// <param name="tcrCodigoAlmacen">Codigo del almacen para el cual se realizara la transaccion</param>
        /// <param name="tmpListaKardex">Lista en formato "List(ModeloInvKardexMaestro)" de registros a consolidar</param>
        /// <returns>listado "List(ModeloInvKardexMaestro)" ya consolidada sin duplicidadespara cargue/descargue en almacen.</returns>
        public static List<ModeloInvKardexMaestro> flsInvGestConsolidarDesCargueKardex(String tcrCodigoAlmacen, List<ModeloInvKardexMaestro> tmpListaKardex)
        {
            List<ModeloInvKardexMaestro> tmpListReturn = new List<ModeloInvKardexMaestro>();
            try
            {
                foreach (var lobReg in tmpListaKardex)
                {
                    lobReg.Inv_codalm_inal = tcrCodigoAlmacen;
                    var lobRegAux = tmpListReturn.FirstOrDefault(x => x.Inv_secart_inar == lobReg.Inv_secart_inar);
                    if (lobRegAux == null)
                    {
                        // Generar nuevo registro
                        tmpListReturn.Add(lobReg);
                    }
                    else
                    {
                        #region cargar Registro
                        // actualizar existente y sumar unidades
                        lobRegAux.Sis_codgme_sigr = lobReg.Sis_codgme_sigr;
                        lobRegAux.Sis_codume_sium = lobReg.Sis_codume_sium;
                        lobRegAux.Inv_tottra_inex = lobRegAux.Inv_tottra_inex + lobReg.Inv_tottra_inex;
                        // Asumir nuevos valores como actualizados
                        lobRegAux.Inv_valing_inar = lobReg.Inv_valing_inar;
                        lobRegAux.Inv_valmov_inar = lobReg.Inv_valmov_inar;
                        // Ubicacion en estantes
                        lobRegAux.Inv_codest_ines = lobReg.Inv_codest_ines;
                        lobRegAux.Inv_seccio_ines = lobReg.Inv_seccio_ines;
                        lobRegAux.Inv_estant_ines = lobReg.Inv_estant_ines;
                        #endregion
                    }
                }
            }
            catch (Exception ex)
            {
                Funciones.fcvVistaErroresEjecucion(ref ex, "Modelo Error Metodo: flsInvGestConsolidarDesCargueKardex");
            }
            return tmpListReturn;
        }
        #endregion
        // Anular Transacciones Entrads/Salidas de inventario
        #region flgInvMaesKardexMovAnular: Movimiento Maestro Anular Kardex de entrada o salida
        /// <summary>
        /// <para>Movimiento Maestro anular entrada/salida en Kardex y restaurar el numero de unidades en maestro exitencias</para>
        /// <para>dado el numero secuencial del registro maestro de la transaccion segun Modulo con el cual se realizo la entrada/salida del Kardex</para>
        /// </summary>
        /// <param name="tcrNumeroDocumento">Codigo o numero secuencial del registro maestro compras, ventas o entrega medicamentos</param>
        /// <returns>Retorna true/false para indicar si la operacion tuvo exito.</returns>
        public static bool flgInvMaesKardexMovAnular(String tcrNumeroDocumento)
        {
            var llgReturn = false;
            try
            {
                var tmpDatos = flsInvGestRegConsultaDocumentoKardex(tcrNumeroDocumento);

                using (_context = new DbAplicacion())
                {
                    // Proceso en Maestro Kardex
                    #region Gestion Kardex
                    foreach (var lobReg in tmpDatos)
                    {
                        var lobRegAux = _context.Invkardexmaestr.FirstOrDefault(p => p.inv_seckar_inka == lobReg.Inv_seckar_inka);
                        if (lobRegAux != null)
                        {
                            lobRegAux.sis_estpro_espr = "3"; // anular
                        }

                        // cuando se anula una salida se deve devolver las unidades al registro kardex que las contenia
                        if (lobReg.Inv_tipmov_intr == "2")
                        {
                            // Buscar registro que contenia las unidades desde la referencia guardada y asi poder recargar las unidades 
                            var lobRegAnterior = _context.Invkardexmaestr.FirstOrDefault(p => p.inv_seckar_inka == lobReg.Inv_refkar_inka);
                            if (lobRegAnterior != null)
                            {
                                // Reponer las unidades en el registro de donde se tomaron anteriormente
                                lobRegAnterior.inv_totuni_inex = lobRegAnterior.inv_totuni_inex + lobReg.Inv_tottra_inex;
                            }
                        }

                    }
                    #endregion
                    // guardar los cambios
                    _context.SaveChanges();
                }
                // Proceso en Maestro Existencias 
                using (_context = new DbAplicacion())
                {
                    #region Gestion existencias
                    // Restaurar cantidades
                    foreach (var lobReg in tmpDatos)
                    {
                        var lobRegAux = _context.Invalmacexisten.FirstOrDefault(p => p.inv_secart_inar == lobReg.Inv_secart_inar &&
                                                                                        p.inv_codalm_inal == lobReg.Inv_codalm_inal);
                        if (lobRegAux != null)
                        {
                            llgReturn = true;
                            // sumar/restar unidades => tcrTipoMovimiento: 1=Entras 2=Salidas
                            #region Actualizar
                            if (lobReg.Inv_tipmov_intr == "1")
                            {
                                // Cuando el proceso era un ingreso se restan 
                                lobRegAux.inv_totuni_inex = lobRegAux.inv_totuni_inex - lobReg.Inv_tottra_inex;
                            }
                            else
                            {
                                // Cuando el proceso era una salida se suman las existencias
                                lobRegAux.inv_totuni_inex = lobRegAux.inv_totuni_inex + lobReg.Inv_tottra_inex;
                            }

                            lobRegAux.inv_valcos_inex = lobRegAux.inv_valing_inar * lobRegAux.inv_totuni_inex;
                            #endregion
                        }
                    }
                    #endregion
                    // guardar los cambios
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Funciones.fcvVistaErroresEjecucion(ref ex, "Modelo Error Metodo: flgInvMaesKardexMovAnular");
            }
            return llgReturn;
        }
        #endregion
        // Procesos auxiliares verios
        #region fobInvGenNuevoRegTmpKardex: generar nuevo registro temporal Kardex
        /// <summary>
        /// Generar nuevo registro temporal para agregar en maestro de Kardex 
        /// </summary>
        public static EFinvkardexmaestr fobInvGenNuevoRegTmpKardex(ModeloInvKardexMaestro tobRegistro)
        {
            var lobjRegistro = new EFinvkardexmaestr
            {
                #region cargar Registro
                inv_seckar_inka = tobRegistro.Inv_seckar_inka,
                inv_codalm_inal = tobRegistro.Inv_codalm_inal,
                inv_codper_inpe = tobRegistro.Inv_codper_inpe,
                inv_llavkr_inka = tobRegistro.Inv_llavkr_inka,
                inv_tiparc_inag = tobRegistro.Inv_tiparc_inag,
                inv_fecges_inka = tobRegistro.Inv_fecges_inka,
                inv_numdoc_inka = tobRegistro.Inv_numdoc_inka,
                inv_refkar_inka = tobRegistro.Inv_refkar_inka,
                inv_tipreg_inka = tobRegistro.Inv_tipreg_inka,
                inv_tipmov_intr = tobRegistro.Inv_tipmov_intr,
                inv_conmov_incm = tobRegistro.Inv_conmov_incm,
                inv_secart_inar = tobRegistro.Inv_secart_inar,
                inv_codaux_inar = tobRegistro.Inv_codaux_inar,
                inv_lotref_inar = tobRegistro.Inv_lotref_inar,
                inv_fecven_inka = tobRegistro.Inv_fecven_inka,
                sis_codgme_sigr = tobRegistro.Sis_codgme_sigr,
                sis_codume_sium = tobRegistro.Sis_codume_sium,
                inv_totuni_inex = tobRegistro.Inv_totuni_inex,
                inv_tottra_inex = tobRegistro.Inv_tottra_inex,
                inv_valing_inar = tobRegistro.Inv_valing_inar,
                inv_valmov_inar = tobRegistro.Inv_valmov_inar,
                sys_codusu_usux = tobRegistro.Sys_codusu_usux,
                sis_estpro_espr = tobRegistro.Sis_estpro_espr,
                #endregion
            };
            return lobjRegistro;
        }
        #endregion
        // Consultas SQL
        #region flsInvGestKardexExistencias: Listar registros Kardex existencias articulo en almacen
        /// <summary>
        /// Devuelve lista de Kardex existencias del articulo en almacen (solo registros que contienen unidades mayor que cero)
        /// </summary>
        /// <param name="tcrCodigoArticulo">Codigo del articulo solicitado</param>
        /// <param name="tcrCodigoAlmacen">Codigo del almacen</param>
        /// <returns>Lista registros existencias del articulo en almacen dado</returns>
        public static List<ModeloInvKardexMaestro> flsInvGestKardexExistencias(String tcrCodigoArticulo, String tcrCodigoAlmacen)
        {
            using (_context = new DbAplicacion())
            {
                var lobConsulta = from invkardexmaestr in _context.Invkardexmaestr
                                  where invkardexmaestr.inv_secart_inar == tcrCodigoArticulo &&
                                        invkardexmaestr.inv_codalm_inal == tcrCodigoAlmacen &&
                                        invkardexmaestr.inv_tipmov_intr == "1" &&
                                        invkardexmaestr.sis_estpro_espr == "2" &&
                                        invkardexmaestr.inv_totuni_inex > 0
                                  orderby invkardexmaestr.inv_fecven_inka
                                  select new ModeloInvKardexMaestro
                                  {
                                      #region Datos
                                      Inv_seckar_inka = invkardexmaestr.inv_seckar_inka,
                                      Inv_codalm_inal = invkardexmaestr.inv_codalm_inal,
                                      Inv_codper_inpe = invkardexmaestr.inv_codper_inpe,
                                      Inv_llavkr_inka = invkardexmaestr.inv_llavkr_inka,
                                      Inv_tiparc_inag = invkardexmaestr.inv_tiparc_inag,
                                      Inv_fecges_inka = (DateTime)invkardexmaestr.inv_fecges_inka,
                                      Inv_numdoc_inka = invkardexmaestr.inv_numdoc_inka,
                                      Inv_refkar_inka = invkardexmaestr.inv_refkar_inka,
                                      Inv_tipreg_inka = invkardexmaestr.inv_tipreg_inka,
                                      Inv_tipmov_intr = invkardexmaestr.inv_tipmov_intr,
                                      Inv_conmov_incm = invkardexmaestr.inv_conmov_incm,
                                      Inv_secart_inar = invkardexmaestr.inv_secart_inar,
                                      Inv_codaux_inar = invkardexmaestr.inv_codaux_inar,
                                      Inv_lotref_inar = invkardexmaestr.inv_lotref_inar,
                                      Inv_fecven_inka = (DateTime)invkardexmaestr.inv_fecven_inka,
                                      Sis_codgme_sigr = invkardexmaestr.sis_codgme_sigr,
                                      Sis_codume_sium = invkardexmaestr.sis_codume_sium,
                                      Inv_totuni_inex = (int)invkardexmaestr.inv_totuni_inex,
                                      Inv_tottra_inex = (int)invkardexmaestr.inv_tottra_inex,
                                      Inv_valing_inar = (float)invkardexmaestr.inv_valing_inar,
                                      Inv_valmov_inar = (float)invkardexmaestr.inv_valmov_inar,
                                      Sys_codusu_usux = invkardexmaestr.sys_codusu_usux,
                                      Sis_estpro_espr = invkardexmaestr.sis_estpro_espr,
                                      Sis_estado_imaen = "I",
                                      #endregion
                                  };
                return lobConsulta.ToList();
            }
        }
        #endregion
        #region flsInvGestRegConsultaDocumentoKardex: Listar registros Kardex pertenecientes a un documento
        /// <summary>
        /// devuelve lista registros maestro Kardex que pertenecen a un documento de gestion (una compra/venta/traslados y otros)
        /// </summary>
        /// <param name="tcrNumeroDocumento">Codigo o numero secuencial del registro maestro compras, ventas o entrega medicamentos</param>
        /// <param name="tcrCodigoAlmacen">Codigo del almacen</param>
        /// <returns>Lista registros existencias del articulo en almacen dado</returns>
        public static List<ModeloInvKardexMaestro> flsInvGestRegConsultaDocumentoKardex(String tcrNumeroDocumento)
        {
            using (_context = new DbAplicacion())
            {
                var lobConsulta = from invkardexmaestr in _context.Invkardexmaestr
                                  where invkardexmaestr.inv_numdoc_inka == tcrNumeroDocumento
                                  orderby invkardexmaestr.inv_fecven_inka
                                  select new ModeloInvKardexMaestro
                                  {
                                      #region Datos
                                      Inv_seckar_inka = invkardexmaestr.inv_seckar_inka,
                                      Inv_codalm_inal = invkardexmaestr.inv_codalm_inal,
                                      Inv_codper_inpe = invkardexmaestr.inv_codper_inpe,
                                      Inv_llavkr_inka = invkardexmaestr.inv_llavkr_inka,
                                      Inv_tiparc_inag = invkardexmaestr.inv_tiparc_inag,
                                      Inv_fecges_inka = (DateTime)invkardexmaestr.inv_fecges_inka,
                                      Inv_numdoc_inka = invkardexmaestr.inv_numdoc_inka,
                                      Inv_refkar_inka = invkardexmaestr.inv_refkar_inka,
                                      Inv_tipreg_inka = invkardexmaestr.inv_tipreg_inka,
                                      Inv_tipmov_intr = invkardexmaestr.inv_tipmov_intr,
                                      Inv_conmov_incm = invkardexmaestr.inv_conmov_incm,
                                      Inv_secart_inar = invkardexmaestr.inv_secart_inar,
                                      Inv_codaux_inar = invkardexmaestr.inv_codaux_inar,
                                      Inv_lotref_inar = invkardexmaestr.inv_lotref_inar,
                                      Inv_fecven_inka = (DateTime)invkardexmaestr.inv_fecven_inka,
                                      Sis_codgme_sigr = invkardexmaestr.sis_codgme_sigr,
                                      Sis_codume_sium = invkardexmaestr.sis_codume_sium,
                                      Inv_totuni_inex = (int)invkardexmaestr.inv_totuni_inex,
                                      Inv_tottra_inex = (int)invkardexmaestr.inv_tottra_inex,
                                      Inv_valing_inar = (float)invkardexmaestr.inv_valing_inar,
                                      Inv_valmov_inar = (float)invkardexmaestr.inv_valmov_inar,
                                      Sys_codusu_usux = invkardexmaestr.sys_codusu_usux,
                                      Sis_estpro_espr = invkardexmaestr.sis_estpro_espr,
                                      Sis_estado_imaen = "I",
                                      #endregion
                                  };
                return lobConsulta.ToList();
            }
        }
        #endregion
        // Registros de Articulos agrupados por lotes
        #region flsInvRegArticuloLote : lista de registro de articulos agrupados por lotes
        /// <summary> 
        /// <param name="tcrNumeroDocumento">Codigo Numero de registros de gestion del movimiento</param>
        /// <param name="tcrCodigoAlmacen">Codigo del articulo</param>
        /// <returns>Lista registros agrupados por lotes</returns>
        /// </summary>
        public static List<ModeloInvKardexMaestro> flsInvRegArticuloLotes(String tcrNumeroDocumento, String tcrCodigoArticulo)
        {

            using (_context = new DbAplicacion())
            {
                var lobConsulta = from invkardexmaestr in _context.Invkardexmaestr
                                  where invkardexmaestr.inv_numdoc_inka == tcrNumeroDocumento &&
                                        invkardexmaestr.inv_tipmov_intr == "2" &&
                                        invkardexmaestr.inv_secart_inar == tcrCodigoArticulo
                                  select new ModeloInvKardexMaestro
                                  {
                                      #region Datos
                                      Inv_seckar_inka = invkardexmaestr.inv_seckar_inka,
                                      Inv_codalm_inal = invkardexmaestr.inv_codalm_inal,
                                      Inv_codper_inpe = invkardexmaestr.inv_codper_inpe,
                                      Inv_llavkr_inka = invkardexmaestr.inv_llavkr_inka,
                                      Inv_tiparc_inag = invkardexmaestr.inv_tiparc_inag,
                                      Inv_fecges_inka = (DateTime)invkardexmaestr.inv_fecges_inka,
                                      Inv_numdoc_inka = invkardexmaestr.inv_numdoc_inka,
                                      Inv_refkar_inka = invkardexmaestr.inv_refkar_inka,
                                      Inv_tipreg_inka = invkardexmaestr.inv_tipreg_inka,
                                      Inv_tipmov_intr = invkardexmaestr.inv_tipmov_intr,
                                      Inv_conmov_incm = invkardexmaestr.inv_conmov_incm,
                                      Inv_secart_inar = invkardexmaestr.inv_secart_inar,
                                      Inv_codaux_inar = invkardexmaestr.inv_codaux_inar,
                                      Inv_lotref_inar = invkardexmaestr.inv_lotref_inar,
                                      Inv_fecven_inka = (DateTime)invkardexmaestr.inv_fecven_inka,
                                      Sis_codgme_sigr = invkardexmaestr.sis_codgme_sigr,
                                      Sis_codume_sium = invkardexmaestr.sis_codume_sium,
                                      Inv_totuni_inex = (int)invkardexmaestr.inv_totuni_inex,
                                      Inv_tottra_inex = (int)invkardexmaestr.inv_tottra_inex,
                                      Inv_valing_inar = (float)invkardexmaestr.inv_valing_inar,
                                      Inv_valmov_inar = (float)invkardexmaestr.inv_valmov_inar,
                                      Sys_codusu_usux = invkardexmaestr.sys_codusu_usux,
                                      Sis_estpro_espr = invkardexmaestr.sis_estpro_espr,
                                      Sis_estado_imaen = "I",
                                      #endregion
                                  };
                return lobConsulta.ToList();
            }

        }
        #endregion
        #endregion
    }
    #endregion
    #region Modelo de Existencias
    /// <summary>
    /// Tabla invalmacexisten: Existencias totales en tiempo real por cada articulo en un almacen, sin tener presente Lotes/Referencias
    /// </summary>
    public class ModeloInvAlmacenExistencias : clBaseInpc
    {
        #region Modelo Attributos
        private static DbAplicacion _context;
        #region Modelo Propiedades Notificacion
        #region Inv_secreg_incx: Codigo registro
        private String _inv_secreg_incx;
        /// <summary>
        /// <para>TABLA: invalmacexisten</para>
        /// <para>TABLA NATIVA: invtiporecompra</para>
        /// <para>CAMPO: Codigo registro</para>
        /// <para>NOMBRE: inv_secreg_incx (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        /// Secuencial unico para cada registro detalle de la tabla (generado
        /// por el sistema)
        /// </para>
        /// </summary>
        public String Inv_secreg_incx
        {
            get { return _inv_secreg_incx; }
            set
            {
                if (_inv_secreg_incx == value) return;
                _inv_secreg_incx = value;
                OnPropertyChanged("Inv_secreg_incx");
            }
        }
        #endregion
        #region Inv_conmov_incm: Concepto de Movimiento
        private String _inv_conmov_incm;
        /// <summary>
        /// <para>TABLA: invalmacexisten</para>
        /// <para>TABLA NATIVA: invtipoconcemov</para>
        /// <para>CAMPO: Concepto de Movimiento</para>
        /// <para>NOMBRE: inv_conmov_incm (char:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        ///Concepto movimiento diario: E11 =Entrada saldo inicial inventario o del mes 
        ///E12= Entradas compras ...  S21= Salidas Ventas 22= Salidas Traslado 
        ///S23= Salidas Otras Áreas Empresa S24= Salida entrega formula 
        ///A30=Ajuste de inventarios y otros
        /// </para>
        /// </summary>
        public String Inv_conmov_incm
        {
            get { return _inv_conmov_incm; }
            set
            {
                if (_inv_conmov_incm == value) return;
                _inv_conmov_incm = value;
                OnPropertyChanged("Inv_conmov_incm");
            }
        }
        #endregion
        #region Inv_codalm_inal: Código Almacén
        private String _inv_codalm_inal;
        /// <summary>
        /// <para>TABLA: invalmacexisten</para>
        /// <para>TABLA NATIVA: invalmacenmaest</para>
        /// <para>CAMPO: Código Almacén</para>
        /// <para>NOMBRE: inv_codalm_inal (char:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Código del Almacén que realiza el movimiento
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
        #region Inv_secart_inar: Secuencial Articulo
        private String _inv_secart_inar;
        /// <summary>
        /// <para>TABLA: invalmacexisten</para>
        /// <para>TABLA NATIVA: invmaearticulos</para>
        /// <para>CAMPO: Secuencial Articulo</para>
        /// <para>NOMBRE: inv_secart_inar (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
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
        #region Inv_codaux_inar: Código Auxiliar Articulo
        private String _inv_codaux_inar;
        /// <summary>
        /// <para>TABLA: invalmacexisten</para>
        /// <para>TABLA NATIVA: invmaearticulos</para>
        /// <para>CAMPO: Código Auxiliar Articulo</para>
        /// <para>NOMBRE: inv_codaux_inar (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
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
        #region Inv_codbar_inar: Código Barras Articulo
        private String _inv_codbar_inar;
        /// <summary>
        /// <para>TABLA: invalmacexisten</para>
        /// <para>TABLA NATIVA: invmaearticulos</para>
        /// <para>CAMPO: Código Auxiliar Articulo</para>
        /// <para>NOMBRE: inv_codaux_inar (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        /// Código de Barra Articulo
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
        #region Sis_codgme_sigr: Patrón medida
        private String _sis_codgme_sigr;
        /// <summary>
        /// <para>TABLA: invalmacexisten</para>
        /// <para>TABLA NATIVA: sisgrupomedidas</para>
        /// <para>CAMPO: Patrón medida</para>
        /// <para>NOMBRE: sis_codgme_sigr (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
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
        /// <para>TABLA: invalmacexisten</para>
        /// <para>TABLA NATIVA: sisunidadmedida</para>
        /// <para>CAMPO: Medida Almacenamiento</para>
        /// <para>NOMBRE: sis_codume_sium (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
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
        #region Inv_totuni_inex: Unidades existencias
        private int _inv_totuni_inex;
        /// <summary>
        /// <para>TABLA: invalmacexisten</para>
        /// <para>TABLA NATIVA: invalmacexisten</para>
        /// <para>CAMPO: Unidades existencias</para>
        /// <para>NOMBRE: inv_totuni_inex (int:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        /// TOTAL UNIDADES EN EXISTENCIAS, cantidad de unidades en existencias
        /// (suma todos los lotes del articulo cuando existen)
        /// </para>
        /// </summary>
        public int Inv_totuni_inex
        {
            get { return _inv_totuni_inex; }
            set
            {
                if (_inv_totuni_inex == value) return;
                _inv_totuni_inex = value;
                OnPropertyChanged("Inv_totuni_inex");
            }
        }
        #endregion
        #region Inv_valing_inar: Valor  Ingreso unidad
        private float _inv_valing_inar;
        /// <summary>
        /// <para>TABLA: invalmacexisten</para>
        /// <para>TABLA NATIVA: invmaearticulos</para>
        /// <para>CAMPO: Valor  Ingreso unidad</para>
        /// <para>NOMBRE: inv_valing_inar (float:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        /// VALOR INGRESO, Valor Ingreso unidad de articulos en inventario
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
        #region Inv_valmov_inar: Valor salida unidad
        private float _inv_valmov_inar;
        /// <summary>
        /// <para>TABLA: invalmacexisten</para>
        /// <para>TABLA NATIVA: invmaearticulos</para>
        /// <para>CAMPO: Valor salida unidad</para>
        /// <para>NOMBRE: inv_valmov_inar (float:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION:
        /// VALOR SALIDA UNIDAD, Valor Movimiento de salida (venta) cada
        /// unidad
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
        #region Inv_valcos_inex: Valor total costo
        private float _inv_valcos_inex;
        /// <summary>
        /// <para>TABLA: invalmacexisten</para>
        /// <para>TABLA NATIVA: invalmacexisten</para>
        /// <para>CAMPO: Valor total costo</para>
        /// <para>NOMBRE: inv_valcos_inex (float:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
        /// <para>DESCRIPCION:
        /// Valor total en costo de compra de actuales existencias en almacen
        /// </para>
        /// </summary>
        public float Inv_valcos_inex
        {
            get { return _inv_valcos_inex; }
            set
            {
                if (_inv_valcos_inex == value) return;
                _inv_valcos_inex = value;
                OnPropertyChanged("Inv_valcos_inex");
            }
        }
        #endregion
        #region Inv_valfac_incd: Valor total Factura
        //private float _inv_valfac_incd;
        ///// <summary>
        ///// <para>TABLA: invalmacexisten</para>
        ///// <para>TABLA NATIVA: invalmacexisten</para>
        ///// <para>CAMPO: Valor total costo</para>
        ///// <para>NOMBRE: _inv_valfac_incd (float:172)</para>
        ///// <para>ORDEN VISTA EN TABLA: 10</para>
        ///// <para>DESCRIPCION:
        ///// Valor total en costo de compra de actuales existencias en almacen
        ///// </para>
        ///// </summary>
        //public float Inv_valfac_incd
        //{
        //    get { return _inv_valfac_incd; }
        //    set
        //    {
        //        if (_inv_valfac_incd == value) return;
        //        _inv_valfac_incd = value;
        //        OnPropertyChanged("Inv_valfac_incd");
        //    }
        //}
        #endregion
        #region Inv_codest_ines: Código Estante
        private String _inv_codest_ines;
        /// <summary>
        /// <para>TABLA: invalmacexisten</para>
        /// <para>TABLA NATIVA: invalmacenestan</para>
        /// <para>CAMPO: Código Estante</para>
        /// <para>NOMBRE: inv_codest_ines (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 11</para>
        /// <para>DESCRIPCION:
        /// Codgo del estante para cada almacen: Ejemplo E01-Estante Medicamentos
        /// de control
        /// </para>
        /// </summary>
        public String Inv_codest_ines
        {
            get { return _inv_codest_ines; }
            set
            {
                if (_inv_codest_ines == value) return;
                _inv_codest_ines = value;
                OnPropertyChanged("Inv_codest_ines");
            }
        }
        #endregion
        #region Inv_seccio_ines: Secciones
        private String _inv_seccio_ines;
        /// <summary>
        /// <para>TABLA: invalmacexisten</para>
        /// <para>TABLA NATIVA: invalmacenestan</para>
        /// <para>CAMPO: Secciones</para>
        /// <para>NOMBRE: inv_seccio_ines (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 12</para>
        /// <para>DESCRIPCION:
        /// Lista de secciones del estante para validacion (generada por
        /// el sistema) ejemplo: S01,S02,S03,S04 según el numero de secciones
        /// que contenga el estante
        /// </para>
        /// </summary>
        public String Inv_seccio_ines
        {
            get { return _inv_seccio_ines; }
            set
            {
                if (_inv_seccio_ines == value) return;
                _inv_seccio_ines = value;
                OnPropertyChanged("Inv_seccio_ines");
            }
        }
        #endregion
        #region Inv_estant_ines: Vista estante
        private String _inv_estant_ines;
        /// <summary>
        /// <para>TABLA: invalmacexisten</para>
        /// <para>TABLA NATIVA: invalmacenestan</para>
        /// <para>CAMPO: Vista estante</para>
        /// <para>NOMBRE: inv_estant_ines (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 13</para>
        /// <para>DESCRIPCION:
        /// Codigo del estante sumado con la seccion, para llave de organización
        /// vista ejemplo: Estante = E01  y Seccion = S05  queda asi: E01S05
        /// </para>
        /// </summary>
        public String Inv_estant_ines
        {
            get { return _inv_estant_ines; }
            set
            {
                if (_inv_estant_ines == value) return;
                _inv_estant_ines = value;
                OnPropertyChanged("Inv_estant_ines");
            }
        }
        #endregion
        #region Sis_estpro_espr: Estado Registro
        private String _sis_estpro_espr;
        /// <summary>
        /// <para>TABLA: invalmacexisten</para>
        /// <para>TABLA NATIVA: sisestadoproces</para>
        /// <para>CAMPO: Estado Registro</para>
        /// <para>NOMBRE: sis_estpro_espr (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 14</para>
        /// <para>DESCRIPCION:
        /// Estado del registro se marca como anulado no se tendra en cuenta
        /// en procesos por lotes de cierre y otros: 1=Abierto 2=Confirmado
        /// 3=Anulado
        /// </para>
        /// </summary>
        public String Sis_estpro_espr
        {
            get { return _sis_estpro_espr; }
            set
            {
                if (_sis_estpro_espr == value) return;
                _sis_estpro_espr = value;
                OnPropertyChanged("Sis_estpro_espr");
            }
        }
        #endregion
        #region Inv_desalm_inal: Descripción Almacén
        private String _inv_desalm_inal;
        /// <summary>
        /// <para>TABLA: invalmacexisten</para>
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
        #region Inv_nomart_inar: Nombre artículo
        private String _inv_nomart_inar;
        /// <summary>
        /// <para>TABLA: invalmacexisten</para>
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
        #region Inv_codctn_intc: Codigo Contenedor
        private String _inv_codctn_intc;
        /// <summary>
        /// <para>TABLA: invalmacexisten</para>
        /// <para>TABLA NATIVA: invcontenedores</para>
        /// <para>CAMPO: Codigo Contenedor</para>
        /// <para>NOMBRE: inv_codctn_intc (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        /// Código tipo de contenedor o presentación
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
        #region Inv_totaju_injd: Unidades digitadas
        private int _inv_totaju_injd;
        /// <summary>
        /// <para>TABLA: invajustesmaemr</para>
        /// <para>TABLA NATIVA: invajustesmaemd</para>
        /// <para>CAMPO: Unidades digitadas</para>
        /// <para>NOMBRE: inv_totaju_injd (int:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 14</para>
        /// <para>DESCRIPCION:
        /// UNIDADES DIGITADAS, cantidad de unidades (lo que existe en Estantes)
        /// digitadas para realizar calculo según tipo ajuste 
        /// 1= Reconteo Total inventario 2= Por suma o Resta de Unidades
        /// </para>
        /// </summary>
        public int Inv_totaju_injd
        {
            get { return _inv_totaju_injd; }
            set
            {
                if (_inv_totaju_injd == value) return;
                _inv_totaju_injd = value;
                OnPropertyChanged("Inv_totaju_injd");
            }
        }
        #endregion
        #region Inv_totmov_injd: Unidades Movimiento
        private int _inv_totmov_injd;
        /// <summary>
        /// <para>TABLA: invajustesmaemr</para>
        /// <para>TABLA NATIVA: invajustesmaemd</para>
        /// <para>CAMPO: Unidades Movimiento</para>
        /// <para>NOMBRE: inv_totmov_injd (int:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 15</para>
        /// <para>DESCRIPCION:
        /// UNIDADES MOVIMIENTO, Cantidad movimiento para Kardex, según
        /// tipo ajuste (1=reconteo/2=suma o resta unidades) si es reconteo:
        /// INV_TOTUNI_INEX - INV_TOTAJU_INJD, Cuando es suma o resta viene
        /// de cantidad de unidades digitadas INV_TOTAJU_INJD
        /// </para>
        /// </summary>
        public int Inv_totmov_injd
        {
            get { return _inv_totmov_injd; }
            set
            {
                if (_inv_totmov_injd == value) return;
                _inv_totmov_injd = value;
                OnPropertyChanged("Inv_totmov_injd");
            }
        }
        #endregion
        #region Inv_totuni_injd: Nuevo total existencias
        private int _inv_totuni_injd;
        /// <summary>
        /// <para>TABLA: invajustesmaemr</para>
        /// <para>TABLA NATIVA: invajustesmaemd</para>
        /// <para>CAMPO: Nuevo total existencias</para>
        /// <para>NOMBRE: inv_totuni_injd (int:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 16</para>
        /// <para>DESCRIPCION:
        /// NUEVO TOTAL EXISTENCIAS ALAMACEN, despues de haber realizado
        /// el calculo de ajuste este campo contiene la nueva cantidad
        /// existencias almacen para el lote
        /// </para>
        /// </summary>
        public int Inv_totuni_injd
        {
            get { return _inv_totuni_injd; }
            set
            {
                if (_inv_totuni_injd == value) return;
                _inv_totuni_injd = value;
                OnPropertyChanged("Inv_totuni_injd");
            }
        }
        #endregion
        #region Inv_desctn_intc: Descripcion Contenedor
        private String _inv_desctn_intc;
        /// <summary>
        /// <para>TABLA: invalmacexisten</para>
        /// <para>TABLA NATIVA: invcontenedores</para>
        /// <para>CAMPO: Descripcion Contenedor</para>
        /// <para>NOMBRE: inv_desctn_intc (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Descripción del contenedor de Artículo o presentación
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
        #region Sis_desgme_sigr: Descripción Grupo medida
        private String _sis_desgme_sigr;
        /// <summary>
        /// <para>TABLA: invalmacexisten</para>
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
        /// <para>TABLA: invalmacexisten</para>
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
        #region Inv_desest_ines: Descripción Estante
        private String _inv_desest_ines;
        /// <summary>
        /// <para>TABLA: invalmacexisten</para>
        /// <para>TABLA NATIVA: invalmacenestan</para>
        /// <para>CAMPO: Descripción Estante</para>
        /// <para>NOMBRE: inv_desest_ines (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        /// Descripción del estante: Ejemplo E01-Estante Medicamentos de
        /// control
        /// </para>
        /// </summary>
        public String Inv_desest_ines
        {
            get { return _inv_desest_ines; }
            set
            {
                if (_inv_desest_ines == value) return;
                _inv_desest_ines = value;
                OnPropertyChanged("Inv_desest_ines");
            }
        }
        #endregion
        #region Sis_despro_espr: Decripción estado proceso
        private String _sis_despro_espr;
        /// <summary>
        /// <para>TABLA: invalmacexisten</para>
        /// <para>TABLA NATIVA: sisestadoproces</para>
        /// <para>CAMPO: Decripción estado proceso</para>
        /// <para>NOMBRE: sis_despro_espr (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Descripcion textual del estado de proceso Abierto(a), Cerrado(a)
        /// Y Anulado(a)
        /// </para>
        /// </summary>
        public String Sis_despro_espr
        {
            get { return _sis_despro_espr; }
            set
            {
                if (_sis_despro_espr == value) return;
                _sis_despro_espr = value;
                OnPropertyChanged("Sis_despro_espr");
            }
        }
        #endregion
        #region Sis_auxiliar_espr: gestion auxiliar de algun proceso
        private String _sis_auxiliar_espr;
        /// <summary>
        /// <para>TABLA: temporal</para>
        /// <para>TABLA NATIVA: temporal</para>
        /// <para>CAMPO: Campo para gestion auxiliar de algun proceso</para>
        /// <para>NOMBRE: Sis_auxiliar_espr (char)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION: Campo para gestion auxiliar de algun proceso</para>
        /// </summary>
        public String Sis_auxiliar_espr
        {
            get { return _sis_auxiliar_espr; }
            set
            {
                if (_sis_auxiliar_espr == value) return;
                _sis_auxiliar_espr = value;
                OnPropertyChanged("Sis_auxiliar_espr");
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
        #region Inv_codgru_ingr: Grupo Clasificación
        private String _inv_codgru_ingr;
        /// <summary>
        /// <para>TABLA: temporal</para>
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
        #region Inv_desgru_ingr: Descripcion Grupo
        private String _inv_desgru_ingr;
        /// <summary>
        /// <para>TABLA: temporal</para>
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
        #endregion
        #endregion
        #region Metodos para edicion de registros
        #region Adicionar Registro
        public static String flgAddRegistro(ModeloInvAlmacenExistencias tobjModelo)
        {
            var lcrCodigoGen = SysModelo.fcrGenerarNuevoCodigo("INV-MAESTRO-EXISTENCIAS", "INV", "Maestro existencias en cada almacen");
            try
            {
                if (!flgBuscarInvalmacexisten(lcrCodigoGen))
                {
                    using (_context = new DbAplicacion())
                    {
                        var lobjRegistro = new EFinvalmacexisten
                        {
                            #region cargar Registro
                            inv_secreg_incx = tobjModelo.Inv_secreg_incx,
                            inv_codalm_inal = tobjModelo.Inv_codalm_inal,
                            inv_secart_inar = tobjModelo.Inv_secart_inar,
                            inv_codaux_inar = tobjModelo.Inv_codaux_inar,
                            sis_codgme_sigr = tobjModelo.Sis_codgme_sigr,
                            sis_codume_sium = tobjModelo.Sis_codume_sium,
                            inv_totuni_inex = tobjModelo.Inv_totuni_inex,
                            inv_valing_inar = tobjModelo.Inv_valing_inar,
                            inv_valmov_inar = tobjModelo.Inv_valmov_inar,
                            inv_valcos_inex = tobjModelo.Inv_valcos_inex,
                            inv_codest_ines = tobjModelo.Inv_codest_ines,
                            inv_seccio_ines = tobjModelo.Inv_seccio_ines,
                            inv_estant_ines = tobjModelo.Inv_estant_ines,
                            sis_estpro_espr = tobjModelo.Sis_estpro_espr,
                            #endregion
                        };
                        lobjRegistro.inv_secreg_incx = lcrCodigoGen;
                        _context.AddToInvalmacexisten(lobjRegistro);
                        _context.SaveChanges();
                    }
                }
                else
                {
                    lcrCodigoGen = String.Empty;
                    MessageBox.Show("Nuevo codigo Generado esta desactualizado, revisar llave: \n" +
                                "'INV-MAESTRO-EXISTENCIAS': Maestro existencias en cada almacen en Maestro Secuenciales.");
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
        public static void fcvActualizar(ModeloInvAlmacenExistencias tobjModelo)
        {
            try
            {
                using (_context = new DbAplicacion())
                {
                    var lobjRegistro = _context.Invalmacexisten.FirstOrDefault(p => p.inv_secreg_incx == tobjModelo.Inv_secreg_incx);
                    if (lobjRegistro != null)
                    {
                        #region cargar Registro
                        lobjRegistro.inv_secreg_incx = tobjModelo.Inv_secreg_incx;
                        lobjRegistro.inv_codalm_inal = tobjModelo.Inv_codalm_inal;
                        lobjRegistro.inv_secart_inar = tobjModelo.Inv_secart_inar;
                        lobjRegistro.inv_codaux_inar = tobjModelo.Inv_codaux_inar;
                        lobjRegistro.sis_codgme_sigr = tobjModelo.Sis_codgme_sigr;
                        lobjRegistro.sis_codume_sium = tobjModelo.Sis_codume_sium;
                        lobjRegistro.inv_totuni_inex = (int)tobjModelo.Inv_totuni_inex;
                        lobjRegistro.inv_valing_inar = (float)tobjModelo.Inv_valing_inar;
                        lobjRegistro.inv_valmov_inar = (float)tobjModelo.Inv_valmov_inar;
                        lobjRegistro.inv_valcos_inex = (float)tobjModelo.Inv_valcos_inex;
                        lobjRegistro.inv_codest_ines = tobjModelo.Inv_codest_ines;
                        lobjRegistro.inv_seccio_ines = tobjModelo.Inv_seccio_ines;
                        lobjRegistro.inv_estant_ines = tobjModelo.Inv_estant_ines;
                        lobjRegistro.sis_estpro_espr = tobjModelo.Sis_estpro_espr;
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
                    var lobjRegistro = _context.Invalmacexisten.FirstOrDefault(p => p.inv_secreg_incx == tcrCodigo);
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
        #region Buscar INVALMACEXISTEN: Logica
        /// <summary>
        /// <para>TABLA: invalmacexisten</para>
        /// <para>TITULO: Maestro existencias en cada almacen</para>
        /// <para>MODULO: INV</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Detalles existencias totales en tiempo real por cada articulo
        /// en un almacen, sin tener presente Lotes/Referencias
        /// </para>
        /// </summary>
        public static bool flgBuscarInvalmacexisten(String tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Invalmacexisten.FirstOrDefault(p => p.inv_secreg_incx == tcrCodigo);
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
        /// //Modelo Existencias: Lista de Registros
        /// </summary>
        /// <param name="tcrBuscar"></param>
        /// <returns></returns>
        public static List<ModeloInvAlmacenExistencias> flsListaInvalmacexisten(String tcrBuscar)
        {
            using (_context = new DbAplicacion())
            {
                if (String.IsNullOrEmpty(tcrBuscar))
                {
                    var lobConsulta = from invalmacexisten in _context.Invalmacexisten
                                      join invalmacenmaest in _context.Invalmacenmaest on invalmacexisten.inv_codalm_inal equals invalmacenmaest.inv_codalm_inal into tminvalmacenmaest
                                      join invmaearticulos in _context.Invmaearticulos on invalmacexisten.inv_secart_inar equals invmaearticulos.inv_secart_inar into tminvmaearticulos
                                      join sisgrupomedidas in _context.Sisgrupomedidas on invalmacexisten.sis_codgme_sigr equals sisgrupomedidas.sis_codgme_sigr into tmsisgrupomedidas
                                      join sisunidadmedida in _context.Sisunidadmedida on invalmacexisten.sis_codume_sium equals sisunidadmedida.sis_codume_sium into tmsisunidadmedida
                                      join invalmacenestan in _context.Invalmacenestan on invalmacexisten.inv_codest_ines equals invalmacenestan.inv_secest_ines into tminvalmacenestan
                                      from inal in tminvalmacenmaest.DefaultIfEmpty()
                                      from inar in tminvmaearticulos.DefaultIfEmpty()
                                      from sigr in tmsisgrupomedidas.DefaultIfEmpty()
                                      from sium in tmsisunidadmedida.DefaultIfEmpty()
                                      from ines in tminvalmacenestan.DefaultIfEmpty()
                                      select new ModeloInvAlmacenExistencias
                                      {
                                          #region Datos
                                          Inv_secreg_incx = invalmacexisten.inv_secreg_incx,
                                          Inv_codalm_inal = invalmacexisten.inv_codalm_inal,
                                          Inv_secart_inar = invalmacexisten.inv_secart_inar,
                                          Inv_codaux_inar = invalmacexisten.inv_codaux_inar,
                                          Inv_codbar_inar = inar.inv_codbar_inar,
                                          Sis_codgme_sigr = invalmacexisten.sis_codgme_sigr,
                                          Sis_codume_sium = invalmacexisten.sis_codume_sium,
                                          Inv_totuni_inex = (int)invalmacexisten.inv_totuni_inex,
                                          Inv_valing_inar = (float)invalmacexisten.inv_valing_inar,
                                          Inv_valmov_inar = (float)invalmacexisten.inv_valmov_inar,
                                          Inv_valcos_inex = (float)invalmacexisten.inv_valcos_inex,
                                          Inv_codest_ines = invalmacexisten.inv_codest_ines,
                                          Inv_seccio_ines = invalmacexisten.inv_seccio_ines,
                                          Inv_estant_ines = invalmacexisten.inv_estant_ines,
                                          Sis_estpro_espr = invalmacexisten.sis_estpro_espr,
                                          Inv_desalm_inal = inal.inv_desalm_inal,
                                          Inv_nomart_inar = inar.inv_nomart_inar,
                                          Sis_desgme_sigr = sigr.sis_desgme_sigr,
                                          Sis_desume_sium = sium.sis_desume_sium,
                                          Inv_desest_ines = ines.inv_desest_ines,
                                          Inv_codctn_intc = inar.inv_codctn_intc,
                                          #endregion
                                      };
                    return lobConsulta.ToList();
                }
                else
                {
                    var lobConsulta = from invalmacexisten in _context.Invalmacexisten
                                      join invalmacenmaest in _context.Invalmacenmaest on invalmacexisten.inv_codalm_inal equals invalmacenmaest.inv_codalm_inal into tminvalmacenmaest
                                      join invmaearticulos in _context.Invmaearticulos on invalmacexisten.inv_secart_inar equals invmaearticulos.inv_secart_inar into tminvmaearticulos
                                      join sisgrupomedidas in _context.Sisgrupomedidas on invalmacexisten.sis_codgme_sigr equals sisgrupomedidas.sis_codgme_sigr into tmsisgrupomedidas
                                      join sisunidadmedida in _context.Sisunidadmedida on invalmacexisten.sis_codume_sium equals sisunidadmedida.sis_codume_sium into tmsisunidadmedida
                                      join invalmacenestan in _context.Invalmacenestan on invalmacexisten.inv_codest_ines equals invalmacenestan.inv_secest_ines into tminvalmacenestan
                                      from inal in tminvalmacenmaest.DefaultIfEmpty()
                                      from inar in tminvmaearticulos.DefaultIfEmpty()
                                      from sigr in tmsisgrupomedidas.DefaultIfEmpty()
                                      from sium in tmsisunidadmedida.DefaultIfEmpty()
                                      from ines in tminvalmacenestan.DefaultIfEmpty()
                                      where invalmacexisten.inv_secreg_incx == tcrBuscar
                                      select new ModeloInvAlmacenExistencias
                                      {
                                          #region Datos
                                          Inv_secreg_incx = invalmacexisten.inv_secreg_incx,
                                          Inv_codalm_inal = invalmacexisten.inv_codalm_inal,
                                          Inv_secart_inar = invalmacexisten.inv_secart_inar,
                                          Inv_codaux_inar = invalmacexisten.inv_codaux_inar,
                                          Inv_codbar_inar = inar.inv_codbar_inar,
                                          Sis_codgme_sigr = invalmacexisten.sis_codgme_sigr,
                                          Sis_codume_sium = invalmacexisten.sis_codume_sium,
                                          Inv_totuni_inex = (int)invalmacexisten.inv_totuni_inex,
                                          Inv_valing_inar = (float)invalmacexisten.inv_valing_inar,
                                          Inv_valmov_inar = (float)invalmacexisten.inv_valmov_inar,
                                          Inv_valcos_inex = (float)invalmacexisten.inv_valcos_inex,
                                          Inv_codest_ines = invalmacexisten.inv_codest_ines,
                                          Inv_seccio_ines = invalmacexisten.inv_seccio_ines,
                                          Inv_estant_ines = invalmacexisten.inv_estant_ines,
                                          Sis_estpro_espr = invalmacexisten.sis_estpro_espr,
                                          Inv_desalm_inal = inal.inv_desalm_inal,
                                          Inv_nomart_inar = inar.inv_nomart_inar,
                                          Sis_desgme_sigr = sigr.sis_desgme_sigr,
                                          Sis_desume_sium = sium.sis_desume_sium,
                                          Inv_desest_ines = ines.inv_desest_ines,
                                          Inv_codctn_intc = inar.inv_codctn_intc,
                                          #endregion
                                      };
                    return lobConsulta.ToList();
                }
            }
        }
        #endregion
        #region Temporal de existencias en almacen
        /// <summary>
        /// //Modelo Existencias: Temporal de existencias en almacen
        /// </summary>
        /// <param name="tcrBuscar"></param>
        /// <returns></returns>
        public static List<ModeloInvAlmacenExistencias> flsListaInvalmacexistenAlm(String tcrBuscar, String tcrTextoBuscar)
        {
            using (_context = new DbAplicacion())
            {
                if (String.IsNullOrEmpty(tcrTextoBuscar))
                {
                    var lobConsulta = from invalmacexisten in _context.Invalmacexisten
                                      join invalmacenmaest in _context.Invalmacenmaest on invalmacexisten.inv_codalm_inal equals invalmacenmaest.inv_codalm_inal into tminvalmacenmaest
                                      join invmaearticulos in _context.Invmaearticulos on invalmacexisten.inv_secart_inar equals invmaearticulos.inv_secart_inar into tminvmaearticulos
                                      join sisgrupomedidas in _context.Sisgrupomedidas on invalmacexisten.sis_codgme_sigr equals sisgrupomedidas.sis_codgme_sigr into tmsisgrupomedidas
                                      join sisunidadmedida in _context.Sisunidadmedida on invalmacexisten.sis_codume_sium equals sisunidadmedida.sis_codume_sium into tmsisunidadmedida
                                      from inal in tminvalmacenmaest.DefaultIfEmpty()
                                      from inar in tminvmaearticulos.DefaultIfEmpty()
                                      from sigr in tmsisgrupomedidas.DefaultIfEmpty()
                                      from sium in tmsisunidadmedida.DefaultIfEmpty()
                                      where invalmacexisten.inv_codalm_inal.Equals(tcrBuscar)
                                      orderby inar.inv_codgru_ingr, invalmacexisten.inv_secart_inar
                                      select new ModeloInvAlmacenExistencias
                                      {
                                          #region Datos
                                          Inv_secreg_incx = invalmacexisten.inv_secreg_incx,
                                          Inv_codalm_inal = invalmacexisten.inv_codalm_inal,
                                          Inv_secart_inar = invalmacexisten.inv_secart_inar,
                                          Inv_codaux_inar = invalmacexisten.inv_codaux_inar,
                                          Sis_codgme_sigr = invalmacexisten.sis_codgme_sigr,
                                          Sis_codume_sium = invalmacexisten.sis_codume_sium,
                                          Inv_totuni_inex = (int)invalmacexisten.inv_totuni_inex,
                                          Inv_valing_inar = (float)invalmacexisten.inv_valing_inar,
                                          Inv_valmov_inar = (float)invalmacexisten.inv_valmov_inar,
                                          Inv_valcos_inex = (float)invalmacexisten.inv_valcos_inex,
                                          Inv_codest_ines = invalmacexisten.inv_codest_ines,
                                          Inv_seccio_ines = invalmacexisten.inv_seccio_ines,
                                          Inv_estant_ines = invalmacexisten.inv_estant_ines,
                                          Sis_estpro_espr = invalmacexisten.sis_estpro_espr,
                                          Inv_desalm_inal = inal.inv_desalm_inal,
                                          Inv_nomart_inar = inar.inv_nomart_inar,
                                          Sis_desgme_sigr = sigr.sis_desgme_sigr,
                                          Sis_desume_sium = sium.sis_desume_sium,
                                          //Inv_codgru_ingr = inar.inv_codgru_ingr,
                                          //Inv_desgru_ingr = _context.Invinventgrupos.FirstOrDefault(x => x.inv_codgru_ingr == inar.inv_codgru_ingr).inv_desgru_ingr,
                                          #endregion
                                      };
                    return lobConsulta.ToList();
                }
                else
                {
                    var lobConsulta = from invalmacexisten in _context.Invalmacexisten
                                      join invalmacenmaest in _context.Invalmacenmaest on invalmacexisten.inv_codalm_inal equals invalmacenmaest.inv_codalm_inal into tminvalmacenmaest
                                      join invmaearticulos in _context.Invmaearticulos on invalmacexisten.inv_secart_inar equals invmaearticulos.inv_secart_inar into tminvmaearticulos
                                      join sisgrupomedidas in _context.Sisgrupomedidas on invalmacexisten.sis_codgme_sigr equals sisgrupomedidas.sis_codgme_sigr into tmsisgrupomedidas
                                      join sisunidadmedida in _context.Sisunidadmedida on invalmacexisten.sis_codume_sium equals sisunidadmedida.sis_codume_sium into tmsisunidadmedida
                                      from inal in tminvalmacenmaest.DefaultIfEmpty()
                                      from inar in tminvmaearticulos.DefaultIfEmpty()
                                      from sigr in tmsisgrupomedidas.DefaultIfEmpty()
                                      from sium in tmsisunidadmedida.DefaultIfEmpty()
                                      where invalmacexisten.inv_codalm_inal.Equals(tcrBuscar) &&
                                      (invalmacexisten.inv_codaux_inar.Contains(tcrTextoBuscar) ||
                                       invalmacexisten.inv_secreg_incx.Contains(tcrTextoBuscar) ||
                                       invalmacexisten.inv_seccio_ines.Contains(tcrTextoBuscar) ||
                                       invalmacexisten.inv_secart_inar.Contains(tcrTextoBuscar) ||
                                       inar.inv_nomart_inar.Contains(tcrTextoBuscar))
                                      orderby inar.inv_codgru_ingr, invalmacexisten.inv_secart_inar
                                      select new ModeloInvAlmacenExistencias
                                      {
                                          #region Datos
                                          Inv_secreg_incx = invalmacexisten.inv_secreg_incx,
                                          Inv_codalm_inal = invalmacexisten.inv_codalm_inal,
                                          Inv_secart_inar = invalmacexisten.inv_secart_inar,
                                          Inv_codaux_inar = invalmacexisten.inv_codaux_inar,
                                          Sis_codgme_sigr = invalmacexisten.sis_codgme_sigr,
                                          Sis_codume_sium = invalmacexisten.sis_codume_sium,
                                          Inv_totuni_inex = (int)invalmacexisten.inv_totuni_inex,
                                          Inv_valing_inar = (float)invalmacexisten.inv_valing_inar,
                                          Inv_valmov_inar = (float)invalmacexisten.inv_valmov_inar,
                                          Inv_valcos_inex = (float)invalmacexisten.inv_valcos_inex,
                                          Inv_codest_ines = invalmacexisten.inv_codest_ines,
                                          Inv_seccio_ines = invalmacexisten.inv_seccio_ines,
                                          Inv_estant_ines = invalmacexisten.inv_estant_ines,
                                          Sis_estpro_espr = invalmacexisten.sis_estpro_espr,
                                          Inv_desalm_inal = inal.inv_desalm_inal,
                                          Inv_nomart_inar = inar.inv_nomart_inar,
                                          Sis_desgme_sigr = sigr.sis_desgme_sigr,
                                          Sis_desume_sium = sium.sis_desume_sium,
                                          //Inv_codgru_ingr = inar.inv_codgru_ingr,
                                          //Inv_desgru_ingr = _context.Invinventgrupos.FirstOrDefault(x => x.inv_codgru_ingr == inar.inv_codgru_ingr).inv_desgru_ingr,
                                          #endregion
                                      };
                    return lobConsulta.ToList();
                }
            }
        }
        #endregion
        #region Registro unico de existencias en almacen
        /// <summary>
        /// Registro temporal de existencias en almacen de un articulo
        /// </summary>
        /// <param name="tcrBuscar"></param>
        /// <returns></returns>
        public static ModeloInvAlmacenExistencias fobRegInvalmacexistenAlm(String tcrCodigoAlmacen, String tcrCodigoAuxArticulo)
        {
            ModeloInvAlmacenExistencias lobConsulta = null;
            using (_context = new DbAplicacion())
            {
                lobConsulta = (from invalmacexisten in _context.Invalmacexisten
                                   join invalmacenmaest in _context.Invalmacenmaest on invalmacexisten.inv_codalm_inal equals invalmacenmaest.inv_codalm_inal into tminvalmacenmaest
                                   join invmaearticulos in _context.Invmaearticulos on invalmacexisten.inv_secart_inar equals invmaearticulos.inv_secart_inar into tminvmaearticulos
                                   from inal in tminvalmacenmaest.DefaultIfEmpty()
                                   from inar in tminvmaearticulos.DefaultIfEmpty()
                                   where invalmacexisten.inv_codalm_inal == tcrCodigoAlmacen &&
                                         invalmacexisten.inv_codaux_inar == tcrCodigoAuxArticulo
                                   select new ModeloInvAlmacenExistencias
                                   {
                                       #region Datos
                                       Inv_secreg_incx = invalmacexisten.inv_secreg_incx,
                                       Inv_codalm_inal = invalmacexisten.inv_codalm_inal,
                                       Inv_secart_inar = invalmacexisten.inv_secart_inar,
                                       Inv_codaux_inar = invalmacexisten.inv_codaux_inar,
                                       Sis_codgme_sigr = invalmacexisten.sis_codgme_sigr,
                                       Sis_codume_sium = invalmacexisten.sis_codume_sium,
                                       Inv_totuni_inex = (int)invalmacexisten.inv_totuni_inex,
                                       Inv_valing_inar = (float)invalmacexisten.inv_valing_inar,
                                       Inv_valmov_inar = (float)invalmacexisten.inv_valmov_inar,
                                       Inv_valcos_inex = (float)invalmacexisten.inv_valcos_inex,
                                       Inv_codest_ines = invalmacexisten.inv_codest_ines,
                                       Inv_seccio_ines = invalmacexisten.inv_seccio_ines,
                                       Inv_estant_ines = invalmacexisten.inv_estant_ines,
                                       Sis_estpro_espr = invalmacexisten.sis_estpro_espr,
                                       Inv_desalm_inal = inal.inv_desalm_inal,
                                       Inv_nomart_inar = inar.inv_nomart_inar,
                                       Fcm_coddig_mant = inar.fcm_coddig_mant,
                                       #endregion
                                   }).FirstOrDefault();
            }
            return lobConsulta;
        }
        #endregion
        //-------------------------------------------
        // PROCESOS GESTION KARDEX Y MOVIMIENTOS
        //-------------------------------------------
        // la funcion que actualiza existencias debe poder sumar/restar/remplazar las existencias

        // Procesos de gestion
        #region flgInvGestKardexMovAddExistencias: Adicionar nuevos registros en "Maestro Existencias"
        /// <summary>
        /// Proceso por lote para adicionar nuevos registros en "Maestro Existencias", realiza los movimientos de entrada en Existencias
        /// </summary>
        /// <param name="tcrCodigoAlmacen">Codigo del almacen para el cual se realizara la transaccion</param>
        /// <param name="tmpListaKardex">Lista en formato "List(ModeloInvKardexMaestro)" de registros a cargar en "Maestro Existencias"</param>
        /// <returns>Retorna true/false para indicar si la operacion tuvo exito.</returns>
        public static bool flgInvGestKardexMovAddExistencias(String tcrCodigoAlmacen, List<ModeloInvKardexMaestro> tmpListaKardex)
        {
            var llgReturn = false;
            try
            {
                var tmpListaCargue = flsInvGestConsolidarAddExistencias(tmpListaKardex);
                var lnuContador = fnuInvGestReservarSecuenciales(ref tmpListaCargue);
                var lobReSecuencial = SYSValidarCodigo.fobRegBuscarSysgeneradorcod("INV-MAESTRO-EXISTENCIAS");

                using (_context = new DbAplicacion())
                {
                    foreach (var lobReg in tmpListaCargue)
                    {
                        var lobRegAux = _context.Invalmacexisten.FirstOrDefault(p => p.inv_secart_inar == lobReg.Inv_secart_inar &&
                                                                                        p.inv_codalm_inal == tcrCodigoAlmacen);
                        if (lobRegAux == null)
                        {
                            lobRegAux = fobInvGenNuevoRegTmpExistencias(lobReg);
                            lobRegAux.inv_codalm_inal = tcrCodigoAlmacen;
                            lobRegAux.inv_secreg_incx = SysModelo.fcrGenFormatoSecuencial(lobReSecuencial, lnuContador);

                            _context.AddToInvalmacexisten(lobRegAux);
                            lnuContador++;
                        }
                        else
                        {
                            // actualizar existente y sumar unidades
                            #region cargar Registro
                            // sumar unidades
                            lobRegAux.sis_codgme_sigr = lobReg.Sis_codgme_sigr;
                            lobRegAux.sis_codume_sium = lobReg.Sis_codume_sium;
                            lobRegAux.inv_totuni_inex = lobRegAux.inv_totuni_inex + lobReg.Inv_totuni_inex;
                            // Asumir nuevos valores como actualizados
                            lobRegAux.inv_valing_inar = lobReg.Inv_valing_inar;
                            lobRegAux.inv_valmov_inar = lobReg.Inv_valmov_inar;
                            lobRegAux.inv_valcos_inex = lobRegAux.inv_valing_inar * lobRegAux.inv_totuni_inex;
                            // Ubicacion en estantes
                            lobRegAux.inv_codest_ines = lobReg.Inv_codest_ines;
                            lobRegAux.inv_seccio_ines = lobReg.Inv_seccio_ines;
                            lobRegAux.inv_estant_ines = lobReg.Inv_estant_ines;
                            #endregion
                        }
                    }
                    _context.SaveChanges();
                    llgReturn = true;
                }
            }
            catch (Exception ex)
            {
                Funciones.fcvVistaErroresEjecucion(ref ex, "Modelo Error Metodo: flgInvGestKardexMovAddExistencias");
            }
            return llgReturn;
        }
        #endregion
        #region flsInvGestConsolidarAddExistencias: Consolidar registros de entradas para existencias almacen
        /// <summary>
        /// <para>Convierte del formato "ModeloInvKardexMaestro" a  "ModeloInvAlmacenExistencias" y consolidar registros de entradas</para>
        /// <para>en registros unicos para evitar duplicidades al cargar en "Maestros Existencias"</para>
        /// <para>este procedimiento suma en uno solo, cuando existen dos registros de un mismo articulo en el Kardex (sea por lotes diferentes).</para>
        /// <para>RETORNA:</para>
        /// <para>listado convertido a "List(ModeloInvAlmacenExistencias)" ya consolidado para agregar al "Maestro de Existencias" en almacen.</para>
        /// </summary>
        /// <param name="tmpListaKardex">Lista en formato "List(ModeloInvKardexMaestro)" de registros a consolidar</param>
        public static List<ModeloInvAlmacenExistencias> flsInvGestConsolidarAddExistencias(List<ModeloInvKardexMaestro> tmpListaKardex)
        {
            List<ModeloInvAlmacenExistencias> tmpListReturn = new List<ModeloInvAlmacenExistencias>();
            try
            {
                foreach (var lobReg in tmpListaKardex)
                {
                    var lobRegAux = tmpListReturn.FirstOrDefault(x => x.Inv_secart_inar == lobReg.Inv_secart_inar);
                    if (lobRegAux == null)
                    {
                        // Generar nuevo registro
                        tmpListReturn.Add(fobInvGestConvertirFormatoExistencias(lobReg));
                    }
                    else
                    {
                        #region cargar Registro
                        // actualizar existente y sumar unidades
                        lobRegAux.Sis_codgme_sigr = lobReg.Sis_codgme_sigr;
                        lobRegAux.Sis_codume_sium = lobReg.Sis_codume_sium;
                        lobRegAux.Inv_totuni_inex = lobRegAux.Inv_totuni_inex + lobReg.Inv_totuni_inex;
                        // Asumir nuevos valores como actualizados
                        lobRegAux.Inv_valing_inar = lobReg.Inv_valing_inar;
                        lobRegAux.Inv_valmov_inar = lobReg.Inv_valmov_inar;
                        lobRegAux.Inv_valcos_inex = lobReg.Inv_valing_inar * lobReg.Inv_totuni_inex;
                        // Ubicacion en estantes
                        lobRegAux.Inv_codest_ines = lobReg.Inv_codest_ines;
                        lobRegAux.Inv_seccio_ines = lobReg.Inv_seccio_ines;
                        lobRegAux.Inv_estant_ines = lobReg.Inv_estant_ines;
                        #endregion
                    }
                }
            }
            catch (Exception ex)
            {
                Funciones.fcvVistaErroresEjecucion(ref ex, "Modelo Error Metodo: flsInvGestConsolidarAddExistencias");
            }
            return tmpListReturn;
        }
        #endregion
        #region fobInvGestConvertirFormatoExistencias: Convertir de formato Kardex a existencias
        /// <summary>
        /// realiza la conversion de un registro del tipo Kardex hacia un de tipo Maestro existencias
        /// </summary>
        /// <param name="tobRegistro">Registro tipo "ModeloInvKardexMaestro" dado para realizar la conversion al formato "ModeloInvAlmacenExistencias"</param>
        /// <returns>Retorna registro del tipo "ModeloInvAlmacenExistencias"</returns>
        public static ModeloInvAlmacenExistencias fobInvGestConvertirFormatoExistencias(ModeloInvKardexMaestro tobRegistro)
        {
            var lobjRegistro = new ModeloInvAlmacenExistencias
            {
                #region cargar Registro
                Inv_secreg_incx = "XX",
                Inv_codalm_inal = tobRegistro.Inv_codalm_inal,
                Inv_secart_inar = tobRegistro.Inv_secart_inar,
                Inv_codaux_inar = tobRegistro.Inv_codaux_inar,
                Sis_codgme_sigr = tobRegistro.Sis_codgme_sigr,
                Sis_codume_sium = tobRegistro.Sis_codume_sium,
                Inv_totuni_inex = tobRegistro.Inv_totuni_inex,
                Inv_valing_inar = tobRegistro.Inv_valing_inar,
                Inv_valmov_inar = tobRegistro.Inv_valmov_inar,
                Inv_valcos_inex = tobRegistro.Inv_valing_inar * tobRegistro.Inv_totuni_inex,
                Inv_codest_ines = tobRegistro.Inv_codest_ines,
                Inv_seccio_ines = tobRegistro.Inv_seccio_ines,
                Inv_estant_ines = tobRegistro.Inv_estant_ines,
                Sis_estpro_espr = tobRegistro.Sis_estpro_espr,
                #endregion
            };
            return lobjRegistro;
        }
        #endregion
        #region fnuInvGestReservarSecuenciales: Reservar secuenciales
        /// <summary>
        /// <para>Verificar y marca cuales de los registros del temporal "lista(ModeloInvAlmacenExistencias)" ya existe en "Maestro Existencias"</para>
        /// <para>esto con el fin de no generar secuenciales duplicados en concurrencia dado el acceso multiusuario en tiempo real</para>
        /// <para>RETURN:</para>
        /// <para>Devuelve un valor entero que representa secuencial inicial para generar los registros no encontrados</para>
        /// </summary>
        public static int fnuInvGestReservarSecuenciales(ref List<ModeloInvAlmacenExistencias> tmpExistencias)
        {
            var lnuContador = 0;
            var lnuSecuencial = 0;
            try
            {
                using (_context = new DbAplicacion())
                {
                    foreach (var lobReg in tmpExistencias)
                    {
                        lobReg.Sis_auxiliar_espr = "OK";
                        var lobjRegistro = _context.Invalmacexisten.FirstOrDefault(p => p.inv_secart_inar == lobReg.Inv_secart_inar &&
                                                                                        p.inv_codalm_inal == lobReg.Inv_codalm_inal);
                        if (lobjRegistro == null)
                        {
                            lobReg.Sis_auxiliar_espr = "NO";
                            lnuContador++;
                        }
                    }
                }
                // Cuando algunos no estan registrados se reserva secuenciales a generar
                if (lnuContador > 0)
                {
                    lnuSecuencial = SysModelo.fnuActualizar("1", "INV-MAESTRO-EXISTENCIAS", lnuContador + 1); // Reservar el rango a usuar

                    // para que inicie en el primer secuencia reservado
                    lnuSecuencial = lnuSecuencial - lnuContador;
                }
            }
            catch (Exception ex)
            {
                Funciones.fcvVistaErroresEjecucion(ref ex, "Modelo Error Metodo: fnuInvGestReservarSecuenciales");
            }
            return lnuSecuencial;
        }
        #endregion
        #region fobInvGenNuevoRegTmpExistencias: generar nuevo registro temporal Existenicas
        /// <summary>
        /// Generar nuevo registro temporal para agregar en maestro de existencas y cargar datos del registro dado en parametro
        /// </summary>
        public static EFinvalmacexisten fobInvGenNuevoRegTmpExistencias(ModeloInvAlmacenExistencias tobRegistro)
        {
            var lobjRegistro = new EFinvalmacexisten
            {
                #region cargar Registro
                inv_secreg_incx = tobRegistro.Inv_secreg_incx,
                inv_codalm_inal = tobRegistro.Inv_codalm_inal,
                inv_secart_inar = tobRegistro.Inv_secart_inar,
                inv_codaux_inar = tobRegistro.Inv_codaux_inar,
                sis_codgme_sigr = tobRegistro.Sis_codgme_sigr,
                sis_codume_sium = tobRegistro.Sis_codume_sium,
                inv_totuni_inex = tobRegistro.Inv_totuni_inex,
                inv_valing_inar = tobRegistro.Inv_valing_inar,
                inv_valmov_inar = tobRegistro.Inv_valmov_inar,
                inv_valcos_inex = tobRegistro.Inv_valcos_inex,
                inv_codest_ines = tobRegistro.Inv_codest_ines,
                inv_seccio_ines = tobRegistro.Inv_seccio_ines,
                inv_estant_ines = tobRegistro.Inv_estant_ines,
                sis_estpro_espr = tobRegistro.Sis_estpro_espr,
                #endregion
            };
            return lobjRegistro;
        }
        #endregion
        // Consultas SQL
        #region fobInvGestRegConsultaExistenciasArticulo: devuelve registro de existencias del articulo en almacen
        /// <summary>
        /// devuelve registro de existencias del articulo en almacen 
        /// </summary>
        /// <param name="tcrCodigoArticulo">Codigo del articulo solicitado</param>
        /// <param name="tcrCodigoAlmacen">Codigo almacen donde se consultara el articulo</param>
        /// <returns>Retorna el registro existencias del articulo en el almacen dado</returns>
        public static ModeloInvAlmacenExistencias fobInvGestRegConsultaExistenciasArticulo(String tcrCodigoArticulo, String tcrCodigoAlmacen)
        {
            ModeloInvAlmacenExistencias lobReturn = null;
            using (_context = new DbAplicacion())
            {
                var lobConsulta = (from invalmacexisten in _context.Invalmacexisten
                                   where invalmacexisten.inv_secreg_incx == tcrCodigoArticulo &&
                                         invalmacexisten.inv_codalm_inal == tcrCodigoAlmacen &&
                                         invalmacexisten.sis_estpro_espr == "2"
                                   select new ModeloInvAlmacenExistencias
                                   {
                                       #region Datos
                                       Inv_secreg_incx = invalmacexisten.inv_secreg_incx,
                                       Inv_codalm_inal = invalmacexisten.inv_codalm_inal,
                                       Inv_secart_inar = invalmacexisten.inv_secart_inar,
                                       Inv_codaux_inar = invalmacexisten.inv_codaux_inar,
                                       Sis_codgme_sigr = invalmacexisten.sis_codgme_sigr,
                                       Sis_codume_sium = invalmacexisten.sis_codume_sium,
                                       Inv_totuni_inex = (int)invalmacexisten.inv_totuni_inex,
                                       Inv_valing_inar = (float)invalmacexisten.inv_valing_inar,
                                       Inv_valmov_inar = (float)invalmacexisten.inv_valmov_inar,
                                       Inv_valcos_inex = (float)invalmacexisten.inv_valcos_inex,
                                       Inv_codest_ines = invalmacexisten.inv_codest_ines,
                                       Inv_seccio_ines = invalmacexisten.inv_seccio_ines,
                                       Inv_estant_ines = invalmacexisten.inv_estant_ines,
                                       Sis_estpro_espr = invalmacexisten.sis_estpro_espr,
                                       Sis_estado_imaen = "I",
                                       #endregion
                                   }).ToList();
                if (lobConsulta.Count > 0)
                {
                    lobReturn = lobConsulta.FirstOrDefault();
                }
            }
            return lobReturn;
        }
        #endregion
        #endregion
    }
    #endregion
    #region Modelo Maestro Entrada Compras
    /// <summary>
    /// invmovcomprasma: Maestro entradas por compras
    /// </summary>
    public class ModeloEntradaCompras : clBaseInpc
    {
        #region Modelo Attributos
        private static DbAplicacion _context;
        #region Modelo Propiedades Notificacion
        #region Inv_secreg_inca: Secuencial reg. Maestro
        private String _inv_secreg_inca;
        /// <summary>
        /// <para>TABLA: invmovcomprasma</para>
        /// <para>TABLA NATIVA: invmovcomprasma</para>
        /// <para>CAMPO: Secuencial reg. Maestro</para>
        /// <para>NOMBRE: inv_secreg_inca (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        ///Secuencial  unico registro maestro movimientos por compras
        /// </para>
        /// </summary>
        public String Inv_secreg_inca
        {
            get { return _inv_secreg_inca; }
            set
            {
                if (_inv_secreg_inca == value) return;
                _inv_secreg_inca = value;
                OnPropertyChanged("Inv_secreg_inca");
            }
        }
        #endregion
        #region Inv_tipmov_intr: Tipo movimiento
        private String _inv_tipmov_intr;
        /// <summary>
        /// <para>TABLA: invmovcomprasma</para>
        /// <para>TABLA NATIVA: invtiporegimovi</para>
        /// <para>CAMPO: Tipo movimiento</para>
        /// <para>NOMBRE: inv_tipmov_intr (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Tipo registro movimiento inventarios: 1= Entradas 2= Salidas
        /// desde tabla: INVTIPOREGIMOVI
        /// </para>
        /// </summary>
        public String Inv_tipmov_intr
        {
            get { return _inv_tipmov_intr; }
            set
            {
                if (_inv_tipmov_intr == value) return;
                _inv_tipmov_intr = value;
                OnPropertyChanged("Inv_tipmov_intr");
            }
        }
        #endregion
        #region Inv_tipreg_incx: Tipo Registro compra
        private String _inv_tipreg_incx;
        /// <summary>
        /// <para>TABLA: invmovcomprasma</para>
        /// <para>TABLA NATIVA: invtiporecompra</para>
        /// <para>CAMPO: Tipo Registro compra</para>
        /// <para>NOMBRE: inv_tipreg_incx (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        /// Tipo registro movimiento o documento  (manejo interno del modulo)
        /// compra: 1=Cotizacion compra 2=Ordenes de compra 3=Ingresos
        /// por compra 4=Devoluciones por compra
        /// </para>
        /// </summary>
        public String Inv_tipreg_incx
        {
            get { return _inv_tipreg_incx; }
            set
            {
                if (_inv_tipreg_incx == value) return;
                _inv_tipreg_incx = value;
                OnPropertyChanged("Inv_tipreg_incx");
            }
        }
        #endregion
        #region Inv_conmov_incm: Codigo concepto
        private String _inv_conmov_incm;
        /// <summary>
        /// <para>TABLA: invmovcomprasma</para>
        /// <para>TABLA NATIVA: invtipoconcemov</para>
        /// <para>CAMPO: Codigo concepto</para>
        /// <para>NOMBRE: inv_conmov_incm (char:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        /// Concepto movimiento: E11= Entradas compras E12= Entrada Traslado
        /// interno E13=Entradas por ajustes  S21= Salidas Ventas 22= Salidas
        /// Traslado S23= Salidas Otras Áreas Empresa S24= Salida entrega
        /// formula A30=Ajuste de inventarios y otros
        /// </para>
        /// </summary>
        public String Inv_conmov_incm
        {
            get { return _inv_conmov_incm; }
            set
            {
                if (_inv_conmov_incm == value) return;
                _inv_conmov_incm = value;
                OnPropertyChanged("Inv_conmov_incm");
            }
        }
        #endregion
        #region Inv_desreg_inca: Descripción registro
        private String _inv_desreg_inca;
        /// <summary>
        /// <para>TABLA: invmovcomprasma</para>
        /// <para>TABLA NATIVA: invmovcomprasma</para>
        /// <para>CAMPO: Descripción registro</para>
        /// <para>NOMBRE: inv_desreg_inca (char:200)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        ///Descripción textual del registro
        /// </para>
        /// </summary>
        public String Inv_desreg_inca
        {
            get { return _inv_desreg_inca; }
            set
            {
                if (_inv_desreg_inca == value) return;
                _inv_desreg_inca = value;
                OnPropertyChanged("Inv_desreg_inca");
            }
        }
        #endregion
        #region Inv_fecges_inca: Fecha gestion
        private DateTime _inv_fecges_inca;
        /// <summary>
        /// <para>TABLA: invmovcomprasma</para>
        /// <para>TABLA NATIVA: invmovcomprasma</para>
        /// <para>CAMPO: Fecha gestion</para>
        /// <para>NOMBRE: inv_fecges_inca (fecha:)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        /// Fecha del registro, cotizacion, orden de compra o  entrada
        /// del pedido
        /// </para>
        /// </summary>
        public DateTime Inv_fecges_inca
        {
            get { return _inv_fecges_inca; }
            set
            {
                if (_inv_fecges_inca == value) return;
                _inv_fecges_inca = value;
                OnPropertyChanged("Inv_fecges_inca");
            }
        }
        #endregion
        #region Inv_numref_inca: Cotizacion/Orden.Compra
        private String _inv_numref_inca;
        /// <summary>
        /// <para>TABLA: invmovcomprasma</para>
        /// <para>TABLA NATIVA: invmovcomprasma</para>
        /// <para>CAMPO: Cotizacion/Orden.Compra</para>
        /// <para>NOMBRE: inv_numref_inca (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        /// Numero del registro para referenciar la COTIZACION, ORDEN DE
        /// COMPRA O INGRESO A INVENTARIO según sea el tipo registro dado
        /// en  campo: INV_TIPREG_INCX del manejo interno del modulo
        /// </para>
        /// </summary>
        public String Inv_numref_inca
        {
            get { return _inv_numref_inca; }
            set
            {
                if (_inv_numref_inca == value) return;
                _inv_numref_inca = value;
                OnPropertyChanged("Inv_numref_inca");
            }
        }
        #endregion
        #region Sis_secpro_sipr: Código Proveedor
        private String _sis_secpro_sipr;
        /// <summary>
        /// <para>TABLA: invmovcomprasma</para>
        /// <para>TABLA NATIVA: sisproveedores</para>
        /// <para>CAMPO: Código Proveedor</para>
        /// <para>NOMBRE: sis_secpro_sipr (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        ///Código Proveedor cuando es un registro de entradas
        /// </para>
        /// </summary>
        public String Sis_secpro_sipr
        {
            get { return _sis_secpro_sipr; }
            set
            {
                if (_sis_secpro_sipr == value) return;
                _sis_secpro_sipr = value;
                OnPropertyChanged("Sis_secpro_sipr");
            }
        }
        #endregion
        #region Inv_codalm_inal: Código Almacén
        private String _inv_codalm_inal;
        /// <summary>
        /// <para>TABLA: invmovcomprasma</para>
        /// <para>TABLA NATIVA: invalmacenmaest</para>
        /// <para>CAMPO: Código Almacén</para>
        /// <para>NOMBRE: inv_codalm_inal (char:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION:
        /// Código del Almacén que para el cual se realiza el movimiento
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
        #region Con_codsco_ccos: Código centro de costo
        private String _con_codsco_ccos;
        /// <summary>
        /// <para>TABLA: invmovcomprasma</para>
        /// <para>TABLA NATIVA: concentrodcosto</para>
        /// <para>CAMPO: Código centro de costo</para>
        /// <para>NOMBRE: con_codsco_ccos (char:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
        /// <para>DESCRIPCION:
        ///Código del centro de costo para gestion contable
        /// </para>
        /// </summary>
        public String Con_codsco_ccos
        {
            get { return _con_codsco_ccos; }
            set
            {
                if (_con_codsco_ccos == value) return;
                _con_codsco_ccos = value;
                OnPropertyChanged("Con_codsco_ccos");
            }
        }
        #endregion
        #region Inv_numdoc_inca: Numero Factura
        private String _inv_numdoc_inca;
        /// <summary>
        /// <para>TABLA: invmovcomprasma</para>
        /// <para>TABLA NATIVA: invmovcomprasma</para>
        /// <para>CAMPO: Numero Factura</para>
        /// <para>NOMBRE: inv_numdoc_inca (char:50)</para>
        /// <para>ORDEN VISTA EN TABLA: 11</para>
        /// <para>DESCRIPCION:
        /// Numero Documento o Factura,  con la que reporta el proveedor
        /// la entrada de pedidos, o se relaciona
        /// </para>
        /// </summary>
        public String Inv_numdoc_inca
        {
            get { return _inv_numdoc_inca; }
            set
            {
                if (_inv_numdoc_inca == value) return;
                _inv_numdoc_inca = value;
                OnPropertyChanged("Inv_numdoc_inca");
            }
        }
        #endregion
        #region Inv_fecdoc_inca: Fecha documento
        private DateTime _inv_fecdoc_inca;
        /// <summary>
        /// <para>TABLA: invmovcomprasma</para>
        /// <para>TABLA NATIVA: invmovcomprasma</para>
        /// <para>CAMPO: Fecha documento</para>
        /// <para>NOMBRE: inv_fecdoc_inca (fecha:)</para>
        /// <para>ORDEN VISTA EN TABLA: 12</para>
        /// <para>DESCRIPCION:
        ///Fecha del documento (Numero factura del proveedor)
        /// </para>
        /// </summary>
        public DateTime Inv_fecdoc_inca
        {
            get { return _inv_fecdoc_inca; }
            set
            {
                if (_inv_fecdoc_inca == value) return;
                _inv_fecdoc_inca = value;
                OnPropertyChanged("Inv_fecdoc_inca");
            }
        }
        #endregion
        #region Inv_fecsol_inca: Fecha pedido
        private DateTime _inv_fecsol_inca;
        /// <summary>
        /// <para>TABLA: invmovcomprasma</para>
        /// <para>TABLA NATIVA: invmovcomprasma</para>
        /// <para>CAMPO: Fecha pedido</para>
        /// <para>NOMBRE: inv_fecsol_inca (fecha:)</para>
        /// <para>ORDEN VISTA EN TABLA: 13</para>
        /// <para>DESCRIPCION:
        ///Fecha Solicitud del pedido al proveedor
        /// </para>
        /// </summary>
        public DateTime Inv_fecsol_inca
        {
            get { return _inv_fecsol_inca; }
            set
            {
                if (_inv_fecsol_inca == value) return;
                _inv_fecsol_inca = value;
                OnPropertyChanged("Inv_fecsol_inca");
            }
        }
        #endregion
        #region Inv_diapla_inca: Dias plazo pago
        private int _inv_diapla_inca;
        /// <summary>
        /// <para>TABLA: invmovcomprasma</para>
        /// <para>TABLA NATIVA: invmovcomprasma</para>
        /// <para>CAMPO: Dias plazo pago</para>
        /// <para>NOMBRE: inv_diapla_inca (int:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 14</para>
        /// <para>DESCRIPCION:
        ///Dias Plazo para pago factura al proveedor
        /// </para>
        /// </summary>
        public int Inv_diapla_inca
        {
            get { return _inv_diapla_inca; }
            set
            {
                if (_inv_diapla_inca == value) return;
                _inv_diapla_inca = value;
                OnPropertyChanged("Inv_diapla_inca");
            }
        }
        #endregion
        #region Inv_brufac_incd: Valor Bruto factura
        private float _inv_brufac_incd;
        /// <summary>
        /// <para>TABLA: invmovcomprasma</para>
        /// <para>TABLA NATIVA: invmovcomprasmd</para>
        /// <para>CAMPO: Valor Bruto factura</para>
        /// <para>NOMBRE: inv_brufac_incd (float:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 15</para>
        /// <para>DESCRIPCION:
        /// Sumatoria Valor Bruto/Neto Facturado sin ninguna deduccion
        /// en entradas por compra es valor de factura cliente sin IVA
        /// y otras deducciones
        /// </para>
        /// </summary>
        public float Inv_brufac_incd
        {
            get { return _inv_brufac_incd; }
            set
            {
                if (_inv_brufac_incd == value) return;
                _inv_brufac_incd = value;
                OnPropertyChanged("Inv_brufac_incd");
            }
        }
        #endregion
        #region Inv_pordes_incd: Porcentaje Descuento
        private float _inv_pordes_incd;
        /// <summary>
        /// <para>TABLA: invmovcomprasma</para>
        /// <para>TABLA NATIVA: invmovcomprasmd</para>
        /// <para>CAMPO: Porcentaje Descuento</para>
        /// <para>NOMBRE: inv_pordes_incd (float:52)</para>
        /// <para>ORDEN VISTA EN TABLA: 16</para>
        /// <para>DESCRIPCION:
        /// Porcentaje Descuento (desde la tabla detalles  movimiento compras)
        /// </para>
        /// </summary>
        public float Inv_pordes_incd
        {
            get { return _inv_pordes_incd; }
            set
            {
                if (_inv_pordes_incd == value) return;
                _inv_pordes_incd = value;
                OnPropertyChanged("Inv_pordes_incd");
            }
        }
        #endregion
        #region Inv_valdes_incd: Valor total descuento
        private float _inv_valdes_incd;
        /// <summary>
        /// <para>TABLA: invmovcomprasma</para>
        /// <para>TABLA NATIVA: invmovcomprasmd</para>
        /// <para>CAMPO: Valor total descuento</para>
        /// <para>NOMBRE: inv_valdes_incd (float:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 17</para>
        /// <para>DESCRIPCION:
        /// Valor total del descuento facturado (desde tabla detalles movimiento
        /// compras)
        /// </para>
        /// </summary>
        public float Inv_valdes_incd
        {
            get { return _inv_valdes_incd; }
            set
            {
                if (_inv_valdes_incd == value) return;
                _inv_valdes_incd = value;
                OnPropertyChanged("Inv_valdes_incd");
            }
        }
        #endregion
        #region Inv_valiva_incd: Valor IVA
        private float _inv_valiva_incd;
        /// <summary>
        /// <para>TABLA: invmovcomprasma</para>
        /// <para>TABLA NATIVA: invmovcomprasmd</para>
        /// <para>CAMPO: Valor IVA</para>
        /// <para>NOMBRE: inv_valiva_incd (float:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 18</para>
        /// <para>DESCRIPCION:
        /// Sumatoria Valor total del IVA pagado en la compra (desde tabla
        /// detalles movimiento compras)
        /// </para>
        /// </summary>
        public float Inv_valiva_incd
        {
            get { return _inv_valiva_incd; }
            set
            {
                if (_inv_valiva_incd == value) return;
                _inv_valiva_incd = value;
                OnPropertyChanged("Inv_valiva_incd");
            }
        }
        #endregion
        #region Inv_valing_inar: Total Valor Ingreso
        private float _inv_valing_inar;
        /// <summary>
        /// <para>TABLA: invmovcomprasma</para>
        /// <para>TABLA NATIVA: invmaearticulos</para>
        /// <para>CAMPO: Total Valor Ingreso</para>
        /// <para>NOMBRE: inv_valing_inar (float:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 19</para>
        /// <para>DESCRIPCION:
        /// Sumatoria Total del Valor Ingreso articulos en inventario (desde
        /// tabla detalles movimiento compras) /sumatoria de registros
        /// para validar contra valor factura del proveedor
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
        #region Inv_valfac_incd: Valor total facturado
        private float _inv_valfac_incd;
        /// <summary>
        /// <para>TABLA: invmovcomprasma</para>
        /// <para>TABLA NATIVA: invmovcomprasmd</para>
        /// <para>CAMPO: Valor total facturado</para>
        /// <para>NOMBRE: inv_valfac_incd (float:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 20</para>
        /// <para>DESCRIPCION:
        /// Valor total factura de compra enviada por el proveedor (desde
        /// tabla detalles movimiento compras)
        /// </para>
        /// </summary>
        public float Inv_valfac_incd
        {
            get { return _inv_valfac_incd; }
            set
            {
                if (_inv_valfac_incd == value) return;
                _inv_valfac_incd = value;
                OnPropertyChanged("Inv_valfac_incd");
            }
        }
        #endregion
        #region Inv_salpag_inca: Saldo por pagar
        private float _inv_salpag_inca;
        /// <summary>
        /// <para>TABLA: invmovcomprasma</para>
        /// <para>TABLA NATIVA: invmovcomprasma</para>
        /// <para>CAMPO: Saldo por pagar</para>
        /// <para>NOMBRE: inv_salpag_inca (float:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 21</para>
        /// <para>DESCRIPCION:
        ///Valor del saldo pendiente por pagar al proveedor
        /// </para>
        /// </summary>
        public float Inv_salpag_inca
        {
            get { return _inv_salpag_inca; }
            set
            {
                if (_inv_salpag_inca == value) return;
                _inv_salpag_inca = value;
                OnPropertyChanged("Inv_salpag_inca");
            }
        }
        #endregion
        #region Inv_valred_inar: total ajuste redondeo
        private float _inv_valred_inar;
        /// <summary>
        /// <para>TABLA: invmovcomprasma</para>
        /// <para>TABLA NATIVA: invmaearticulos</para>
        /// <para>CAMPO: total ajuste redondeo</para>
        /// <para>NOMBRE: inv_valred_inar (float:62)</para>
        /// <para>ORDEN VISTA EN TABLA: 23</para>
        /// <para>DESCRIPCION:
        /// Sumatoria total Valor descontado o sumado para ajustar el redondeo
        /// al generar el precio de venta, puede ser positivo o negativo
        /// (viene de la tabla detalles compras)
        /// </para>
        /// </summary>
        public float Inv_valred_inar
        {
            get { return _inv_valred_inar; }
            set
            {
                if (_inv_valred_inar == value) return;
                _inv_valred_inar = value;
                OnPropertyChanged("Inv_valred_inar");
            }
        }
        #endregion
        #region Sys_codusu_usux: Código Usuario
        private String _sys_codusu_usux;
        /// <summary>
        /// <para>TABLA: invmovcomprasma</para>
        /// <para>TABLA NATIVA: sysusuarios</para>
        /// <para>CAMPO: Código Usuario</para>
        /// <para>NOMBRE: sys_codusu_usux (char:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 22</para>
        /// <para>DESCRIPCION:
        ///Código del usuario que realiza proceso
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
        #region Inv_fecanu_inca: Fecha Anulación
        private DateTime _inv_fecanu_inca;
        /// <summary>
        /// <para>TABLA: invmovcomprasma</para>
        /// <para>TABLA NATIVA: invmovcomprasma</para>
        /// <para>CAMPO: Fecha Anulación</para>
        /// <para>NOMBRE: inv_fecanu_inca (fecha:)</para>
        /// <para>ORDEN VISTA EN TABLA: 23</para>
        /// <para>DESCRIPCION:
        ///Fecha anulacion del registro de movimiento
        /// </para>
        /// </summary>
        public DateTime Inv_fecanu_inca
        {
            get { return _inv_fecanu_inca; }
            set
            {
                if (_inv_fecanu_inca == value) return;
                _inv_fecanu_inca = value;
                OnPropertyChanged("Inv_fecanu_inca");
            }
        }
        #endregion
        #region Inv_conreg_inca: Contador items
        private int _inv_conreg_inca;
        /// <summary>
        /// <para>TABLA: invmovcomprasma</para>
        /// <para>TABLA NATIVA: invmovcomprasma</para>
        /// <para>CAMPO: Contador items</para>
        /// <para>NOMBRE: inv_conreg_inca (int:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 24</para>
        /// <para>DESCRIPCION:
        /// Contador para generar el secuencial unico de registros en detalle
        /// </para>
        /// </summary>
        public int Inv_conreg_inca
        {
            get { return _inv_conreg_inca; }
            set
            {
                if (_inv_conreg_inca == value) return;
                _inv_conreg_inca = value;
                OnPropertyChanged("Inv_conreg_inca");
            }
        }
        #endregion
        #region Sis_estpro_espr: Estado Registro
        private String _sis_estpro_espr;
        /// <summary>
        /// <para>TABLA: invmovcomprasma</para>
        /// <para>TABLA NATIVA: sisestadoproces</para>
        /// <para>CAMPO: Estado Registro</para>
        /// <para>NOMBRE: sis_estpro_espr (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 25</para>
        /// <para>DESCRIPCION:
        ///Estado del registro: 1=Abierto 2=Confirmado 3=Anulado
        /// </para>
        /// </summary>
        public String Sis_estpro_espr
        {
            get { return _sis_estpro_espr; }
            set
            {
                if (_sis_estpro_espr == value) return;
                _sis_estpro_espr = value;
                OnPropertyChanged("Sis_estpro_espr");
            }
        }
        #endregion
        #region Inv_desreg_intr: Descripción tipo movimiento
        private String _inv_desreg_intr;
        /// <summary>
        /// <para>TABLA: invmovcomprasma</para>
        /// <para>TABLA NATIVA: invtiporegimovi</para>
        /// <para>CAMPO: Descripción tipo movimiento</para>
        /// <para>NOMBRE: inv_desreg_intr (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripción tipo registro
        /// </para>
        /// </summary>
        public String Inv_desreg_intr
        {
            get { return _inv_desreg_intr; }
            set
            {
                if (_inv_desreg_intr == value) return;
                _inv_desreg_intr = value;
                OnPropertyChanged("Inv_desreg_intr");
            }
        }
        #endregion
        #region Inv_desreg_incx: Descripción tipo registro
        private String _inv_desreg_incx;
        /// <summary>
        /// <para>TABLA: invmovcomprasma</para>
        /// <para>TABLA NATIVA: invtiporecompra</para>
        /// <para>CAMPO: Descripción tipo registro</para>
        /// <para>NOMBRE: inv_desreg_incx (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripción tipo registro movimiento en compras
        /// </para>
        /// </summary>
        public String Inv_desreg_incx
        {
            get { return _inv_desreg_incx; }
            set
            {
                if (_inv_desreg_incx == value) return;
                _inv_desreg_incx = value;
                OnPropertyChanged("Inv_desreg_incx");
            }
        }
        #endregion
        #region Inv_descon_incm: Descripción concepto
        private String _inv_descon_incm;
        /// <summary>
        /// <para>TABLA: invmovcomprasma</para>
        /// <para>TABLA NATIVA: invtipoconcemov</para>
        /// <para>CAMPO: Descripción concepto</para>
        /// <para>NOMBRE: inv_descon_incm (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripción concepto movimiento diario
        /// </para>
        /// </summary>
        public String Inv_descon_incm
        {
            get { return _inv_descon_incm; }
            set
            {
                if (_inv_descon_incm == value) return;
                _inv_descon_incm = value;
                OnPropertyChanged("Inv_descon_incm");
            }
        }
        #endregion
        #region Sis_razsoc_sipr: Razón Social
        private String _sis_razsoc_sipr;
        /// <summary>
        /// <para>TABLA: invmovcomprasma</para>
        /// <para>TABLA NATIVA: sisproveedores</para>
        /// <para>CAMPO: Razón Social</para>
        /// <para>NOMBRE: sis_razsoc_sipr (char:60)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        ///Razón Social del Proveedor
        /// </para>
        /// </summary>
        public String Sis_razsoc_sipr
        {
            get { return _sis_razsoc_sipr; }
            set
            {
                if (_sis_razsoc_sipr == value) return;
                _sis_razsoc_sipr = value;
                OnPropertyChanged("Sis_razsoc_sipr");
            }
        }
        #endregion
        #region Inv_desalm_inal: Descripción Almacén
        private String _inv_desalm_inal;
        /// <summary>
        /// <para>TABLA: invmovcomprasma</para>
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
        #region Con_dessco_ccos: Nombre centro de costo
        private String _con_dessco_ccos;
        /// <summary>
        /// <para>TABLA: invmovcomprasma</para>
        /// <para>TABLA NATIVA: concentrodcosto</para>
        /// <para>CAMPO: Nombre centro de costo</para>
        /// <para>NOMBRE: con_dessco_ccos (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Nombre o descripción del centro de costo
        /// </para>
        /// </summary>
        public String Con_dessco_ccos
        {
            get { return _con_dessco_ccos; }
            set
            {
                if (_con_dessco_ccos == value) return;
                _con_dessco_ccos = value;
                OnPropertyChanged("Con_dessco_ccos");
            }
        }
        #endregion
        #region Sys_nomusu_usux: Nombre Usuario
        private String _sys_nomusu_usux;
        /// <summary>
        /// <para>TABLA: invmovcomprasma</para>
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
        #region Sis_despro_espr: Decripción estado proceso
        private String _sis_despro_espr;
        /// <summary>
        /// <para>TABLA: invmovcomprasma</para>
        /// <para>TABLA NATIVA: sisestadoproces</para>
        /// <para>CAMPO: Decripción estado proceso</para>
        /// <para>NOMBRE: sis_despro_espr (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Descripcion textual del estado de proceso Abierto(a), Cerrado(a)
        /// Y Anulado(a)
        /// </para>
        /// </summary>
        public String Sis_despro_espr
        {
            get { return _sis_despro_espr; }
            set
            {
                if (_sis_despro_espr == value) return;
                _sis_despro_espr = value;
                OnPropertyChanged("Sis_despro_espr");
            }
        }
        #endregion
        #endregion
        #endregion
        #region Metodos para edicion de registros
        #region Adicionar Registro
        public static string flgAddRegistro(ModeloEntradaCompras tobjModelo)
        {
            var lcrCodigoGen = SysModelo.fcrGenerarNuevoCodigo("INV-IDECOMPRAS-MAECOMPRAS", "INV", "Secuencial Unico maestro compras");
            try
            {
                if (!flgBuscarInvmovcomprasma(lcrCodigoGen))
                {
                    using (_context = new DbAplicacion())
                    {
                        var lobjRegistro = new EFinvmovcomprasma
                        {
                            #region cargar Registro
                            inv_secreg_inca = tobjModelo.Inv_secreg_inca,
                            inv_tipmov_intr = tobjModelo.Inv_tipmov_intr,
                            inv_tipreg_incx = tobjModelo.Inv_tipreg_incx,
                            inv_conmov_incm = tobjModelo.Inv_conmov_incm,
                            inv_desreg_inca = tobjModelo.Inv_desreg_inca,
                            inv_fecges_inca = tobjModelo.Inv_fecges_inca,
                            inv_numref_inca = tobjModelo.Inv_numref_inca,
                            sis_secpro_sipr = tobjModelo.Sis_secpro_sipr,
                            inv_codalm_inal = tobjModelo.Inv_codalm_inal,
                            con_codsco_ccos = tobjModelo.Con_codsco_ccos,
                            inv_numdoc_inca = tobjModelo.Inv_numdoc_inca,
                            inv_fecdoc_inca = tobjModelo.Inv_fecdoc_inca,
                            inv_fecsol_inca = tobjModelo.Inv_fecsol_inca,
                            inv_diapla_inca = tobjModelo.Inv_diapla_inca,
                            inv_brufac_incd = tobjModelo.Inv_brufac_incd,
                            inv_pordes_incd = tobjModelo.Inv_pordes_incd,
                            inv_valdes_incd = tobjModelo.Inv_valdes_incd,
                            inv_valiva_incd = tobjModelo.Inv_valiva_incd,
                            inv_valing_inar = tobjModelo.Inv_valing_inar,
                            inv_valfac_incd = tobjModelo.Inv_valfac_incd,
                            inv_salpag_inca = tobjModelo.Inv_salpag_inca,
                            inv_valred_inar = tobjModelo.Inv_valred_inar,
                            sys_codusu_usux = tobjModelo.Sys_codusu_usux,
                            inv_fecanu_inca = tobjModelo.Inv_fecanu_inca,
                            inv_conreg_inca = tobjModelo.Inv_conreg_inca,
                            sis_estpro_espr = tobjModelo.Sis_estpro_espr,
                            #endregion
                        };
                        lobjRegistro.inv_secreg_inca = lcrCodigoGen;
                        _context.AddToInvmovcomprasma(lobjRegistro);
                        _context.SaveChanges();
                    }
                }
                else
                {
                    lcrCodigoGen = string.Empty;
                    MessageBox.Show("Nuevo codigo Generado esta desactualizado, revisar llave: \n" +
                                "'INV-IDECOMPRAS-MAECOMPRAS': Secuencial Unico maestro compras en Maestro Secuenciales.");
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
        public static void fcvActualizar(ModeloEntradaCompras tobjModelo)
        {
            try
            {
                using (_context = new DbAplicacion())
                {
                    var lobjRegistro = _context.Invmovcomprasma.FirstOrDefault(p => p.inv_secreg_inca == tobjModelo.Inv_secreg_inca);
                    if (lobjRegistro != null)
                    {
                        lobjRegistro.inv_secreg_inca = tobjModelo.Inv_secreg_inca;
                        lobjRegistro.inv_tipmov_intr = tobjModelo.Inv_tipmov_intr;
                        lobjRegistro.inv_tipreg_incx = tobjModelo.Inv_tipreg_incx;
                        lobjRegistro.inv_conmov_incm = tobjModelo.Inv_conmov_incm;
                        lobjRegistro.inv_desreg_inca = tobjModelo.Inv_desreg_inca;
                        lobjRegistro.inv_fecges_inca = (DateTime)tobjModelo.Inv_fecges_inca;
                        lobjRegistro.inv_numref_inca = tobjModelo.Inv_numref_inca;
                        lobjRegistro.sis_secpro_sipr = tobjModelo.Sis_secpro_sipr;
                        lobjRegistro.inv_codalm_inal = tobjModelo.Inv_codalm_inal;
                        lobjRegistro.con_codsco_ccos = tobjModelo.Con_codsco_ccos;
                        lobjRegistro.inv_numdoc_inca = tobjModelo.Inv_numdoc_inca;
                        lobjRegistro.inv_fecdoc_inca = (DateTime)tobjModelo.Inv_fecdoc_inca;
                        lobjRegistro.inv_fecsol_inca = (DateTime)tobjModelo.Inv_fecsol_inca;
                        lobjRegistro.inv_diapla_inca = (int)tobjModelo.Inv_diapla_inca;
                        lobjRegistro.inv_brufac_incd = (float)tobjModelo.Inv_brufac_incd;
                        lobjRegistro.inv_pordes_incd = (float)tobjModelo.Inv_pordes_incd;
                        lobjRegistro.inv_valdes_incd = (float)tobjModelo.Inv_valdes_incd;
                        lobjRegistro.inv_valiva_incd = (float)tobjModelo.Inv_valiva_incd;
                        lobjRegistro.inv_valing_inar = (float)tobjModelo.Inv_valing_inar;
                        lobjRegistro.inv_valfac_incd = (float)tobjModelo.Inv_valfac_incd;
                        lobjRegistro.inv_salpag_inca = (float)tobjModelo.Inv_salpag_inca;
                        lobjRegistro.inv_valred_inar = (float)tobjModelo.Inv_valred_inar;
                        lobjRegistro.sys_codusu_usux = tobjModelo.Sys_codusu_usux;
                        lobjRegistro.inv_fecanu_inca = (DateTime)tobjModelo.Inv_fecanu_inca;
                        lobjRegistro.inv_conreg_inca = (int)tobjModelo.Inv_conreg_inca;
                        lobjRegistro.sis_estpro_espr = tobjModelo.Sis_estpro_espr;
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
                    var lobjRegistro = _context.Invmovcomprasma.FirstOrDefault(p => p.inv_secreg_inca == tcrCodigo);
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
        #region Buscar INVMOVCOMPRASMA: Logica
        /// <summary>
        /// <para>TABLA: invmovcomprasma</para>
        /// <para>TITULO: Tabla maestro movimientos compras</para>
        /// <para>MODULO: INV</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Tabla maestro movimientos de compras  e ingresos en inventarios:
        /// 1=Cotizacion compra  2=Ordenes de compra 3=Ingresos por compra
        /// 4=Devoluciones por compra
        /// </para>
        /// </summary>
        public static bool flgBuscarInvmovcomprasma(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Invmovcomprasma.FirstOrDefault(p => p.inv_secreg_inca == tcrCodigo);
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
        /// //Modelo Maestro Entrada de Compras: Lista de Registros
        /// </summary>
        /// <param name="tcrBuscar"></param>
        /// <returns></returns>
        public static List<ModeloEntradaCompras> flsListaInvmovcomprasma(string tcrBuscar)
        {
            using (_context = new DbAplicacion())
            {
                var lobConsulta = from invmovcomprasma in _context.Invmovcomprasma
                                  join sisproveedores in _context.Sisproveedores on invmovcomprasma.sis_secpro_sipr equals sisproveedores.sis_secpro_sipr into tmsisproveedores
                                  join invalmacenmaest in _context.Invalmacenmaest on invmovcomprasma.inv_codalm_inal equals invalmacenmaest.inv_codalm_inal into tminvalmacenmaest
                                  join concentrodcosto in _context.Concentrodcosto on invmovcomprasma.con_codsco_ccos equals concentrodcosto.con_codsco_ccos into tmconcentrodcosto
                                  join sysusuarios in _context.Sysusuarios on invmovcomprasma.sys_codusu_usux equals sysusuarios.sys_codusu_usux into tmsysusuarios
                                  join sisestadoproces in _context.Sisestadoproces on invmovcomprasma.sis_estpro_espr equals sisestadoproces.sis_estpro_espr into tmsisestadoproces
                                  from sipr in tmsisproveedores.DefaultIfEmpty()
                                  from inal in tminvalmacenmaest.DefaultIfEmpty()
                                  from ccos in tmconcentrodcosto.DefaultIfEmpty()
                                  from usux in tmsysusuarios.DefaultIfEmpty()
                                  from espr in tmsisestadoproces.DefaultIfEmpty()
                                  where invmovcomprasma.inv_secreg_inca.Contains(tcrBuscar)
                                  select new ModeloEntradaCompras
                                  {
                                      #region
                                      Inv_secreg_inca = invmovcomprasma.inv_secreg_inca,
                                      Inv_tipmov_intr = invmovcomprasma.inv_tipmov_intr,
                                      Inv_tipreg_incx = invmovcomprasma.inv_tipreg_incx,
                                      Inv_conmov_incm = invmovcomprasma.inv_conmov_incm,
                                      Inv_desreg_inca = invmovcomprasma.inv_desreg_inca,
                                      Inv_fecges_inca = (DateTime)invmovcomprasma.inv_fecges_inca,
                                      Inv_numref_inca = invmovcomprasma.inv_numref_inca,
                                      Sis_secpro_sipr = invmovcomprasma.sis_secpro_sipr,
                                      Inv_codalm_inal = invmovcomprasma.inv_codalm_inal,
                                      Con_codsco_ccos = invmovcomprasma.con_codsco_ccos,
                                      Inv_numdoc_inca = invmovcomprasma.inv_numdoc_inca,
                                      Inv_fecdoc_inca = (DateTime)invmovcomprasma.inv_fecdoc_inca,
                                      Inv_fecsol_inca = (DateTime)invmovcomprasma.inv_fecsol_inca,
                                      Inv_diapla_inca = (int)invmovcomprasma.inv_diapla_inca,
                                      Inv_brufac_incd = (float)invmovcomprasma.inv_brufac_incd,
                                      Inv_pordes_incd = (float)invmovcomprasma.inv_pordes_incd,
                                      Inv_valdes_incd = (float)invmovcomprasma.inv_valdes_incd,
                                      Inv_valiva_incd = (float)invmovcomprasma.inv_valiva_incd,
                                      Inv_valing_inar = (float)invmovcomprasma.inv_valing_inar,
                                      Inv_valfac_incd = (float)invmovcomprasma.inv_valfac_incd,
                                      Inv_salpag_inca = (float)invmovcomprasma.inv_salpag_inca,
                                      Inv_valred_inar = (float)invmovcomprasma.inv_valred_inar,
                                      Sys_codusu_usux = invmovcomprasma.sys_codusu_usux,
                                      Inv_fecanu_inca = (DateTime)invmovcomprasma.inv_fecanu_inca,
                                      Inv_conreg_inca = (int)invmovcomprasma.inv_conreg_inca,
                                      Sis_estpro_espr = invmovcomprasma.sis_estpro_espr,
                                      Sis_razsoc_sipr = sipr.sis_razsoc_sipr,
                                      Inv_desalm_inal = inal.inv_desalm_inal,
                                      Con_dessco_ccos = ccos.con_dessco_ccos,
                                      Sys_nomusu_usux = usux.sys_nomusu_usux,
                                      Sis_despro_espr = espr.sis_despro_espr,
                                      #endregion
                                  };
                return lobConsulta.ToList();
            }
        }
        #endregion
        #endregion
    }
    #endregion
    #region Modelo Detalles Entrada Compras
    /// <summary>
    /// invmovcomprasmd: Detalles entradas por compras
    /// </summary>
    public class ModeloDetallEntCompra : clBaseInpc
    {
        #region Modelo Attributos
        private static DbAplicacion _context;
        #region Modelo Propiedades Notificacion
        #region Inv_secreg_incd: Codigo registro
        private String _inv_secreg_incd;
        /// <summary>
        /// <para>TABLA: invmovcomprasmd</para>
        /// <para>TABLA NATIVA: invmovcomprasmd</para>
        /// <para>CAMPO: Codigo registro</para>
        /// <para>NOMBRE: inv_secreg_incd (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        /// Secuencial unico para cada registro detalle de la tabla (generado
        /// por el sistema)
        /// </para>
        /// </summary>
        public String Inv_secreg_incd
        {
            get { return _inv_secreg_incd; }
            set
            {
                if (_inv_secreg_incd == value) return;
                _inv_secreg_incd = value;
                OnPropertyChanged("Inv_secreg_incd");
            }
        }
        #endregion
        #region Inv_secreg_inca: Secuencial reg. Maestro
        private String _inv_secreg_inca;
        /// <summary>
        /// <para>TABLA: invmovcomprasmd</para>
        /// <para>TABLA NATIVA: invmovcomprasma</para>
        /// <para>CAMPO: Secuencial reg. Maestro</para>
        /// <para>NOMBRE: inv_secreg_inca (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Secuencial  unico registro maestro movimientos por compras
        /// tabla: INVMOVCOMPRASMA
        /// </para>
        /// </summary>
        public String Inv_secreg_inca
        {
            get { return _inv_secreg_inca; }
            set
            {
                if (_inv_secreg_inca == value) return;
                _inv_secreg_inca = value;
                OnPropertyChanged("Inv_secreg_inca");
            }
        }
        #endregion
        #region Inv_codalm_inal: Código Almacén
        private String _inv_codalm_inal;
        /// <summary>
        /// <para>TABLA: invmovcomprasmd</para>
        /// <para>TABLA NATIVA: invalmacenmaest</para>
        /// <para>CAMPO: Código Almacén</para>
        /// <para>NOMBRE: inv_codalm_inal (char:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        ///Código del Almacén desde el maestro almacen
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
        #region Inv_tipreg_incx: Tipo Registro compra
        private String _inv_tipreg_incx;
        /// <summary>
        /// <para>TABLA: invmovcomprasmd</para>
        /// <para>TABLA NATIVA: invtiporecompra</para>
        /// <para>CAMPO: Tipo Registro compra</para>
        /// <para>NOMBRE: inv_tipreg_incx (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        /// Tipo registro movimiento o documento  (manejo interno del modulo)
        /// compra: 1=Cotizacion compra 2=Ordenes de compra 3=Ingresos
        /// por compra 4=Devoluciones por compra
        /// </para>
        /// </summary>
        public String Inv_tipreg_incx
        {
            get { return _inv_tipreg_incx; }
            set
            {
                if (_inv_tipreg_incx == value) return;
                _inv_tipreg_incx = value;
                OnPropertyChanged("Inv_tipreg_incx");
            }
        }
        #endregion
        #region Inv_conmov_incm: Concepto Movimiento
        private String _inv_conmov_incm;
        /// <summary>
        /// <para>TABLA: invmovcomprasmd</para>
        /// <para>TABLA NATIVA: invtipoconcemov</para>
        /// <para>CAMPO: Concepto Movimiento</para>
        /// <para>NOMBRE: inv_conmov_incm (char:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        /// Concepto movimiento: 11= Entradas compras 12= Entrada Traslado
        /// interno 13=Entradas por ajustes  21= Salidas Ventas 22= Salidas
        /// Traslado 23= Salidas Otras Áreas Empresa 24= Salida entrega
        /// formula 25=Salida suministro intrahospitalario y otros
        /// </para>
        /// </summary>
        public String Inv_conmov_incm
        {
            get { return _inv_conmov_incm; }
            set
            {
                if (_inv_conmov_incm == value) return;
                _inv_conmov_incm = value;
                OnPropertyChanged("Inv_conmov_incm");
            }
        }
        #endregion
        #region Inv_secart_inar: Codigo articulo
        private String _inv_secart_inar;
        /// <summary>
        /// <para>TABLA: invmovcomprasmd</para>
        /// <para>TABLA NATIVA: invmaearticulos</para>
        /// <para>CAMPO: Codigo articulo</para>
        /// <para>NOMBRE: inv_secart_inar (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        /// Secuencial de articulo generado por el sistema viene de la
        /// tabla: MAESTRO ARTICULOS
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
        #region Inv_codaux_inar: Código Auxiliar
        private String _inv_codaux_inar;
        /// <summary>
        /// <para>TABLA: invmovcomprasmd</para>
        /// <para>TABLA NATIVA: invmaearticulos</para>
        /// <para>CAMPO: Código Auxiliar</para>
        /// <para>NOMBRE: inv_codaux_inar (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
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
        #region Inv_lotref_inar: Lote o Referencia
        private String _inv_lotref_inar;
        /// <summary>
        /// <para>TABLA: invmovcomprasmd</para>
        /// <para>TABLA NATIVA: invmaearticulos</para>
        /// <para>CAMPO: Lote o Referencia</para>
        /// <para>NOMBRE: inv_lotref_inar (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        /// Lote o Referencia del articulo Artículo, se captura dato cuando
        /// el subgrupo de inventario lo requiera según configuracion
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
        /// <para>TABLA: invmovcomprasmd</para>
        /// <para>TABLA NATIVA: invmaearticulos</para>
        /// <para>CAMPO: Registro sanitario</para>
        /// <para>NOMBRE: inv_regsan_inar (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION:
        /// Registro sanitario (IMVIMA) se captura cuando el articulo lo
        /// requiera según configracion en manual de articulos
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
        #region Inv_fecven_incd: Fecha vencimiento
        private DateTime _inv_fecven_incd;
        /// <summary>
        /// <para>TABLA: invmovcomprasmd</para>
        /// <para>TABLA NATIVA: invmovcomprasmd</para>
        /// <para>CAMPO: Fecha vencimiento</para>
        /// <para>NOMBRE: inv_fecven_incd (fecha:8)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
        /// <para>DESCRIPCION:
        /// Fecha vencimiento del producto, cuando sea perecedero (Verdura/Medicament
        /// os y otros)
        /// </para>
        /// </summary>
        public DateTime Inv_fecven_incd
        {
            get { return _inv_fecven_incd; }
            set
            {
                if (_inv_fecven_incd == value) return;
                _inv_fecven_incd = value;
                OnPropertyChanged("Inv_fecven_incd");
            }
        }
        #endregion
        #region Sis_codgme_sigr: Patrón medida
        private String _sis_codgme_sigr;
        /// <summary>
        /// <para>TABLA: invmovcomprasmd</para>
        /// <para>TABLA NATIVA: sisgrupomedidas</para>
        /// <para>CAMPO: Patrón medida</para>
        /// <para>NOMBRE: sis_codgme_sigr (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 11</para>
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
        #region Sis_codume_sium: Medida consumo
        private String _sis_codume_sium;
        /// <summary>
        /// <para>TABLA: invmovcomprasmd</para>
        /// <para>TABLA NATIVA: sisunidadmedida</para>
        /// <para>CAMPO: Medida consumo</para>
        /// <para>NOMBRE: sis_codume_sium (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 12</para>
        /// <para>DESCRIPCION:
        /// Unidad Medida como quedaran las existencias en Inventario (libra,
        /// metro, litros etc.)  para consumo/salida
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
        #region Inv_codctn_intc: Código Contenedor
        private String _inv_codctn_intc;
        /// <summary>
        /// <para>TABLA: invmovcomprasmd</para>
        /// <para>TABLA NATIVA: invcontenedores</para>
        /// <para>CAMPO: Código Contenedor</para>
        /// <para>NOMBRE: inv_codctn_intc (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 13</para>
        /// <para>DESCRIPCION:
        ///Código tipo de contenedor o presentación
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
        #region Inv_totctn_incd: Total Contenedores
        private int _inv_totctn_incd;
        /// <summary>
        /// <para>TABLA: invmovcomprasmd</para>
        /// <para>TABLA NATIVA: invmovcomprasmd</para>
        /// <para>CAMPO: Total Contenedores</para>
        /// <para>NOMBRE: inv_totctn_incd (int:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 14</para>
        /// <para>DESCRIPCION:
        /// Total Contenedores para (realizar calculo de ingreso o salida)
        /// </para>
        /// </summary>
        public int Inv_totctn_incd
        {
            get { return _inv_totctn_incd; }
            set
            {
                if (_inv_totctn_incd == value) return;
                _inv_totctn_incd = value;
                OnPropertyChanged("Inv_totctn_incd");
            }
        }
        #endregion
        #region Inv_unictn_incd: Unidad Contenedores
        private int _inv_unictn_incd;
        /// <summary>
        /// <para>TABLA: invmovcomprasmd</para>
        /// <para>TABLA NATIVA: invmovcomprasmd</para>
        /// <para>CAMPO: Unidad Contenedores</para>
        /// <para>NOMBRE: inv_unictn_incd (int:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 15</para>
        /// <para>DESCRIPCION:
        /// Unidades en un Contenedor: Ejemplo: una caja es un contenedor
        /// y tiene 10 unidades.
        /// </para>
        /// </summary>
        public int Inv_unictn_incd
        {
            get { return _inv_unictn_incd; }
            set
            {
                if (_inv_unictn_incd == value) return;
                _inv_unictn_incd = value;
                OnPropertyChanged("Inv_unictn_incd");
            }
        }
        #endregion
        #region Inv_unisue_incd: Unidades sueltas
        private int _inv_unisue_incd;
        /// <summary>
        /// <para>TABLA: invmovcomprasmd</para>
        /// <para>TABLA NATIVA: invmovcomprasmd</para>
        /// <para>CAMPO: Unidades sueltas</para>
        /// <para>NOMBRE: inv_unisue_incd (int:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 16</para>
        /// <para>DESCRIPCION:
        /// Cantidad unidades sueltas adicinales que no alcanzan para ser
        /// contadas como un contenedor mas
        /// </para>
        /// </summary>
        public int Inv_unisue_incd
        {
            get { return _inv_unisue_incd; }
            set
            {
                if (_inv_unisue_incd == value) return;
                _inv_unisue_incd = value;
                OnPropertyChanged("Inv_unisue_incd");
            }
        }
        #endregion
        #region Inv_unitot_incd: Total Unidades
        private int _inv_unitot_incd;
        /// <summary>
        /// <para>TABLA: invmovcomprasmd</para>
        /// <para>TABLA NATIVA: invmovcomprasmd</para>
        /// <para>CAMPO: Total Unidades</para>
        /// <para>NOMBRE: inv_unitot_incd (int:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 17</para>
        /// <para>DESCRIPCION:
        /// TOTAL UNIDADES, cantidad de unidades en total de la transaccion
        /// (calculo Unidades por  contenedor mas unidades sueltas)
        /// </para>
        /// </summary>
        public int Inv_unitot_incd
        {
            get { return _inv_unitot_incd; }
            set
            {
                if (_inv_unitot_incd == value) return;
                _inv_unitot_incd = value;
                OnPropertyChanged("Inv_unitot_incd");
            }
        }
        #endregion
        #region Inv_unidev_incd: Unidades devolucion
        private int _inv_unidev_incd;
        /// <summary>
        /// <para>TABLA: invmovcomprasmd</para>
        /// <para>TABLA NATIVA: invmovcomprasmd</para>
        /// <para>CAMPO: Unidades devolucion</para>
        /// <para>NOMBRE: inv_unidev_incd (int:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 18</para>
        /// <para>DESCRIPCION:
        /// UNIDADES EN DEVOLUCION, cantidad de unidades para una devolucion
        /// de compra realizada a un proveedor
        /// </para>
        /// </summary>
        public int Inv_unidev_incd
        {
            get { return _inv_unidev_incd; }
            set
            {
                if (_inv_unidev_incd == value) return;
                _inv_unidev_incd = value;
                OnPropertyChanged("Inv_unidev_incd");
            }
        }
        #endregion
        #region Inv_valing_inar: Costo compra Unidad
        private float _inv_valing_inar;
        /// <summary>
        /// <para>TABLA: invmovcomprasmd</para>
        /// <para>TABLA NATIVA: invmaearticulos</para>
        /// <para>CAMPO: Costo compra Unidad</para>
        /// <para>NOMBRE: inv_valing_inar (float:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 19</para>
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
        #region Inv_brufac_incd: Valor Bruto
        private float _inv_brufac_incd;
        /// <summary>
        /// <para>TABLA: invmovcomprasmd</para>
        /// <para>TABLA NATIVA: invmovcomprasmd</para>
        /// <para>CAMPO: Valor Bruto</para>
        /// <para>NOMBRE: inv_brufac_incd (float:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 20</para>
        /// <para>DESCRIPCION:
        /// Valor Bruto/Neto Facturado articulo sin ninguna deduccion (desde
        /// la tabla detalles movimiento diario)
        /// </para>
        /// </summary>
        public float Inv_brufac_incd
        {
            get { return _inv_brufac_incd; }
            set
            {
                if (_inv_brufac_incd == value) return;
                _inv_brufac_incd = value;
                OnPropertyChanged("Inv_brufac_incd");
            }
        }
        #endregion
        #region Inv_pordes_incd: Porcentaje Descuento
        private float _inv_pordes_incd;
        /// <summary>
        /// <para>TABLA: invmovcomprasmd</para>
        /// <para>TABLA NATIVA: invmovcomprasmd</para>
        /// <para>CAMPO: Porcentaje Descuento</para>
        /// <para>NOMBRE: inv_pordes_incd (float:52)</para>
        /// <para>ORDEN VISTA EN TABLA: 21</para>
        /// <para>DESCRIPCION:
        /// Porcentaje Descuento (desde la tabla detalles movimiento diario)
        /// </para>
        /// </summary>
        public float Inv_pordes_incd
        {
            get { return _inv_pordes_incd; }
            set
            {
                if (_inv_pordes_incd == value) return;
                _inv_pordes_incd = value;
                OnPropertyChanged("Inv_pordes_incd");
            }
        }
        #endregion
        #region Inv_valdes_incd: Valor descuento
        private float _inv_valdes_incd;
        /// <summary>
        /// <para>TABLA: invmovcomprasmd</para>
        /// <para>TABLA NATIVA: invmovcomprasmd</para>
        /// <para>CAMPO: Valor descuento</para>
        /// <para>NOMBRE: inv_valdes_incd (float:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 22</para>
        /// <para>DESCRIPCION:
        ///Valor total del descuento facturado
        /// </para>
        /// </summary>
        public float Inv_valdes_incd
        {
            get { return _inv_valdes_incd; }
            set
            {
                if (_inv_valdes_incd == value) return;
                _inv_valdes_incd = value;
                OnPropertyChanged("Inv_valdes_incd");
            }
        }
        #endregion
        #region Inv_valiva_incd: Valor IVA
        private float _inv_valiva_incd;
        /// <summary>
        /// <para>TABLA: invmovcomprasmd</para>
        /// <para>TABLA NATIVA: invmovcomprasmd</para>
        /// <para>CAMPO: Valor IVA</para>
        /// <para>NOMBRE: inv_valiva_incd (float:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 23</para>
        /// <para>DESCRIPCION:
        ///Valor total del IVA pagado en la compra
        /// </para>
        /// </summary>
        public float Inv_valiva_incd
        {
            get { return _inv_valiva_incd; }
            set
            {
                if (_inv_valiva_incd == value) return;
                _inv_valiva_incd = value;
                OnPropertyChanged("Inv_valiva_incd");
            }
        }
        #endregion
        #region Inv_porive_inar: % Incremento venta
        private float _inv_porive_inar;
        /// <summary>
        /// <para>TABLA: invmovcomprasmd</para>
        /// <para>TABLA NATIVA: invmaearticulos</para>
        /// <para>CAMPO: % Incremento venta</para>
        /// <para>NOMBRE: inv_porive_inar (float:52)</para>
        /// <para>ORDEN VISTA EN TABLA: 24</para>
        /// <para>DESCRIPCION:
        /// Porcentaje de Incremento para Generar Precio de Venta (con
        /// Base al Precio de Compra)
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
        #region Inv_valred_inar: Valor ajuste redondeo
        private float _inv_valred_inar;
        /// <summary>
        /// <para>TABLA: invmovcomprasmd</para>
        /// <para>TABLA NATIVA: invmaearticulos</para>
        /// <para>CAMPO: Valor ajuste redondeo</para>
        /// <para>NOMBRE: inv_valred_inar (float:62)</para>
        /// <para>ORDEN VISTA EN TABLA: 25</para>
        /// <para>DESCRIPCION:
        /// Valor descontado o sumado para ajustar el redondeo al generar
        /// el precio de venta, puede ser positivo o negativo
        /// </para>
        /// </summary>
        public float Inv_valred_inar
        {
            get { return _inv_valred_inar; }
            set
            {
                if (_inv_valred_inar == value) return;
                _inv_valred_inar = value;
                OnPropertyChanged("Inv_valred_inar");
            }
        }
        #endregion
        #region Inv_valmov_inar: Valor unidad venta
        private float _inv_valmov_inar;
        /// <summary>
        /// <para>TABLA: invmovcomprasmd</para>
        /// <para>TABLA NATIVA: invmaearticulos</para>
        /// <para>CAMPO: Valor unidad venta</para>
        /// <para>NOMBRE: inv_valmov_inar (float:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 25</para>
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
        #region Inv_valfac_incd: Valor total facturado
        private float _inv_valfac_incd;
        /// <summary>
        /// <para>TABLA: invmovcomprasmd</para>
        /// <para>TABLA NATIVA: invmovcomprasmd</para>
        /// <para>CAMPO: Valor total facturado</para>
        /// <para>NOMBRE: inv_valfac_incd (float:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 26</para>
        /// <para>DESCRIPCION:
        ///Valor total del registro articulo
        /// </para>
        /// </summary>
        public float Inv_valfac_incd
        {
            get { return _inv_valfac_incd; }
            set
            {
                if (_inv_valfac_incd == value) return;
                _inv_valfac_incd = value;
                OnPropertyChanged("Inv_valfac_incd");
            }
        }
        #endregion
        #region Inv_codest_ines: Código Estante
        private String _inv_codest_ines;
        /// <summary>
        /// <para>TABLA: invmovcomprasmd</para>
        /// <para>TABLA NATIVA: invalmacenestan</para>
        /// <para>CAMPO: Código Estante</para>
        /// <para>NOMBRE: inv_codest_ines (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 27</para>
        /// <para>DESCRIPCION:
        /// Codgo del estante para cada almacen: Ejemplo E01-Estante Medicamentos
        /// de control
        /// </para>
        /// </summary>
        public String Inv_codest_ines
        {
            get { return _inv_codest_ines; }
            set
            {
                if (_inv_codest_ines == value) return;
                _inv_codest_ines = value;
                OnPropertyChanged("Inv_codest_ines");
            }
        }
        #endregion
        #region Inv_seccio_ines: Secciones
        private String _inv_seccio_ines;
        /// <summary>
        /// <para>TABLA: invmovcomprasmd</para>
        /// <para>TABLA NATIVA: invalmacenestan</para>
        /// <para>CAMPO: Secciones</para>
        /// <para>NOMBRE: inv_seccio_ines (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 28</para>
        /// <para>DESCRIPCION:
        /// Lista de secciones del estante para validacion (generada por
        /// el sistema) ejemplo: S01,S02,S03,S04 según el numero de secciones
        /// que contenga el estante
        /// </para>
        /// </summary>
        public String Inv_seccio_ines
        {
            get { return _inv_seccio_ines; }
            set
            {
                if (_inv_seccio_ines == value) return;
                _inv_seccio_ines = value;
                OnPropertyChanged("Inv_seccio_ines");
            }
        }
        #endregion
        #region Inv_estant_ines: Vista estante
        private String _inv_estant_ines;
        /// <summary>
        /// <para>TABLA: invmovcomprasmd</para>
        /// <para>TABLA NATIVA: invalmacenestan</para>
        /// <para>CAMPO: Vista estante</para>
        /// <para>NOMBRE: inv_estant_ines (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 29</para>
        /// <para>DESCRIPCION:
        /// Codigo del estante sumado con la seccion, para llave de organización
        /// vista ejemplo: Estante = E01  y Seccion = S05  queda asi: E01S05
        /// </para>
        /// </summary>
        public String Inv_estant_ines
        {
            get { return _inv_estant_ines; }
            set
            {
                if (_inv_estant_ines == value) return;
                _inv_estant_ines = value;
                OnPropertyChanged("Inv_estant_ines");
            }
        }
        #endregion
        #region Sys_codusu_usux: Código Usuario
        private String _sys_codusu_usux;
        /// <summary>
        /// <para>TABLA: invmovcomprasmd</para>
        /// <para>TABLA NATIVA: sysusuarios</para>
        /// <para>CAMPO: Código Usuario</para>
        /// <para>NOMBRE: sys_codusu_usux (char:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 30</para>
        /// <para>DESCRIPCION:
        ///Código del usuario que realiza proceso
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
        #region Inv_fecedt_ines: Fecha ultima modificación
        private DateTime _inv_fecedt_ines;
        /// <summary>
        /// <para>TABLA: invmovcomprasmd</para>
        /// <para>TABLA NATIVA: invalmacenestan</para>
        /// <para>CAMPO: Fecha ultima modificación</para>
        /// <para>NOMBRE: inv_fecedt_ines (fecha:8)</para>
        /// <para>ORDEN VISTA EN TABLA: 31</para>
        /// <para>DESCRIPCION:
        ///Fecha ultima modificacion realizada por un usario
        /// </para>
        /// </summary>
        public DateTime Inv_fecedt_ines
        {
            get { return _inv_fecedt_ines; }
            set
            {
                if (_inv_fecedt_ines == value) return;
                _inv_fecedt_ines = value;
                OnPropertyChanged("Inv_fecedt_ines");
            }
        }
        #endregion
        #region Sis_estpro_espr: Estado Registro
        private String _sis_estpro_espr;
        /// <summary>
        /// <para>TABLA: invmovcomprasmd</para>
        /// <para>TABLA NATIVA: sisestadoproces</para>
        /// <para>CAMPO: Estado Registro</para>
        /// <para>NOMBRE: sis_estpro_espr (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 32</para>
        /// <para>DESCRIPCION:
        ///Estado del registro: 1=Abierto 2=Confirmado 3=Anulado
        /// </para>
        /// </summary>
        public String Sis_estpro_espr
        {
            get { return _sis_estpro_espr; }
            set
            {
                if (_sis_estpro_espr == value) return;
                _sis_estpro_espr = value;
                OnPropertyChanged("Sis_estpro_espr");
            }
        }
        #endregion
        #region Inv_desreg_inca: Descripción registro
        private String _inv_desreg_inca;
        /// <summary>
        /// <para>TABLA: invmovcomprasmd</para>
        /// <para>TABLA NATIVA: invmovcomprasma</para>
        /// <para>CAMPO: Descripción registro</para>
        /// <para>NOMBRE: inv_desreg_inca (char:200)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        ///Descripción textual del registro
        /// </para>
        /// </summary>
        public String Inv_desreg_inca
        {
            get { return _inv_desreg_inca; }
            set
            {
                if (_inv_desreg_inca == value) return;
                _inv_desreg_inca = value;
                OnPropertyChanged("Inv_desreg_inca");
            }
        }
        #endregion
        #region Inv_desalm_inal: Descripción Almacén
        private String _inv_desalm_inal;
        /// <summary>
        /// <para>TABLA: invmovcomprasmd</para>
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
        #region Inv_desreg_incx: Descripción tipo registro
        private String _inv_desreg_incx;
        /// <summary>
        /// <para>TABLA: invmovcomprasmd</para>
        /// <para>TABLA NATIVA: invtiporecompra</para>
        /// <para>CAMPO: Descripción tipo registro</para>
        /// <para>NOMBRE: inv_desreg_incx (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripción tipo registro movimiento en compras
        /// </para>
        /// </summary>
        public String Inv_desreg_incx
        {
            get { return _inv_desreg_incx; }
            set
            {
                if (_inv_desreg_incx == value) return;
                _inv_desreg_incx = value;
                OnPropertyChanged("Inv_desreg_incx");
            }
        }
        #endregion
        #region Inv_descon_incm: Descripción concepto
        private String _inv_descon_incm;
        /// <summary>
        /// <para>TABLA: invmovcomprasmd</para>
        /// <para>TABLA NATIVA: invtipoconcemov</para>
        /// <para>CAMPO: Descripción concepto</para>
        /// <para>NOMBRE: inv_descon_incm (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripción concepto movimiento diario
        /// </para>
        /// </summary>
        public String Inv_descon_incm
        {
            get { return _inv_descon_incm; }
            set
            {
                if (_inv_descon_incm == value) return;
                _inv_descon_incm = value;
                OnPropertyChanged("Inv_descon_incm");
            }
        }
        #endregion
        #region Inv_nomart_inar: Nombre artículo
        private String _inv_nomart_inar;
        /// <summary>
        /// <para>TABLA: invmovcomprasmd</para>
        /// <para>TABLA NATIVA: invmaearticulos</para>
        /// <para>CAMPO: Nombre artículo</para>
        /// <para>NOMBRE: inv_nomart_inar (char:50)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
        /// <para>DESCRIPCION:
        /// Titulo o descripción del artículo para vista en informes y
        /// gestion
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
        #region Sis_desgme_sigr: Descripción Grupo medida
        private String _sis_desgme_sigr;
        /// <summary>
        /// <para>TABLA: invmovcomprasmd</para>
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
        /// <para>TABLA: invmovcomprasmd</para>
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
        /// <para>TABLA: invmovcomprasmd</para>
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
        #region Inv_desest_ines: Descripción Estante
        private String _inv_desest_ines;
        /// <summary>
        /// <para>TABLA: invmovcomprasmd</para>
        /// <para>TABLA NATIVA: invalmacenestan</para>
        /// <para>CAMPO: Descripción Estante</para>
        /// <para>NOMBRE: inv_desest_ines (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        ///Descripción del estante
        /// </para>
        /// </summary>
        public String Inv_desest_ines
        {
            get { return _inv_desest_ines; }
            set
            {
                if (_inv_desest_ines == value) return;
                _inv_desest_ines = value;
                OnPropertyChanged("Inv_desest_ines");
            }
        }
        #endregion
        #region Sys_nomusu_usux: Nombre Usuario
        private String _sys_nomusu_usux;
        /// <summary>
        /// <para>TABLA: invmovcomprasmd</para>
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
        #region Sis_despro_espr: Decripción estado proceso
        private String _sis_despro_espr;
        /// <summary>
        /// <para>TABLA: invmovcomprasmd</para>
        /// <para>TABLA NATIVA: sisestadoproces</para>
        /// <para>CAMPO: Decripción estado proceso</para>
        /// <para>NOMBRE: sis_despro_espr (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Descripcion textual del estado de proceso Abierto(a), Cerrado(a)
        /// Y Anulado(a)
        /// </para>
        /// </summary>
        public String Sis_despro_espr
        {
            get { return _sis_despro_espr; }
            set
            {
                if (_sis_despro_espr == value) return;
                _sis_despro_espr = value;
                OnPropertyChanged("Sis_despro_espr");
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
        #region Far_codcum_famd: Código CUM
        private String _far_codcum_famd;
        /// <summary>
        /// <para>TABLA: temporal</para>
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
        /// <para>TABLA: temporal</para>
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
        /// <para>TABLA: temporal</para>
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
        #region Fcm_desser_sips: Nombre servicio
        private String _fcm_desser_sips;
        /// <summary>
        /// <para>TABLA: temporal</para>
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
        #region Inv_refips_inar: saber si cambió codigo servicio IPS
        private string _inv_refips_inar;
        /// <summary>
        /// <para>CAMPO: Saber si cambió codigo que referencia al servicio IPS</para>
        /// <para>NOMBRE: Sis_estado_imaen (char:1)</para>
        /// <para>DESCRIPCION: Saber si al digitar datos se cambia el codigo del servicio IPS referenciado</para>
        /// <para>Valores: 1=Hay Cambio 2=No hay cambios, valor por defecto es "2=No hay cambios", cambia a "1" cuando se actualiza el codigo servicio IPS</para>
        /// </summary>
        public String Inv_refips_inar
        {
            get { return _inv_refips_inar; }
            set
            {
                if (_inv_refips_inar == value) return;
                _inv_refips_inar = value;
                OnPropertyChanged("Inv_refips_inar");
            }
        }
        #endregion
        #region Inv_codgru_ingr: Grupo Clasificación
        private String _inv_codgru_ingr;
        /// <summary>
        /// <para>TABLA: temporal</para>
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
        #region Inv_desgru_ingr: Descripcion Grupo
        private String _inv_desgru_ingr;
        /// <summary>
        /// <para>TABLA: temporal</para>
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
        #endregion
        #endregion
        #region Metodos para edicion de registros
        #region Adicionar Registro Relacion
        public static bool flgAddRegistro(ModeloDetallEntCompra tobTempReg, string tcrCodigoR1)
        {
            bool llgReturn = false;
            try
            {
                using (_context = new DbAplicacion())
                {
                    llgReturn = true;
                    var lobEFReg = new EFinvmovcomprasmd();
                    //-----------------------
                    if (tobTempReg.Sis_estado_imaen == "M")
                    {
                        lobEFReg = _context.Invmovcomprasmd.FirstOrDefault(p => p.inv_secreg_incd == tobTempReg.Inv_secreg_incd);
                    }
                    if (tobTempReg.Sis_estado_imaen == "A" || tobTempReg.Sis_estado_imaen == "M") // Adicionar o Modificar
                    {
                        #region cargar Registro
                        if (lobEFReg != null)
                        {
                            lobEFReg.inv_secreg_incd = tobTempReg.Inv_secreg_incd;
                            lobEFReg.inv_secreg_inca = tobTempReg.Inv_secreg_inca;
                            lobEFReg.inv_codalm_inal = tobTempReg.Inv_codalm_inal;
                            lobEFReg.inv_tipreg_incx = tobTempReg.Inv_tipreg_incx;
                            lobEFReg.inv_conmov_incm = tobTempReg.Inv_conmov_incm;
                            lobEFReg.inv_secart_inar = tobTempReg.Inv_secart_inar;
                            lobEFReg.inv_codaux_inar = tobTempReg.Inv_codaux_inar;
                            lobEFReg.inv_lotref_inar = tobTempReg.Inv_lotref_inar;
                            lobEFReg.inv_regsan_inar = tobTempReg.Inv_regsan_inar;
                            lobEFReg.inv_fecven_incd = (DateTime)tobTempReg.Inv_fecven_incd;
                            lobEFReg.sis_codgme_sigr = tobTempReg.Sis_codgme_sigr;
                            lobEFReg.sis_codume_sium = tobTempReg.Sis_codume_sium;
                            lobEFReg.inv_codctn_intc = tobTempReg.Inv_codctn_intc;
                            lobEFReg.inv_totctn_incd = (int)tobTempReg.Inv_totctn_incd;
                            lobEFReg.inv_unictn_incd = (int)tobTempReg.Inv_unictn_incd;
                            lobEFReg.inv_unisue_incd = (int)tobTempReg.Inv_unisue_incd;
                            lobEFReg.inv_unitot_incd = (int)tobTempReg.Inv_unitot_incd;
                            lobEFReg.inv_unidev_incd = (int)tobTempReg.Inv_unidev_incd;
                            lobEFReg.inv_valing_inar = (float)tobTempReg.Inv_valing_inar;
                            lobEFReg.inv_brufac_incd = (float)tobTempReg.Inv_brufac_incd;
                            lobEFReg.inv_pordes_incd = (float)tobTempReg.Inv_pordes_incd;
                            lobEFReg.inv_valdes_incd = (float)tobTempReg.Inv_valdes_incd;
                            lobEFReg.inv_valiva_incd = (float)tobTempReg.Inv_valiva_incd;
                            lobEFReg.inv_porive_inar = (float)tobTempReg.Inv_porive_inar;
                            lobEFReg.inv_valred_inar = (float)tobTempReg.Inv_valred_inar;
                            lobEFReg.inv_valmov_inar = (float)tobTempReg.Inv_valmov_inar;
                            lobEFReg.inv_valfac_incd = (float)tobTempReg.Inv_valfac_incd;
                            lobEFReg.inv_codest_ines = tobTempReg.Inv_codest_ines;
                            lobEFReg.inv_seccio_ines = tobTempReg.Inv_seccio_ines;
                            lobEFReg.inv_estant_ines = tobTempReg.Inv_estant_ines;
                            lobEFReg.sys_codusu_usux = tobTempReg.Sys_codusu_usux;
                            lobEFReg.inv_fecedt_ines = (DateTime)tobTempReg.Inv_fecedt_ines;
                            lobEFReg.sis_estpro_espr = tobTempReg.Sis_estpro_espr;
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
                                lobEFReg.inv_secreg_incd = tcrCodigoR1 + lobEFReg.inv_secreg_incd; // concatenar
                                _context.AddToInvmovcomprasmd(lobEFReg);
                                _context.SaveChanges();
                                break;

                            case "M": // Modificar el registro
                                _context.SaveChanges();
                                break;

                            case "E": // Eliminar el registro
                                var lobjRegistro = _context.Invmovcomprasmd.FirstOrDefault(p => p.inv_secreg_incd == tobTempReg.Inv_secreg_incd);
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
        #region Buscar INVMOVCOMPRASMD: Logica
        /// <summary>
        /// <para>TABLA: invmovcomprasmd</para>
        /// <para>TITULO: Tabla detalle movimiento diarios por compra</para>
        /// <para>MODULO: INV</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Detalles de la tabla INVMOVCOMPRASMA, contiene todos los registros
        /// de articulos correpondentes a un movimiento de ingreso a inventarios
        /// </para>
        /// </summary>
        public static bool flgBuscarInvmovcomprasmd(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Invmovcomprasmd.FirstOrDefault(p => p.inv_secreg_incd == tcrCodigo);
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
        /// //Modelo Detalles Entrada de Compras: Lista de Registros
        /// </summary>
        /// <param name="tcrBuscar"></param>
        /// <returns></returns>
        public static List<ModeloDetallEntCompra> flsListaInvmovcomprasmd(string tcrBuscar)
        {
            using (_context = new DbAplicacion())
            {
                var lobConsulta = (from invmovcomprasmd in _context.Invmovcomprasmd
                                   join invalmacenmaest in _context.Invalmacenmaest on invmovcomprasmd.inv_codalm_inal equals invalmacenmaest.inv_codalm_inal into tminvalmacenmaest
                                   join invmaearticulos in _context.Invmaearticulos on invmovcomprasmd.inv_secart_inar equals invmaearticulos.inv_secart_inar into tminvmaearticulos
                                   join sisunidadmedida in _context.Sisunidadmedida on invmovcomprasmd.sis_codume_sium equals sisunidadmedida.sis_codume_sium into tmsisunidadmedida
                                   join invcontenedores in _context.Invcontenedores on invmovcomprasmd.inv_codctn_intc equals invcontenedores.inv_codctn_intc into tminvcontenedores
                                   from inal in tminvalmacenmaest.DefaultIfEmpty()
                                   from inar in tminvmaearticulos.DefaultIfEmpty()
                                   from sium in tmsisunidadmedida.DefaultIfEmpty()
                                   from intc in tminvcontenedores.DefaultIfEmpty()
                                   where invmovcomprasmd.inv_secreg_inca == tcrBuscar
                                   select new ModeloDetallEntCompra
                                   {
                                       Inv_secreg_incd = invmovcomprasmd.inv_secreg_incd,
                                       Inv_secreg_inca = invmovcomprasmd.inv_secreg_inca,
                                       Inv_codalm_inal = invmovcomprasmd.inv_codalm_inal,
                                       Inv_tipreg_incx = invmovcomprasmd.inv_tipreg_incx,
                                       Inv_conmov_incm = invmovcomprasmd.inv_conmov_incm,
                                       Inv_secart_inar = invmovcomprasmd.inv_secart_inar,
                                       Inv_codaux_inar = invmovcomprasmd.inv_codaux_inar,
                                       Inv_lotref_inar = invmovcomprasmd.inv_lotref_inar,
                                       Inv_regsan_inar = invmovcomprasmd.inv_regsan_inar,
                                       Inv_fecven_incd = (DateTime)invmovcomprasmd.inv_fecven_incd,
                                       Sis_codgme_sigr = invmovcomprasmd.sis_codgme_sigr,
                                       Sis_codume_sium = invmovcomprasmd.sis_codume_sium,
                                       Inv_codctn_intc = invmovcomprasmd.inv_codctn_intc,
                                       Inv_totctn_incd = (int)invmovcomprasmd.inv_totctn_incd,
                                       Inv_unictn_incd = (int)invmovcomprasmd.inv_unictn_incd,
                                       Inv_unisue_incd = (int)invmovcomprasmd.inv_unisue_incd,
                                       Inv_unitot_incd = (int)invmovcomprasmd.inv_unitot_incd,
                                       Inv_unidev_incd = (int)invmovcomprasmd.inv_unidev_incd,
                                       Inv_valing_inar = (float)invmovcomprasmd.inv_valing_inar,
                                       Inv_brufac_incd = (float)invmovcomprasmd.inv_brufac_incd,
                                       Inv_pordes_incd = (float)invmovcomprasmd.inv_pordes_incd,
                                       Inv_valdes_incd = (float)invmovcomprasmd.inv_valdes_incd,
                                       Inv_valiva_incd = (float)invmovcomprasmd.inv_valiva_incd,
                                       Inv_porive_inar = (float)invmovcomprasmd.inv_porive_inar,
                                       Inv_valred_inar = (float)invmovcomprasmd.inv_valred_inar,
                                       Inv_valmov_inar = (float)invmovcomprasmd.inv_valmov_inar,
                                       Inv_valfac_incd = (float)invmovcomprasmd.inv_valfac_incd,
                                       Inv_codest_ines = invmovcomprasmd.inv_codest_ines,
                                       Inv_seccio_ines = invmovcomprasmd.inv_seccio_ines,
                                       Inv_estant_ines = invmovcomprasmd.inv_estant_ines,
                                       Sys_codusu_usux = invmovcomprasmd.sys_codusu_usux,
                                       Inv_fecedt_ines = (DateTime)invmovcomprasmd.inv_fecedt_ines,
                                       Sis_estpro_espr = invmovcomprasmd.sis_estpro_espr,
                                       Inv_desalm_inal = inal.inv_desalm_inal,
                                       Inv_nomart_inar = inar.inv_nomart_inar,
                                       Sis_desume_sium = sium.sis_desume_sium,
                                       Inv_desctn_intc = intc.inv_desctn_intc,
                                       Inv_gesips_inar = inar.inv_gesips_inar,
                                       Fcm_idesec_sips = inar.fcm_idesec_sips,
                                       Far_codcum_famd = inar.far_codcum_famd,
                                       Sis_estado_imaen = "I",
                                       Inv_refips_inar = "2",
                                   }).ToList();
                // Complementar datos servico IPS
                foreach (var lobReg in lobConsulta)
                {
                    if (lobReg.Fcm_idesec_sips != "NA")
                    {
                        lobReg.Inv_gesips_inar = "2";
                        var tmp = FCMValidarCodigo.fobRegBuscarFcmmanservicips(lobReg.Fcm_idesec_sips);
                        if (tmp != null)
                        {
                            lobReg.Fcm_desser_sips = tmp.fcm_desser_sips;
                            lobReg.Fcm_coddig_mant = tmp.fcm_coddig_mant;
                            lobReg.Fcm_codser_sips = tmp.fcm_codser_sips;
                            lobReg.Inv_gesips_inar = "1"; // Se activa la referencia a servicios IPS
                        }
                    }
                }

                return lobConsulta;
            }
        }
        #endregion
        #region Temporal con datos agrupados por categorias de articulos
        /// <summary>
        /// //Modelo Detalles Entrada de Compras: Temporal con datos agrupados por categorias de articulos
        /// </summary>
        /// <param name="tcrBuscar"></param>
        /// <returns></returns>
        public static List<ModeloDetallEntCompra> flsListaInvmovcomprasmdRpt(string tcrCodigoRegistroMaestro)
        {
            using (_context = new DbAplicacion())
            {
                var lobConsulta = (from invmovcomprasmd in _context.Invmovcomprasmd
                                   join invalmacenmaest in _context.Invalmacenmaest on invmovcomprasmd.inv_codalm_inal equals invalmacenmaest.inv_codalm_inal into tminvalmacenmaest
                                   join invmaearticulos in _context.Invmaearticulos on invmovcomprasmd.inv_secart_inar equals invmaearticulos.inv_secart_inar into tminvmaearticulos
                                   join sisunidadmedida in _context.Sisunidadmedida on invmovcomprasmd.sis_codume_sium equals sisunidadmedida.sis_codume_sium into tmsisunidadmedida
                                   join invcontenedores in _context.Invcontenedores on invmovcomprasmd.inv_codctn_intc equals invcontenedores.inv_codctn_intc into tminvcontenedores
                                   from inar in tminvmaearticulos.DefaultIfEmpty()
                                   from inal in tminvalmacenmaest.DefaultIfEmpty()
                                   from sium in tmsisunidadmedida.DefaultIfEmpty()
                                   from intc in tminvcontenedores.DefaultIfEmpty()
                                   where invmovcomprasmd.inv_secreg_inca == tcrCodigoRegistroMaestro
                                   orderby inar.inv_codgru_ingr, invmovcomprasmd.inv_secart_inar
                                   select new ModeloDetallEntCompra
                                   {
                                       Inv_secreg_incd = invmovcomprasmd.inv_secreg_incd,
                                       Inv_secreg_inca = invmovcomprasmd.inv_secreg_inca,
                                       Inv_codalm_inal = invmovcomprasmd.inv_codalm_inal,
                                       Inv_tipreg_incx = invmovcomprasmd.inv_tipreg_incx,
                                       Inv_conmov_incm = invmovcomprasmd.inv_conmov_incm,
                                       Inv_secart_inar = invmovcomprasmd.inv_secart_inar,
                                       Inv_codaux_inar = invmovcomprasmd.inv_codaux_inar,
                                       Inv_lotref_inar = invmovcomprasmd.inv_lotref_inar,
                                       Inv_regsan_inar = invmovcomprasmd.inv_regsan_inar,
                                       Inv_fecven_incd = (DateTime)invmovcomprasmd.inv_fecven_incd,
                                       Sis_codgme_sigr = invmovcomprasmd.sis_codgme_sigr,
                                       Sis_codume_sium = invmovcomprasmd.sis_codume_sium,
                                       Inv_codctn_intc = invmovcomprasmd.inv_codctn_intc,
                                       Inv_totctn_incd = (int)invmovcomprasmd.inv_totctn_incd,
                                       Inv_unictn_incd = (int)invmovcomprasmd.inv_unictn_incd,
                                       Inv_unisue_incd = (int)invmovcomprasmd.inv_unisue_incd,
                                       Inv_unitot_incd = (int)invmovcomprasmd.inv_unitot_incd,
                                       Inv_unidev_incd = (int)invmovcomprasmd.inv_unidev_incd,
                                       Inv_valing_inar = (float)invmovcomprasmd.inv_valing_inar,
                                       Inv_brufac_incd = (float)invmovcomprasmd.inv_brufac_incd,
                                       Inv_pordes_incd = (float)invmovcomprasmd.inv_pordes_incd,
                                       Inv_valdes_incd = (float)invmovcomprasmd.inv_valdes_incd,
                                       Inv_valiva_incd = (float)invmovcomprasmd.inv_valiva_incd,
                                       Inv_porive_inar = (float)invmovcomprasmd.inv_porive_inar,
                                       Inv_valred_inar = (float)invmovcomprasmd.inv_valred_inar,
                                       Inv_valmov_inar = (float)invmovcomprasmd.inv_valmov_inar,
                                       Inv_valfac_incd = (float)invmovcomprasmd.inv_valfac_incd,
                                       Inv_codest_ines = invmovcomprasmd.inv_codest_ines,
                                       Inv_seccio_ines = invmovcomprasmd.inv_seccio_ines,
                                       Inv_estant_ines = invmovcomprasmd.inv_estant_ines,
                                       Sys_codusu_usux = invmovcomprasmd.sys_codusu_usux,
                                       Inv_fecedt_ines = (DateTime)invmovcomprasmd.inv_fecedt_ines,
                                       Sis_estpro_espr = invmovcomprasmd.sis_estpro_espr,
                                       Inv_desalm_inal = inal.inv_desalm_inal,
                                       Inv_nomart_inar = inar.inv_nomart_inar,
                                       Sis_desume_sium = sium.sis_desume_sium,
                                       Inv_desctn_intc = intc.inv_desctn_intc,
                                       Inv_gesips_inar = inar.inv_gesips_inar,
                                       Fcm_idesec_sips = inar.fcm_idesec_sips,
                                       Far_codcum_famd = inar.far_codcum_famd,
                                       Inv_codgru_ingr = inar.inv_codgru_ingr,
                                       Inv_desgru_ingr = _context.Invinventgrupos.FirstOrDefault(x => x.inv_codgru_ingr == inar.inv_codgru_ingr).inv_desgru_ingr,
                                       Sis_estado_imaen = "I",
                                       Inv_refips_inar = "2",
                                   }).ToList();
                // Complementar datos servico IPS
                foreach (var lobReg in lobConsulta)
                {
                    if (lobReg.Fcm_idesec_sips != "NA")
                    {
                        lobReg.Inv_gesips_inar = "2";
                        var tmp = FCMValidarCodigo.fobRegBuscarFcmmanservicips(lobReg.Fcm_idesec_sips);
                        if (tmp != null)
                        {
                            lobReg.Fcm_desser_sips = tmp.fcm_desser_sips;
                            lobReg.Fcm_coddig_mant = tmp.fcm_coddig_mant;
                            lobReg.Fcm_codser_sips = tmp.fcm_codser_sips;
                            lobReg.Inv_gesips_inar = "1"; // Se activa la referencia a servicios IPS
                        }
                    }
                }

                return lobConsulta;
            }
        }
        #endregion
        #region Temporal con datos agrupados por Estantes
        public static List<ModeloDetallEntCompra> flsListaInvmovcomprasmdRptAlm(string tcrCodigoRegistroMaestro)
        {
            using (_context = new DbAplicacion())
            {
                var lobConsulta = (from invmovcomprasmd in _context.Invmovcomprasmd
                                   join invalmacenmaest in _context.Invalmacenmaest on invmovcomprasmd.inv_codalm_inal equals invalmacenmaest.inv_codalm_inal into tminvalmacenmaest
                                   join invmaearticulos in _context.Invmaearticulos on invmovcomprasmd.inv_secart_inar equals invmaearticulos.inv_secart_inar into tminvmaearticulos
                                   from inar in tminvmaearticulos.DefaultIfEmpty()
                                   from inal in tminvalmacenmaest.DefaultIfEmpty()
                                   where invmovcomprasmd.inv_secreg_inca == tcrCodigoRegistroMaestro
                                   orderby inar.inv_codgru_ingr, invmovcomprasmd.inv_secart_inar
                                   select new ModeloDetallEntCompra
                                   {
                                       #region Datos
                                       Inv_secreg_incd = invmovcomprasmd.inv_secreg_incd,
                                       Inv_secreg_inca = invmovcomprasmd.inv_secreg_inca,
                                       Inv_codalm_inal = invmovcomprasmd.inv_codalm_inal,
                                       Inv_tipreg_incx = invmovcomprasmd.inv_tipreg_incx,
                                       Inv_conmov_incm = invmovcomprasmd.inv_conmov_incm,
                                       Inv_secart_inar = invmovcomprasmd.inv_secart_inar,
                                       Inv_codaux_inar = invmovcomprasmd.inv_codaux_inar,
                                       Inv_lotref_inar = invmovcomprasmd.inv_lotref_inar,
                                       Inv_regsan_inar = invmovcomprasmd.inv_regsan_inar,
                                       Inv_fecven_incd = (DateTime)invmovcomprasmd.inv_fecven_incd,
                                       Sis_codgme_sigr = invmovcomprasmd.sis_codgme_sigr,
                                       Sis_codume_sium = invmovcomprasmd.sis_codume_sium,
                                       Inv_codctn_intc = invmovcomprasmd.inv_codctn_intc,
                                       Inv_totctn_incd = (int)invmovcomprasmd.inv_totctn_incd,
                                       Inv_unictn_incd = (int)invmovcomprasmd.inv_unictn_incd,
                                       Inv_unisue_incd = (int)invmovcomprasmd.inv_unisue_incd,
                                       Inv_unitot_incd = (int)invmovcomprasmd.inv_unitot_incd,
                                       Inv_unidev_incd = (int)invmovcomprasmd.inv_unidev_incd,
                                       Inv_valing_inar = (float)invmovcomprasmd.inv_valing_inar,
                                       Inv_brufac_incd = (float)invmovcomprasmd.inv_brufac_incd,
                                       Inv_pordes_incd = (float)invmovcomprasmd.inv_pordes_incd,
                                       Inv_valdes_incd = (float)invmovcomprasmd.inv_valdes_incd,
                                       Inv_valiva_incd = (float)invmovcomprasmd.inv_valiva_incd,
                                       Inv_porive_inar = (float)invmovcomprasmd.inv_porive_inar,
                                       Inv_valred_inar = (float)invmovcomprasmd.inv_valred_inar,
                                       Inv_valmov_inar = (float)invmovcomprasmd.inv_valmov_inar,
                                       Inv_valfac_incd = (float)invmovcomprasmd.inv_valfac_incd,
                                       Inv_codest_ines = invmovcomprasmd.inv_codest_ines,
                                       Inv_seccio_ines = invmovcomprasmd.inv_seccio_ines,
                                       Inv_estant_ines = invmovcomprasmd.inv_estant_ines,
                                       Sys_codusu_usux = invmovcomprasmd.sys_codusu_usux,
                                       Inv_fecedt_ines = (DateTime)invmovcomprasmd.inv_fecedt_ines,
                                       Sis_estpro_espr = invmovcomprasmd.sis_estpro_espr,
                                       Inv_desalm_inal = inal.inv_desalm_inal,
                                       Inv_nomart_inar = inar.inv_nomart_inar,
                                       Inv_gesips_inar = inar.inv_gesips_inar,
                                       Fcm_idesec_sips = inar.fcm_idesec_sips,
                                       Far_codcum_famd = inar.far_codcum_famd,
                                       Inv_codgru_ingr = inar.inv_codgru_ingr,
                                       Inv_desgru_ingr = _context.Invinventgrupos.FirstOrDefault(x => x.inv_codgru_ingr == inar.inv_codgru_ingr).inv_desgru_ingr,
                                       Sis_estado_imaen = "I",
                                       Inv_refips_inar = "2",
                                   }).ToList();
                                       #endregion

                return lobConsulta;
            }
        }
        #endregion
        #endregion
    }
    #endregion
    #region Modelo Maestro Suministro Interno
    /// <summary>
    /// Descripcion para la Vista de  la tabla: invmovdiariosma
    /// </summary>
    public class ModeloInvMovSuministro : clBaseInpc
    {
        #region Modelo Attributos
        private static DbAplicacion _context;
        #region Modelo Propiedades Notificacion
        #region Inv_secreg_inma: Secuencial reg. Maestro
        private String _inv_secreg_inma;
        /// <summary>
        /// <para>TABLA: invmovdiariosma</para>
        /// <para>TABLA NATIVA: invmovdiariosma</para>
        /// <para>CAMPO: Secuencial reg. Maestro</para>
        /// <para>NOMBRE: inv_secreg_inma (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        ///Secuencial  unico registro maestro movimiento inventario
        /// </para>
        /// </summary>
        public String Inv_secreg_inma
        {
            get { return _inv_secreg_inma; }
            set
            {
                if (_inv_secreg_inma == value) return;
                _inv_secreg_inma = value;
                OnPropertyChanged("Inv_secreg_inma");
            }
        }
        #endregion
        #region Inv_tipmov_intr: Tipo Movimiento
        private String _inv_tipmov_intr;
        /// <summary>
        /// <para>TABLA: invmovdiariosma</para>
        /// <para>TABLA NATIVA: invtiporegimovi</para>
        /// <para>CAMPO: Tipo Movimiento</para>
        /// <para>NOMBRE: inv_tipmov_intr (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Tipo Registro maestro: 1=Registro de Entrada 2=Registro de
        /// Salida
        /// </para>
        /// </summary>
        public String Inv_tipmov_intr
        {
            get { return _inv_tipmov_intr; }
            set
            {
                if (_inv_tipmov_intr == value) return;
                _inv_tipmov_intr = value;
                OnPropertyChanged("Inv_tipmov_intr");
            }
        }
        #endregion
        #region Inv_conmov_incm: Concepto movimiento
        private String _inv_conmov_incm;
        /// <summary>
        /// <para>TABLA: invmovdiariosma</para>
        /// <para>TABLA NATIVA: invtipoconcemov</para>
        /// <para>CAMPO: Concepto movimiento</para>
        /// <para>NOMBRE: inv_conmov_incm (char:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        /// Concepto movimiento diario: E11 =Entrada saldo inicial inventario
        /// o del mes E12= Entradas compras ...  S21= Salidas Ventas 22=
        /// Salidas Traslado S23= Salidas Otras Áreas Empresa S24= Salida
        /// entrega formula A30=Ajuste de inventarios y otros
        /// </para>
        /// </summary>
        public String Inv_conmov_incm
        {
            get { return _inv_conmov_incm; }
            set
            {
                if (_inv_conmov_incm == value) return;
                _inv_conmov_incm = value;
                OnPropertyChanged("Inv_conmov_incm");
            }
        }
        #endregion
        #region Inv_desreg_inma: Descripción registro
        private String _inv_desreg_inma;
        /// <summary>
        /// <para>TABLA: invmovdiariosma</para>
        /// <para>TABLA NATIVA: invmovdiariosma</para>
        /// <para>CAMPO: Descripción registro</para>
        /// <para>NOMBRE: inv_desreg_inma (char:200)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        ///Descripción textual o detalle de la transaccion
        /// </para>
        /// </summary>
        public String Inv_desreg_inma
        {
            get { return _inv_desreg_inma; }
            set
            {
                if (_inv_desreg_inma == value) return;
                _inv_desreg_inma = value;
                OnPropertyChanged("Inv_desreg_inma");
            }
        }
        #endregion
        #region Inv_fecges_inma: Fecha gestion
        private DateTime _inv_fecges_inma;
        /// <summary>
        /// <para>TABLA: invmovdiariosma</para>
        /// <para>TABLA NATIVA: invmovdiariosma</para>
        /// <para>CAMPO: Fecha gestion</para>
        /// <para>NOMBRE: inv_fecges_inma (fecha:)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        ///Fecha del registro diario o comprobante del movimiento
        /// </para>
        /// </summary>
        public DateTime Inv_fecges_inma
        {
            get { return _inv_fecges_inma; }
            set
            {
                if (_inv_fecges_inma == value) return;
                _inv_fecges_inma = value;
                OnPropertyChanged("Inv_fecges_inma");
            }
        }
        #endregion
        #region Inv_secref_inma: Refe reg. Maestro
        private String _inv_secref_inma;
        /// <summary>
        /// <para>TABLA: invmovdiariosma</para>
        /// <para>TABLA NATIVA: invmovdiariosma</para>
        /// <para>CAMPO: Refe reg. Maestro</para>
        /// <para>NOMBRE: inv_secref_inma (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        /// Id que referencia INV_SECREG_INMA creado como registro salida
        /// por traslado/devoluciones y otros casos  (para referencia de
        /// la contraparte)
        /// </para>
        /// </summary>
        public String Inv_secref_inma
        {
            get { return _inv_secref_inma; }
            set
            {
                if (_inv_secref_inma == value) return;
                _inv_secref_inma = value;
                OnPropertyChanged("Inv_secref_inma");
            }
        }
        #endregion
        #region Inv_codalm_inal: Código Almacén
        private String _inv_codalm_inal;
        /// <summary>
        /// <para>TABLA: invmovdiariosma</para>
        /// <para>TABLA NATIVA: invalmacenmaest</para>
        /// <para>CAMPO: Código Almacén</para>
        /// <para>NOMBRE: inv_codalm_inal (char:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        /// Código del Almacén desde el maestro almacen, que inicia la
        /// transaccion
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
        #region Deinv_codald_inal: Descripción Almacén
        private String _deinv_codald_inal;
        /// <summary>
        /// <para>TABLA: invalmacenmaest</para>
        /// <para>TABLA NATIVA: invalmacenmaest</para>
        /// <para>CAMPO: Descripción Almacén</para>
        /// <para>NOMBRE: deinv_codald_inal (char:)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        ///Relacion 'RB' - inv_codald_inal: Descripción del almacén
        /// </para>
        /// </summary>
        public String Deinv_codald_inal
        {
            get { return _deinv_codald_inal; }
            set
            {
                if (_deinv_codald_inal == value) return;
                _deinv_codald_inal = value;
                OnPropertyChanged("Deinv_codald_inal");
            }
        }
        #endregion
        #region Inv_codald_inal: Código Almacén Destino
        private String _inv_codald_inal;
        /// <summary>
        /// <para>TABLA: invmovdiariosma</para>
        /// <para>TABLA NATIVA: invalmacenmaest</para>
        /// <para>CAMPO: Código Almacén Destino</para>
        /// <para>NOMBRE: inv_codald_inal (char:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        /// Código del Almacén Destino (para Traslados) desde maestro almacen
        /// </para>
        /// </summary>
        public String Inv_codald_inal
        {
            get { return _inv_codald_inal; }
            set
            {
                if (_inv_codald_inal == value) return;
                _inv_codald_inal = value;
                OnPropertyChanged("Inv_codald_inal");
            }
        }
        #endregion
        #region Con_codsco_ccos: Código centro de costo
        private String _con_codsco_ccos;
        /// <summary>
        /// <para>TABLA: invmovdiariosma</para>
        /// <para>TABLA NATIVA: concentrodcosto</para>
        /// <para>CAMPO: Código centro de costo</para>
        /// <para>NOMBRE: con_codsco_ccos (char:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION:
        ///Código del centro de costo para gestion contable
        /// </para>
        /// </summary>
        public String Con_codsco_ccos
        {
            get { return _con_codsco_ccos; }
            set
            {
                if (_con_codsco_ccos == value) return;
                _con_codsco_ccos = value;
                OnPropertyChanged("Con_codsco_ccos");
            }
        }
        #endregion
        #region Inv_fecdoc_inma: Fecha registro referencia
        private DateTime _inv_fecdoc_inma;
        /// <summary>
        /// <para>TABLA: invmovdiariosma</para>
        /// <para>TABLA NATIVA: invmovdiariosma</para>
        /// <para>CAMPO: Fecha registro referencia</para>
        /// <para>NOMBRE: inv_fecdoc_inma (fecha:)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
        /// <para>DESCRIPCION:
        /// Fecha del documento traslado o entrega suministro, formula
        /// medica etc.)
        /// </para>
        /// </summary>
        public DateTime Inv_fecdoc_inma
        {
            get { return _inv_fecdoc_inma; }
            set
            {
                if (_inv_fecdoc_inma == value) return;
                _inv_fecdoc_inma = value;
                OnPropertyChanged("Inv_fecdoc_inma");
            }
        }
        #endregion
        #region Inv_codres_inre: Código responsable
        private String _inv_codres_inre;
        /// <summary>
        /// <para>TABLA: invmovdiariosma</para>
        /// <para>TABLA NATIVA: invresponsables</para>
        /// <para>CAMPO: Código responsable</para>
        /// <para>NOMBRE: inv_codres_inre (char:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 11</para>
        /// <para>DESCRIPCION:
        /// Código de la persona responsable o que solicita  pedido para
        /// gasto interno de la empresa, viene de la tabla: INVRESPONSABLES
        /// </para>
        /// </summary>
        public String Inv_codres_inre
        {
            get { return _inv_codres_inre; }
            set
            {
                if (_inv_codres_inre == value) return;
                _inv_codres_inre = value;
                OnPropertyChanged("Inv_codres_inre");
            }
        }
        #endregion
        #region Sis_coddep_sidp: Codigo dependencia
        private String _sis_coddep_sidp;
        /// <summary>
        /// <para>TABLA: invmovdiariosma</para>
        /// <para>TABLA NATIVA: sismaesdependen</para>
        /// <para>CAMPO: Codigo dependencia</para>
        /// <para>NOMBRE: sis_coddep_sidp (char:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 12</para>
        /// <para>DESCRIPCION:
        ///Codigo dependencia o departamento de la empresa
        /// </para>
        /// </summary>
        public String Sis_coddep_sidp
        {
            get { return _sis_coddep_sidp; }
            set
            {
                if (_sis_coddep_sidp == value) return;
                _sis_coddep_sidp = value;
                OnPropertyChanged("Sis_coddep_sidp");
            }
        }
        #endregion
        #region Sia_codare_aser: Código area servicios
        private String _sia_codare_aser;
        /// <summary>
        /// <para>TABLA: invmovdiariosma</para>
        /// <para>TABLA NATIVA: siaareapreservi</para>
        /// <para>CAMPO: Código area servicios</para>
        /// <para>NOMBRE: sia_codare_aser (char:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 12</para>
        /// <para>DESCRIPCION:
        /// Código área servicio para gastos medicamentos intrahospitalarios
        /// o entrega formulas, tambien cuando se entregan pedidos para
        /// gasto inerno de la empresa
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
        #region Inv_brufac_inmd: Valor Bruto
        private float _inv_brufac_inmd;
        /// <summary>
        /// <para>TABLA: invmovdiariosma</para>
        /// <para>TABLA NATIVA: invmovdiariosmd</para>
        /// <para>CAMPO: Valor Bruto</para>
        /// <para>NOMBRE: inv_brufac_inmd (float:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 14</para>
        /// <para>DESCRIPCION:
        /// Sumatoria Valor Bruto Facturado sin ninguna deduccion (desde
        /// la tabla detalles movimiento diario)
        /// </para>
        /// </summary>
        public float Inv_brufac_inmd
        {
            get { return _inv_brufac_inmd; }
            set
            {
                if (_inv_brufac_inmd == value) return;
                _inv_brufac_inmd = value;
                OnPropertyChanged("Inv_brufac_inmd");
            }
        }
        #endregion
        #region Inv_pordes_inmd: Porcentaje Descuento
        private float _inv_pordes_inmd;
        /// <summary>
        /// <para>TABLA: invmovdiariosma</para>
        /// <para>TABLA NATIVA: invmovdiariosmd</para>
        /// <para>CAMPO: Porcentaje Descuento</para>
        /// <para>NOMBRE: inv_pordes_inmd (float:52)</para>
        /// <para>ORDEN VISTA EN TABLA: 15</para>
        /// <para>DESCRIPCION:
        /// Porcentaje Descuento (desde la tabla detalles movimiento diario)
        /// </para>
        /// </summary>
        public float Inv_pordes_inmd
        {
            get { return _inv_pordes_inmd; }
            set
            {
                if (_inv_pordes_inmd == value) return;
                _inv_pordes_inmd = value;
                OnPropertyChanged("Inv_pordes_inmd");
            }
        }
        #endregion
        #region Inv_valiva_inmd: Valor IVA
        private float _inv_valiva_inmd;
        /// <summary>
        /// <para>TABLA: invmovdiariosma</para>
        /// <para>TABLA NATIVA: invmovdiariosmd</para>
        /// <para>CAMPO: Valor IVA</para>
        /// <para>NOMBRE: inv_valiva_inmd (float:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 16</para>
        /// <para>DESCRIPCION:
        ///Sumatoria Valor total del IVA descontado en la transaccion
        /// </para>
        /// </summary>
        public float Inv_valiva_inmd
        {
            get { return _inv_valiva_inmd; }
            set
            {
                if (_inv_valiva_inmd == value) return;
                _inv_valiva_inmd = value;
                OnPropertyChanged("Inv_valiva_inmd");
            }
        }
        #endregion
        #region Inv_valing_inar: Valor Ingreso
        private float _inv_valing_inar;
        /// <summary>
        /// <para>TABLA: invmovdiariosma</para>
        /// <para>TABLA NATIVA: invmaearticulos</para>
        /// <para>CAMPO: Valor Ingreso</para>
        /// <para>NOMBRE: inv_valing_inar (float:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 17</para>
        /// <para>DESCRIPCION:
        /// Sumatoria Total del Valor Ingreso de articulos en inventario
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
        #region Inv_valmov_inar: Valor salida
        private float _inv_valmov_inar;
        /// <summary>
        /// <para>TABLA: invmovdiariosma</para>
        /// <para>TABLA NATIVA: invmaearticulos</para>
        /// <para>CAMPO: Valor salida</para>
        /// <para>NOMBRE: inv_valmov_inar (float:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 18</para>
        /// <para>DESCRIPCION:
        /// Sumatoria total valor Movimiento de salida entrega medicamentos
        /// intrahospitalario o formula medica
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
        #region Inv_valfac_inmd: Valor total facturado
        private float _inv_valfac_inmd;
        /// <summary>
        /// <para>TABLA: invmovdiariosma</para>
        /// <para>TABLA NATIVA: invmovdiariosmd</para>
        /// <para>CAMPO: Valor total facturado</para>
        /// <para>NOMBRE: inv_valfac_inmd (float:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 19</para>
        /// <para>DESCRIPCION:
        ///Sumatoria valor total con deducciones de la factura
        /// </para>
        /// </summary>
        public float Inv_valfac_inmd
        {
            get { return _inv_valfac_inmd; }
            set
            {
                if (_inv_valfac_inmd == value) return;
                _inv_valfac_inmd = value;
                OnPropertyChanged("Inv_valfac_inmd");
            }
        }
        #endregion
        #region Inv_fecanu_inma: Fecha Anulación
        private DateTime _inv_fecanu_inma;
        /// <summary>
        /// <para>TABLA: invmovdiariosma</para>
        /// <para>TABLA NATIVA: invmovdiariosma</para>
        /// <para>CAMPO: Fecha Anulación</para>
        /// <para>NOMBRE: inv_fecanu_inma (fecha:)</para>
        /// <para>ORDEN VISTA EN TABLA: 20</para>
        /// <para>DESCRIPCION:
        ///Fecha anulacion del registro de movimiento
        /// </para>
        /// </summary>
        public DateTime Inv_fecanu_inma
        {
            get { return _inv_fecanu_inma; }
            set
            {
                if (_inv_fecanu_inma == value) return;
                _inv_fecanu_inma = value;
                OnPropertyChanged("Inv_fecanu_inma");
            }
        }
        #endregion
        #region Sys_codusu_usux: Código Usuario
        private String _sys_codusu_usux;
        /// <summary>
        /// <para>TABLA: invmovdiariosma</para>
        /// <para>TABLA NATIVA: sysusuarios</para>
        /// <para>CAMPO: Código Usuario</para>
        /// <para>NOMBRE: sys_codusu_usux (char:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 21</para>
        /// <para>DESCRIPCION:
        ///Código del usuario que realiza proceso
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
        #region Inv_conreg_inma: Contador items
        private int _inv_conreg_inma;
        /// <summary>
        /// <para>TABLA: invmovdiariosma</para>
        /// <para>TABLA NATIVA: invmovdiariosma</para>
        /// <para>CAMPO: Contador items</para>
        /// <para>NOMBRE: inv_conreg_inma (int:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 22</para>
        /// <para>DESCRIPCION:
        /// Contador para generar el secuencial unico de registros en detalle
        /// </para>
        /// </summary>
        public int Inv_conreg_inma
        {
            get { return _inv_conreg_inma; }
            set
            {
                if (_inv_conreg_inma == value) return;
                _inv_conreg_inma = value;
                OnPropertyChanged("Inv_conreg_inma");
            }
        }
        #endregion
        #region Sis_estpro_espr: Estado Registro
        private String _sis_estpro_espr;
        /// <summary>
        /// <para>TABLA: invmovdiariosma</para>
        /// <para>TABLA NATIVA: sisestadoproces</para>
        /// <para>CAMPO: Estado Registro</para>
        /// <para>NOMBRE: sis_estpro_espr (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 23</para>
        /// <para>DESCRIPCION:
        ///Estado del registro: 1=Abierto 2=Confirmado 3=Anulado
        /// </para>
        /// </summary>
        public String Sis_estpro_espr
        {
            get { return _sis_estpro_espr; }
            set
            {
                if (_sis_estpro_espr == value) return;
                _sis_estpro_espr = value;
                OnPropertyChanged("Sis_estpro_espr");
            }
        }
        #endregion
        #region Inv_desreg_intr: Descripción tipo movimiento
        private String _inv_desreg_intr;
        /// <summary>
        /// <para>TABLA: invmovdiariosma</para>
        /// <para>TABLA NATIVA: invtiporegimovi</para>
        /// <para>CAMPO: Descripción tipo movimiento</para>
        /// <para>NOMBRE: inv_desreg_intr (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripción tipo registro
        /// </para>
        /// </summary>
        public String Inv_desreg_intr
        {
            get { return _inv_desreg_intr; }
            set
            {
                if (_inv_desreg_intr == value) return;
                _inv_desreg_intr = value;
                OnPropertyChanged("Inv_desreg_intr");
            }
        }
        #endregion
        #region Inv_descon_incm: Descripción concepto
        private String _inv_descon_incm;
        /// <summary>
        /// <para>TABLA: invmovdiariosma</para>
        /// <para>TABLA NATIVA: invtipoconcemov</para>
        /// <para>CAMPO: Descripción concepto</para>
        /// <para>NOMBRE: inv_descon_incm (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        ///Descripción concepto movimiento diario
        /// </para>
        /// </summary>
        public String Inv_descon_incm
        {
            get { return _inv_descon_incm; }
            set
            {
                if (_inv_descon_incm == value) return;
                _inv_descon_incm = value;
                OnPropertyChanged("Inv_descon_incm");
            }
        }
        #endregion
        #region Inv_desalm_inal: Descripción Almacén
        private String _inv_desalm_inal;
        /// <summary>
        /// <para>TABLA: invmovdiariosma</para>
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
        #region Con_dessco_ccos: Nombre centro de costo
        private String _con_dessco_ccos;
        /// <summary>
        /// <para>TABLA: invmovdiariosma</para>
        /// <para>TABLA NATIVA: concentrodcosto</para>
        /// <para>CAMPO: Nombre centro de costo</para>
        /// <para>NOMBRE: con_dessco_ccos (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Nombre o descripción del centro de costo
        /// </para>
        /// </summary>
        public String Con_dessco_ccos
        {
            get { return _con_dessco_ccos; }
            set
            {
                if (_con_dessco_ccos == value) return;
                _con_dessco_ccos = value;
                OnPropertyChanged("Con_dessco_ccos");
            }
        }
        #endregion
        #region Inv_nomres_inre: Persona responsable
        private String _inv_nomres_inre;
        /// <summary>
        /// <para>TABLA: invmovdiariosma</para>
        /// <para>TABLA NATIVA: invresponsables</para>
        /// <para>CAMPO: Persona responsable</para>
        /// <para>NOMBRE: inv_nomres_inre (char:50)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        ///Descripción del contenedor de Artículo o presentación
        /// </para>
        /// </summary>
        public String Inv_nomres_inre
        {
            get { return _inv_nomres_inre; }
            set
            {
                if (_inv_nomres_inre == value) return;
                _inv_nomres_inre = value;
                OnPropertyChanged("Inv_nomres_inre");
            }
        }
        #endregion
        #region Sis_nomdep_sidp: Nombre dependencia
        private String _sis_nomdep_sidp;
        /// <summary>
        /// <para>TABLA: invmovdiariosma</para>
        /// <para>TABLA NATIVA: sismaesdependen</para>
        /// <para>CAMPO: Nombre dependencia</para>
        /// <para>NOMBRE: sis_nomdep_sidp (char:50)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Nombre o descripcion de la dependencia
        /// </para>
        /// </summary>
        public String Sis_nomdep_sidp
        {
            get { return _sis_nomdep_sidp; }
            set
            {
                if (_sis_nomdep_sidp == value) return;
                _sis_nomdep_sidp = value;
                OnPropertyChanged("Sis_nomdep_sidp");
            }
        }
        #endregion
        #region Sia_desare_aser: Nombre área de servicios
        private String _sia_desare_aser;
        /// <summary>
        /// <para>TABLA: invmovdiariosma</para>
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
        #region Sis_despro_espr: Decripción estado proceso
        private String _sis_despro_espr;
        /// <summary>
        /// <para>TABLA: invmovdiariosma</para>
        /// <para>TABLA NATIVA: sisestadoproces</para>
        /// <para>CAMPO: Decripción estado proceso</para>
        /// <para>NOMBRE: sis_despro_espr (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Descripcion textual del estado de proceso Abierto(a), Cerrado(a)
        /// Y Anulado(a)
        /// </para>
        /// </summary>
        public String Sis_despro_espr
        {
            get { return _sis_despro_espr; }
            set
            {
                if (_sis_despro_espr == value) return;
                _sis_despro_espr = value;
                OnPropertyChanged("Sis_despro_espr");
            }
        }
        #endregion
        #endregion
        #endregion
        #region Metodos para edicion de registros
        #region Adicionar Registro
        public static String flgAddRegistro(ModeloInvMovSuministro tobjModelo)
        {
            var lcrCodigoGen = SysModelo.fcrGenerarNuevoCodigo("INV-SUMI-TRASLA-OT-AREAS", "INV", "Suministro a otras areas");
            //try
            //{
            if (!flgBuscarInvmovdiariosma(lcrCodigoGen))
            {
                using (_context = new DbAplicacion())
                {
                    var lobjRegistro = new EFinvmovdiariosma
                    {
                        #region cargar Registro
                        inv_secreg_inma = tobjModelo.Inv_secreg_inma,
                        inv_tipmov_intr = tobjModelo.Inv_tipmov_intr,
                        inv_conmov_incm = tobjModelo.Inv_conmov_incm,
                        inv_desreg_inma = tobjModelo.Inv_desreg_inma,
                        inv_fecges_inma = tobjModelo.Inv_fecges_inma,
                        inv_secref_inma = tobjModelo.Inv_secref_inma,
                        inv_codalm_inal = tobjModelo.Inv_codalm_inal,
                        inv_codald_inal = tobjModelo.Inv_codald_inal,
                        con_codsco_ccos = tobjModelo.Con_codsco_ccos,
                        inv_fecdoc_inma = tobjModelo.Inv_fecdoc_inma,
                        inv_codres_inre = tobjModelo.Inv_codres_inre,
                        sis_coddep_sidp = tobjModelo.Sis_coddep_sidp,
                        sia_codare_aser = tobjModelo.Sia_codare_aser,
                        inv_brufac_inmd = tobjModelo.Inv_brufac_inmd,
                        inv_pordes_inmd = tobjModelo.Inv_pordes_inmd,
                        inv_valiva_inmd = tobjModelo.Inv_valiva_inmd,
                        inv_valing_inar = tobjModelo.Inv_valing_inar,
                        inv_valmov_inar = tobjModelo.Inv_valmov_inar,
                        inv_valfac_inmd = tobjModelo.Inv_valfac_inmd,
                        inv_fecanu_inma = tobjModelo.Inv_fecanu_inma,
                        sys_codusu_usux = tobjModelo.Sys_codusu_usux,
                        inv_conreg_inma = tobjModelo.Inv_conreg_inma,
                        sis_estpro_espr = tobjModelo.Sis_estpro_espr,
                        #endregion
                    };
                    lobjRegistro.inv_secreg_inma = lcrCodigoGen;
                    _context.AddToInvmovdiariosma(lobjRegistro);
                    _context.SaveChanges();
                }
            }
            else
            {
                lcrCodigoGen = String.Empty;
                MessageBox.Show("Nuevo codigo Generado esta desactualizado, revisar llave: \n" +
                            "'INV-SUMI-TRASLA-OT-AREAS': Suministro a otras areas en Maestro Secuenciales.");
            }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Modelo Error Metodo: flgAddRegistro");
            //}
            return lcrCodigoGen;
        }
        #endregion
        #region Modificar Registro
        public static void fcvActualizar(ModeloInvMovSuministro tobjModelo)
        {
            try
            {
                using (_context = new DbAplicacion())
                {
                    var lobjRegistro = _context.Invmovdiariosma.FirstOrDefault(p => p.inv_secreg_inma == tobjModelo.Inv_secreg_inma);
                    if (lobjRegistro != null)
                    {
                        #region cargar Registro
                        lobjRegistro.inv_secreg_inma = tobjModelo.Inv_secreg_inma;
                        lobjRegistro.inv_tipmov_intr = tobjModelo.Inv_tipmov_intr;
                        lobjRegistro.inv_conmov_incm = tobjModelo.Inv_conmov_incm;
                        lobjRegistro.inv_desreg_inma = tobjModelo.Inv_desreg_inma;
                        lobjRegistro.inv_fecges_inma = (DateTime)tobjModelo.Inv_fecges_inma;
                        lobjRegistro.inv_secref_inma = tobjModelo.Inv_secref_inma;
                        lobjRegistro.inv_codalm_inal = tobjModelo.Inv_codalm_inal;
                        lobjRegistro.inv_codald_inal = tobjModelo.Inv_codald_inal;
                        lobjRegistro.con_codsco_ccos = tobjModelo.Con_codsco_ccos;
                        lobjRegistro.inv_fecdoc_inma = (DateTime)tobjModelo.Inv_fecdoc_inma;
                        lobjRegistro.inv_codres_inre = tobjModelo.Inv_codres_inre;
                        lobjRegistro.sis_coddep_sidp = tobjModelo.Sis_coddep_sidp;
                        lobjRegistro.sia_codare_aser = tobjModelo.Sia_codare_aser;
                        lobjRegistro.inv_brufac_inmd = (float)tobjModelo.Inv_brufac_inmd;
                        lobjRegistro.inv_pordes_inmd = (float)tobjModelo.Inv_pordes_inmd;
                        lobjRegistro.inv_valiva_inmd = (float)tobjModelo.Inv_valiva_inmd;
                        lobjRegistro.inv_valing_inar = (float)tobjModelo.Inv_valing_inar;
                        lobjRegistro.inv_valmov_inar = (float)tobjModelo.Inv_valmov_inar;
                        lobjRegistro.inv_valfac_inmd = (float)tobjModelo.Inv_valfac_inmd;
                        lobjRegistro.inv_fecanu_inma = (DateTime)tobjModelo.Inv_fecanu_inma;
                        lobjRegistro.sys_codusu_usux = tobjModelo.Sys_codusu_usux;
                        lobjRegistro.inv_conreg_inma = (int)tobjModelo.Inv_conreg_inma;
                        lobjRegistro.sis_estpro_espr = tobjModelo.Sis_estpro_espr;
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
                    var lobjRegistro = _context.Invmovdiariosma.FirstOrDefault(p => p.inv_secreg_inma == tcrCodigo);
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
        #region Buscar INVMOVDIARIOSMA: Logica
        /// <summary>
        /// <para>TABLA: invmovdiariosma</para>
        /// <para>TITULO: Tabla maestro movimientos diarios inventarios</para>
        /// <para>MODULO: INV</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Tabla maestro movimientos diarios inventarios, contiene un
        /// registro maestro según cada tipo registro movimiento del inventario:
        /// (INMA = Maestro de movimientos diarios del inventario) ,traslado
        /// entre almacenes, pedidos para consumo interno y otros.
        /// </para>
        /// </summary>
        public static bool flgBuscarInvmovdiariosma(String tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Invmovdiariosma.FirstOrDefault(p => p.inv_secreg_inma == tcrCodigo);
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
        /// //Modelo Maestro Movimiento Sumunistro: Lista de Registros
        /// </summary>
        /// <param name="tcrBuscar"></param>
        /// <returns></returns>
        public static List<ModeloInvMovSuministro> flsListaInvmovdiariosma(String tcrBuscar)
        {
            using (_context = new DbAplicacion())
            {
                if (String.IsNullOrEmpty(tcrBuscar))
                {
                    var lobConsulta = from invmovdiariosma in _context.Invmovdiariosma
                                      join invtiporegimovi in _context.Invtiporegimovi on invmovdiariosma.inv_tipmov_intr equals invtiporegimovi.inv_tipmov_intr into tminvtiporegimovi
                                      join invtipoconcemov in _context.Invtipoconcemov on invmovdiariosma.inv_conmov_incm equals invtipoconcemov.inv_conmov_incm into tminvtipoconcemov
                                      join invalmacenmaest in _context.Invalmacenmaest on invmovdiariosma.inv_codalm_inal equals invalmacenmaest.inv_codalm_inal into tminvalmacenmaest
                                      join concentrodcosto in _context.Concentrodcosto on invmovdiariosma.con_codsco_ccos equals concentrodcosto.con_codsco_ccos into tmconcentrodcosto
                                      join invresponsables in _context.Invresponsables on invmovdiariosma.inv_codres_inre equals invresponsables.inv_codres_inre into tminvresponsables
                                      join sismaesdependen in _context.Sismaesdependen on invmovdiariosma.sis_coddep_sidp equals sismaesdependen.sis_coddep_sidp into tmsismaesdependen
                                      join siaareapreservi in _context.Siaareapreservi on invmovdiariosma.sia_codare_aser equals siaareapreservi.sia_codare_aser into tmsiaareapreservi
                                      join sisestadoproces in _context.Sisestadoproces on invmovdiariosma.sis_estpro_espr equals sisestadoproces.sis_estpro_espr into tmsisestadoproces
                                      join invkardexmaestr in _context.Invkardexmaestr on invmovdiariosma.inv_conmov_incm equals invkardexmaestr.inv_conmov_incm into tminvkardexmaestr
                                      from intr in tminvtiporegimovi.DefaultIfEmpty()
                                      from incm in tminvtipoconcemov.DefaultIfEmpty()
                                      from inal in tminvalmacenmaest.DefaultIfEmpty()
                                      from ccos in tmconcentrodcosto.DefaultIfEmpty()
                                      from inre in tminvresponsables.DefaultIfEmpty()
                                      from sidp in tmsismaesdependen.DefaultIfEmpty()
                                      from aser in tmsiaareapreservi.DefaultIfEmpty()
                                      from espr in tmsisestadoproces.DefaultIfEmpty()
                                      select new ModeloInvMovSuministro
                                      {
                                          #region Datos
                                          Inv_secreg_inma = invmovdiariosma.inv_secreg_inma,
                                          Inv_tipmov_intr = invmovdiariosma.inv_tipmov_intr,
                                          Inv_conmov_incm = invmovdiariosma.inv_conmov_incm,
                                          Inv_desreg_inma = invmovdiariosma.inv_desreg_inma,
                                          Inv_fecges_inma = (DateTime)invmovdiariosma.inv_fecges_inma,
                                          Inv_secref_inma = invmovdiariosma.inv_secref_inma,
                                          Inv_codalm_inal = invmovdiariosma.inv_codalm_inal,
                                          Inv_codald_inal = invmovdiariosma.inv_codald_inal,
                                          Deinv_codald_inal = _context.Invalmacenmaest.FirstOrDefault(rxp => rxp.inv_codalm_inal == invmovdiariosma.inv_codald_inal).inv_desalm_inal,
                                          Con_codsco_ccos = invmovdiariosma.con_codsco_ccos,
                                          Inv_fecdoc_inma = (DateTime)invmovdiariosma.inv_fecdoc_inma,
                                          Inv_codres_inre = invmovdiariosma.inv_codres_inre,
                                          Sis_coddep_sidp = invmovdiariosma.sis_coddep_sidp,
                                          Sia_codare_aser = invmovdiariosma.sia_codare_aser,
                                          Inv_brufac_inmd = (float)invmovdiariosma.inv_brufac_inmd,
                                          Inv_pordes_inmd = (float)invmovdiariosma.inv_pordes_inmd,
                                          Inv_valiva_inmd = (float)invmovdiariosma.inv_valiva_inmd,
                                          Inv_valing_inar = (float)invmovdiariosma.inv_valing_inar,
                                          Inv_valmov_inar = (float)invmovdiariosma.inv_valmov_inar,
                                          Inv_valfac_inmd = (float)invmovdiariosma.inv_valfac_inmd,
                                          Inv_fecanu_inma = (DateTime)invmovdiariosma.inv_fecanu_inma,
                                          Sys_codusu_usux = invmovdiariosma.sys_codusu_usux,
                                          Inv_conreg_inma = (int)invmovdiariosma.inv_conreg_inma,
                                          Sis_estpro_espr = invmovdiariosma.sis_estpro_espr,
                                          Inv_desreg_intr = intr.inv_desreg_intr,
                                          Inv_descon_incm = incm.inv_descon_incm,
                                          Inv_desalm_inal = inal.inv_desalm_inal,
                                          Con_dessco_ccos = ccos.con_dessco_ccos,
                                          Inv_nomres_inre = inre.inv_nomres_inre,
                                          Sis_nomdep_sidp = sidp.sis_nomdep_sidp,
                                          Sia_desare_aser = aser.sia_desare_aser,
                                          Sis_despro_espr = espr.sis_despro_espr,
                                          #endregion
                                      };
                    return lobConsulta.ToList();
                }
                else
                {
                    var lobConsulta = from invmovdiariosma in _context.Invmovdiariosma
                                      join invtiporegimovi in _context.Invtiporegimovi on invmovdiariosma.inv_tipmov_intr equals invtiporegimovi.inv_tipmov_intr into tminvtiporegimovi
                                      join invtipoconcemov in _context.Invtipoconcemov on invmovdiariosma.inv_conmov_incm equals invtipoconcemov.inv_conmov_incm into tminvtipoconcemov
                                      join invalmacenmaest in _context.Invalmacenmaest on invmovdiariosma.inv_codalm_inal equals invalmacenmaest.inv_codalm_inal into tminvalmacenmaest
                                      join concentrodcosto in _context.Concentrodcosto on invmovdiariosma.con_codsco_ccos equals concentrodcosto.con_codsco_ccos into tmconcentrodcosto
                                      join invresponsables in _context.Invresponsables on invmovdiariosma.inv_codres_inre equals invresponsables.inv_codres_inre into tminvresponsables
                                      join sismaesdependen in _context.Sismaesdependen on invmovdiariosma.sis_coddep_sidp equals sismaesdependen.sis_coddep_sidp into tmsismaesdependen
                                      join siaareapreservi in _context.Siaareapreservi on invmovdiariosma.sia_codare_aser equals siaareapreservi.sia_codare_aser into tmsiaareapreservi
                                      join sisestadoproces in _context.Sisestadoproces on invmovdiariosma.sis_estpro_espr equals sisestadoproces.sis_estpro_espr into tmsisestadoproces
                                      from intr in tminvtiporegimovi.DefaultIfEmpty()
                                      from incm in tminvtipoconcemov.DefaultIfEmpty()
                                      from inal in tminvalmacenmaest.DefaultIfEmpty()
                                      from ccos in tmconcentrodcosto.DefaultIfEmpty()
                                      from inre in tminvresponsables.DefaultIfEmpty()
                                      from sidp in tmsismaesdependen.DefaultIfEmpty()
                                      from aser in tmsiaareapreservi.DefaultIfEmpty()
                                      from espr in tmsisestadoproces.DefaultIfEmpty()
                                      where invmovdiariosma.inv_secreg_inma.Contains(tcrBuscar) || invmovdiariosma.inv_desreg_inma.Contains(tcrBuscar)
                                      select new ModeloInvMovSuministro
                                      {
                                          #region Datos
                                          Inv_secreg_inma = invmovdiariosma.inv_secreg_inma,
                                          Inv_tipmov_intr = invmovdiariosma.inv_tipmov_intr,
                                          Inv_conmov_incm = invmovdiariosma.inv_conmov_incm,
                                          Inv_desreg_inma = invmovdiariosma.inv_desreg_inma,
                                          Inv_fecges_inma = (DateTime)invmovdiariosma.inv_fecges_inma,
                                          Inv_secref_inma = invmovdiariosma.inv_secref_inma,
                                          Inv_codalm_inal = invmovdiariosma.inv_codalm_inal,
                                          Inv_codald_inal = invmovdiariosma.inv_codald_inal,
                                          Deinv_codald_inal = _context.Invalmacenmaest.FirstOrDefault(rxp => rxp.inv_codalm_inal == invmovdiariosma.inv_codald_inal).inv_desalm_inal,
                                          Con_codsco_ccos = invmovdiariosma.con_codsco_ccos,
                                          Inv_fecdoc_inma = (DateTime)invmovdiariosma.inv_fecdoc_inma,
                                          Inv_codres_inre = invmovdiariosma.inv_codres_inre,
                                          Sis_coddep_sidp = invmovdiariosma.sis_coddep_sidp,
                                          Sia_codare_aser = invmovdiariosma.sia_codare_aser,
                                          Inv_brufac_inmd = (float)invmovdiariosma.inv_brufac_inmd,
                                          Inv_pordes_inmd = (float)invmovdiariosma.inv_pordes_inmd,
                                          Inv_valiva_inmd = (float)invmovdiariosma.inv_valiva_inmd,
                                          Inv_valing_inar = (float)invmovdiariosma.inv_valing_inar,
                                          Inv_valmov_inar = (float)invmovdiariosma.inv_valmov_inar,
                                          Inv_valfac_inmd = (float)invmovdiariosma.inv_valfac_inmd,
                                          Inv_fecanu_inma = (DateTime)invmovdiariosma.inv_fecanu_inma,
                                          Sys_codusu_usux = invmovdiariosma.sys_codusu_usux,
                                          Inv_conreg_inma = (int)invmovdiariosma.inv_conreg_inma,
                                          Sis_estpro_espr = invmovdiariosma.sis_estpro_espr,
                                          Inv_desreg_intr = intr.inv_desreg_intr,
                                          Inv_descon_incm = incm.inv_descon_incm,
                                          Inv_desalm_inal = inal.inv_desalm_inal,
                                          Con_dessco_ccos = ccos.con_dessco_ccos,
                                          Inv_nomres_inre = inre.inv_nomres_inre,
                                          Sis_nomdep_sidp = sidp.sis_nomdep_sidp,
                                          Sia_desare_aser = aser.sia_desare_aser,
                                          Sis_despro_espr = espr.sis_despro_espr,
                                          #endregion
                                      };
                    return lobConsulta.ToList();
                }
            }
        }
        #endregion
        #endregion
    }
    #endregion
    #region Modelo Detalles Suministro Interno
    /// <summary>
    /// Descripcion para la Vista de  la tabla: invmovdiariosmd
    /// </summary>
    public class ModeloInvMovSuministroDe : clBaseInpc
    {
        #region Modelo Attributos
        private static DbAplicacion _context;
        #region Modelo Propiedades Notificacion
        #region Inv_secreg_inmd: Codigo registro
        private String _inv_secreg_inmd;
        /// <summary>
        /// <para>TABLA: invmovdiariosmd</para>
        /// <para>TABLA NATIVA: invmovdiariosmd</para>
        /// <para>CAMPO: Codigo registro</para>
        /// <para>NOMBRE: inv_secreg_inmd (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        /// Secuencial unico para cada registro detalle de la tabla (generado
        /// por el sistema)
        /// </para>
        /// </summary>
        public String Inv_secreg_inmd
        {
            get { return _inv_secreg_inmd; }
            set
            {
                if (_inv_secreg_inmd == value) return;
                _inv_secreg_inmd = value;
                OnPropertyChanged("Inv_secreg_inmd");
            }
        }
        #endregion
        #region Inv_secreg_inma: Secuencial reg. Maestro
        private String _inv_secreg_inma;
        /// <summary>
        /// <para>TABLA: invmovdiariosmd</para>
        /// <para>TABLA NATIVA: invmovdiariosma</para>
        /// <para>CAMPO: Secuencial reg. Maestro</para>
        /// <para>NOMBRE: inv_secreg_inma (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        /// Secuencial  unico registro maestro movimiento inventario, relacion
        /// con la tabla: INVMOVIMIENTOMA
        /// </para>
        /// </summary>
        public String Inv_secreg_inma
        {
            get { return _inv_secreg_inma; }
            set
            {
                if (_inv_secreg_inma == value) return;
                _inv_secreg_inma = value;
                OnPropertyChanged("Inv_secreg_inma");
            }
        }
        #endregion
        #region Inv_fecges_inma: Fecha gestion
        private DateTime _inv_fecges_inma;
        /// <summary>
        /// <para>TABLA: invmovdiariosmd</para>
        /// <para>TABLA NATIVA: invmovdiariosma</para>
        /// <para>CAMPO: Fecha gestion</para>
        /// <para>NOMBRE: inv_fecges_inma (fecha:)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        ///Fecha del registro diario o comprobante del movimiento
        /// </para>
        /// </summary>
        public DateTime Inv_fecges_inma
        {
            get { return _inv_fecges_inma; }
            set
            {
                if (_inv_fecges_inma == value) return;
                _inv_fecges_inma = value;
                OnPropertyChanged("Inv_fecges_inma");
            }
        }
        #endregion
        #region Inv_secart_inar: Secuencial  Articulo
        private String _inv_secart_inar;
        /// <summary>
        /// <para>TABLA: invmovdiariosmd</para>
        /// <para>TABLA NATIVA: invmaearticulos</para>
        /// <para>CAMPO: Secuencial  Articulo</para>
        /// <para>NOMBRE: inv_secart_inar (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        /// Secuencial de articulo generado por el sistema viene de la
        /// tabla:
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
        #region Inv_codaux_inar: Código Auxiliar Articulo
        private String _inv_codaux_inar;
        /// <summary>
        /// <para>TABLA: invmovdiariosmd</para>
        /// <para>TABLA NATIVA: invmaearticulos</para>
        /// <para>CAMPO: Código Auxiliar Articulo</para>
        /// <para>NOMBRE: inv_codaux_inar (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
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
        #region Inv_codbar_inar: Código Barras Articulo
        private String _inv_codbar_inar;
        /// <summary>
        /// <para>TABLA: invmovdiariosmd</para>
        /// <para>TABLA NATIVA: invmaearticulos</para>
        /// <para>CAMPO: Código Barras Articulo</para>
        /// <para>NOMBRE: inv_codbar_inar (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        /// Código de Barra Articulo 
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
        #region Inv_lotref_inar: Lote de Referencia
        private String _inv_lotref_inar;
        /// <summary>
        /// <para>TABLA: invmovdiariosmd</para>
        /// <para>TABLA NATIVA: invmaearticulos</para>
        /// <para>CAMPO: Código Barras Articulo</para>
        /// <para>NOMBRE: inv_codbar_inar (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        /// Código de Barra Articulo 
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
        #region Inv_codalm_inal: Código Almacén
        private String _inv_codalm_inal;
        /// <summary>
        /// <para>TABLA: invmovdiariosmd</para>
        /// <para>TABLA NATIVA: invalmacenmaest</para>
        /// <para>CAMPO: Código Almacén</para>
        /// <para>NOMBRE: inv_codalm_inal (char:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION:
        ///Código del Almacén que realiza el movimiento
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
        #region Deinv_codald_inal: Descripción Almacén
        private String _deinv_codald_inal;
        /// <summary>
        /// <para>TABLA: invalmacenmaest</para>
        /// <para>TABLA NATIVA: invalmacenmaest</para>
        /// <para>CAMPO: Descripción Almacén</para>
        /// <para>NOMBRE: deinv_codald_inal (char:)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
        /// <para>DESCRIPCION:
        ///Relacion 'RB' - inv_codald_inal: Descripción del almacén
        /// </para>
        /// </summary>
        public String Deinv_codald_inal
        {
            get { return _deinv_codald_inal; }
            set
            {
                if (_deinv_codald_inal == value) return;
                _deinv_codald_inal = value;
                OnPropertyChanged("Deinv_codald_inal");
            }
        }
        #endregion
        #region Inv_codald_inal: Código Almacén Destino
        private String _inv_codald_inal;
        /// <summary>
        /// <para>TABLA: invmovdiariosmd</para>
        /// <para>TABLA NATIVA: invalmacenmaest</para>
        /// <para>CAMPO: Código Almacén Destino</para>
        /// <para>NOMBRE: inv_codald_inal (char:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
        /// <para>DESCRIPCION:
        ///Código del Almacén Destino (para Traslados)
        /// </para>
        /// </summary>
        public String Inv_codald_inal
        {
            get { return _inv_codald_inal; }
            set
            {
                if (_inv_codald_inal == value) return;
                _inv_codald_inal = value;
                OnPropertyChanged("Inv_codald_inal");
            }
        }
        #endregion
        #region Con_codsco_ccos: Código centro de costo
        private String _con_codsco_ccos;
        /// <summary>
        /// <para>TABLA: invmovdiariosmd</para>
        /// <para>TABLA NATIVA: concentrodcosto</para>
        /// <para>CAMPO: Código centro de costo</para>
        /// <para>NOMBRE: con_codsco_ccos (char:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 11</para>
        /// <para>DESCRIPCION:
        ///Código del centro de costo generado por el sistema
        /// </para>
        /// </summary>
        public String Con_codsco_ccos
        {
            get { return _con_codsco_ccos; }
            set
            {
                if (_con_codsco_ccos == value) return;
                _con_codsco_ccos = value;
                OnPropertyChanged("Con_codsco_ccos");
            }
        }
        #endregion
        #region Sis_codgme_sigr: Patrón medida
        private String _sis_codgme_sigr;
        /// <summary>
        /// <para>TABLA: invmovdiariosmd</para>
        /// <para>TABLA NATIVA: sisgrupomedidas</para>
        /// <para>CAMPO: Patrón medida</para>
        /// <para>NOMBRE: sis_codgme_sigr (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 12</para>
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
        #region Inv_coduma_sium: Medida consumo
        private String _inv_coduma_sium;
        /// <summary>
        /// <para>TABLA: invmovdiariosmd</para>
        /// <para>TABLA NATIVA: sisunidadmedida</para>
        /// <para>CAMPO: Medida consumo</para>
        /// <para>NOMBRE: inv_coduma_sium (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 11</para>
        /// <para>DESCRIPCION:
        /// Unidad Medida como quedaran las existencias en Inventario (libra,
        /// metro, litros etc.)  para consumo/salida
        /// </para>
        /// </summary>
        public String Inv_coduma_sium
        {
            get { return _inv_coduma_sium; }
            set
            {
                if (_inv_coduma_sium == value) return;
                _inv_coduma_sium = value;
                OnPropertyChanged("Inv_coduma_sium");
            }
        }
        #endregion
        #region Inv_codctn_intc: Código Contenedor
        private String _inv_codctn_intc;
        /// <summary>
        /// <para>TABLA: invmovdiariosmd</para>
        /// <para>TABLA NATIVA: invcontenedores</para>
        /// <para>CAMPO: Código Contenedor</para>
        /// <para>NOMBRE: inv_codctn_intc (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 12</para>
        /// <para>DESCRIPCION:
        ///Código tipo de contenedor o presentación
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
        #region Inv_totctn_inmd: Total Contenedores
        private int _inv_totctn_inmd;
        /// <summary>
        /// <para>TABLA: invmovdiariosmd</para>
        /// <para>TABLA NATIVA: invmovdiariosmd</para>
        /// <para>CAMPO: Total Contenedores</para>
        /// <para>NOMBRE: inv_totctn_inmd (int:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 13</para>
        /// <para>DESCRIPCION:
        /// Total Contenedores para (realizar calculo de ingreso o salida)
        /// </para>
        /// </summary>
        public int Inv_totctn_inmd
        {
            get { return _inv_totctn_inmd; }
            set
            {
                if (_inv_totctn_inmd == value) return;
                _inv_totctn_inmd = value;
                OnPropertyChanged("Inv_totctn_inmd");
            }
        }
        #endregion
        #region Inv_unictn_inmd: Unidad Contenedores
        private int _inv_unictn_inmd;
        /// <summary>
        /// <para>TABLA: invmovdiariosmd</para>
        /// <para>TABLA NATIVA: invmovdiariosmd</para>
        /// <para>CAMPO: Unidad Contenedores</para>
        /// <para>NOMBRE: inv_unictn_inmd (int:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 14</para>
        /// <para>DESCRIPCION:
        /// Unidades en un Contenedor: Ejemplo: una caja es un contenedor
        /// y tiene 10 unidades.
        /// </para>
        /// </summary>
        public int Inv_unictn_inmd
        {
            get { return _inv_unictn_inmd; }
            set
            {
                if (_inv_unictn_inmd == value) return;
                _inv_unictn_inmd = value;
                OnPropertyChanged("Inv_unictn_inmd");
            }
        }
        #endregion
        #region Inv_unisue_inmd: Unidades sueltas
        private int _inv_unisue_inmd;
        /// <summary>
        /// <para>TABLA: invmovdiariosmd</para>
        /// <para>TABLA NATIVA: invmovdiariosmd</para>
        /// <para>CAMPO: Unidades sueltas</para>
        /// <para>NOMBRE: inv_unisue_inmd (int:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 15</para>
        /// <para>DESCRIPCION:
        /// Cantidad unidades sueltas adicinales que no alcanzan para ser
        /// contadas como un contenedor mas
        /// </para>
        /// </summary>
        public int Inv_unisue_inmd
        {
            get { return _inv_unisue_inmd; }
            set
            {
                if (_inv_unisue_inmd == value) return;
                _inv_unisue_inmd = value;
                OnPropertyChanged("Inv_unisue_inmd");
            }
        }
        #endregion
        #region Inv_unitot_inmd: Total Unidades
        private int _inv_unitot_inmd;
        /// <summary>
        /// <para>TABLA: invmovdiariosmd</para>
        /// <para>TABLA NATIVA: invmovdiariosmd</para>
        /// <para>CAMPO: Total Unidades</para>
        /// <para>NOMBRE: inv_unitot_inmd (int:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 16</para>
        /// <para>DESCRIPCION:
        /// TOTAL UNIDADES, cantidad de unidades en total de la transaccion
        /// (calculo Unidades por  contenedor mas unidades sueltas)
        /// </para>
        /// </summary>
        public int Inv_unitot_inmd
        {
            get { return _inv_unitot_inmd; }
            set
            {
                if (_inv_unitot_inmd == value) return;
                _inv_unitot_inmd = value;
                OnPropertyChanged("Inv_unitot_inmd");
            }
        }
        #endregion
        #region Inv_unidev_inmd: Unidades devolucion
        private int _inv_unidev_inmd;
        /// <summary>
        /// <para>TABLA: invmovdiariosmd</para>
        /// <para>TABLA NATIVA: invmovdiariosmd</para>
        /// <para>CAMPO: Unidades devolucion</para>
        /// <para>NOMBRE: inv_unidev_inmd (int:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 17</para>
        /// <para>DESCRIPCION:
        /// UNIDADES EN DEVOLUCION, cantidad de unidades para una devolucion
        /// de compra realizada a un proveedor
        /// </para>
        /// </summary>
        public int Inv_unidev_inmd
        {
            get { return _inv_unidev_inmd; }
            set
            {
                if (_inv_unidev_inmd == value) return;
                _inv_unidev_inmd = value;
                OnPropertyChanged("Inv_unidev_inmd");
            }
        }
        #endregion
        #region Inv_valing_inar: Valor Unidad al Ingreso
        private float _inv_valing_inar;
        /// <summary>
        /// <para>TABLA: invmovdiariosmd</para>
        /// <para>TABLA NATIVA: invmaearticulos</para>
        /// <para>CAMPO: Valor Unidad al Ingreso</para>
        /// <para>NOMBRE: inv_valing_inar (float:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 18</para>
        /// <para>DESCRIPCION:
        ///Valor de la Unidad articulo al Ingreso
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
        #region Inv_brufac_inmd: Valor Bruto
        private float _inv_brufac_inmd;
        /// <summary>
        /// <para>TABLA: invmovdiariosmd</para>
        /// <para>TABLA NATIVA: invmovdiariosmd</para>
        /// <para>CAMPO: Valor Bruto</para>
        /// <para>NOMBRE: inv_brufac_inmd (float:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 19</para>
        /// <para>DESCRIPCION:
        ///Valor Bruto del articulo sin ninguna deduccion
        /// </para>
        /// </summary>
        public float Inv_brufac_inmd
        {
            get { return _inv_brufac_inmd; }
            set
            {
                if (_inv_brufac_inmd == value) return;
                _inv_brufac_inmd = value;
                OnPropertyChanged("Inv_brufac_inmd");
            }
        }
        #endregion
        #region Inv_pordes_inmd: Porcentaje Descuento
        private float _inv_pordes_inmd;
        /// <summary>
        /// <para>TABLA: invmovdiariosmd</para>
        /// <para>TABLA NATIVA: invmovdiariosmd</para>
        /// <para>CAMPO: Porcentaje Descuento</para>
        /// <para>NOMBRE: inv_pordes_inmd (float:52)</para>
        /// <para>ORDEN VISTA EN TABLA: 20</para>
        /// <para>DESCRIPCION:
        ///Porcentaje Descuento realizado al articulo
        /// </para>
        /// </summary>
        public float Inv_pordes_inmd
        {
            get { return _inv_pordes_inmd; }
            set
            {
                if (_inv_pordes_inmd == value) return;
                _inv_pordes_inmd = value;
                OnPropertyChanged("Inv_pordes_inmd");
            }
        }
        #endregion
        #region Inv_valiva_inmd: Valor IVA
        private float _inv_valiva_inmd;
        /// <summary>
        /// <para>TABLA: invmovdiariosmd</para>
        /// <para>TABLA NATIVA: invmovdiariosmd</para>
        /// <para>CAMPO: Valor IVA</para>
        /// <para>NOMBRE: inv_valiva_inmd (float:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 21</para>
        /// <para>DESCRIPCION:
        ///Valor total del IVA descontado en articulo
        /// </para>
        /// </summary>
        public float Inv_valiva_inmd
        {
            get { return _inv_valiva_inmd; }
            set
            {
                if (_inv_valiva_inmd == value) return;
                _inv_valiva_inmd = value;
                OnPropertyChanged("Inv_valiva_inmd");
            }
        }
        #endregion
        #region Inv_valmov_inar: Valor salida unidad
        private float _inv_valmov_inar;
        /// <summary>
        /// <para>TABLA: invmovdiariosmd</para>
        /// <para>TABLA NATIVA: invmaearticulos</para>
        /// <para>CAMPO: Valor salida unidad</para>
        /// <para>NOMBRE: inv_valmov_inar (float:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 22</para>
        /// <para>DESCRIPCION:
        ///Valor Movimiento de salida cada unidad
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
        #region Inv_valfac_inmd: Valor total facturado
        private float _inv_valfac_inmd;
        /// <summary>
        /// <para>TABLA: invmovdiariosmd</para>
        /// <para>TABLA NATIVA: invmovdiariosmd</para>
        /// <para>CAMPO: Valor total facturado</para>
        /// <para>NOMBRE: inv_valfac_inmd (float:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 23</para>
        /// <para>DESCRIPCION:
        ///Valor total con deducciones de la factura
        /// </para>
        /// </summary>
        public float Inv_valfac_inmd
        {
            get { return _inv_valfac_inmd; }
            set
            {
                if (_inv_valfac_inmd == value) return;
                _inv_valfac_inmd = value;
                OnPropertyChanged("Inv_valfac_inmd");
            }
        }
        #endregion
        #region Inv_codest_ines: Código Estante
        private String _inv_codest_ines;
        /// <summary>
        /// <para>TABLA: invmovdiariosmd</para>
        /// <para>TABLA NATIVA: invalmacenestan</para>
        /// <para>CAMPO: Código Estante</para>
        /// <para>NOMBRE: inv_codest_ines (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 24</para>
        /// <para>DESCRIPCION:
        /// Codgo del estante para cada almacen: Ejemplo E01-Estante Medicamentos
        /// de control
        /// </para>
        /// </summary>
        public String Inv_codest_ines
        {
            get { return _inv_codest_ines; }
            set
            {
                if (_inv_codest_ines == value) return;
                _inv_codest_ines = value;
                OnPropertyChanged("Inv_codest_ines");
            }
        }
        #endregion
        #region Inv_seccio_ines: Secciones
        private String _inv_seccio_ines;
        /// <summary>
        /// <para>TABLA: invmovdiariosmd</para>
        /// <para>TABLA NATIVA: invalmacenestan</para>
        /// <para>CAMPO: Secciones</para>
        /// <para>NOMBRE: inv_seccio_ines (char:100)</para>
        /// <para>ORDEN VISTA EN TABLA: 25</para>
        /// <para>DESCRIPCION:
        /// Lista de secciones del estante para validacion (generada por
        /// el sistema) ejemplo: S01,S02,S03,S04 según el numero de secciones
        /// que contenga el estante
        /// </para>
        /// </summary>
        public String Inv_seccio_ines
        {
            get { return _inv_seccio_ines; }
            set
            {
                if (_inv_seccio_ines == value) return;
                _inv_seccio_ines = value;
                OnPropertyChanged("Inv_seccio_ines");
            }
        }
        #endregion
        #region Sys_codusu_usux: Código Usuario
        private String _sys_codusu_usux;
        /// <summary>
        /// <para>TABLA: invmovdiariosmd</para>
        /// <para>TABLA NATIVA: sysusuarios</para>
        /// <para>CAMPO: Código Usuario</para>
        /// <para>NOMBRE: sys_codusu_usux (char:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 26</para>
        /// <para>DESCRIPCION:
        ///Código del usuario que realiza el ajuste
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
        #region Sis_estpro_espr: Estado Registro
        private String _sis_estpro_espr;
        /// <summary>
        /// <para>TABLA: invmovdiariosmd</para>
        /// <para>TABLA NATIVA: sisestadoproces</para>
        /// <para>CAMPO: Estado Registro</para>
        /// <para>NOMBRE: sis_estpro_espr (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 27</para>
        /// <para>DESCRIPCION:
        ///Estado del registro: 1=Abierto 2=Confirmado 3=Anulado
        /// </para>
        /// </summary>
        public String Sis_estpro_espr
        {
            get { return _sis_estpro_espr; }
            set
            {
                if (_sis_estpro_espr == value) return;
                _sis_estpro_espr = value;
                OnPropertyChanged("Sis_estpro_espr");
            }
        }
        #endregion
        #region Inv_nomart_inar: Nombre artículo
        private String _inv_nomart_inar;
        /// <summary>
        /// <para>TABLA: invmovdiariosmd</para>
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
        #region Inv_desalm_inal: Descripción Almacén
        private String _inv_desalm_inal;
        /// <summary>
        /// <para>TABLA: invmovdiariosmd</para>
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
        #region Sis_desgme_sigr: Descripción Grupo medida
        private String _sis_desgme_sigr;
        /// <summary>
        /// <para>TABLA: invmovdiariosmd</para>
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
        /// <para>TABLA: invmovdiariosmd</para>
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
        /// <para>TABLA: invmovdiariosmd</para>
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
        #region Sis_despro_espr: Decripción estado proceso
        private String _sis_despro_espr;
        /// <summary>
        /// <para>TABLA: invmovdiariosmd</para>
        /// <para>TABLA NATIVA: sisestadoproces</para>
        /// <para>CAMPO: Decripción estado proceso</para>
        /// <para>NOMBRE: sis_despro_espr (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Descripcion textual del estado de proceso Abierto(a), Cerrado(a)
        /// Y Anulado(a)
        /// </para>
        /// </summary>
        public String Sis_despro_espr
        {
            get { return _sis_despro_espr; }
            set
            {
                if (_sis_despro_espr == value) return;
                _sis_despro_espr = value;
                OnPropertyChanged("Sis_despro_espr");
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
        #region Inv_codgru_ingr: Grupo Clasificación
        private String _inv_codgru_ingr;
        /// <summary>
        /// <para>TABLA: temporal</para>
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
        #region Inv_desgru_ingr: Descripcion Grupo
        private String _inv_desgru_ingr;
        /// <summary>
        /// <para>TABLA: temporal</para>
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
        #endregion
        #endregion
        #region Metodos para edicion de registros
        #region Adicionar Registro Relacion
        public static bool flgAddRegistro(ModeloInvMovSuministroDe tobTempReg, String tcrCodigoR1)
        {
            bool llgReturn = false;
            try
            {
                using (_context = new DbAplicacion())
                {
                    llgReturn = true;
                    var lobEFReg = new EFinvmovdiariosmd();
                    //-----------------------
                    if (tobTempReg.Sis_estado_imaen == "M")
                    {
                        lobEFReg = _context.Invmovdiariosmd.FirstOrDefault(p => p.inv_secreg_inmd == tobTempReg.Inv_secreg_inmd);
                    }
                    if (tobTempReg.Sis_estado_imaen == "A" || tobTempReg.Sis_estado_imaen == "M") // Adicionar o Modificar
                    {
                        #region cargar Registro
                        if (lobEFReg != null)
                        {
                            lobEFReg.inv_secreg_inmd = tobTempReg.Inv_secreg_inmd;
                            lobEFReg.inv_secreg_inma = tobTempReg.Inv_secreg_inma;
                            lobEFReg.inv_fecges_inma = (DateTime)tobTempReg.Inv_fecges_inma;
                            lobEFReg.inv_secart_inar = tobTempReg.Inv_secart_inar;
                            lobEFReg.inv_codaux_inar = tobTempReg.Inv_codaux_inar;
                            //lobEFReg.inv_codbar_inar = tobTempReg.Inv_codbar_inar;
                            lobEFReg.inv_codalm_inal = tobTempReg.Inv_codalm_inal;
                            lobEFReg.inv_codald_inal = tobTempReg.Inv_codald_inal;
                            lobEFReg.con_codsco_ccos = tobTempReg.Con_codsco_ccos;
                            lobEFReg.sis_codgme_sigr = tobTempReg.Sis_codgme_sigr;
                            lobEFReg.inv_coduma_sium = tobTempReg.Inv_coduma_sium;
                            lobEFReg.inv_codctn_intc = tobTempReg.Inv_codctn_intc;
                            lobEFReg.inv_totctn_inmd = (int)tobTempReg.Inv_totctn_inmd;
                            lobEFReg.inv_unictn_inmd = (int)tobTempReg.Inv_unictn_inmd;
                            lobEFReg.inv_unisue_inmd = (int)tobTempReg.Inv_unisue_inmd;
                            lobEFReg.inv_unitot_inmd = (int)tobTempReg.Inv_unitot_inmd;
                            lobEFReg.inv_unidev_inmd = (int)tobTempReg.Inv_unidev_inmd;
                            lobEFReg.inv_valing_inar = (float)tobTempReg.Inv_valing_inar;
                            lobEFReg.inv_brufac_inmd = (float)tobTempReg.Inv_brufac_inmd;
                            lobEFReg.inv_pordes_inmd = (float)tobTempReg.Inv_pordes_inmd;
                            lobEFReg.inv_valiva_inmd = (float)tobTempReg.Inv_valiva_inmd;
                            lobEFReg.inv_valmov_inar = (float)tobTempReg.Inv_valmov_inar;
                            lobEFReg.inv_valfac_inmd = (float)tobTempReg.Inv_valfac_inmd;
                            lobEFReg.inv_codest_ines = tobTempReg.Inv_codest_ines;
                            lobEFReg.inv_seccio_ines = tobTempReg.Inv_seccio_ines;
                            lobEFReg.sys_codusu_usux = tobTempReg.Sys_codusu_usux;
                            lobEFReg.sis_estpro_espr = tobTempReg.Sis_estpro_espr;
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
                                lobEFReg.inv_secreg_inmd = tcrCodigoR1 + lobEFReg.inv_secreg_inmd; // concatenar
                                _context.AddToInvmovdiariosmd(lobEFReg);
                                _context.SaveChanges();
                                break;

                            case "M": // Modificar el registro
                                _context.SaveChanges();
                                break;

                            case "E": // Eliminar el registro
                                var lobjRegistro = _context.Invmovdiariosmd.FirstOrDefault(p => p.inv_secreg_inmd == tobTempReg.Inv_secreg_inmd);
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
        #region Buscar INVMOVDIARIOSMD: Logica
        /// <summary>
        /// <para>TABLA: invmovdiariosmd</para>
        /// <para>TITULO: Tabla Detalle movimientos diarios</para>
        /// <para>MODULO: INV</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Detalles de la tabla INVMOVDIARIOSMA, contiene todos los registros
        /// de articulos correpondentes a un movimiento diario (traslado
        /// entre almacenes, pedidos para consumo interno y otros), Compras
        /// y entrega mendicamentos esta en otros archivos.
        /// </para>
        /// </summary>
        public static bool flgBuscarInvmovdiariosmd(String tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Invmovdiariosmd.FirstOrDefault(p => p.inv_secreg_inmd == tcrCodigo);
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
        /// //Modelo Detalles Movimiento Suministro: Lista de Registros
        /// </summary>
        /// <param name="tcrBuscar"></param>
        /// <returns></returns>
        public static List<ModeloInvMovSuministroDe> flsListaInvmovdiariosmd(String tcrBuscar)
        {
            using (_context = new DbAplicacion())
            {
                var lobConsulta = from invmovdiariosmd in _context.Invmovdiariosmd
                                  join invmaearticulos in _context.Invmaearticulos on invmovdiariosmd.inv_secart_inar equals invmaearticulos.inv_secart_inar into tminvmaearticulos
                                  join invalmacenmaest in _context.Invalmacenmaest on invmovdiariosmd.inv_codalm_inal equals invalmacenmaest.inv_codalm_inal into tminvalmacenmaest
                                  join sisgrupomedidas in _context.Sisgrupomedidas on invmovdiariosmd.sis_codgme_sigr equals sisgrupomedidas.sis_codgme_sigr into tmsisgrupomedidas
                                  join sisunidadmedida in _context.Sisunidadmedida on invmovdiariosmd.inv_coduma_sium equals sisunidadmedida.sis_codume_sium into tmsisunidadmedida
                                  join invcontenedores in _context.Invcontenedores on invmovdiariosmd.inv_codctn_intc equals invcontenedores.inv_codctn_intc into tminvcontenedores
                                  join sisestadoproces in _context.Sisestadoproces on invmovdiariosmd.sis_estpro_espr equals sisestadoproces.sis_estpro_espr into tmsisestadoproces
                                  from inar in tminvmaearticulos.DefaultIfEmpty()
                                  from inal in tminvalmacenmaest.DefaultIfEmpty()
                                  from sigr in tmsisgrupomedidas.DefaultIfEmpty()
                                  from sium in tmsisunidadmedida.DefaultIfEmpty()
                                  from intc in tminvcontenedores.DefaultIfEmpty()
                                  from espr in tmsisestadoproces.DefaultIfEmpty()
                                  where invmovdiariosmd.inv_secreg_inma == tcrBuscar
                                  select new ModeloInvMovSuministroDe
                                  {
                                      Inv_secreg_inmd = invmovdiariosmd.inv_secreg_inmd,
                                      Inv_secreg_inma = invmovdiariosmd.inv_secreg_inma,
                                      Inv_fecges_inma = (DateTime)invmovdiariosmd.inv_fecges_inma,
                                      Inv_secart_inar = invmovdiariosmd.inv_secart_inar,
                                      Inv_codaux_inar = invmovdiariosmd.inv_codaux_inar,
                                      //Inv_codbar_inar = invmovdiariosmd.inv_codbar_inar,
                                      Inv_codalm_inal = invmovdiariosmd.inv_codalm_inal,
                                      Inv_codald_inal = invmovdiariosmd.inv_codald_inal,
                                      Deinv_codald_inal = _context.Invalmacenmaest.FirstOrDefault(rxp => rxp.inv_codalm_inal == invmovdiariosmd.inv_codald_inal).inv_desalm_inal,
                                      Con_codsco_ccos = invmovdiariosmd.con_codsco_ccos,
                                      Sis_codgme_sigr = invmovdiariosmd.sis_codgme_sigr,
                                      Inv_coduma_sium = invmovdiariosmd.inv_coduma_sium,
                                      Inv_codctn_intc = invmovdiariosmd.inv_codctn_intc,
                                      Inv_totctn_inmd = (int)invmovdiariosmd.inv_totctn_inmd,
                                      Inv_unictn_inmd = (int)invmovdiariosmd.inv_unictn_inmd,
                                      Inv_unisue_inmd = (int)invmovdiariosmd.inv_unisue_inmd,
                                      Inv_unitot_inmd = (int)invmovdiariosmd.inv_unitot_inmd,
                                      Inv_unidev_inmd = (int)invmovdiariosmd.inv_unidev_inmd,
                                      Inv_valing_inar = (float)invmovdiariosmd.inv_valing_inar,
                                      Inv_brufac_inmd = (float)invmovdiariosmd.inv_brufac_inmd,
                                      Inv_pordes_inmd = (float)invmovdiariosmd.inv_pordes_inmd,
                                      Inv_valiva_inmd = (float)invmovdiariosmd.inv_valiva_inmd,
                                      Inv_valmov_inar = (float)invmovdiariosmd.inv_valmov_inar,
                                      Inv_valfac_inmd = (float)invmovdiariosmd.inv_valfac_inmd,
                                      Inv_codest_ines = invmovdiariosmd.inv_codest_ines,
                                      Inv_seccio_ines = invmovdiariosmd.inv_seccio_ines,
                                      Sys_codusu_usux = invmovdiariosmd.sys_codusu_usux,
                                      Sis_estpro_espr = invmovdiariosmd.sis_estpro_espr,
                                      Inv_nomart_inar = inar.inv_nomart_inar,
                                      Inv_desalm_inal = inal.inv_desalm_inal,
                                      Sis_desgme_sigr = sigr.sis_desgme_sigr,
                                      Sis_desume_sium = sium.sis_desume_sium,
                                      Inv_desctn_intc = intc.inv_desctn_intc,
                                      Sis_despro_espr = espr.sis_despro_espr,
                                      Sis_estado_imaen = "I",
                                  };
                return lobConsulta.ToList();
            }
        }
        #endregion
        #region Temporal con datos agrupados por categorias de articulos
        /// <summary>
        /// Devuelve un temporal con datos agrupados por categorias de articulos
        /// </summary>
        /// <param name="tcrCodigoRegistroMaestro">Codigo del registro maestro (viene de la tabla maestro MA)</param>
        /// <returns></returns>
        public static List<ModeloInvMovSuministroDe> flsListaInvmovdiariosmdRpt(String tcrCodigoRegistroMaestro)
        {
            using (_context = new DbAplicacion())
            {
                var lobConsulta = from invmovdiariosmd in _context.Invmovdiariosmd
                                  join invmaearticulos in _context.Invmaearticulos on invmovdiariosmd.inv_secart_inar equals invmaearticulos.inv_secart_inar into tminvmaearticulos
                                  join invalmacenmaest in _context.Invalmacenmaest on invmovdiariosmd.inv_codalm_inal equals invalmacenmaest.inv_codalm_inal into tminvalmacenmaest
                                  from inar in tminvmaearticulos.DefaultIfEmpty()
                                  from inal in tminvalmacenmaest.DefaultIfEmpty()
                                  where invmovdiariosmd.inv_secreg_inma == tcrCodigoRegistroMaestro
                                  orderby inar.inv_codgru_ingr, invmovdiariosmd.inv_secart_inar

                                  select new ModeloInvMovSuministroDe
                                  {
                                      Inv_secreg_inmd = invmovdiariosmd.inv_secreg_inmd,
                                      Inv_secreg_inma = invmovdiariosmd.inv_secreg_inma,
                                      Inv_fecges_inma = (DateTime)invmovdiariosmd.inv_fecges_inma,
                                      Inv_secart_inar = invmovdiariosmd.inv_secart_inar,
                                      Inv_codaux_inar = invmovdiariosmd.inv_codaux_inar,
                                      //Inv_codbar_inar = invmovdiariosmd.inv_codbar_inar,
                                      Inv_codalm_inal = invmovdiariosmd.inv_codalm_inal,
                                      Inv_codald_inal = invmovdiariosmd.inv_codald_inal,
                                      Deinv_codald_inal = _context.Invalmacenmaest.FirstOrDefault(rxp => rxp.inv_codalm_inal == invmovdiariosmd.inv_codald_inal).inv_desalm_inal,
                                      Con_codsco_ccos = invmovdiariosmd.con_codsco_ccos,
                                      Sis_codgme_sigr = invmovdiariosmd.sis_codgme_sigr,
                                      Inv_coduma_sium = invmovdiariosmd.inv_coduma_sium,
                                      Inv_codctn_intc = invmovdiariosmd.inv_codctn_intc,
                                      Inv_totctn_inmd = (int)invmovdiariosmd.inv_totctn_inmd,
                                      Inv_unictn_inmd = (int)invmovdiariosmd.inv_unictn_inmd,
                                      Inv_unisue_inmd = (int)invmovdiariosmd.inv_unisue_inmd,
                                      Inv_unitot_inmd = (int)invmovdiariosmd.inv_unitot_inmd,
                                      Inv_unidev_inmd = (int)invmovdiariosmd.inv_unidev_inmd,
                                      Inv_valing_inar = (float)invmovdiariosmd.inv_valing_inar,
                                      Inv_brufac_inmd = (float)invmovdiariosmd.inv_brufac_inmd,
                                      Inv_pordes_inmd = (float)invmovdiariosmd.inv_pordes_inmd,
                                      Inv_valiva_inmd = (float)invmovdiariosmd.inv_valiva_inmd,
                                      Inv_valmov_inar = (float)invmovdiariosmd.inv_valmov_inar,
                                      Inv_valfac_inmd = (float)invmovdiariosmd.inv_valfac_inmd,
                                      Inv_codest_ines = invmovdiariosmd.inv_codest_ines,
                                      Inv_seccio_ines = invmovdiariosmd.inv_seccio_ines,
                                      Sys_codusu_usux = invmovdiariosmd.sys_codusu_usux,
                                      Sis_estpro_espr = invmovdiariosmd.sis_estpro_espr,
                                      Inv_nomart_inar = inar.inv_nomart_inar,
                                      Inv_codgru_ingr = inar.inv_codgru_ingr,
                                      Inv_desalm_inal = inal.inv_desalm_inal,
                                      Inv_desgru_ingr = _context.Invinventgrupos.FirstOrDefault(x => x.inv_codgru_ingr == inar.inv_codgru_ingr).inv_desgru_ingr,
                                      Sis_estado_imaen = "I",
                                  };
                return lobConsulta.ToList();
            }
        }
        #endregion
        #endregion
    }
    #endregion
    #region Modelo Ajuste Inventario Maestro
    /// <summary>
    /// Descripcion para la Vista de  la tabla: invajustesmaema
    /// </summary>
    public class ModeloInvajustesmaema : clBaseInpc
    {
        #region Modelo Attributos
        private static DbAplicacion _context;
        #region Modelo Propiedades Notificacion
        #region Inv_secreg_inja: Codigo registro
        private String _inv_secreg_inja;
        /// <summary>
        /// <para>TABLA: invajustesmaema</para>
        /// <para>TABLA NATIVA: invajustesmaema</para>
        /// <para>CAMPO: Codigo registro</para>
        /// <para>NOMBRE: inv_secreg_inja (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        /// Secuencial unico para cada registro maestro ajuste inventario
        /// (generado por el sistema)
        /// </para>
        /// </summary>
        public String Inv_secreg_inja
        {
            get { return _inv_secreg_inja; }
            set
            {
                if (_inv_secreg_inja == value) return;
                _inv_secreg_inja = value;
                OnPropertyChanged("Inv_secreg_inja");
            }
        }
        #endregion
        #region Inv_fecges_inja: Fecha ajuste
        private DateTime _inv_fecges_inja;
        /// <summary>
        /// <para>TABLA: invajustesmaema</para>
        /// <para>TABLA NATIVA: invajustesmaema</para>
        /// <para>CAMPO: Fecha ajuste</para>
        /// <para>NOMBRE: inv_fecges_inja (fecha:)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Fecha gestion registro ajuste y  movimientos al inventario
        /// </para>
        /// </summary>
        public DateTime Inv_fecges_inja
        {
            get { return _inv_fecges_inja; }
            set
            {
                if (_inv_fecges_inja == value) return;
                _inv_fecges_inja = value;
                OnPropertyChanged("Inv_fecges_inja");
            }
        }
        #endregion
        #region Inv_codalm_inal: Código Almacén
        private String _inv_codalm_inal;
        /// <summary>
        /// <para>TABLA: invajustesmaema</para>
        /// <para>TABLA NATIVA: invalmacenmaest</para>
        /// <para>CAMPO: Código Almacén</para>
        /// <para>NOMBRE: inv_codalm_inal (char:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        ///Código del Almacén para el que se realiza el ajuste
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
        #region Inv_conaju_incp: Código concepto ajuste
        private String _inv_conaju_incp;
        /// <summary>
        /// <para>TABLA: invajustesmaema</para>
        /// <para>TABLA NATIVA: invajusteconcep</para>
        /// <para>CAMPO: Código concepto ajuste</para>
        /// <para>NOMBRE: inv_conaju_incp (char:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        /// Código concepto de Ajuste inventario: 01=Por reconteo inventario
        /// 02=Aprovechamiento sobrantes 03= Reingreso prestamos 04=Deterioro
        /// del producto y otros
        /// </para>
        /// </summary>
        public String Inv_conaju_incp
        {
            get { return _inv_conaju_incp; }
            set
            {
                if (_inv_conaju_incp == value) return;
                _inv_conaju_incp = value;
                OnPropertyChanged("Inv_conaju_incp");
            }
        }
        #endregion
        #region Inv_conmov_incm: Concepto Movimiento
        private String _inv_conmov_incm;
        /// <summary>
        /// <para>TABLA: invajustesmaema</para>
        /// <para>TABLA NATIVA: invtipoconcemov</para>
        /// <para>CAMPO: Concepto Movimiento</para>
        /// <para>NOMBRE: inv_conmov_incm (char:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        /// Concepto movimiento diario: E11 =Entrada saldo inicial inventario
        /// o del mes E12= Entradas compras ...  S21= Salidas Ventas 22=
        /// Salidas Traslado S23= Salidas Otras Áreas Empresa S24= Salida
        /// entrega formula A30=Ajuste de inventarios y otros
        /// </para>
        /// </summary>
        public String Inv_conmov_incm
        {
            get { return _inv_conmov_incm; }
            set
            {
                if (_inv_conmov_incm == value) return;
                _inv_conmov_incm = value;
                OnPropertyChanged("Inv_conmov_incm");
            }
        }
        #endregion
        #region Inv_desaju_inja: Nota detallle
        private String _inv_desaju_inja;
        /// <summary>
        /// <para>TABLA: invajustesmaema</para>
        /// <para>TABLA NATIVA: invajustesmaema</para>
        /// <para>CAMPO: Nota detallle</para>
        /// <para>NOMBRE: inv_desaju_inja (char:150)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        ///Descripcion detalle para nota sobre el proceso de ajuste
        /// </para>
        /// </summary>
        public String Inv_desaju_inja
        {
            get { return _inv_desaju_inja; }
            set
            {
                if (_inv_desaju_inja == value) return;
                _inv_desaju_inja = value;
                OnPropertyChanged("Inv_desaju_inja");
            }
        }
        #endregion
        #region Sia_codare_aser: Código Área de servicios
        private String _sia_codare_aser;
        /// <summary>
        /// <para>TABLA: invajustesmaema</para>
        /// <para>TABLA NATIVA: siaareapreservi</para>
        /// <para>CAMPO: Código Área de servicios</para>
        /// <para>NOMBRE: sia_codare_aser (char:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
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
        #region Fcm_codcpr_cpro: Centro producción
        private String _fcm_codcpr_cpro;
        /// <summary>
        /// <para>TABLA: invajustesmaema</para>
        /// <para>TABLA NATIVA: </para>
        /// <para>CAMPO: Centro producción</para>
        /// <para>NOMBRE: fcm_codcpr_cpro (char:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
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
        /// <para>TABLA: invajustesmaema</para>
        /// <para>TABLA NATIVA: siacentroaten</para>
        /// <para>CAMPO: Código centro atención</para>
        /// <para>NOMBRE: sia_codcat_ceat (char:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
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
        #region Sys_codusu_usux: Usuario del sistema
        private String _sys_codusu_usux;
        /// <summary>
        /// <para>TABLA: invajustesmaema</para>
        /// <para>TABLA NATIVA: sysusuarios</para>
        /// <para>CAMPO: Usuario del sistema</para>
        /// <para>NOMBRE: sys_codusu_usux (char:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
        /// <para>DESCRIPCION:
        /// Código usuario del sistema para los personas que lo requieran
        /// (no obligatorio) , NA = cuando no sea requerido
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
        #region Inv_conreg_inja: Contador items
        private int _inv_conreg_inja;
        /// <summary>
        /// <para>TABLA: invajustesmaema</para>
        /// <para>TABLA NATIVA: invajustesmaema</para>
        /// <para>CAMPO: Contador items</para>
        /// <para>NOMBRE: inv_conreg_inja (int:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 11</para>
        /// <para>DESCRIPCION:
        /// Contador para generar el secuencial unico de registros en detalle
        /// (gestion interna)
        /// </para>
        /// </summary>
        public int Inv_conreg_inja
        {
            get { return _inv_conreg_inja; }
            set
            {
                if (_inv_conreg_inja == value) return;
                _inv_conreg_inja = value;
                OnPropertyChanged("Inv_conreg_inja");
            }
        }
        #endregion
        #region Sis_estpro_espr: Estado Registro
        private String _sis_estpro_espr;
        /// <summary>
        /// <para>TABLA: invajustesmaema</para>
        /// <para>TABLA NATIVA: sisestadoproces</para>
        /// <para>CAMPO: Estado Registro</para>
        /// <para>NOMBRE: sis_estpro_espr (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 12</para>
        /// <para>DESCRIPCION:
        ///Estado del registro: 1=Abierto 2=Confirmado 3=Anulado
        /// </para>
        /// </summary>
        public String Sis_estpro_espr
        {
            get { return _sis_estpro_espr; }
            set
            {
                if (_sis_estpro_espr == value) return;
                _sis_estpro_espr = value;
                OnPropertyChanged("Sis_estpro_espr");
            }
        }
        #endregion
        #region Inv_desalm_inal: Descripción Almacén
        private String _inv_desalm_inal;
        /// <summary>
        /// <para>TABLA: invajustesmaema</para>
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
        #region Inv_desaju_incp: Descripción Concepto
        private String _inv_desaju_incp;
        /// <summary>
        /// <para>TABLA: invajustesmaema</para>
        /// <para>TABLA NATIVA: invajusteconcep</para>
        /// <para>CAMPO: Descripción Concepto</para>
        /// <para>NOMBRE: inv_desaju_incp (char:50)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripción concepto de Ajuste
        /// </para>
        /// </summary>
        public String Inv_desaju_incp
        {
            get { return _inv_desaju_incp; }
            set
            {
                if (_inv_desaju_incp == value) return;
                _inv_desaju_incp = value;
                OnPropertyChanged("Inv_desaju_incp");
            }
        }
        #endregion
        #region Inv_descon_incm: Descripción concepto
        private String _inv_descon_incm;
        /// <summary>
        /// <para>TABLA: invajustesmaema</para>
        /// <para>TABLA NATIVA: invtipoconcemov</para>
        /// <para>CAMPO: Descripción concepto</para>
        /// <para>NOMBRE: inv_descon_incm (char:50)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        ///Descripción concepto movimiento diario
        /// </para>
        /// </summary>
        public String Inv_descon_incm
        {
            get { return _inv_descon_incm; }
            set
            {
                if (_inv_descon_incm == value) return;
                _inv_descon_incm = value;
                OnPropertyChanged("Inv_descon_incm");
            }
        }
        #endregion
        #region Sia_desare_aser: Nombre área de servicios
        private String _sia_desare_aser;
        /// <summary>
        /// <para>TABLA: invajustesmaema</para>
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
        #region Sys_nomusu_usux: Nombre Usuario
        private String _sys_nomusu_usux;
        /// <summary>
        /// <para>TABLA: invajustesmaema</para>
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
        #region Sis_despro_espr: Decripción estado proceso
        private String _sis_despro_espr;
        /// <summary>
        /// <para>TABLA: invajustesmaema</para>
        /// <para>TABLA NATIVA: sisestadoproces</para>
        /// <para>CAMPO: Decripción estado proceso</para>
        /// <para>NOMBRE: sis_despro_espr (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Descripcion textual del estado de proceso Abierto(a), Cerrado(a)
        /// Y Anulado(a)
        /// </para>
        /// </summary>
        public String Sis_despro_espr
        {
            get { return _sis_despro_espr; }
            set
            {
                if (_sis_despro_espr == value) return;
                _sis_despro_espr = value;
                OnPropertyChanged("Sis_despro_espr");
            }
        }
        #endregion
        #endregion
        #endregion
        #region Metodos para edicion de registros
        #region Adicionar Registro
        public static String flgAddRegistro(ModeloInvajustesmaema tobjModelo)
        {
            var lcrCodigoGen = SysModelo.fcrGenerarNuevoCodigo("INV-AJUST-INVEN", "INV", "Ajuste de inventario Almacen");
            try
            {
                if (!flgBuscarInvajustesmaema(lcrCodigoGen))
                {
                    using (_context = new DbAplicacion())
                    {
                        var lobjRegistro = new EFinvajustesmaema
                        {
                            #region cargar Registro
                            inv_secreg_inja = tobjModelo.Inv_secreg_inja,
                            inv_fecges_inja = tobjModelo.Inv_fecges_inja,
                            inv_codalm_inal = tobjModelo.Inv_codalm_inal,
                            inv_conaju_incp = tobjModelo.Inv_conaju_incp,
                            inv_conmov_incm = tobjModelo.Inv_conmov_incm,
                            inv_desaju_inja = tobjModelo.Inv_desaju_inja,
                            sia_codare_aser = tobjModelo.Sia_codare_aser,
                            fcm_codcpr_cpro = tobjModelo.Fcm_codcpr_cpro,
                            sia_codcat_ceat = tobjModelo.Sia_codcat_ceat,
                            sys_codusu_usux = tobjModelo.Sys_codusu_usux,
                            inv_conreg_inja = tobjModelo.Inv_conreg_inja,
                            sis_estpro_espr = tobjModelo.Sis_estpro_espr,
                            #endregion
                        };
                        lobjRegistro.inv_secreg_inja = lcrCodigoGen;
                        _context.AddToInvajustesmaema(lobjRegistro);
                        _context.SaveChanges();
                    }
                }
                else
                {
                    lcrCodigoGen = String.Empty;
                    MessageBox.Show("Nuevo codigo Generado esta desactualizado, revisar llave: \n" +
                                "'INV-AJUST-INVEN': Ajuste de inventario Almacen en Maestro Secuenciales.");
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
        public static void fcvActualizar(ModeloInvajustesmaema tobjModelo)
        {
            try
            {
                using (_context = new DbAplicacion())
                {
                    var lobjRegistro = _context.Invajustesmaema.FirstOrDefault(p => p.inv_secreg_inja == tobjModelo.Inv_secreg_inja);
                    if (lobjRegistro != null)
                    {
                        #region cargar Registro
                        lobjRegistro.inv_secreg_inja = tobjModelo.Inv_secreg_inja;
                        lobjRegistro.inv_fecges_inja = (DateTime)tobjModelo.Inv_fecges_inja;
                        lobjRegistro.inv_codalm_inal = tobjModelo.Inv_codalm_inal;
                        lobjRegistro.inv_conaju_incp = tobjModelo.Inv_conaju_incp;
                        lobjRegistro.inv_conmov_incm = tobjModelo.Inv_conmov_incm;
                        lobjRegistro.inv_desaju_inja = tobjModelo.Inv_desaju_inja;
                        lobjRegistro.sia_codare_aser = tobjModelo.Sia_codare_aser;
                        lobjRegistro.fcm_codcpr_cpro = tobjModelo.Fcm_codcpr_cpro;
                        lobjRegistro.sia_codcat_ceat = tobjModelo.Sia_codcat_ceat;
                        lobjRegistro.sys_codusu_usux = tobjModelo.Sys_codusu_usux;
                        lobjRegistro.inv_conreg_inja = (int)tobjModelo.Inv_conreg_inja;
                        lobjRegistro.sis_estpro_espr = tobjModelo.Sis_estpro_espr;
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
                    var lobjRegistro = _context.Invajustesmaema.FirstOrDefault(p => p.inv_secreg_inja == tcrCodigo);
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
        #region Buscar INVAJUSTESMAEMA: Logica
        /// <summary>
        /// <para>TABLA: invajustesmaema</para>
        /// <para>TITULO: Maestro ajustes de inventario</para>
        /// <para>MODULO: INV</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        ///Archivo maestro para registrar los ajustes de inventarios
        /// </para>
        /// </summary>
        public static bool flgBuscarInvajustesmaema(String tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Invajustesmaema.FirstOrDefault(p => p.inv_secreg_inja == tcrCodigo);
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
        /// //Modelo Maestro Ajuste Inventario: Lista de Registros
        /// </summary>
        /// <param name="tcrBuscar"></param>
        /// <returns></returns>
        public static List<ModeloInvajustesmaema> flsListaInvajustesmaema(String tcrBuscar)
        {
            using (_context = new DbAplicacion())
            {
                if (String.IsNullOrEmpty(tcrBuscar))
                {
                    var lobConsulta = from invajustesmaema in _context.Invajustesmaema
                                      join invalmacenmaest in _context.Invalmacenmaest on invajustesmaema.inv_codalm_inal equals invalmacenmaest.inv_codalm_inal into tminvalmacenmaest
                                      join invajusteconcep in _context.Invajusteconcep on invajustesmaema.inv_conaju_incp equals invajusteconcep.inv_conaju_incp into tminvajusteconcep
                                      join invtipoconcemov in _context.Invtipoconcemov on invajustesmaema.inv_conmov_incm equals invtipoconcemov.inv_conmov_incm into tminvtipoconcemov
                                      join siaareapreservi in _context.Siaareapreservi on invajustesmaema.sia_codare_aser equals siaareapreservi.sia_codare_aser into tmsiaareapreservi
                                      join sysusuarios in _context.Sysusuarios on invajustesmaema.sys_codusu_usux equals sysusuarios.sys_codusu_usux into tmsysusuarios
                                      join sisestadoproces in _context.Sisestadoproces on invajustesmaema.sis_estpro_espr equals sisestadoproces.sis_estpro_espr into tmsisestadoproces
                                      from inal in tminvalmacenmaest.DefaultIfEmpty()
                                      from incp in tminvajusteconcep.DefaultIfEmpty()
                                      from incm in tminvtipoconcemov.DefaultIfEmpty()
                                      from aser in tmsiaareapreservi.DefaultIfEmpty()
                                      from usux in tmsysusuarios.DefaultIfEmpty()
                                      from espr in tmsisestadoproces.DefaultIfEmpty()
                                      where invajustesmaema.inv_secreg_inja.Contains(tcrBuscar)
                                      select new ModeloInvajustesmaema
                                      {
                                          #region Datos
                                          Inv_secreg_inja = invajustesmaema.inv_secreg_inja,
                                          Inv_fecges_inja = (DateTime)invajustesmaema.inv_fecges_inja,
                                          Inv_codalm_inal = invajustesmaema.inv_codalm_inal,
                                          Inv_conaju_incp = invajustesmaema.inv_conaju_incp,
                                          Inv_conmov_incm = invajustesmaema.inv_conmov_incm,
                                          Inv_desaju_inja = invajustesmaema.inv_desaju_inja,
                                          Sia_codare_aser = invajustesmaema.sia_codare_aser,
                                          Fcm_codcpr_cpro = invajustesmaema.fcm_codcpr_cpro,
                                          Sia_codcat_ceat = invajustesmaema.sia_codcat_ceat,
                                          Sys_codusu_usux = invajustesmaema.sys_codusu_usux,
                                          Inv_conreg_inja = (int)invajustesmaema.inv_conreg_inja,
                                          Sis_estpro_espr = invajustesmaema.sis_estpro_espr,
                                          Inv_desalm_inal = inal.inv_desalm_inal,
                                          Inv_desaju_incp = incp.inv_desaju_incp,
                                          Inv_descon_incm = incm.inv_descon_incm,
                                          Sia_desare_aser = aser.sia_desare_aser,
                                          Sys_nomusu_usux = usux.sys_nomusu_usux,
                                          Sis_despro_espr = espr.sis_despro_espr,
                                          #endregion
                                      };
                    return lobConsulta.ToList();
                }
                else
                {
                    var lobConsulta = from invajustesmaema in _context.Invajustesmaema
                                      join invalmacenmaest in _context.Invalmacenmaest on invajustesmaema.inv_codalm_inal equals invalmacenmaest.inv_codalm_inal into tminvalmacenmaest
                                      join invajusteconcep in _context.Invajusteconcep on invajustesmaema.inv_conaju_incp equals invajusteconcep.inv_conaju_incp into tminvajusteconcep
                                      join invtipoconcemov in _context.Invtipoconcemov on invajustesmaema.inv_conmov_incm equals invtipoconcemov.inv_conmov_incm into tminvtipoconcemov
                                      join siaareapreservi in _context.Siaareapreservi on invajustesmaema.sia_codare_aser equals siaareapreservi.sia_codare_aser into tmsiaareapreservi
                                      join sysusuarios in _context.Sysusuarios on invajustesmaema.sys_codusu_usux equals sysusuarios.sys_codusu_usux into tmsysusuarios
                                      join sisestadoproces in _context.Sisestadoproces on invajustesmaema.sis_estpro_espr equals sisestadoproces.sis_estpro_espr into tmsisestadoproces
                                      from inal in tminvalmacenmaest.DefaultIfEmpty()
                                      from incp in tminvajusteconcep.DefaultIfEmpty()
                                      from incm in tminvtipoconcemov.DefaultIfEmpty()
                                      from aser in tmsiaareapreservi.DefaultIfEmpty()
                                      from usux in tmsysusuarios.DefaultIfEmpty()
                                      from espr in tmsisestadoproces.DefaultIfEmpty()
                                      where invajustesmaema.inv_secreg_inja == (tcrBuscar)
                                      select new ModeloInvajustesmaema
                                      {
                                          #region Datos
                                          Inv_secreg_inja = invajustesmaema.inv_secreg_inja,
                                          Inv_fecges_inja = (DateTime)invajustesmaema.inv_fecges_inja,
                                          Inv_codalm_inal = invajustesmaema.inv_codalm_inal,
                                          Inv_conaju_incp = invajustesmaema.inv_conaju_incp,
                                          Inv_conmov_incm = invajustesmaema.inv_conmov_incm,
                                          Inv_desaju_inja = invajustesmaema.inv_desaju_inja,
                                          Sia_codare_aser = invajustesmaema.sia_codare_aser,
                                          Fcm_codcpr_cpro = invajustesmaema.fcm_codcpr_cpro,
                                          Sia_codcat_ceat = invajustesmaema.sia_codcat_ceat,
                                          Sys_codusu_usux = invajustesmaema.sys_codusu_usux,
                                          Inv_conreg_inja = (int)invajustesmaema.inv_conreg_inja,
                                          Sis_estpro_espr = invajustesmaema.sis_estpro_espr,
                                          Inv_desalm_inal = inal.inv_desalm_inal,
                                          Inv_desaju_incp = incp.inv_desaju_incp,
                                          Inv_descon_incm = incm.inv_descon_incm,
                                          Sia_desare_aser = aser.sia_desare_aser,
                                          Sys_nomusu_usux = usux.sys_nomusu_usux,
                                          Sis_despro_espr = espr.sis_despro_espr,
                                          #endregion
                                      };
                    return lobConsulta.ToList();
                }
            }
        }
        #endregion
        #endregion
    }
    #endregion
    #region Modelo Ajuste Inventario Detalles
    /// <summary>
    /// Descripcion para la Vista de  la tabla: invajustesmaemd
    /// </summary>
    public class ModeloInvajustesmaemd : clBaseInpc
    {
        #region Modelo Attributos
        private static DbAplicacion _context;
        #region Modelo Propiedades Notificacion
        #region Inv_secreg_injd: Codigo registro
        private String _inv_secreg_injd;
        /// <summary>
        /// <para>TABLA: invajustesmaemd</para>
        /// <para>TABLA NATIVA: invajustesmaemd</para>
        /// <para>CAMPO: Codigo registro</para>
        /// <para>NOMBRE: inv_secreg_injd (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        /// Secuencial unico para cada registro detalles ajuste inventario
        /// (generado por el sistema)
        /// </para>
        /// </summary>
        public String Inv_secreg_injd
        {
            get { return _inv_secreg_injd; }
            set
            {
                if (_inv_secreg_injd == value) return;
                _inv_secreg_injd = value;
                OnPropertyChanged("Inv_secreg_injd");
            }
        }
        #endregion
        #region Inv_secreg_inja: Registro maestro
        private String _inv_secreg_inja;
        /// <summary>
        /// <para>TABLA: invajustesmaemd</para>
        /// <para>TABLA NATIVA: invajustesmaema</para>
        /// <para>CAMPO: Registro maestro</para>
        /// <para>NOMBRE: inv_secreg_inja (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Secuencial unico para cada registro maestro ajuste inventario
        /// viene de la tabla  INVAJUSTESMAEMA
        /// </para>
        /// </summary>
        public String Inv_secreg_inja
        {
            get { return _inv_secreg_inja; }
            set
            {
                if (_inv_secreg_inja == value) return;
                _inv_secreg_inja = value;
                OnPropertyChanged("Inv_secreg_inja");
            }
        }
        #endregion
        #region Inv_fecges_inja: Fecha ajuste
        private DateTime _inv_fecges_inja;
        /// <summary>
        /// <para>TABLA: invajustesmaemd</para>
        /// <para>TABLA NATIVA: invajustesmaema</para>
        /// <para>CAMPO: Fecha ajuste</para>
        /// <para>NOMBRE: inv_fecges_inja (fecha:)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        ///Fecha gestion registro ajuste y  movimientos al inventario
        /// </para>
        /// </summary>
        public DateTime Inv_fecges_inja
        {
            get { return _inv_fecges_inja; }
            set
            {
                if (_inv_fecges_inja == value) return;
                _inv_fecges_inja = value;
                OnPropertyChanged("Inv_fecges_inja");
            }
        }
        #endregion
        #region Inv_codalm_inal: Código Almacén
        private String _inv_codalm_inal;
        /// <summary>
        /// <para>TABLA: invajustesmaemd</para>
        /// <para>TABLA NATIVA: invalmacenmaest</para>
        /// <para>CAMPO: Código Almacén</para>
        /// <para>NOMBRE: inv_codalm_inal (char:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        ///Código del Almacén para el que se realiza el ajuste
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
        #region Inv_secart_inar: Secuencial Articulo
        private String _inv_secart_inar;
        /// <summary>
        /// <para>TABLA: invajustesmaemd</para>
        /// <para>TABLA NATIVA: invmaearticulos</para>
        /// <para>CAMPO: Secuencial Articulo</para>
        /// <para>NOMBRE: inv_secart_inar (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
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
        #region Inv_codaux_inar: Código Auxiliar Articulo
        private String _inv_codaux_inar;
        /// <summary>
        /// <para>TABLA: invajustesmaemd</para>
        /// <para>TABLA NATIVA: invmaearticulos</para>
        /// <para>CAMPO: Código Auxiliar Articulo</para>
        /// <para>NOMBRE: inv_codaux_inar (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
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
        #region Sis_codgme_sigr: Patrón medida
        private String _sis_codgme_sigr;
        /// <summary>
        /// <para>TABLA: invajustesmaemd</para>
        /// <para>TABLA NATIVA: sisgrupomedidas</para>
        /// <para>CAMPO: Patrón medida</para>
        /// <para>NOMBRE: sis_codgme_sigr (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
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
        #region Inv_codest_ines: Código Estante
        private String _inv_codest_ines;
        /// <summary>
        /// <para>TABLA: invajustesmaemd</para>
        /// <para>TABLA NATIVA: invalmacenestan</para>
        /// <para>CAMPO: Código Estante</para>
        /// <para>NOMBRE: inv_codest_ines (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 13</para>
        /// <para>DESCRIPCION:
        /// Codgo del estante para cada almacen: Ejemplo E01-Estante Medicamentos
        /// de control
        /// </para>
        /// </summary>
        public String Inv_codest_ines
        {
            get { return _inv_codest_ines; }
            set
            {
                if (_inv_codest_ines == value) return;
                _inv_codest_ines = value;
                OnPropertyChanged("Inv_codest_ines");
            }
        }
        #endregion
        #region Inv_seccio_ines: Secciones
        private String _inv_seccio_ines;
        /// <summary>
        /// <para>TABLA: invajustesmaemd</para>
        /// <para>TABLA NATIVA: invalmacenestan</para>
        /// <para>CAMPO: Secciones</para>
        /// <para>NOMBRE: inv_seccio_ines (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 14</para>
        /// <para>DESCRIPCION:
        /// Lista de secciones del estante para validacion (generada por
        /// el sistema) ejemplo: S01,S02,S03,S04 según el numero de secciones
        /// que contenga el estante
        /// </para>
        /// </summary>
        public String Inv_seccio_ines
        {
            get { return _inv_seccio_ines; }
            set
            {
                if (_inv_seccio_ines == value) return;
                _inv_seccio_ines = value;
                OnPropertyChanged("Inv_seccio_ines");
            }
        }
        #endregion
        #region Inv_totuni_inex: existencias alamacen
        private int _inv_totuni_inex;
        /// <summary>
        /// <para>TABLA: invajustesmaemd</para>
        /// <para>TABLA NATIVA: invalmacexisten</para>
        /// <para>CAMPO: existencias alamacen</para>
        /// <para>NOMBRE: inv_totuni_inex (int:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 12</para>
        /// <para>DESCRIPCION:
        /// TOTAL UNIDADES EN ALMACEN, cantidad de unidades en existencias
        /// fisicas desde almacen (teniendo en cuenta el lote)
        /// </para>
        /// </summary>
        public int Inv_totuni_inex
        {
            get { return _inv_totuni_inex; }
            set
            {
                if (_inv_totuni_inex == value) return;
                _inv_totuni_inex = value;
                OnPropertyChanged("Inv_totuni_inex");
            }
        }
        #endregion       
        #region Inv_totuni_injd: Nuevo total existencias
        private int _inv_totuni_injd;
        /// <summary>
        /// <para>TABLA: invajustesmaemd</para>
        /// <para>TABLA NATIVA: invajustesmaemd</para>
        /// <para>CAMPO: Nuevo total existencias</para>
        /// <para>NOMBRE: inv_totuni_injd (int:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 15</para>
        /// <para>DESCRIPCION:
        /// NUEVO TOTAL EXISTENCIAS ALAMACEN, despues de haber realizado
        /// el calculo de ajuste este campo contiene la nueva cantidad
        /// existencias almacen para el lote
        /// </para>
        /// </summary>
        public int Inv_totuni_injd
        {
            get { return _inv_totuni_injd; }
            set
            {
                if (_inv_totuni_injd == value) return;
                _inv_totuni_injd = value;
                OnPropertyChanged("Inv_totuni_injd");
            }
        }
        #endregion
        #region Inv_valing_inar: Valor  Ingreso unidad
        private float _inv_valing_inar;
        /// <summary>
        /// <para>TABLA: invajustesmaemd</para>
        /// <para>TABLA NATIVA: invmaearticulos</para>
        /// <para>CAMPO: Valor  Ingreso unidad</para>
        /// <para>NOMBRE: inv_valing_inar (float:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 16</para>
        /// <para>DESCRIPCION:
        /// Ultimo valor Ingreso unidad de articulos en inventario, por
        /// compras
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
        #region Inv_valmov_inar: Valor salida unidad
        private float _inv_valmov_inar;
        /// <summary>
        /// <para>TABLA: invajustesmaemd</para>
        /// <para>TABLA NATIVA: invmaearticulos</para>
        /// <para>CAMPO: Valor salida unidad</para>
        /// <para>NOMBRE: inv_valmov_inar (float:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 17</para>
        /// <para>DESCRIPCION:
        /// ultimo Valor Movimiento de salida (valor venta) cada unidad
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
        #region Sis_estpro_espr: Estado Registro
        private String _sis_estpro_espr;
        /// <summary>
        /// <para>TABLA: invajustesmaemd</para>
        /// <para>TABLA NATIVA: sisestadoproces</para>
        /// <para>CAMPO: Estado Registro</para>
        /// <para>NOMBRE: sis_estpro_espr (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 18</para>
        /// <para>DESCRIPCION:
        ///Estado del registro: 1=Abierto 2=Confirmado 3=Anulado
        /// </para>
        /// </summary>
        public String Sis_estpro_espr
        {
            get { return _sis_estpro_espr; }
            set
            {
                if (_sis_estpro_espr == value) return;
                _sis_estpro_espr = value;
                OnPropertyChanged("Sis_estpro_espr");
            }
        }
        #endregion
        #region Inv_nomart_inar: Nombre artículo
        private String _inv_nomart_inar;
        /// <summary>
        /// <para>TABLA: invajustesmaemd</para>
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
        #region Sis_desgme_sigr: Descripción Grupo medida
        private String _sis_desgme_sigr;
        /// <summary>
        /// <para>TABLA: invajustesmaemd</para>
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
        /// <para>TABLA: invajustesmaemd</para>
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
        #region Sis_despro_espr: Decripción estado proceso
        private String _sis_despro_espr;
        /// <summary>
        /// <para>TABLA: invajustesmaemd</para>
        /// <para>TABLA NATIVA: sisestadoproces</para>
        /// <para>CAMPO: Decripción estado proceso</para>
        /// <para>NOMBRE: sis_despro_espr (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Descripcion textual del estado de proceso Abierto(a), Cerrado(a)
        /// Y Anulado(a)
        /// </para>
        /// </summary>
        public String Sis_despro_espr
        {
            get { return _sis_despro_espr; }
            set
            {
                if (_sis_despro_espr == value) return;
                _sis_despro_espr = value;
                OnPropertyChanged("Sis_despro_espr");
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
        #endregion
        #region Metodos para edicion de registros
        #region Adicionar Registro Relacion
        public static String lcrAddRegistro(ModeloInvajustesmaemd tobTempReg, String tcrCodigoR1)
        {
            var lobEFReg = new EFinvajustesmaemd();            
            try
            {
                using (_context = new DbAplicacion())
                {                                
                    if (tobTempReg.Sis_estado_imaen == "M")
                    {
                        lobEFReg = _context.Invajustesmaemd.FirstOrDefault(p => p.inv_secreg_injd == tobTempReg.Inv_secreg_injd);
                    }
                    if (tobTempReg.Sis_estado_imaen == "A" || tobTempReg.Sis_estado_imaen == "M") // Adicionar o Modificar
                    {
                        #region cargar Registro
                        if (lobEFReg != null)
                        {
                            lobEFReg.inv_secreg_injd = tobTempReg.Inv_secreg_injd;
                            lobEFReg.inv_secreg_inja = tobTempReg.Inv_secreg_inja;
                            lobEFReg.inv_fecges_inja = (DateTime)tobTempReg.Inv_fecges_inja;
                            lobEFReg.inv_codalm_inal = tobTempReg.Inv_codalm_inal;                                                       
                            lobEFReg.inv_secart_inar = tobTempReg.Inv_secart_inar;
                            lobEFReg.inv_codaux_inar = tobTempReg.Inv_codaux_inar;                            
                            lobEFReg.sis_codgme_sigr = tobTempReg.Sis_codgme_sigr;                           
                            lobEFReg.inv_totuni_inex = (int)tobTempReg.Inv_totuni_inex;                                                      
                            lobEFReg.inv_totuni_injd = (int)tobTempReg.Inv_totuni_injd;
                            lobEFReg.inv_valing_inar = (float)tobTempReg.Inv_valing_inar;
                            lobEFReg.inv_valmov_inar = (float)tobTempReg.Inv_valmov_inar;
                            lobEFReg.sis_estpro_espr = tobTempReg.Sis_estpro_espr;
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
                                lobEFReg.inv_secreg_injd = tcrCodigoR1 + lobEFReg.inv_secreg_injd; // concatenar
                                _context.AddToInvajustesmaemd(lobEFReg);
                                _context.SaveChanges();
                                break;

                            case "M": // Modificar el registro
                                _context.SaveChanges();
                                break;

                            case "E": // Eliminar el registro
                                var lobjRegistro = _context.Invajustesmaemd.FirstOrDefault(p => p.inv_secreg_injd == tobTempReg.Inv_secreg_injd);
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
                MessageBox.Show(ex.Message, "Modelo Error Metodo: flgAddRegistro");
            }
            return lobEFReg.inv_secreg_injd;
        }
        #endregion
        #region Buscar INVAJUSTESMAEMD: Logica
        /// <summary>
        /// <para>TABLA: invajustesmaemd</para>
        /// <para>TITULO: Registros tipo detalles para ajustes de inventario</para>
        /// <para>MODULO: INV</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Registros tipo detalles para archivo maestro INVAJUSTESMAEMA,
        /// ajustes de inventarios
        /// </para>
        /// </summary>
        public static bool flgBuscarInvajustesmaemd(String tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Invajustesmaemd.FirstOrDefault(p => p.inv_secreg_injd == tcrCodigo);
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
        /// //Modelo Detalles Ajuste Intentario: Lista de Registros
        /// </summary>
        /// <param name="tcrBuscar"></param>
        /// <returns></returns>
        public static List<ModeloInvajustesmaemd> flsListaInvajustesmaemd(String tcrBuscar)
        {
            using (_context = new DbAplicacion())
            {
                var lobConsulta = from invajustesmaemd in _context.Invajustesmaemd                                  
                                  join invmaearticulos in _context.Invmaearticulos on invajustesmaemd.inv_secart_inar equals invmaearticulos.inv_secart_inar into tminvmaearticulos
                                  join sisgrupomedidas in _context.Sisgrupomedidas on invajustesmaemd.sis_codgme_sigr equals sisgrupomedidas.sis_codgme_sigr into tmsisgrupomedidas                                  
                                  join sisestadoproces in _context.Sisestadoproces on invajustesmaemd.sis_estpro_espr equals sisestadoproces.sis_estpro_espr into tmsisestadoproces                                 
                                  from inar in tminvmaearticulos.DefaultIfEmpty()
                                  from sigr in tmsisgrupomedidas.DefaultIfEmpty()                                
                                  from espr in tmsisestadoproces.DefaultIfEmpty()
                                  where invajustesmaemd.inv_secreg_inja == tcrBuscar
                                  select new ModeloInvajustesmaemd
                                  {
                                      Inv_secreg_injd = invajustesmaemd.inv_secreg_injd,
                                      Inv_secreg_inja = invajustesmaemd.inv_secreg_inja,
                                      Inv_fecges_inja = (DateTime)invajustesmaemd.inv_fecges_inja,
                                      Inv_codalm_inal = invajustesmaemd.inv_codalm_inal,                                                                          
                                      Inv_secart_inar = invajustesmaemd.inv_secart_inar,
                                      Inv_codaux_inar = invajustesmaemd.inv_codaux_inar,                                     
                                      Sis_codgme_sigr = invajustesmaemd.sis_codgme_sigr,                                     
                                      Inv_totuni_inex = (int)invajustesmaemd.inv_totuni_inex,                                                                          
                                      Inv_totuni_injd = (int)invajustesmaemd.inv_totuni_injd,
                                      Inv_valing_inar = (float)invajustesmaemd.inv_valing_inar,
                                      Inv_valmov_inar = (float)invajustesmaemd.inv_valmov_inar,
                                      Sis_estpro_espr = invajustesmaemd.sis_estpro_espr,
                                      Inv_nomart_inar = inar.inv_nomart_inar,
                                      Sis_desgme_sigr = sigr.sis_desgme_sigr,
                                      //Sis_desume_sium = _context.Sisunidadmedida.FirstOrDefault(rxp => rxp.sis_codume_sium == invajustesmaemd.sis_codume_sium).sis_desume_sium,                         
                                      Sis_despro_espr = espr.sis_despro_espr,
                                      Sis_estado_imaen = "I",
                                  };
                return lobConsulta.ToList();
            }
        }
        #endregion
        #region Temporal con datos agrupados por Estantes
        public static List<ModeloInvajustesmaemd> flsListaInvajustesmaemdRpt(string tcrCodigoRegistroMaestro)
        {
            using (_context = new DbAplicacion())
            {
                var lobConsulta = (from invajustesmaemd in _context.Invajustesmaemd
                                   join invmaearticulos in _context.Invmaearticulos on invajustesmaemd.inv_secart_inar equals invmaearticulos.inv_secart_inar into tminvmaearticulos
                                   join sisgrupomedidas in _context.Sisgrupomedidas on invajustesmaemd.sis_codgme_sigr equals sisgrupomedidas.sis_codgme_sigr into tmsisgrupomedidas
                                   join sisestadoproces in _context.Sisestadoproces on invajustesmaemd.sis_estpro_espr equals sisestadoproces.sis_estpro_espr into tmsisestadoproces
                                   from inar in tminvmaearticulos.DefaultIfEmpty()
                                   from sigr in tmsisgrupomedidas.DefaultIfEmpty()
                                   from espr in tmsisestadoproces.DefaultIfEmpty()
                                   where invajustesmaemd.inv_secreg_inja == tcrCodigoRegistroMaestro
                                   orderby inar.inv_codgru_ingr, invajustesmaemd.inv_secart_inar
                                   select new ModeloInvajustesmaemd
                                   {
                                       #region Datos
                                       Inv_secreg_injd = invajustesmaemd.inv_secreg_injd,
                                       Inv_secreg_inja = invajustesmaemd.inv_secreg_inja,
                                       Inv_fecges_inja = (DateTime)invajustesmaemd.inv_fecges_inja,
                                       Inv_codalm_inal = invajustesmaemd.inv_codalm_inal,
                                       Inv_secart_inar = invajustesmaemd.inv_secart_inar,
                                       Inv_codaux_inar = invajustesmaemd.inv_codaux_inar,
                                       Sis_codgme_sigr = invajustesmaemd.sis_codgme_sigr,
                                       Inv_totuni_inex = (int)invajustesmaemd.inv_totuni_inex,
                                       Inv_totuni_injd = (int)invajustesmaemd.inv_totuni_injd,
                                       Inv_valing_inar = (float)invajustesmaemd.inv_valing_inar,
                                       Inv_valmov_inar = (float)invajustesmaemd.inv_valmov_inar,
                                       Sis_estpro_espr = invajustesmaemd.sis_estpro_espr,
                                       Inv_nomart_inar = inar.inv_nomart_inar,
                                       Sis_desgme_sigr = sigr.sis_desgme_sigr,
                                       //Sis_desume_sium = _context.Sisunidadmedida.FirstOrDefault(rxp => rxp.sis_codume_sium == invajustesmaemd.sis_codume_sium).sis_desume_sium,                         
                                       Sis_despro_espr = espr.sis_despro_espr,
                                       Sis_estado_imaen = "I",
                                   }).ToList();
                                       #endregion

                return lobConsulta;
            }
        }
        #endregion
        #endregion
    }
    #endregion
    #region Modelo Registros tipo detalles lotes o referencias kardex
    /// <summary>
    /// Descripcion para la Vista de  la tabla: invajustesmaemr
    /// </summary>
    public class ModeloInvajustesmaemr : clBaseInpc
    {
        #region Modelo Attributos
        private static DbAplicacion _context;
        #region Modelo Propiedades Notificacion
        #region Inv_secreg_injr: Codigo registro
        private String _inv_secreg_injr;
        /// <summary>
        /// <para>TABLA: invajustesmaemr</para>
        /// <para>TABLA NATIVA: invajustesmaemr</para>
        /// <para>CAMPO: Codigo registro</para>
        /// <para>NOMBRE: inv_secreg_injr (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        ///Secuencial unico registro lote referencia
        /// </para>
        /// </summary>
        public String Inv_secreg_injr
        {
            get { return _inv_secreg_injr; }
            set
            {
                if (_inv_secreg_injr == value) return;
                _inv_secreg_injr = value;
                OnPropertyChanged("Inv_secreg_injr");
            }
        }
        #endregion
        #region Inv_secreg_injd: Registro Detalle ajuste
        private String _inv_secreg_injd;
        /// <summary>
        /// <para>TABLA: invajustesmaemr</para>
        /// <para>TABLA NATIVA: invajustesmaemd</para>
        /// <para>CAMPO: Registro Detalle ajuste</para>
        /// <para>NOMBRE: inv_secreg_injd (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Secuencial unico para cada registro detalles ajuste inventario,
        /// referencia del ajuste articulo
        /// </para>
        /// </summary>
        public String Inv_secreg_injd
        {
            get { return _inv_secreg_injd; }
            set
            {
                if (_inv_secreg_injd == value) return;
                _inv_secreg_injd = value;
                OnPropertyChanged("Inv_secreg_injd");
            }
        }
        #endregion
        #region Inv_secreg_inja: Registro maestro
        private String _inv_secreg_inja;
        /// <summary>
        /// <para>TABLA: invajustesmaemr</para>
        /// <para>TABLA NATIVA: invajustesmaema</para>
        /// <para>CAMPO: Registro maestro</para>
        /// <para>NOMBRE: inv_secreg_inja (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        /// Secuencial unico para cada registro maestro ajuste inventario
        /// viene de la tabla  INVAJUSTESMAEMA
        /// </para>
        /// </summary>
        public String Inv_secreg_inja
        {
            get { return _inv_secreg_inja; }
            set
            {
                if (_inv_secreg_inja == value) return;
                _inv_secreg_inja = value;
                OnPropertyChanged("Inv_secreg_inja");
            }
        }
        #endregion
        #region Inv_codalm_inal: Código Almacén
        private String _inv_codalm_inal;
        /// <summary>
        /// <para>TABLA: invajustesmaemr</para>
        /// <para>TABLA NATIVA: invalmacenmaest</para>
        /// <para>CAMPO: Código Almacén</para>
        /// <para>NOMBRE: inv_codalm_inal (char:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        ///Código del Almacén para el que se realiza el ajuste
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
        #region Inv_tipmov_intr: Tipo movimiento
        private String _inv_tipmov_intr;
        /// <summary>
        /// <para>TABLA: invajustesmaemr</para>
        /// <para>TABLA NATIVA: invtiporegimovi</para>
        /// <para>CAMPO: Tipo movimiento</para>
        /// <para>NOMBRE: inv_tipmov_intr (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        /// Tipo registro movimiento inventarios: 1= Entradas 2= Salidas
        /// desde tabla: INVTIPOREGIMOVI, este campo se cambia al realizar
        /// el calculo de cantidad en sistema y cantidad digitada para
        /// ajuste
        /// </para>
        /// </summary>
        public String Inv_tipmov_intr
        {
            get { return _inv_tipmov_intr; }
            set
            {
                if (_inv_tipmov_intr == value) return;
                _inv_tipmov_intr = value;
                OnPropertyChanged("Inv_tipmov_intr");
            }
        }
        #endregion
        #region Inv_seckar_inka: Registro kardex
        private String _inv_seckar_inka;
        /// <summary>
        /// <para>TABLA: invajustesmaemr</para>
        /// <para>TABLA NATIVA: invkardexmaestr</para>
        /// <para>CAMPO: Registro kardex</para>
        /// <para>NOMBRE: inv_seckar_inka (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        /// Referencia al Secuencial unico del registro en maestro kardex
        /// INVKARDEXMAESTR, que se afecta con el ajuste
        /// </para>
        /// </summary>
        public String Inv_seckar_inka
        {
            get { return _inv_seckar_inka; }
            set
            {
                if (_inv_seckar_inka == value) return;
                _inv_seckar_inka = value;
                OnPropertyChanged("Inv_seckar_inka");
            }
        }
        #endregion
        #region Inv_secart_inar: Secuencial Articulo
        private String _inv_secart_inar;
        /// <summary>
        /// <para>TABLA: invajustesmaemr</para>
        /// <para>TABLA NATIVA: invmaearticulos</para>
        /// <para>CAMPO: Secuencial Articulo</para>
        /// <para>NOMBRE: inv_secart_inar (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
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
        #region Inv_codaux_inar: Código Auxiliar Articulo
        private String _inv_codaux_inar;
        /// <summary>
        /// <para>TABLA: invajustesmaemr</para>
        /// <para>TABLA NATIVA: invmaearticulos</para>
        /// <para>CAMPO: Código Auxiliar Articulo</para>
        /// <para>NOMBRE: inv_codaux_inar (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
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
        #region Inv_lotref_inar: Lote o Referencia
        private String _inv_lotref_inar;
        /// <summary>
        /// <para>TABLA: invajustesmaemr</para>
        /// <para>TABLA NATIVA: invmaearticulos</para>
        /// <para>CAMPO: Lote o Referencia</para>
        /// <para>NOMBRE: inv_lotref_inar (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
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
        #region Inv_conmov_incm: Concepto Movimiento
        private String _inv_conmov_incm;
        /// <summary>
        /// <para>TABLA: invajustesmaemr</para>
        /// <para>TABLA NATIVA: invtipoconcemov</para>
        /// <para>CAMPO: Concepto Movimiento</para>
        /// <para>NOMBRE: inv_conmov_incm (char:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        /// Concepto movimiento diario: E11 =Entrada saldo inicial inventario
        /// o del mes E12= Entradas compras ...  S21= Salidas Ventas 22=
        /// Salidas Traslado S23= Salidas Otras Áreas Empresa S24= Salida
        /// entrega formula A30=Ajuste de inventarios y otros
        /// </para>
        /// </summary>
        public String Inv_conmov_incm
        {
            get { return _inv_conmov_incm; }
            set
            {
                if (_inv_conmov_incm == value) return;
                _inv_conmov_incm = value;
                OnPropertyChanged("Inv_conmov_incm");
            }
        }
        #endregion
        #region Inv_fecven_inka: Fecha vencimiento
        private DateTime _inv_fecven_inka;
        /// <summary>
        /// <para>TABLA: invajustesmaemr</para>
        /// <para>TABLA NATIVA: invkardexmaestr</para>
        /// <para>CAMPO: Fecha vencimiento</para>
        /// <para>NOMBRE: inv_fecven_inka (fecha:8)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
        /// <para>DESCRIPCION:
        /// Fecha vencimiento del producto, cuando sea perecedero (Verdura/Medicament
        /// os y otros)
        /// </para>
        /// </summary>
        public DateTime Inv_fecven_inka
        {
            get { return _inv_fecven_inka; }
            set
            {
                if (_inv_fecven_inka == value) return;
                _inv_fecven_inka = value;
                OnPropertyChanged("Inv_fecven_inka");
            }
        }
        #endregion
        #region Inv_codest_ines: Código Estante
        private String _inv_codest_ines;
        /// <summary>
        /// <para>TABLA: invajustesmaemr</para>
        /// <para>TABLA NATIVA: invalmacenestan</para>
        /// <para>CAMPO: Código Estante</para>
        /// <para>NOMBRE: inv_codest_ines (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 11</para>
        /// <para>DESCRIPCION:
        /// Codgo del estante para cada almacen: Ejemplo E01-Estante Medicamentos
        /// de control
        /// </para>
        /// </summary>
        public String Inv_codest_ines
        {
            get { return _inv_codest_ines; }
            set
            {
                if (_inv_codest_ines == value) return;
                _inv_codest_ines = value;
                OnPropertyChanged("Inv_codest_ines");
            }
        }
        #endregion
        #region Inv_seccio_ines: Secciones
        private String _inv_seccio_ines;
        /// <summary>
        /// <para>TABLA: invajustesmaemr</para>
        /// <para>TABLA NATIVA: invalmacenestan</para>
        /// <para>CAMPO: Secciones</para>
        /// <para>NOMBRE: inv_seccio_ines (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 12</para>
        /// <para>DESCRIPCION:
        /// Lista de secciones del estante para validacion (generada por
        /// el sistema) ejemplo: S01,S02,S03,S04 según el numero de secciones
        /// que contenga el estante
        /// </para>
        /// </summary>
        public String Inv_seccio_ines
        {
            get { return _inv_seccio_ines; }
            set
            {
                if (_inv_seccio_ines == value) return;
                _inv_seccio_ines = value;
                OnPropertyChanged("Inv_seccio_ines");
            }
        }
        #endregion
        #region Inv_totuni_inex: existencias alamacen
        private int _inv_totuni_inex;
        /// <summary>
        /// <para>TABLA: invajustesmaemr</para>
        /// <para>TABLA NATIVA: invalmacexisten</para>
        /// <para>CAMPO: existencias alamacen</para>
        /// <para>NOMBRE: inv_totuni_inex (int:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 13</para>
        /// <para>DESCRIPCION:
        /// TOTAL UNIDADES EN ALMACEN, cantidad de unidades en existencias 
        /// Kardex almacen (teniendo en cuenta el lote)
        /// </para>
        /// </summary>
        public int Inv_totuni_inex
        {
            get { return _inv_totuni_inex; }
            set
            {
                if (_inv_totuni_inex == value) return;
                _inv_totuni_inex = value;
                OnPropertyChanged("Inv_totuni_inex");
            }
        }
        #endregion
        #region Inv_totaju_injd: Unidades digitadas
        private int _inv_totaju_injd;
        /// <summary>
        /// <para>TABLA: invajustesmaemr</para>
        /// <para>TABLA NATIVA: invajustesmaemd</para>
        /// <para>CAMPO: Unidades digitadas</para>
        /// <para>NOMBRE: inv_totaju_injd (int:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 14</para>
        /// <para>DESCRIPCION:
        /// UNIDADES DIGITADAS, cantidad de unidades (lo que existe en Estantes)
        /// digitadas para realizar calculo según tipo ajuste 
        /// 1= Reconteo Total inventario 2= Por suma o Resta de Unidades
        /// </para>
        /// </summary>
        public int Inv_totaju_injd
        {
            get { return _inv_totaju_injd; }
            set
            {
                if (_inv_totaju_injd == value) return;
                _inv_totaju_injd = value;
                OnPropertyChanged("Inv_totaju_injd");
            }
        }
        #endregion
        #region Inv_totmov_injd: Unidades Movimiento
        private int _inv_totmov_injd;
        /// <summary>
        /// <para>TABLA: invajustesmaemr</para>
        /// <para>TABLA NATIVA: invajustesmaemd</para>
        /// <para>CAMPO: Unidades Movimiento</para>
        /// <para>NOMBRE: inv_totmov_injd (int:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 15</para>
        /// <para>DESCRIPCION:
        /// UNIDADES MOVIMIENTO, Cantidad movimiento para Kardex, según
        /// tipo ajuste (1=reconteo/2=suma o resta unidades) si es reconteo:
        /// INV_TOTUNI_INEX - INV_TOTAJU_INJD, Cuando es suma o resta viene
        /// de cantidad de unidades digitadas INV_TOTAJU_INJD
        /// </para>
        /// </summary>
        public int Inv_totmov_injd
        {
            get { return _inv_totmov_injd; }
            set
            {
                if (_inv_totmov_injd == value) return;
                _inv_totmov_injd = value;
                OnPropertyChanged("Inv_totmov_injd");
            }
        }
        #endregion
        #region Inv_totuni_injd: Nuevo total existencias
        private int _inv_totuni_injd;
        /// <summary>
        /// <para>TABLA: invajustesmaemr</para>
        /// <para>TABLA NATIVA: invajustesmaemd</para>
        /// <para>CAMPO: Nuevo total existencias</para>
        /// <para>NOMBRE: inv_totuni_injd (int:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 16</para>
        /// <para>DESCRIPCION:
        /// NUEVO TOTAL EXISTENCIAS ALAMACEN, despues de haber realizado
        /// el calculo de ajuste este campo contiene la nueva cantidad
        /// existencias almacen para el lote
        /// </para>
        /// </summary>
        public int Inv_totuni_injd
        {
            get { return _inv_totuni_injd; }
            set
            {
                if (_inv_totuni_injd == value) return;
                _inv_totuni_injd = value;
                OnPropertyChanged("Inv_totuni_injd");
            }
        }
        #endregion
        #region Inv_valing_inar: Valor  Ingreso unidad
        private float _inv_valing_inar;
        /// <summary>
        /// <para>TABLA: invajustesmaemr</para>
        /// <para>TABLA NATIVA: invmaearticulos</para>
        /// <para>CAMPO: Valor  Ingreso unidad</para>
        /// <para>NOMBRE: inv_valing_inar (float:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 17</para>
        /// <para>DESCRIPCION:
        /// Ultimo valor Ingreso unidad de articulos en inventario, por
        /// compras
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
        #region Inv_valmov_inar: Valor salida unidad
        private float _inv_valmov_inar;
        /// <summary>
        /// <para>TABLA: invajustesmaemr</para>
        /// <para>TABLA NATIVA: invmaearticulos</para>
        /// <para>CAMPO: Valor salida unidad</para>
        /// <para>NOMBRE: inv_valmov_inar (float:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 18</para>
        /// <para>DESCRIPCION:
        /// ultimo Valor Movimiento de salida (valor venta) cada unidad
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
        #region Sis_estpro_espr: Estado Registro
        private String _sis_estpro_espr;
        /// <summary>
        /// <para>TABLA: invajustesmaemr</para>
        /// <para>TABLA NATIVA: </para>
        /// <para>CAMPO: Estado Registro</para>
        /// <para>NOMBRE: sis_estpro_espr (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 19</para>
        /// <para>DESCRIPCION:
        ///Estado del registro: 1=Abierto 2=Confirmado 3=Anulado
        /// </para>
        /// </summary>
        public String Sis_estpro_espr
        {
            get { return _sis_estpro_espr; }
            set
            {
                if (_sis_estpro_espr == value) return;
                _sis_estpro_espr = value;
                OnPropertyChanged("Sis_estpro_espr");
            }
        }
        #endregion
        #region Inv_desalm_inal: Descripción Almacén
        private String _inv_desalm_inal;
        /// <summary>
        /// <para>TABLA: invajustesmaemr</para>
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
        #region Inv_desreg_intr: Descripción tipo movimiento
        private String _inv_desreg_intr;
        /// <summary>
        /// <para>TABLA: invajustesmaemr</para>
        /// <para>TABLA NATIVA: invtiporegimovi</para>
        /// <para>CAMPO: Descripción tipo movimiento</para>
        /// <para>NOMBRE: inv_desreg_intr (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripción tipo registro
        /// </para>
        /// </summary>
        public String Inv_desreg_intr
        {
            get { return _inv_desreg_intr; }
            set
            {
                if (_inv_desreg_intr == value) return;
                _inv_desreg_intr = value;
                OnPropertyChanged("Inv_desreg_intr");
            }
        }
        #endregion
        #region Inv_nomart_inar: Nombre artículo
        private String _inv_nomart_inar;
        /// <summary>
        /// <para>TABLA: invajustesmaemr</para>
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
        #region Inv_codume_sium: Codigo unidad medida
        private String _inv_codume_sium;
        /// <summary>
        /// <para>TABLA: invajustesmaemr</para>
        /// <para>TABLA NATIVA: invmaearticulos</para>
        /// <para>CAMPO: Nombre artículo</para>
        /// <para>NOMBRE: inv_codume_sium (char:80)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION:
        ///Nombre del artículo para vista en informes y gestion
        /// </para>
        /// </summary>
        public String Inv_codume_sium
        {
            get { return _inv_codume_sium; }
            set
            {
                if (_inv_codume_sium == value) return;
                _inv_codume_sium = value;
                OnPropertyChanged("Inv_codume_sium");
            }
        }
        #endregion
        #region Inv_desume_sium: Descripcion unidad medida
        private String _inv_desume_sium;
        /// <summary>
        /// <para>TABLA: invajustesmaemr</para>
        /// <para>TABLA NATIVA: invmaearticulos</para>
        /// <para>CAMPO: Nombre artículo</para>
        /// <para>NOMBRE: inv_codume_sium (char:80)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION:
        ///Nombre del artículo para vista en informes y gestion
        /// </para>
        /// </summary>
        public String Inv_desume_sium
        {
            get { return _inv_desume_sium; }
            set
            {
                if (_inv_desume_sium == value) return;
                _inv_desume_sium = value;
                OnPropertyChanged("Inv_desume_sium");
            }
        }
        #endregion
        #region Inv_desest_ines: Descripción Estante
        private String _inv_desest_ines;
        /// <summary>
        /// <para>TABLA: invajustesmaemr</para>
        /// <para>TABLA NATIVA: invalmacenestan</para>
        /// <para>CAMPO: Descripción Estante</para>
        /// <para>NOMBRE: inv_desest_ines (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        /// Descripción del estante: Ejemplo E01-Estante Medicamentos de
        /// control
        /// </para>
        /// </summary>
        public String Inv_desest_ines
        {
            get { return _inv_desest_ines; }
            set
            {
                if (_inv_desest_ines == value) return;
                _inv_desest_ines = value;
                OnPropertyChanged("Inv_desest_ines");
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
        #region RefObjeto: Referencia objeto instancia en la vista
        /// <summary>
        /// Referencia objeto instancia en la vista
        /// </summary>
        public FrameworkElement RefObjeto { get; set; }
        #endregion
        #endregion
        #endregion
        #region Metodos para edicion de registros
        #region Adicionar Registros Existencias
        public static bool flgAddRegistro(ModeloInvajustesmaemr tobTempReg, String tcrCodigoR1)
        {
            bool llgReturn = false;
            try
            {                
                using (_context = new DbAplicacion())
                {
                    llgReturn = true;
                    var lobEFReg = new EFinvajustesmaemr();
                    //-----------------------
                    if (tobTempReg.Sis_estado_imaen == "M")
                    {
                        lobEFReg = _context.Invajustesmaemr.FirstOrDefault(p => p.inv_secreg_injr == tobTempReg.Inv_secreg_injr);
                    }
                    if (tobTempReg.Sis_estado_imaen == "A" || tobTempReg.Sis_estado_imaen == "M") // Adicionar o Modificar
                    {                      
                        #region cargar Registro
                        if (lobEFReg != null)
                        {
                            lobEFReg.inv_secreg_injr = tobTempReg.Inv_secreg_injr;
                            lobEFReg.inv_secreg_injd = tobTempReg.Inv_secreg_injd;
                            lobEFReg.inv_secreg_inja = tobTempReg.Inv_secreg_inja;
                            lobEFReg.inv_codalm_inal = tobTempReg.Inv_codalm_inal;
                            lobEFReg.inv_tipmov_intr = tobTempReg.Inv_tipmov_intr;
                            lobEFReg.inv_seckar_inka = tobTempReg.Inv_seckar_inka;
                            lobEFReg.inv_secart_inar = tobTempReg.Inv_secart_inar;
                            lobEFReg.inv_codaux_inar = tobTempReg.Inv_codaux_inar;
                            lobEFReg.inv_lotref_inar = tobTempReg.Inv_lotref_inar;
                            lobEFReg.inv_fecven_inka = (DateTime)tobTempReg.Inv_fecven_inka;
                            lobEFReg.inv_codest_ines = tobTempReg.Inv_codest_ines;
                            lobEFReg.inv_seccio_ines = tobTempReg.Inv_seccio_ines;                  
                            lobEFReg.inv_totuni_inex = (int)tobTempReg.Inv_totuni_inex;
                            lobEFReg.inv_totaju_injd = (int)tobTempReg.Inv_totaju_injd;
                            lobEFReg.inv_totmov_injd = (int)tobTempReg.Inv_totmov_injd;
                            lobEFReg.inv_totuni_injd = (int)tobTempReg.Inv_totuni_injd;
                            lobEFReg.inv_valing_inar = (float)tobTempReg.Inv_valing_inar;
                            lobEFReg.inv_valmov_inar = (float)tobTempReg.Inv_valmov_inar;
                            lobEFReg.sis_estpro_espr = tobTempReg.Sis_estpro_espr;

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
                                lobEFReg.inv_secreg_injr = tcrCodigoR1 + lobEFReg.inv_secreg_injr; // concatenar
                                _context.AddToInvajustesmaemr(lobEFReg);
                                _context.SaveChanges();
                                break;

                            case "M": // Modificar el registro
                                _context.SaveChanges();
                                break;

                            case "E": // Eliminar el registro
                                var lobjRegistro = _context.Invajustesmaemr.FirstOrDefault(p => p.inv_secreg_injr == tobTempReg.Inv_secreg_injr);
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
        #region Buscar INVAJUSTESMAEMR: Logica
        /// <summary>
        /// <para>TABLA: invajustesmaemr</para>
        /// <para>TITULO: Registros tipo detalles lotes o referencias kardex</para>
        /// <para>MODULO: INV</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Registros tipo detalles para archivo lotes o referencias ajustados
        /// </para>
        /// </summary>
        public static bool flgBuscarInvajustesmaemr(String tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Invajustesmaemr.FirstOrDefault(p => p.inv_secreg_injr == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Listar Registros
        public static List<ModeloInvajustesmaemr> flsListaInvajustesmaemr(String tcrBuscar)
        {
            using (_context = new DbAplicacion())
            {
                var lobConsulta = from invajustesmaemr in _context.Invajustesmaemr                                 
                                  join invalmacenmaest in _context.Invalmacenmaest on invajustesmaemr.inv_codalm_inal equals invalmacenmaest.inv_codalm_inal into tminvalmacenmaest
                                  join invtiporegimovi in _context.Invtiporegimovi on invajustesmaemr.inv_tipmov_intr equals invtiporegimovi.inv_tipmov_intr into tminvtiporegimovi
                                  join invmaearticulos in _context.Invmaearticulos on invajustesmaemr.inv_secart_inar equals invmaearticulos.inv_secart_inar into tminvmaearticulos
                                  join invalmacenestan in _context.Invalmacenestan on invajustesmaemr.inv_codest_ines equals invalmacenestan.inv_secest_ines into tminvalmacenestan
                                  join sisestadoproces in _context.Sisestadoproces on invajustesmaemr.sis_estpro_espr equals sisestadoproces.sis_estpro_espr into tmsisestadoproces                                
                                  from inal in tminvalmacenmaest.DefaultIfEmpty()
                                  from intr in tminvtiporegimovi.DefaultIfEmpty()                                
                                  from inar in tminvmaearticulos.DefaultIfEmpty()
                                  from ines in tminvalmacenestan.DefaultIfEmpty()
                                  from espr in tmsisestadoproces.DefaultIfEmpty()
                                  where invajustesmaemr.inv_secreg_inja == tcrBuscar
                                  select new ModeloInvajustesmaemr
                                  {
                                      #region Datos
                                      Inv_secreg_injr = invajustesmaemr.inv_secreg_injr,
                                      Inv_secreg_injd = invajustesmaemr.inv_secreg_injd,
                                      Inv_secreg_inja = invajustesmaemr.inv_secreg_inja,
                                      Inv_codalm_inal = invajustesmaemr.inv_codalm_inal,
                                      Inv_tipmov_intr = invajustesmaemr.inv_tipmov_intr,
                                      Inv_seckar_inka = invajustesmaemr.inv_seckar_inka,
                                      Inv_secart_inar = invajustesmaemr.inv_secart_inar,
                                      Inv_codaux_inar = invajustesmaemr.inv_codaux_inar,
                                      Inv_lotref_inar = invajustesmaemr.inv_lotref_inar,
                                      Inv_fecven_inka = (DateTime)invajustesmaemr.inv_fecven_inka,
                                      Inv_codest_ines = invajustesmaemr.inv_codest_ines,
                                      Inv_seccio_ines = invajustesmaemr.inv_seccio_ines,
                                      Inv_totuni_inex = (int)invajustesmaemr.inv_totuni_inex,
                                      Inv_totaju_injd = (int)invajustesmaemr.inv_totaju_injd,
                                      Inv_totmov_injd = (int)invajustesmaemr.inv_totmov_injd,
                                      Inv_totuni_injd = (int)invajustesmaemr.inv_totuni_injd,
                                      Inv_valing_inar = (float)invajustesmaemr.inv_valing_inar,
                                      Inv_valmov_inar = (float)invajustesmaemr.inv_valmov_inar,
                                      Sis_estpro_espr = invajustesmaemr.sis_estpro_espr,
                                      Inv_desalm_inal = inal.inv_desalm_inal,
                                      Inv_desreg_intr = intr.inv_desreg_intr,
                                      Inv_nomart_inar = inar.inv_nomart_inar,
                                      //Sis_desume_sium = _context.Sisunidadmedida.FirstOrDefault(rxp => rxp.sis_codume_sium == invajustesmaemr.sis_codume_sium).sis_desume_sium,
                                      Inv_desest_ines = ines.inv_desest_ines,
                                      Sis_estado_imaen = "I",                                    
                                      #endregion
                                  };
                return lobConsulta.ToList();
            }
        }
    
        #endregion
        #region Temporal grilla lotes
        /// <summary>
        /// //Modelo Ajuste Inventario Registros Kardex: Temporal grilla lotes
        /// </summary>
        /// <param name="tcrBuscar"></param>
        /// <returns></returns>
        public static List<ModeloInvajustesmaemr> flsListaInvajustesmaemrLot(String tcrCodigoAlmacen, String tcrCodigoArticulo, String tcrSecuencialReg)
        {
            using (_context = new DbAplicacion())
            {
                var lobConsulta = from invajustesmaemr in _context.Invajustesmaemr
                                  join invalmacenmaest in _context.Invalmacenmaest on invajustesmaemr.inv_codalm_inal equals invalmacenmaest.inv_codalm_inal into tminvalmacenmaest
                                  join invmaearticulos in _context.Invmaearticulos on invajustesmaemr.inv_secart_inar equals invmaearticulos.inv_secart_inar into tminvmaearticulos
                                  join invtiporegimovi in _context.Invtiporegimovi on invajustesmaemr.inv_tipmov_intr equals invtiporegimovi.inv_tipmov_intr into tminvtiporegimovi
                                  join invalmacenestan in _context.Invalmacenestan on invajustesmaemr.inv_codest_ines equals invalmacenestan.inv_secest_ines into tminvalmacenestan
                                  from inal in tminvalmacenmaest.DefaultIfEmpty()
                                  from inar in tminvmaearticulos.DefaultIfEmpty()
                                  from ines in tminvalmacenestan.DefaultIfEmpty()
                                  from intr in tminvtiporegimovi.DefaultIfEmpty()
                                  where invajustesmaemr.inv_codalm_inal == tcrCodigoAlmacen  &&
                                        invajustesmaemr.inv_secart_inar == tcrCodigoArticulo &&
                                        invajustesmaemr.inv_secreg_inja == tcrSecuencialReg
                                  select new ModeloInvajustesmaemr
                                  {
                                      #region Datos
                                      Inv_secreg_injr = invajustesmaemr.inv_secreg_injr,
                                      Inv_secreg_injd = invajustesmaemr.inv_secreg_injd,
                                      Inv_secreg_inja = invajustesmaemr.inv_secreg_inja,
                                      Inv_codalm_inal = invajustesmaemr.inv_codalm_inal,
                                      Inv_tipmov_intr = invajustesmaemr.inv_tipmov_intr,
                                      Inv_seckar_inka = invajustesmaemr.inv_seckar_inka,
                                      Inv_secart_inar = invajustesmaemr.inv_secart_inar,
                                      Inv_codaux_inar = invajustesmaemr.inv_codaux_inar,
                                      Inv_lotref_inar = invajustesmaemr.inv_lotref_inar,
                                      Inv_fecven_inka = (DateTime)invajustesmaemr.inv_fecven_inka,
                                      Inv_codest_ines = invajustesmaemr.inv_codest_ines,
                                      Inv_seccio_ines = invajustesmaemr.inv_seccio_ines,
                                      Inv_totuni_inex = (int)invajustesmaemr.inv_totuni_inex,
                                      Inv_totaju_injd = (int)invajustesmaemr.inv_totaju_injd,
                                      Inv_totmov_injd = (int)invajustesmaemr.inv_totmov_injd,
                                      Inv_totuni_injd = (int)invajustesmaemr.inv_totuni_injd,
                                      Inv_valing_inar = (float)invajustesmaemr.inv_valing_inar,
                                      Inv_valmov_inar = (float)invajustesmaemr.inv_valmov_inar,
                                      Sis_estpro_espr = invajustesmaemr.sis_estpro_espr,
                                      Inv_desalm_inal = inal.inv_desalm_inal,
                                      Inv_desreg_intr = intr.inv_desreg_intr,
                                      Inv_nomart_inar = inar.inv_nomart_inar,
                                      //Sis_desume_sium = _context.Sisunidadmedida.FirstOrDefault(rxp => rxp.sis_codume_sium == invajustesmaemd.sis_codume_sium).sis_desume_sium,
                                      Inv_desest_ines = ines.inv_desest_ines,
                                      Sis_estado_imaen = "I",
                                      #endregion
                                  };
                return lobConsulta.ToList();
            }
        }
        #endregion
        #region Temporal con datos agrupados por Estantes
        public static List<ModeloInvajustesmaemr> flsListaInvajustesmaemrRpt(String tcrCodigoRegistroMaestro)
        {
            using (_context = new DbAplicacion())
            {
                var lobConsulta = (from invajustesmaemr in _context.Invajustesmaemr
                                   join invalmacenmaest in _context.Invalmacenmaest on invajustesmaemr.inv_codalm_inal equals invalmacenmaest.inv_codalm_inal into tminvalmacenmaest
                                   join invmaearticulos in _context.Invmaearticulos on invajustesmaemr.inv_secart_inar equals invmaearticulos.inv_secart_inar into tminvmaearticulos
                                   join invtiporegimovi in _context.Invtiporegimovi on invajustesmaemr.inv_tipmov_intr equals invtiporegimovi.inv_tipmov_intr into tminvtiporegimovi
                                   join invalmacenestan in _context.Invalmacenestan on invajustesmaemr.inv_codest_ines equals invalmacenestan.inv_secest_ines into tminvalmacenestan
                                   from inal in tminvalmacenmaest.DefaultIfEmpty()
                                   from inar in tminvmaearticulos.DefaultIfEmpty()
                                   from ines in tminvalmacenestan.DefaultIfEmpty()
                                   from intr in tminvtiporegimovi.DefaultIfEmpty()
                                   where invajustesmaemr.inv_secreg_inja == tcrCodigoRegistroMaestro
                                   orderby inar.inv_codgru_ingr, invajustesmaemr.inv_secart_inar
                                   select new ModeloInvajustesmaemr
                                   {
                                       #region Datos
                                       Inv_secreg_injr = invajustesmaemr.inv_secreg_injr,
                                       Inv_secreg_injd = invajustesmaemr.inv_secreg_injd,
                                       Inv_secreg_inja = invajustesmaemr.inv_secreg_inja,
                                       Inv_codalm_inal = invajustesmaemr.inv_codalm_inal,
                                       Inv_tipmov_intr = invajustesmaemr.inv_tipmov_intr,
                                       Inv_seckar_inka = invajustesmaemr.inv_seckar_inka,
                                       Inv_secart_inar = invajustesmaemr.inv_secart_inar,
                                       Inv_codaux_inar = invajustesmaemr.inv_codaux_inar,
                                       Inv_lotref_inar = invajustesmaemr.inv_lotref_inar,
                                       Inv_fecven_inka = (DateTime)invajustesmaemr.inv_fecven_inka,
                                       Inv_codest_ines = invajustesmaemr.inv_codest_ines,
                                       Inv_seccio_ines = invajustesmaemr.inv_seccio_ines,
                                       Inv_totuni_inex = (int)invajustesmaemr.inv_totuni_inex,
                                       Inv_totaju_injd = (int)invajustesmaemr.inv_totaju_injd,
                                       Inv_totmov_injd = (int)invajustesmaemr.inv_totmov_injd,
                                       Inv_totuni_injd = (int)invajustesmaemr.inv_totuni_injd,
                                       Inv_valing_inar = (float)invajustesmaemr.inv_valing_inar,
                                       Inv_valmov_inar = (float)invajustesmaemr.inv_valmov_inar,
                                       Sis_estpro_espr = invajustesmaemr.sis_estpro_espr,
                                       Inv_desalm_inal = inal.inv_desalm_inal,
                                       Inv_desreg_intr = intr.inv_desreg_intr,
                                       Inv_nomart_inar = inar.inv_nomart_inar,
                                       //Sis_desume_sium = _context.Sisunidadmedida.FirstOrDefault(rxp => rxp.sis_codume_sium == invajustesmaemd.sis_codume_sium).sis_desume_sium,
                                       Inv_desest_ines = ines.inv_desest_ines,
                                       Sis_estado_imaen = "I",
                                   }).ToList();
                                       #endregion

                return lobConsulta;
            }
        }
        #endregion
        #endregion
    }
    #endregion
}
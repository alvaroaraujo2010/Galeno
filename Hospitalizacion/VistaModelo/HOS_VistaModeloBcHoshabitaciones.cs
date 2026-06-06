//- MARMOTA-GENCODE: VERSION 2.0 - 21/02/2013 05:13:41 PM
using System;
using System.Windows;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Sistema.Utilidades;
using Sistema.Modelo;
using Datos.Modelos;
using Hospitalizacion.Modelo;

namespace Hospitalizacion.VistaModelo
{
    /// <summary>
    /// <para>TABLA: hoshabitaciones</para>
    /// <para>DESCRIPCION:
    ///  Lista habitaciones con sus numeros, que pertenecen a una seccion
    ///  (una secccion puede tener varias habitaciones) ejm: HA001=
    ///  201 HOSPITALIZACION MUJERES  HA022= 203 HOSPITALIZACION MUJERES
    ///  HA004 = 103 HOSPITALIZACION NIÑOS
    /// </para>
    /// </summary>
    public class VistaModeloBcHoshabitaciones : VistaModeloBcHoshabitacionesBase
    {
        //-------------------------------------------------
        // fcrValidacion: Validacion campos
        //-------------------------------------------------
        #region Validacion Campos: fcrValidacion
        /// <summary>
        /// Funcion para validar los datos cargados en el registro
        /// que se esta editando
        /// </summary>
        /// <param name="tcrNombrePropiedad"></param>
        /// <returns>Retorna vacio o una cadena que describe el error</returns>
        public override string fcrValidacion(string tcrNombrePropiedad)
        {
            string lcrValorReturn = string.Empty;

            //lcrValorReturn=base.fcrValidacion(tcrNombrePropiedad); //para llamar funcionalidad en clase Base

            try
            {
                switch (tcrNombrePropiedad)
                {
                    case "G1Hos_nrohab_habi":
                        if (string.IsNullOrWhiteSpace(G1Hos_nrohab_habi))
                        {
                            lcrValorReturn = "Codigo habitacion: Es requerido";
                        }
                        else
                        {
                            if (GlgSIS_ModoAdicion == true && HOSValidarCodigo.flgBuscarHoshabitaciones(G1Hos_nrohab_habi))
                            {
                                lcrValorReturn = "Codigo habitacion: Ya existe en Base de Datos";
                            }
                        }
                        break;

                    case "G1Hos_deshab_habi":
                        if (string.IsNullOrWhiteSpace(G1Hos_deshab_habi))
                        {
                            lcrValorReturn = "Numero/nombre habitacion: Es requerido";
                        }
                        break;

                    case "G1Hos_codsec_hsec":
                        if (string.IsNullOrWhiteSpace(G1Hos_codsec_hsec))
                        {
                            lcrValorReturn = "Codigo sección: Es requerido";
                        }
                        else
                        {
                            EFhosseccionareas tmp = new EFhosseccionareas();
                            tmp = HOSValidarCodigo.fobRegBuscarHosseccionareas(G1Hos_codsec_hsec);
                            if (tmp != null)
                            {
                                G1Hos_dessec_hsec = tmp.hos_dessec_hsec;
                            }
                            if (string.IsNullOrWhiteSpace(G1Hos_dessec_hsec))
                            {
                                lcrValorReturn = "Codigo sección: No existe";
                            }
                        }
                        break;

                    case "G1Hos_tiphab_habi":
                        if (string.IsNullOrWhiteSpace(G1Hos_tiphab_habi))
                        {
                            lcrValorReturn = "Unipersonal SI/NO: Es requerido";
                        }
                        break;

                    case "G1Sis_estreg_esrg":
                        if (string.IsNullOrWhiteSpace(G1Sis_estreg_esrg))
                        {
                            lcrValorReturn = "Estado habitacion: Es requerido";
                        }
                        else
                        {
                            EFsisestadoregist tmp = new EFsisestadoregist();
                            tmp = SISValidarCodigo.fobRegBuscarSisestadoregist(G1Sis_estreg_esrg);
                            if (tmp != null)
                            {
                                G1Sis_desest_esrg = tmp.sis_desest_esrg;
                            }
                            if (string.IsNullOrWhiteSpace(G1Sis_desest_esrg))
                            {
                                lcrValorReturn = "Estado habitacion: No existe";
                            }
                        }
                        break;

                    default:
                        lcrValorReturn = fcrValidacionRel(tcrNombrePropiedad);
                        break;
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: fcrValidacion");
            }
            return lcrValorReturn;
        }
        #endregion
        //-------------------------------------------------
        // fcrValidacionRel: Validacion campos
        //-------------------------------------------------
        #region Validacion Campos: fcrValidacionRel
        /// <summary>
        /// Funcion para validar los datos cargados en el registro
        /// que se esta editando
        /// </summary>
        /// <param name="tcrNombrePropiedad"></param>
        /// <returns>Retorna vacio o una cadena que describe el error</returns>
        public override string fcrValidacionRel(string tcrNombrePropiedad)
        {
            string lcrValorReturn = string.Empty;

            //lcrValorReturn=base.fcrValidacionRel(tcrNombrePropiedad); //para llamar funcionalidad en clase Base

            try
            {
                switch (tcrNombrePropiedad)
                {
                    case "G2Hos_descam_caho":
                        if (string.IsNullOrWhiteSpace(G2Hos_descam_caho))
                        {
                            lcrValorReturn = "Descripcion cama: Es requerido";
                        }
                        break;

                    case "G2Hos_tipcam_tcam":
                        if (string.IsNullOrWhiteSpace(G2Hos_tipcam_tcam))
                        {
                            lcrValorReturn = "Codigo Tipo cama: Es requerido";
                        }
                        else
                        {
                            EFhostipocamas tmp = new EFhostipocamas();
                            tmp = HOSValidarCodigo.fobRegBuscarHostipocamas(G2Hos_tipcam_tcam);
                            if (tmp != null)
                            {
                                G2Hos_destip_tcam = tmp.hos_destip_tcam;
                            }
                            if (string.IsNullOrWhiteSpace(G2Hos_destip_tcam))
                            {
                                lcrValorReturn = "Codigo Tipo cama: No existe";
                            }
                        }
                        break;

                    case "G2Hos_camaux_caho":
                        if (string.IsNullOrWhiteSpace(G2Hos_camaux_caho))
                        {
                            lcrValorReturn = "Cama adecuada SI/NO: Es requerido";
                        }
                        break;

                    case "G2Fcm_idesec_sips":
                        if (string.IsNullOrWhiteSpace(G2Fcm_idesec_sips))
                        {
                            lcrValorReturn = "Codigo servicio estancia: Es requerido";
                        }
                        else
                        {
                            EFfcmmanservicips tmp = new EFfcmmanservicips();
                            tmp = FCMValidarCodigo.fobRegBuscarFcmmanservicips(G2Fcm_idesec_sips);
                            if (tmp != null)
                            {
                                G2Fcm_desser_sips = tmp.fcm_desser_sips;
                            }
                            if (string.IsNullOrWhiteSpace(G2Fcm_desser_sips))
                            {
                                lcrValorReturn = "Codigo servicio estancia: No existe";
                            }
                        }
                        break;

                    case "G2Hos_estcam_ecam":
                        if (string.IsNullOrWhiteSpace(G2Hos_estcam_ecam))
                        {
                            lcrValorReturn = "Codigo estado cama: Es requerido";
                        }
                        else
                        {
                            EFhosestadocama tmp = new EFhosestadocama();
                            tmp = HOSValidarCodigo.fobRegBuscarHosestadocama(G2Hos_estcam_ecam);
                            if (tmp != null)
                            {
                                G2Hos_desest_ecam = tmp.hos_desest_ecam;
                            }
                            if (string.IsNullOrWhiteSpace(G2Hos_desest_ecam))
                            {
                                lcrValorReturn = "Codigo estado cama: No existe";
                            }
                        }
                        break;

                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: fcrValidacionRel");
            }
            return lcrValorReturn;
        }
        #endregion
    }
}
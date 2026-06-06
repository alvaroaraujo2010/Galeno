using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Datos.Modelos;
using Sistema.Vista;
using Sistema.Utilidades;

namespace GestorReportes.Vista
{
    /// <summary>
    /// Interaction logic for EDT_TextBoxRelacion.xaml
    /// </summary>
    public partial class TextBoxRelacion : UserControl
    {
        public TextBoxRelacion()
        {
            InitializeComponent();
        }
        public int gnuTabIndex { get; set; }
        public String gcrTipoTabla { get; set; }
        //-------------------------------------------------
        //  Metodo que recoge el valor Key desde browser 
        //-------------------------------------------------
        /*
        #region Metodo que recoge el valor Key desde browser F2
        public void fcvBuscarRegistro(string tcrCodigo)
        {
            this.txtCodigo.Text = String.Empty;
            this.txtCodigo.Text = tcrCodigo;
            // Validar para mostrar descripcion
        }
        #endregion
        #region Metodo para mostrar Browser segun tipo tabla
        public void fcvBrowserTipoTabla()
        {
            switch (gcrTipoTabla)
            {
                case "DIAG":    // Diagnosticos CIE 10
                            #region Diagnostico principal
                            G2Sia_desdia_tdia = String.Empty;
                            if (string.IsNullOrWhiteSpace(G2Sia_coddia_tdia))
                            {
                                lcrValorReturn = "Diagnostico principal: Es requerido";
                            }
                            else
                            {
                                EFsiadiagnosticos tmp = new EFsiadiagnosticos();
                                tmp = SIAValidarCodigo.fobRegBuscarSiadiagnosticos(G2Sia_coddia_tdia);
                                if (tmp != null && !String.IsNullOrWhiteSpace(tmp.sia_desdia_tdia))
                                {
                                    G2Sia_desdia_tdia = tmp.sia_desdia_tdia;
                                }
                                else
                                {
                                    lcrValorReturn = "Diagnostico principal: No existe";
                                }
                            }
                            break;
                            #endregion

                    break;

                case "USUA":    // Usuarios Pacientes
                    break;

                case "USUX":    // Usuarios del sistema
                    break;

            }
        }
        #endregion
        */

    }
}

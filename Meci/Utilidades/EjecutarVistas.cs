using System;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using Meci.Vista;
using Sistema.Utilidades;

namespace Meci.Utilidades
{
    public static class MCIEjecutar
    {
        public static void fcvEjecutarFormularios(String tcrComponente)
        {
            Aplicacion oApp = Aplicacion.Instancia();
            var lcrCodProfActivo = MCIValidarCodigo.fobRegBuscarMcimoduloevmeci(oApp.gcrUsuIdUsuario);

            switch (tcrComponente)
            {
                case "MCI001":
                    VistaMciplantillmeci mci001 = new VistaMciplantillmeci();
                    mci001.ShowDialog();
                    break;

                case "MCI002":
                    VistaMcicomponenmeci mci002 = new VistaMcicomponenmeci();
                    mci002.ShowDialog();
                    break;

                case "MCI003":
                    VistaMciparametrmeci mci003 = new VistaMciparametrmeci();
                    mci003.ShowDialog();
                    break;

                case "MCI004":
                    VistaMcigrupoprgmeci mci004 = new VistaMcigrupoprgmeci();
                    mci004.ShowDialog();
                    break;

                case "MCI005":
                    VistaMcipreguntameci mci005 = new VistaMcipreguntameci();
                    mci005.ShowDialog();
                    break;

                case "MCI006":
                    VistaMcievaluacionms mci006 = new VistaMcievaluacionms();
                    mci006.ShowDialog();
                    break;
            }
        }
    }
}
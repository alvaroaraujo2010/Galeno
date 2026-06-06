using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Collections;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Data;
using Datos.Modelos;
using System.Text;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace Sistema.Clases
{
    /// <summary>
    /// Clase Auxiliar para el Browser01 que permite generar la lista y otros procesos auxiliares
    /// </summary>
    public class AuxBrowser01 : ViewModelBase
    {
        //-----------------------------------
        //- Clase Cargar Browser de la tabla
        //-----------------------------------
        #region Clase Cargar Browser de la tabla
        public class BrowerTabla
        {
            public BrowerTabla() { }
            public String campo1 { get; set; }
            public String campo2 { get; set; }
            public String campo3 { get; set; }
            public String campo4 { get; set; }
            public String campo5 { get; set; }
            public String campo6 { get; set; }
            public String campo7 { get; set; }
            public String campo8 { get; set; }
            public String campo9 { get; set; }
            public String campo10 { get; set; }
            public String campo11 { get; set; }
            public String campo12 { get; set; }
            public String campo13 { get; set; }
            public String campo14 { get; set; }
            public DateTime campo15 { get; set; }
            public DateTime campo16 { get; set; }
            public DateTime campo17 { get; set; }
            public String campo18 { get; set; }
            public String campo19 { get; set; }
            public String campo20 { get; set; }
            public int campo21 { get; set; }
            public int campo22 { get; set; }
            public int campo23 { get; set; }
            public int campo24 { get; set; }
            public int campo25 { get; set; }
            public float campo26 { get; set; }
            public float campo27 { get; set; }
            public float campo28 { get; set; }
            public float campo29 { get; set; }
            public float campo30 { get; set; }
        }
        #endregion
    }
}

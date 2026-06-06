using System;
using System.Data;
using System.Data.Objects;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Collections;
using System.Windows.Controls;
using System.Windows.Data;
using Datos.Modelos;
using System.Text;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Sistema.Utilidades;
using Sistema.Clases;

namespace Sistema.Utilidades
{
 
    public class CAR_Browser02 : AuxBrowser02
    {
        #region Configurar la vista General del Browser
        //----------------------------------------------------------------------
        //    Funcion: ConfigInicial()
        //----------------------------------------------------------------------
        #region ConfigInicial: Inicio y Configuracion de DataGrid
        public void ConfigInicial()
        {
            fcvReferenciaObjetos();
            switch (gcrTabla.ToUpper())
            {
                case "CARMAESFACTUMA":
                    fcvAddColGrid_Carmaesfactuma();
                    //gobDataGrid.ItemsSource = flsBuscar_Carmaesfactuma();
                    break;
            }

        }
        #endregion
        //----------------------------------------------------------------------
        //    Funcion: Buscar()
        //----------------------------------------------------------------------
        #region fcvBuscar: Buscar Registro
        public void fcvBuscar()
        {
            fcvReferenciaObjetos();
            switch (gcrTabla.ToUpper())
            {
                case "CARMAESFACTUMA":
                    //gobDataGrid.ItemsSource = flsBuscar_Carmaesfactuma();
                    break;
            }

        }
        #endregion
        //----------------------------------------------------------------------
        //    Funcion: fcrRegistroSelect()
        //----------------------------------------------------------------------
        #region fcrRegistroSelect: Seleccion del Registro activo en la Grilla
        public string fcrRegistroSelect()
        {
            fcvReferenciaObjetos();
            string lcrReturnCodigo = string.Empty;
            switch (gcrTabla.ToUpper())
            {
                case "CARMAESFACTUMA":
                    lcrReturnCodigo = fcrSelect_Carmaesfactuma();
                    break;

            }
            return lcrReturnCodigo;
        }
        #endregion
        #endregion
        //----------------------------------------------------------------------
        //    TABLA: CITMAESTROTURNO - Maestro de turnos por profesional
        //----------------------------------------------------------------------
        #region CARMAESFACTUMA
        //public List<BrowerTabla>flsBuscar_Carmaesfactuma()
        //{
        //    using (DbAplicacion db = new DbAplicacion())
        //    {
        //        if (gcrIndiceActivo == "1") //Identificación y nombre del profesional
        //        {
        //            #region ESTADO TODOS
                   
        //            #endregion
        //        }
        //        else if (gcrIndiceActivo == "2") // Descripcion turno y Codigo del profesional
        //        {
        //            #region Descripcion turno y Codigo del profesional
                   
        //            #endregion
        //        }
        //        else if (gcrIndiceActivo == "3") //Descripcion turno y nombre del profesional
        //        {
        //            #region Descripcion turno y nombre del profesional
                    
        //            #endregion
        //        }
        //        else
        //        {
        //            #region Sin ningun filtro
                   
        //            #endregion
        //        }
        //    }
        //}
        // Crear Columans del DataGrid
        public void fcvAddColGrid_Carmaesfactuma()
        {
            gobGridView.Columns.Add(new GridViewColumn { Header = "Codigo", Width = 120, DisplayMemberBinding = new Binding("campo1") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Observacion", Width = 400, DisplayMemberBinding = new Binding("campo2") });

        }
        // Seleccionar Registro
        public string fcrSelect_Carmaesfactuma()
        {
            var lcrReturn = string.Empty;
            if (gobDataGrid.SelectedIndex != -1)
            {
                var objReg = (BrowerTabla)gobDataGrid.Items[gobDataGrid.SelectedIndex];
                lcrReturn = objReg.campo1.Trim();
            }
            return lcrReturn;
        }
        #endregion
    }
}

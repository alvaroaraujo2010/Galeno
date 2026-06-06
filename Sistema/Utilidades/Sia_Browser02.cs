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
    public class SIA_Browser02 : AuxBrowser02
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
                case "CITMAESTROTURNO":
                    fcvAddColGrid_Citmaestroturno();
                    gobDataGrid.ItemsSource = flsBuscar_Citmaestroturno();
                    break;

                case "HOSESTADOCAMA":
                    fcvAddColGrid_Hosestadocama();
                    gobDataGrid.ItemsSource = flsBuscar_Hosestadocama();
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
                case "CITMAESTROTURNO":
                    gobDataGrid.ItemsSource = flsBuscar_Citmaestroturno();
                    break;

                case "HOSESTADOCAMA":
                    gobDataGrid.ItemsSource = flsBuscar_Hosestadocama();
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

                case "CITMAESTROTURNO":
                    lcrReturnCodigo = fcrSelect_Citmaestroturno();
                    break;

                case "HOSESTADOCAMA":
                    lcrReturnCodigo = fcrSelect_Hosestadocama();
                    break;

            }
            return lcrReturnCodigo;
        }
        #endregion
        #endregion
        //----------------------------------------------------------------------
        //    TABLA:  HOSESTADOCAMA
        //----------------------------------------------------------------------
        #region HOSESTADOCAMA
        // Realizar la busqueda en la tabla
        public List<EFhosestadocama> flsBuscar_Hosestadocama()
        {
            using (DbAplicacion db = new DbAplicacion())
            {
                if (gcrIndiceActivo == "1")
                {
                    string lcrConsulta = Funciones.fcrGenConsultaSqlBrowser("Hosestadocama", gobjTextBox11.Text, "like", "OR", "hos_codcam_caho,hos_descam_caho", gcrFiltroTabla);
                    ObjectQuery<EFhosestadocama> lcrQuery = new ObjectQuery<EFhosestadocama>(lcrConsulta, db);
                    return lcrQuery.ToList();
                }
                else if (gcrIndiceActivo == "2")
                {
                    string lcrConsulta = Funciones.fcrGenConsultaSqlBrowser("Hosestadocama", gobjTextBox11.Text, "like", "OR", "hos_desest_ecam", gcrFiltroTabla);
                    ObjectQuery<EFhosestadocama> lcrQuery = new ObjectQuery<EFhosestadocama>(lcrConsulta, db);
                    return lcrQuery.ToList();
                }
                else if (gcrIndiceActivo == "3")
                {
                    string lcrConsulta = Funciones.fcrGenConsultaSqlBrowser("Hosestadocama", gobjTextBox21.Text.Trim(), "like", "AND", "hos_estcam_ecam", "hos_desest_ecam = '" + gobjTextBox22.Text.Trim() + "'");
                    ObjectQuery<EFhosestadocama> lcrQuery = new ObjectQuery<EFhosestadocama>(lcrConsulta, db);
                    return lcrQuery.ToList();
                }
                else
                {
                    var lArDatos = (from reg in db.Hosestadocama select reg).ToList();
                    return lArDatos;
                }
            }
        }

        // Crear Columans del DataGrid e indices
        public void fcvAddColGrid_Hosestadocama()
        {
            //---------------------------
            // Lista de campos para grilla
            //---------------------------
            #region Configurar la Grilla
            gobGridView.Columns.Add(new GridViewColumn { Header = "Código", Width = 120, DisplayMemberBinding = new Binding("hos_estcam_ecam") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Descripción", Width = 220, DisplayMemberBinding = new Binding("hos_desest_ecam") });
            #endregion
            //---------------------------
            // Lista de indices y titulos para Texbox de busqueda
            //---------------------------
            #region Configurar lista de indices
            gclListaIndices.Add(new ComboItem() { IdIndice = "1", NombreIndice = "Codigo              ", TotalCampos = 1, Titulos = new List<string> { "Codigo" } });
            gclListaIndices.Add(new ComboItem() { IdIndice = "2", NombreIndice = "Descripcion         ", TotalCampos = 1, Titulos = new List<string> { "Descripcion" } });
            gclListaIndices.Add(new ComboItem() { IdIndice = "3", NombreIndice = "Codigo y Descripcion", TotalCampos = 2, Titulos = new List<string> { "Codigo", "Descripcion" } });
            //---------------------------
            //Establecemos el itemssource del ComboBox a lista de Indices.
            gobListBoxIndices.ItemsSource = gclListaIndices;
            gobListBoxIndices.SelectedItem = gobListBoxIndices.Items[gnuIdIndiceInicial];
            // Activar el Tab de Textbox correspondiente
            fcvActivarTab("Tab" + fcrTotalCamposIndiceActivo());
            #endregion

        }

        // Devolver el codigo de Registro Seleccionado
        public string fcrSelect_Hosestadocama()
        {
            var lcrReturn = string.Empty;
            if (gobDataGrid.SelectedIndex != -1)
            {
                var objReg = (EFhosestadocama)gobDataGrid.Items[gobDataGrid.SelectedIndex];
                lcrReturn = objReg.hos_estcam_ecam;
            }
            return lcrReturn;
        }
        #endregion
        //----------------------------------------------------------------------
        //    TABLA: CITMAESTROTURNO - Maestro de turnos por profesional
        //----------------------------------------------------------------------
        #region CITMAESTROTURNO
        public List<BrowerTabla> flsBuscar_Citmaestroturno()
        {
            using (DbAplicacion db = new DbAplicacion())
            {
                if (gcrIndiceActivo == "1") //Identificación y nombre del profesional
                {
                    #region Identificacion y nombre
                    var lcrQuery = from t1 in db.Citmaestroturno
                                   join t2 in db.Siamaeprofsalud on t1.sia_codpfa_prof equals t2.sia_codpfa_prof
                                   where t1.sia_codpfa_prof.Contains(gobjTextBox21.Text.Trim()) ||
                                         t2.sia_nompro_prof.Contains(gobjTextBox22.Text.Trim())  
                                   select new BrowerTabla
                                   {
                                       campo1 = t1.cit_codtur_turn,
                                       campo2 = t1.cit_destur_turn,
                                       campo3 = t1.sia_codpfa_prof,
                                       campo4 = t2.sia_nompro_prof
                                   };
                    return lcrQuery.ToList();
                    #endregion
                }
                else if (gcrIndiceActivo == "2") // Descripcion turno y Codigo del profesional
                {
                    #region Descripcion turno y Codigo del profesional
                    var lcrQuery = from t1 in db.Citmaestroturno
                                   join t2 in db.Siamaeprofsalud on t1.sia_codpfa_prof equals t2.sia_codpfa_prof
                                   where t1.cit_destur_turn.Contains(gobjTextBox21.Text.Trim()) ||
                                         t1.sia_codpfa_prof.Contains(gobjTextBox22.Text.Trim())
                                   select new BrowerTabla
                                   {
                                       campo1 = t1.cit_codtur_turn,
                                       campo2 = t1.cit_destur_turn,
                                       campo3 = t1.sia_codpfa_prof,
                                       campo4 = t2.sia_nompro_prof
                                   };
                    return lcrQuery.ToList();
                    #endregion
                }
                else if (gcrIndiceActivo == "3") //Descripcion turno y nombre del profesional
                {
                    #region Descripcion turno y nombre del profesional
                    var lcrQuery = from t1 in db.Citmaestroturno
                                   join t2 in db.Siamaeprofsalud on t1.sia_codpfa_prof equals t2.sia_codpfa_prof
                                   where t1.cit_destur_turn.Contains(gobjTextBox21.Text.Trim()) ||
                                         t2.sia_nompro_prof.Contains(gobjTextBox22.Text.Trim())
                                   select new BrowerTabla
                                   {
                                       campo1 = t1.cit_codtur_turn,
                                       campo2 = t1.cit_destur_turn,
                                       campo3 = t1.sia_codpfa_prof,
                                       campo4 = t2.sia_nompro_prof
                                   };
                    return lcrQuery.ToList();
                    #endregion
                }
                else
                {
                    #region Sin ningun filtro
                    var lcrQuery = from t1 in db.Citmaestroturno
                                   join t2 in db.Siamaeprofsalud on t1.sia_codpfa_prof equals t2.sia_codpfa_prof
                                   select new BrowerTabla
                                   {
                                       campo1 = t1.cit_codtur_turn,
                                       campo2 = t1.sia_codpfa_prof,
                                       campo3 = t2.sia_nompro_prof,
                                       campo4 = t1.cit_destur_turn
                                   };
                    return lcrQuery.ToList();
                    #endregion
                }
            }
        }
        // Crear Columans del DataGrid
        public void fcvAddColGrid_Citmaestroturno()
        {
            gobGridView.Columns.Add(new GridViewColumn { Header = "Registro", Width = 120, DisplayMemberBinding = new Binding("campo1") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Código", Width = 120, DisplayMemberBinding = new Binding("campo2") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Profesional", Width = 220, DisplayMemberBinding = new Binding("campo3") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Descripción turno", Width = 200, DisplayMemberBinding = new Binding("campo4") });
            //---------------------------
            // Lista de indices y titulos para Texbox de busqueda
            //---------------------------
            #region Configurar lista de indices
            gclListaIndices.Add(new ComboItem() { IdIndice = "1", NombreIndice = "Identificación y nombre", TotalCampos = 2, Titulos = new List<string> { "Codigo","Nombre Profesional" } });
            gclListaIndices.Add(new ComboItem() { IdIndice = "2", NombreIndice = "Fecha y Codigo Profesional", TotalCampos = 2, Titulos = new List<string> { "Fecha","Codigo Profesional" } });
            gclListaIndices.Add(new ComboItem() { IdIndice = "3", NombreIndice = "Fecha y Nombre Profesional", TotalCampos = 2, Titulos = new List<string> { "Fecha","Nombre Profesional" } });
            //---------------------------
            //Establecemos el itemssource del ComboBox a lista de Indices.
            gobListBoxIndices.ItemsSource = gclListaIndices;
            gobListBoxIndices.SelectedItem = gobListBoxIndices.Items[gnuIdIndiceInicial];
            // Activar el Tab de Textbox correspondiente
            fcvActivarTab("Tab" + fcrTotalCamposIndiceActivo());
            #endregion
        }
        // Seleccionar Registro
        public string fcrSelect_Citmaestroturno()
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

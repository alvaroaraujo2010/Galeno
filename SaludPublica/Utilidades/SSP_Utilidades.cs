using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Reflection;
using Microsoft.CSharp;
using Sistema.Utilidades;
using Sistema.Modelo;
using Sistema.Clases;
using Datos.Modelos;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;
using System.Globalization;

namespace SaludPublica.Utilidades
{
    //public class Utilidades { }
    //---------------------------------------------------------------
    // COLORES REGISTROS GRILLA
    //---------------------------------------------------------------
    #region ForegroundColorEstado: Poner color a la fuente de la grilla segun estado del registro
    /// <summary>
    /// <para>Poner color a la fuente de la grilla segun estado del registro</para>
    /// </summary>
    public class ForegroundColorEstado : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is String)
            {
                String lcrEstado = (String)value;
                switch (lcrEstado)
                {
                    case "VALIDADO-OK":
                        return Brushes.Blue;

                    case "VALIDADO-ERROR-BAJO":
                        return Brushes.BlueViolet;

                    case "VALIDADO-ERROR-ALTO":
                        return Brushes.Red;

                    case "VERIFICADO-OK":
                        return Brushes.Blue;

                    case "VERIFICADO-ERROR":
                        return Brushes.Red;

                    case "MODIFICADO":
                        return Brushes.Green;

                    default:
                        return Brushes.Black;
                }
            }
            return Brushes.Black;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    #endregion
    #region BackgroundColorEstado: Poner color al fondo de la grilla segun marca de seleccion del registro
    /// <summary>
    /// <para> Poner color al fondo de la grilla segun marca de seleccion del registro</para>
    /// </summary>
    public class BackgroundColorEstado : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool)
            {
                bool llgEstado = (bool)value;
                if (llgEstado == false)
                {
                    return Brushes.Pink;
                }
            }
            return Brushes.White;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    #endregion
    //---------------------------------------------------------------
    // INTERFACE
    //---------------------------------------------------------------
    #region IEdicionRegistro: Interface para devolver el registro editado en la vista gestion 4505
    /// <summary>
    /// <para>Interface para devolver el registro editado en la vista gestion 4505</para>
    /// </summary>
    public interface IEdicionRegistro : SIS_Interface
    {
        void fcvIEdicionRegistro(ModeloSspNsRes4505Ex tobRegistro);
    }
    #endregion
    //---------------------------------------------------------------
    // CLASES UTILITARIAS DE PROCESOS
    //---------------------------------------------------------------
    #region Clase para referenciar los combobox asociados a campos 4505
    /// <summary>
    /// Clase para referenciar ComboBox asociados a campos 4505 y TextBox
    /// </summary>
    public class ObjetosVista
    {
        public ObjetosVista() { }
        public String Nombre { get; set; }      // Nombre del objeto dentro del formulario
        public String Tipo { get; set; }        // Tipo objeto TextBox o ComboBox
        public String Variable { get; set; }    // Numero Variable 4505
        public FrameworkElement RefObjeto { get; set; }   // Referencia
    }
    #endregion

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Sistema.Modelo
{
    public abstract class clBaseInpc : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged Implementacion 
        /// <summary>
        /// Implementacion para clase base INotifyPropertyChanged
        /// que permite notificar los cambios en propiedades y con esto
        /// actualizar la vista en objetos y entidades 
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string tcrNombrePropiedad)
        {
            var lpthandler = PropertyChanged;
            if (lpthandler !=null)
            {
                lpthandler(this, new PropertyChangedEventArgs(tcrNombrePropiedad));
            }
        }
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace HMIParking.Models
{
    public class Piso:INotifyPropertyChanged
    {
        private List<Puesto> puestos;
        private int numeroCarrosTotal;
        public List<Puesto> Puestos
        {
            get { return puestos; }
            set
            {
                puestos = value;
                OnPropertyChanged("Puestos");
            }
        }
        public int NumeroCarrosToltal {
            get
            {
                return numeroCarrosTotal;
            }
            set {
                numeroCarrosTotal = value;
                OnPropertyChanged("NumeroCarrosTotal");
            } }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string name)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }
}

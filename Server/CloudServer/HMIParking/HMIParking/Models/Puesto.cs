using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace HMIParking.Models
{
    public class Puesto : INotifyPropertyChanged
    {
        private bool state;
        private Carro carroActual;
        public bool State
        {
            get { return state; }
            set
            {
                state = value;
                OnPropertyChanged("State");
            }
        }
        public Carro CarroActual
        {
            get { return carroActual; }
            set
            {
                carroActual = value;
                OnPropertyChanged("CarroActual");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string name)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }
}

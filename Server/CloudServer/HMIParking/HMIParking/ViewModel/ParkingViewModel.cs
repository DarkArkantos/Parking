using HMIParking.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;


namespace HMIParking.ViewModel
{
    public class ParkingViewModel:BaseViewModel
    {
        public ObservableCollection<Puesto> Parqueadero { get; set; }
        
        public ParkingViewModel()
        {
            Parqueadero = new ObservableCollection<Puesto>();
            llenarDatos();
        }

        public async void llenarDatos()
        {
            Parqueadero = new ObservableCollection<Puesto>(await Datos.GetPuesto());
        }
    }
}

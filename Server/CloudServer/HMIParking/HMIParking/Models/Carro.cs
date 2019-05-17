using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace HMIParking.Models
{
    public class Carro : INotifyPropertyChanged
    {
        private int carID;
        private int placeID;
        private int floorID;
        private string owner;
        private string licensePlate;
        public int CarID
        {
            get { return carID; }
            set
            {
                carID = value;
                OnPropertyChanged("CarID");
            }
        }
        public int PlaceID
        {
            get { return placeID; }
            set
            {
                placeID = value;
                OnPropertyChanged("PlaceID");
            }
        }
        public int FloorID
        {
            get { return floorID; }
            set
            {
                floorID = value;
                OnPropertyChanged("FloorID");
            }
        }
        public string Owner
        {
            get { return owner; }
            set
            {
                owner = value;
                OnPropertyChanged("Owner");
            }
        }
        public string LicensePlate
        {
            get { return licensePlate; }
            set
            {
                licensePlate = value;
                OnPropertyChanged("LicensePlate");
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

using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using HMIParking.Models;
using Xamarin.Forms;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HMIParking.ViewModel
{
    public class ParkingViewModel:BaseViewModel
    {
        public ICommand Reload { get; private set; }
        public ICommand PostPLC { get; private set; }
        public ObservableCollection<Carro> Carros { get; set; } 
        public ParkingViewModel()
        {
            Reload = new Command(async()=> await LoadData());
            Carros = new ObservableCollection<Carro>() {
            new Carro { CarID = 1, FloorID = 1, PlaceID = 1, LicensePlate = "N/A", Owner = "N/A" },
            new Carro { CarID = 2, FloorID = 1, PlaceID = 2, LicensePlate = "N/A", Owner = "N/A" },
            new Carro { CarID = 3, FloorID = 1, PlaceID = 3, LicensePlate = "N/A", Owner = "N/A" },
            new Carro { CarID = 4, FloorID = 1, PlaceID = 4, LicensePlate = "N/A", Owner = "N/A" },
            new Carro { CarID = 5, FloorID = 1, PlaceID = 5, LicensePlate = "N/A", Owner = "N/A" },
            new Carro { CarID = 6, FloorID = 1, PlaceID = 6, LicensePlate = "N/A", Owner = "N/A" },
            new Carro { CarID = 7, FloorID = 1, PlaceID = 7, LicensePlate = "N/A", Owner = "N/A" },
            new Carro { CarID = 8, FloorID = 1, PlaceID = 8, LicensePlate = "N/A", Owner = "N/A" },
            //Piso2
            new Carro { CarID = 9, FloorID = 2, PlaceID = 1, LicensePlate = "N/A", Owner = "N/A" },
            new Carro { CarID = 10, FloorID = 2, PlaceID = 2, LicensePlate = "N/A", Owner = "N/A" },
            new Carro { CarID = 11, FloorID = 2, PlaceID = 3, LicensePlate = "N/A", Owner = "N/A" },
            new Carro { CarID = 12, FloorID = 2, PlaceID = 4, LicensePlate = "N/A", Owner = "N/A" },
            new Carro { CarID = 13, FloorID = 2, PlaceID = 5, LicensePlate = "N/A", Owner = "N/A" },
            new Carro { CarID = 14, FloorID = 2, PlaceID = 6, LicensePlate = "N/A", Owner = "N/A" },
            new Carro { CarID = 15, FloorID = 2, PlaceID = 7, LicensePlate = "N/A", Owner = "N/A" },
            new Carro { CarID = 16, FloorID = 2, PlaceID = 8, LicensePlate = "N/A", Owner = "N/A" },
            //Piso3
            new Carro { CarID = 17, FloorID = 3, PlaceID = 1, LicensePlate = "N/A", Owner = "N/A" },
            new Carro { CarID = 18, FloorID = 3, PlaceID = 3, LicensePlate = "N/A", Owner = "N/A" },
            new Carro { CarID = 19, FloorID = 3, PlaceID = 4, LicensePlate = "N/A", Owner = "N/A" },
            new Carro { CarID = 20, FloorID = 3, PlaceID = 5, LicensePlate = "N/A", Owner = "N/A" },
            new Carro { CarID = 21, FloorID = 3, PlaceID = 6, LicensePlate = "N/A", Owner = "N/A" },
            new Carro { CarID = 22, FloorID = 3, PlaceID = 7, LicensePlate = "N/A", Owner = "N/A" },
            new Carro { CarID = 23, FloorID = 3, PlaceID = 7, LicensePlate = "N/A", Owner = "N/A" },
            new Carro { CarID = 24, FloorID = 3, PlaceID = 8, LicensePlate = "N/A", Owner = "N/A" },
            //Piso4
            new Carro { CarID = 25, FloorID = 4, PlaceID = 1, LicensePlate = "N/A", Owner = "N/A" },
            new Carro { CarID = 26, FloorID = 4, PlaceID = 3, LicensePlate = "N/A", Owner = "N/A" },
            new Carro { CarID = 27, FloorID = 4, PlaceID = 4, LicensePlate = "N/A", Owner = "N/A" },
            new Carro { CarID = 28, FloorID = 4, PlaceID = 5, LicensePlate = "N/A", Owner = "N/A" },
            new Carro { CarID = 29, FloorID = 4, PlaceID = 6, LicensePlate = "N/A", Owner = "N/A" },
            new Carro { CarID = 30, FloorID = 4, PlaceID = 7, LicensePlate = "N/A", Owner = "N/A" },
            new Carro { CarID = 31, FloorID = 4, PlaceID = 7, LicensePlate = "N/A", Owner = "N/A" },
            new Carro { CarID = 32, FloorID = 4, PlaceID = 8, LicensePlate = "N/A", Owner = "N/A" }
            
        };
            LoadData();
        }
        public async Task<bool> LoadData()
        {
             var data = await DataStore.GetFloors();
            if (data.Any())
            {
                foreach (var item in data)
                {
                    var item2 = Carros.FirstOrDefault(c => c.CarID == item.CarID).LicensePlate = item.LicensePlate;
                    var item3 = Carros.FirstOrDefault(c => c.CarID == item.CarID).Owner = item.Owner;
                }
            }
              return true;

        }
    }
}

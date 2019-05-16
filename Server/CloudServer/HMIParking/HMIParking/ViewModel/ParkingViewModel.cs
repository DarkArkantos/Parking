using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using HMIParking.Models;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace HMIParking.ViewModel
{
    public class ParkingViewModel:BaseViewModel
    {
        ObservableCollection<Piso> Pisos { get; set; }
        public ParkingViewModel()
        {
            Device.StartTimer(TimeSpan.FromMilliseconds(500), () =>
            {
                Task.Factory.StartNew(async () =>
                {
                    return await LoadData();
                });
                return false;
            });
        }
        public async Task<bool> LoadData()
        {
            var data = await DataStore.GetFloor();
            foreach (var item in data)
            {
                Pisos.Add(item);
            }
            return true;
        }
    }
}

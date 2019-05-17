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
        Piso Piso1 { get; set; }
        Piso Piso2 { get; set; }
        Piso Piso3 { get; set; }
        Piso Piso4 { get; set; }
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
            Piso1 = data[0];
            Piso2 = data[1];
            Piso3 = data[2];
            Piso4 = data[3];
            return true;
        }
    }
}

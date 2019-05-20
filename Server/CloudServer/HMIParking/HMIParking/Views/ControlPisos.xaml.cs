using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using HMIParking.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HMIParking.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ControlPisos : ContentPage
    {
        public ControlPisos()
        {
            InitializeComponent();
            BindingContext = new ParkingViewModel();
            Device.StartTimer(TimeSpan.FromMilliseconds(100), () =>
            {
                Task.Factory.StartNew(async () =>
                {
                    return await loadData();
                });
                return true;
            });
        }
        public async Task<bool> loadData()
        {
            var a = (ParkingViewModel)BindingContext;
            if (a.Reload.CanExecute(null))
                a.Reload.Execute(null);
            return true;
        }
    }
}
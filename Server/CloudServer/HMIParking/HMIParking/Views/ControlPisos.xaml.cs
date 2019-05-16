using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        }
    }
}
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using HMIParking.Services;
using HMIParking.Views;
namespace HMIParking
{
    public partial class App : Application
    {
        public App()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MTAyMTcxQDMxMzcyZTMxMmUzMGpJSG9NSzFQKytVWUt5VjBqT0Jic2pDaGNuaFhiM08rYXd3RzE0V2E3TUE9");
            InitializeComponent();
            MainPage = new ControlPisos();
            DependencyService.Register<IData>();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}

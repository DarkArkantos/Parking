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
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("OTI2NzhAMzEzNzJlMzEyZTMwQWVVRHFlYnlMMnQrbHdvTXpZTEhtVUMwWUFXWkVPNHlxbHJmcEZVS3Njaz0=");
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

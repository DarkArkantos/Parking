using System;
using System.Collections.Generic;
using System.Text;
using HMIParking.Services;
using Xamarin.Forms;

namespace HMIParking.ViewModel
{
    public class BaseViewModel
    {
        public IData DataStore => DependencyService.Get<IData>() ?? new Data();
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HMIParking.Models;
using S7.Net;
using Xamarin.Forms;

namespace HMIParking.Services
{
    public class Data : IData
    {
        private Plc PLC;
        public List<Puesto> Puestos { get; set; }
        public Data()
        {
            PLC = new Plc(CpuType.S71200, "12.51.456.45", 0, 0);
            Device.StartTimer(TimeSpan.FromMilliseconds(500), () =>
            {
                Task.Factory.StartNew(async () =>
                {
                    return await GetPLCData();
                });
                return false;
            });
        }

        public Task<List<Puesto>> GetPuesto()
        {
            throw new NotImplementedException();
        }

        public Task PostDataToServer()
        {
            throw new NotImplementedException();
        }

        public Task<bool> GetPLCData()
        {
            throw new NotImplementedException();
        }
    }
    public struct PLCData
    {
        
    }
}

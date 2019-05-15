using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using HMIParking.Models;
using Newtonsoft.Json;
using S7.Net;
using Xamarin.Forms;

namespace HMIParking.Services
{
    public class Data : IData
    {
        private Plc PLC;
        private HttpClient httpClient;
        public List<Puesto> Puestos { get; set; }
        public Data()
        {
            httpClient = new HttpClient();
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

        public async Task<List<Puesto>> GetPuesto()
        {
            var uri = new Uri("https://parkingutadeo2019.azurewebsites.net/api/Cars");
            var response = await httpClient.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                Puestos = JsonConvert.DeserializeObject<List<Puesto>>(content);
            }
            return Puestos;
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

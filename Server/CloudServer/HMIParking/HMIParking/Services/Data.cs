using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        private List<Puesto> Piso1 { get; set; }
        private List<Puesto> Piso2 { get; set; }
        private List<Carro> DataServer { get; set; }
        private List<List<Puesto>> Pisos { get; set; }
        public Data()
        {
            Piso2 = new List<Puesto>();
            Piso1 = new List<Puesto>();
            httpClient = new HttpClient();
            PLC = new Plc(CpuType.S71200, "169.254.1.13", 0, 0);
            DataServer=new List<Carro>();
        }

        public async Task<List<Carro>> GetFloors()
        {
            var uri = new Uri("https://parkingutadeo2019.azurewebsites.net/api/Cars");
            var response = await httpClient.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                DataServer = JsonConvert.DeserializeObject<List<Carro>>(content);
            }
            return DataServer;
        }

        public Carro GetCar(bool x, int CarID, int PlaceID)
        {
            Carro c = new Carro();
            if (x)
            {
                c.LicensePlate = RandomString(3, false)+RandomNumber(0,9)+ RandomNumber(0, 9)+ RandomNumber(0, 9);
                c.Owner = RandomString(5, false);
            }
            c.LicensePlate = "N/A";
            c.Owner = "N/A";
            c.CarID = CarID;
            return c;
        }
        public string RandomString(int size, bool lowerCase)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            if (lowerCase)
                return builder.ToString().ToLower();
            return builder.ToString();
        }
        public int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }
    }
    public struct PLCData
    {
        public bool M1 { get; set; }
        public bool M2 { get; set; }
        public bool M3 { get; set; }
        public bool M4 { get; set; }
        public bool M5 { get; set; }
        public bool M6 { get; set; }
        public bool M7 { get; set; }
        public bool M8 { get; set; }
        public bool M9 { get; set; }
        public bool M10 { get; set; }
        public bool M11 { get; set; }
        public bool M12 { get; set; }
        public bool M13 { get; set; }
        public bool M14 { get; set; }
        public bool M15 { get; set; }
        public bool M16 { get; set; }
    }
}

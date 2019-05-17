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
        private List<Puesto> Piso1 { get; set; }
        private List<Puesto> Piso2 { get; set; }
        private List<Puesto> Piso3 { get; set; }
        private List<Puesto> Piso4 { get; set; }
        private List<Carro> DataServer { get; set; }
        private List<Piso> Pisos { get; set; }
        public Data()
        {
            httpClient = new HttpClient();
            PLC = new Plc(CpuType.S71200, "12.51.456.45", 0, 0);
            Device.StartTimer(TimeSpan.FromSeconds(2), () =>
            {
                Task.Factory.StartNew(async () =>
                {
                    return await Timer();
                });
                return false;
            });
        }

        public async Task<bool> Timer()
        {
            await GetPLCData();
            await GetPisos();
            return true;
        }
        public async Task<List<Piso>> GetPisos()
        {
            var uri = new Uri("https://parkingutadeo2019.azurewebsites.net/api/Cars");
            var response = await httpClient.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                DataServer = JsonConvert.DeserializeObject<List<Carro>>(content);
                foreach (var item in DataServer)
                {
                    switch (item.FloorID)
                    {
                        case 0:
                            Piso1.Add(new Puesto { Carroactual = new Carro { CarID = item.CarID, FloorID = item.FloorID, LicensePlate = item.LicensePlate, PlaceID = item.PlaceID, Owner = item.Owner } });
                            break;
                        case 1:
                            Piso2.Add(new Puesto { Carroactual = new Carro { CarID = item.CarID, FloorID = item.FloorID, LicensePlate = item.LicensePlate, PlaceID = item.PlaceID, Owner = item.Owner } });
                            break;
                        case 2:
                            Piso3.Add(new Puesto { Carroactual = new Carro { CarID = item.CarID, FloorID = item.FloorID, LicensePlate = item.LicensePlate, PlaceID = item.PlaceID, Owner = item.Owner } });
                            break;
                        case 3:
                            Piso4.Add(new Puesto { Carroactual = new Carro { CarID = item.CarID, FloorID = item.FloorID, LicensePlate = item.LicensePlate, PlaceID = item.PlaceID, Owner = item.Owner } });
                            break;
                    }
                }
                Pisos.Add(new Piso { Puestos= Piso1});
                Pisos.Add(new Piso { Puestos = Piso2 });
                Pisos.Add(new Piso { Puestos = Piso3 });
                Pisos.Add(new Piso { Puestos = Piso4 });
            }
            return Pisos;
        }

        public Task PostDataToServer()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> GetPLCData()
        {
            
            await PLC.OpenAsync();
            if (PLC.IsConnected)
            {
                Piso2 = new List<Puesto>();
                Piso1 = new List<Puesto>();
                var data = (PLCData)PLC.ReadStruct(typeof(PLCData), 4);

                Piso1.Add(new Puesto { State = data.p1, Carroactual=GetCar(data.p1, 1)});
                Piso1.Add(new Puesto { State = data.p2, Carroactual=GetCar(data.p2, 2)});
                Piso1.Add(new Puesto { State = data.p3, Carroactual=GetCar(data.p3, 3)});
                Piso1.Add(new Puesto { State = data.p4, Carroactual=GetCar(data.p4, 4)});
                Piso1.Add(new Puesto { State = data.p5, Carroactual=GetCar(data.p5, 5)});
                Piso1.Add(new Puesto { State = data.p6, Carroactual=GetCar(data.p6, 6)});
                Piso1.Add(new Puesto { State = data.p7, Carroactual=GetCar(data.p7, 7)});
                Piso1.Add(new Puesto { State = data.p8, Carroactual=GetCar(data.p8, 8)});

                Piso2.Add(new Puesto { State = data.p9, Carroactual=GetCar(data.p9, 9)});
                Piso2.Add(new Puesto { State = data.p10, Carroactual=GetCar(data.p10, 10)});
                Piso2.Add(new Puesto { State = data.p11, Carroactual=GetCar(data.p11, 11)});
                Piso2.Add(new Puesto { State = data.p12, Carroactual=GetCar(data.p12, 12)});
                Piso2.Add(new Puesto { State = data.p13, Carroactual=GetCar(data.p13, 13)});
                Piso2.Add(new Puesto { State = data.p14, Carroactual=GetCar(data.p14, 14)});
                Piso2.Add(new Puesto { State = data.p15, Carroactual=GetCar(data.p15, 15)});
                Piso2.Add(new Puesto { State = data.p16, Carroactual=GetCar(data.p16, 16)});
                
            }
            return true;
        }
        public Carro GetCar(bool x, int i)
        {
            Carro c = new Carro();
            if (x)
            {
                c.LicensePlate = RandomString(3, false)+RandomNumber(0,9)+ RandomNumber(0, 9)+ RandomNumber(0, 9);
                c.Owner = RandomString(5, false);
            }
            c.LicensePlate = "N/A";
            c.Owner = "N/A";
            c.CarID = i;
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

        public Task<List<Piso>> GetPlaces()
        {
            throw new NotImplementedException();
        }
    }
    public struct PLCData
    {
        public bool p1 { get; set; }
        public bool p2 { get; set; }
        public bool p3 { get; set; }
        public bool p4 { get; set; }
        public bool p5 { get; set; }
        public bool p6 { get; set; }
        public bool p7 { get; set; }
        public bool p8 { get; set; }
        public bool p9 { get; set; }
        public bool p10 { get; set; }
        public bool p11 { get; set; }
        public bool p12 { get; set; }
        public bool p13 { get; set; }
        public bool p14 { get; set; }
        public bool p15 { get; set; }
        public bool p16 { get; set; }
    }
}

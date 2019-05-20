using PLCData.Model;
using S7.Net;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Net.Http;
using Newtonsoft.Json;

namespace PLCData
{
    class Program
    {
        public static List<Car> Cars = new List<Car>();
        public static Plc Plc = new Plc(CpuType.S71200, "169.254.1.13", 0, 0);
        public static string temp;
        public static HttpClient httpClient = new HttpClient();
        static void Main(string[] args)
        {
            while (!Plc.IsAvailable)
            {
                Console.WriteLine("Esperando PLC");
                Thread.Sleep(100);
            }
            Plc.Open();
            if (Plc.IsConnected)
            {
                Console.WriteLine("PLC Conectado");
                while (true)
                {
                    UpdateValue();
                    foreach (var item in Cars)
                    {
                        var json = JsonConvert.SerializeObject(item);
                        var content = new StringContent(json, Encoding.UTF8, "application/json");
                        var response = httpClient.PutAsync(new Uri("https://parkingutadeo2019.azurewebsites.net/api/Cars"), content);
                        Console.WriteLine(json);
                        Console.WriteLine();
                    }
                    Thread.Sleep(1000);
                }
                
            }
        }
        public static Car GetCar(bool x, int CarID, int PlaceID, int FloorID)
        {
            Car c = new Car();
            if (x)
            {
                c.LicensePlate = RandomString(3, false) + RandomNumber(0, 9) + RandomNumber(0, 9) + RandomNumber(0, 9);
                c.Owner = RandomString(5, false);
            }
            else
            {
                c.LicensePlate = "N/A";
                c.Owner = "N/A";
            }
            c.CarID = CarID;
            return c;
        }

        static void UpdateValue()
        {
            Data reading = (Data)Plc.ReadStruct(typeof(Data), 4, 0);
            List<Car> x = new List<Car>()
            {
                GetCar(reading.M1, 1, 1, 2),
                GetCar(reading.M2, 2, 2, 2),
                GetCar(reading.M3, 3, 3, 2),
                GetCar(reading.M4, 4, 4, 2),
                GetCar(reading.M5, 5, 5, 2),
                GetCar(reading.M6, 6, 6, 2),
                GetCar(reading.M7, 7, 7, 2),
                GetCar(reading.M8, 8, 8, 2),
                GetCar(reading.M9, 9, 1, 3),
                GetCar(reading.M10, 10, 2, 3),
                GetCar(reading.M11, 11, 3, 3),
                GetCar(reading.M12, 12, 4, 3),
                GetCar(reading.M13, 13, 5, 3),
                GetCar(reading.M13, 14, 6, 3),
                GetCar(reading.M13, 15, 7, 3),
                GetCar(reading.M13, 16, 8, 3)
            };
            Cars = x;
        }
        public static string RandomString(int size, bool lowerCase)
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
        public static int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }

    }
    public struct Data
    {
        public bool M1;
        public bool M2;
        public bool M3;
        public bool M4;
        public bool M5;
        public bool M6;
        public bool M7;
        public bool M8;
        public bool M9;
        public bool M10;
        public bool M11;
        public bool M12;
        public bool M13;
        public bool M14;
        public bool M15;
        public bool M16;
    }
}

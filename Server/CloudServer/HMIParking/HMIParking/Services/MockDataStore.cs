using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HMIParking.Models;

namespace HMIParking.Services
{
    public class MockDataStore : IData
    {
        public async Task<List<Carro>> GetFloors()
        {
            var res = new List<Carro>() { new Carro { CarID = 1, PlaceID = 1, FloorID = 1, LicensePlate = RandomString(3, false), Owner = RandomString(5, false) },
            new Carro { CarID = 2, PlaceID = 2, FloorID = 1, LicensePlate = RandomString(3, false), Owner = RandomString(5, false) },
            new Carro { CarID = 3, PlaceID = 3, FloorID = 1, LicensePlate = RandomString(3, false), Owner = RandomString(5, false) },
            new Carro { CarID = 4, PlaceID = 4, FloorID = 1, LicensePlate = RandomString(3, false), Owner = RandomString(5, false) },
            new Carro { CarID = 5, PlaceID = 5, FloorID = 1, LicensePlate = RandomString(3, false), Owner = RandomString(5, false) },
            new Carro { CarID = 6, PlaceID = 6, FloorID = 1, LicensePlate = RandomString(3, false), Owner = RandomString(5, false) },
            new Carro { CarID = 7, PlaceID = 7, FloorID = 1, LicensePlate = RandomString(3, false), Owner = RandomString(5, false) },
            new Carro { CarID = 8, PlaceID = 8, FloorID = 1, LicensePlate = RandomString(3, false), Owner = RandomString(5, false) }};
            return res;
        }

        public Task<bool> GetPLCData()
        {
            throw new NotImplementedException();
        }

        public Task PostDataToServer()
        {
            throw new NotImplementedException();
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
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace HMIParking.Models
{
    public class Carro
    {
        public int CarID { get; set; }
        public int PlaceID { get; set; }
        public int FloorID { get; set; }
        public string Owner { get; set; }
        public string LicensePlate { get; set; }
    }
}

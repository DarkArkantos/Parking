using System;
using System.Collections.Generic;
using System.Text;

namespace PLCData.Model
{
    public class Car
    {
        public int CarID { get; set; }
        public int PlaceID { get; set; }
        public int FloorID { get; set; }
        public string Owner { get; set; }
        public string LicensePlate { get; set; }
    }
}

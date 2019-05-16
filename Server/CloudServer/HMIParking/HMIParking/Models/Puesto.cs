using System;
using System.Collections.Generic;
using System.Text;

namespace HMIParking.Models
{
    public class Puesto
    {
        public bool State { get; set; }
        public Carro Carroactual { get; set; }
        public int Numerocarros { get; set; }

    }
}

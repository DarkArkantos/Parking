using System;
using System.Collections.Generic;
using System.Text;

namespace HMIParking.Models
{
    public class Puesto
    {
        public bool State { get; set; }
        public Carrol Carroactual { get; set; }
        public int Numerocarros { get; set; }

        public List<Carrol> ListaCarros { get; set; }

    }
}

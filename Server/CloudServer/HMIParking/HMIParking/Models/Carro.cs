using System;
using System.Collections.Generic;
using System.Text;

namespace HMIParking.Models
{
    public class Carro
    {
        public int Id { get; set; }
        public String Placa { get; set; }
        public DateTime HoraIngreso { get; set; }
        public DateTime HoraSalida { get; set; }
    }
}

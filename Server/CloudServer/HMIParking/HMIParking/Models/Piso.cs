using System;
using System.Collections.Generic;
using System.Text;

namespace HMIParking.Models
{
    public class Piso
    {
        public List<Puesto> Puestos { get; set; }
        public int NumeroCarrosToltal { get; set; }
        public int CarrosActualPiso { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace NewServer_V2.Models
{
    public class Dato
    {
        [Key]
        public int ID { get; set; }
        public int Pos { get; set; }
        public string LicensePlate { get; set; }
        public bool State { get; set; }
    }
}

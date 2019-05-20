using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HMIParking.Models;
namespace HMIParking.Services
{
    public interface IData
    {
        Task<List<Carro>> GetFloors(); //Devuelve los pisos del servidor y de los plcs
    }
}

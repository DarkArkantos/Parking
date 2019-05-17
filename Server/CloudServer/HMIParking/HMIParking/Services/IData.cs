using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HMIParking.Models;
namespace HMIParking.Services
{
    public interface IData
    {
        Task<bool> GetPLCData(); //Obtiene los datos del plc
        Task PostDataToServer(); //Publica los datos del plc al servidor
        Task<List<Piso>> GetPlaces(); //Devuelve los pisos del servidor y de los plcs
    }
}

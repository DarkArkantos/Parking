using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HMIParking.Models;
namespace HMIParking.Services
{
    public interface IData
    {
        Task<List<Puesto>> GetPuesto();
        Task<bool> GetPLCData();
        Task PostDataToServer();
       
    }
}

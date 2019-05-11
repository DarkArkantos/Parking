using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewServer_V2.Models;

namespace Server.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class SendController : ControllerBase
    {
        public SendController()
        {
            DatosTemp = new List<Dato>();
        }
        public List<Dato> DatosTemp { get; set; }
        [HttpPost]
        public void Post(List<Dato> d)
        {
            DatosTemp = d;
        }
        [HttpGet]
        public List<Dato> Get()
        {
            return DatosTemp;
        }
    }
}
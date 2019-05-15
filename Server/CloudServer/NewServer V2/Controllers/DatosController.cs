using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewServer_V2.Models;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DatosController : ControllerBase
    {
        private readonly TempDbContext _context;
        private readonly ParkingDbContext _parkingDbContext;
        private Place[] floors = new Place[32];
        public DatosController(TempDbContext context, ParkingDbContext parkingDbContext)
        {
            _context = context;
            _parkingDbContext = parkingDbContext;
            if (_parkingDbContext.Places.Any())
            {
                return;
            }
            for (int i = 0; i < 32; i++)
            {
                floors[i] = new Place {PlaceId=i+1, PlaceNumber = i + 1, State = false };
            }
            foreach (var item in floors)
            {
                _parkingDbContext.Places.Add(item);
            }
            _parkingDbContext.SaveChangesAsync();
        }

        // GET: api/Datos
        [HttpGet]
        public async Task<IQueryable< Place>> GetTemp()
        {
            return  _parkingDbContext.Places.Include(p=>p.Cars) ;
        }

        // GET: api/Datos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Place>> GetDato(int id)
        {
            var dato = _parkingDbContext.Places.Where(s => s.PlaceId == id).FirstOrDefault();

            if (dato == null)
            {
                return NotFound();
            }

            return dato;
        }

        // PUT: api/Datos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDato(int id, Dato dato)
        {
            if (id != dato.ID)
            {
                return BadRequest();
            }

            _context.Entry(dato).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DatoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Datos
        [HttpPost]
        public async Task<ActionResult<Dato>> PostDato(Dato dato)
        {
            //Gets an instance of a place
            var p = _parkingDbContext.Places.Where(pos => pos.PlaceNumber == dato.Pos).First();
            _parkingDbContext.Cars.Add(new Car { LicensePlate = dato.LicensePlate, Input = DateTime.Now, PlaceId=p.PlaceId });
            p.State = dato.State;
            _parkingDbContext.Entry(p).State = EntityState.Modified;
            await _parkingDbContext.SaveChangesAsync();
            return CreatedAtAction("GetDato", new { id = dato.ID }, dato);
        }

        // DELETE: api/Datos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Dato>> DeleteDato(int id)
        {
            var dato = await _context.Temp.FindAsync(id);
            if (dato == null)
            {
                return NotFound();
            }

            _context.Temp.Remove(dato);
            await _context.SaveChangesAsync();

            return dato;
        }

        private bool DatoExists(int id)
        {
            return _context.Temp.Any(e => e.ID == id);
        }
    }
}

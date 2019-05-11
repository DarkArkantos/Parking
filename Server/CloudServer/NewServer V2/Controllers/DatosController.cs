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
        private Car[] Cars = new Car[32];
        private Connection[] Con = new Connection[32];
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
                floors[i] = new Place { PlaceNumber = i + 1, State = false };
                Cars[i] = new Car { LicensePlate = "asdf", Owner = "N/A", PlaceId = i + 1 };
                Con[i] = new Connection { CarId = i + 1, PlaceId = i + 1 };
            }
            foreach (var item in floors)
            {
                _parkingDbContext.Places.Add(item);
            }
            _parkingDbContext.SaveChangesAsync();
            foreach (var item in Cars)
            {
                _parkingDbContext.Cars.Add(item);
            }
            _parkingDbContext.SaveChangesAsync();
            foreach (var item in Con)
            {
                _parkingDbContext.Conections.Add(item);
            }
            _parkingDbContext.SaveChangesAsync();
        }

        // GET: api/Datos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Place>>> GetTemp()
        {
            return await _parkingDbContext.Places.ToListAsync();
        }

        // GET: api/Datos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Dato>> GetDato(int id)
        {
            var dato = await _context.Temp.FindAsync(id);

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
            var p = _parkingDbContext.Places.Where(pos => pos.PlaceNumber == dato.Pos).First();
            p.State = dato.State;
            _parkingDbContext.Cars.Add(new Car { PlaceId = dato.Pos, LicensePlate = dato.LicensePlate, Input = DateTime.Now });
            _parkingDbContext.SaveChanges();
            var x = _parkingDbContext.Cars.Where(c => c.PlaceId == dato.Pos).First().Id;
            _parkingDbContext.Conections.Add(new Connection { PlaceId = dato.Pos, CarId= x});
            _parkingDbContext.SaveChanges();
            _parkingDbContext.Entry(p).State = EntityState.Modified;
            _context.Temp.Add(dato);
            _context.SaveChanges();
            _parkingDbContext.SaveChanges();
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

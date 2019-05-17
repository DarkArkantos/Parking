using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServerLocal.Model;

namespace ServerLocal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly ParkingDbContext _context;

        public CarsController(ParkingDbContext context)
        {
            _context = context;
            if (!_context.Cars.Any())
            {
                _context.Cars.Add(new Car { FloorID = 1, PlaceID = 1, LicensePlate = "N/A", Owner = "N/A" });
                _context.Cars.Add(new Car { FloorID = 1, PlaceID = 2, LicensePlate = "N/A", Owner = "N/A" });
                _context.Cars.Add(new Car { FloorID = 1, PlaceID = 3, LicensePlate = "N/A", Owner = "N/A" });
                _context.Cars.Add(new Car { FloorID = 1, PlaceID = 4, LicensePlate = "N/A", Owner = "N/A" });
                _context.Cars.Add(new Car { FloorID = 1, PlaceID = 5, LicensePlate = "N/A", Owner = "N/A" });
                _context.Cars.Add(new Car { FloorID = 1, PlaceID = 6, LicensePlate = "N/A", Owner = "N/A" });
                _context.Cars.Add(new Car { FloorID = 1, PlaceID = 7, LicensePlate = "N/A", Owner = "N/A" });
                _context.Cars.Add(new Car { FloorID = 1, PlaceID = 8, LicensePlate = "N/A", Owner = "N/A" });
                //Piso2
                _context.Cars.Add(new Car { FloorID = 2, PlaceID = 1, LicensePlate = "N/A", Owner = "N/A" });
                _context.Cars.Add(new Car { FloorID = 2, PlaceID = 2, LicensePlate = "N/A", Owner = "N/A" });
                _context.Cars.Add(new Car { FloorID = 2, PlaceID = 3, LicensePlate = "N/A", Owner = "N/A" });
                _context.Cars.Add(new Car { FloorID = 2, PlaceID = 4, LicensePlate = "N/A", Owner = "N/A" });
                _context.Cars.Add(new Car { FloorID = 2, PlaceID = 5, LicensePlate = "N/A", Owner = "N/A" });
                _context.Cars.Add(new Car { FloorID = 2, PlaceID = 6, LicensePlate = "N/A", Owner = "N/A" });
                _context.Cars.Add(new Car { FloorID = 2, PlaceID = 7, LicensePlate = "N/A", Owner = "N/A" });
                _context.Cars.Add(new Car { FloorID = 2, PlaceID = 8, LicensePlate = "N/A", Owner = "N/A" });
                //Piso3
                _context.Cars.Add(new Car { FloorID = 3, PlaceID = 1, LicensePlate = "N/A", Owner = "N/A" });
                _context.Cars.Add(new Car { FloorID = 3, PlaceID = 3, LicensePlate = "N/A", Owner = "N/A" });
                _context.Cars.Add(new Car { FloorID = 3, PlaceID = 4, LicensePlate = "N/A", Owner = "N/A" });
                _context.Cars.Add(new Car { FloorID = 3, PlaceID = 5, LicensePlate = "N/A", Owner = "N/A" });
                _context.Cars.Add(new Car { FloorID = 3, PlaceID = 6, LicensePlate = "N/A", Owner = "N/A" });
                _context.Cars.Add(new Car { FloorID = 3, PlaceID = 7, LicensePlate = "N/A", Owner = "N/A" });
                _context.Cars.Add(new Car { FloorID = 3, PlaceID = 7, LicensePlate = "N/A", Owner = "N/A" });
                _context.Cars.Add(new Car { FloorID = 3, PlaceID = 8, LicensePlate = "N/A", Owner = "N/A" });
                //Piso4
                _context.Cars.Add(new Car { FloorID = 4, PlaceID = 1, LicensePlate = "N/A", Owner = "N/A" });
                _context.Cars.Add(new Car { FloorID = 4, PlaceID = 3, LicensePlate = "N/A", Owner = "N/A" });
                _context.Cars.Add(new Car { FloorID = 4, PlaceID = 4, LicensePlate = "N/A", Owner = "N/A" });
                _context.Cars.Add(new Car { FloorID = 4, PlaceID = 5, LicensePlate = "N/A", Owner = "N/A" });
                _context.Cars.Add(new Car { FloorID = 4, PlaceID = 6, LicensePlate = "N/A", Owner = "N/A" });
                _context.Cars.Add(new Car { FloorID = 4, PlaceID = 7, LicensePlate = "N/A", Owner = "N/A" });
                _context.Cars.Add(new Car { FloorID = 4, PlaceID = 7, LicensePlate = "N/A", Owner = "N/A" });
                _context.Cars.Add(new Car { FloorID = 4, PlaceID = 8, LicensePlate = "N/A", Owner = "N/A" });
                _context.SaveChangesAsync();
            }
        }

        // GET: api/Cars
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Car>>> GetCars()
        {
            return await _context.Cars.ToListAsync();
        }

        // GET: api/Cars/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Car>> GetCar(int id)
        {
            var car = await _context.Cars.FindAsync(id);

            if (car == null)
            {
                return NotFound();
            }

            return car;
        }

        // PUT: api/Cars/5
        [HttpPut]
        public async Task<IActionResult> PutCar(Dato car)
        {
            var c = new Car { CarID=int.Parse(car.CarID), FloorID=int.Parse(car.FloorID), LicensePlate=car.LicensePlate, Owner=car.Owner, PlaceID=int.Parse(car.PlaceID)};
            _context.Entry(c).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {

            }

            return NoContent();
        }

        // POST: api/Cars
        [HttpPost]
        public async Task<ActionResult<Car>> PostCar(Car car)
        {
            _context.Cars.Add(car);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCar", new { id = car.CarID }, car);
        }

        // DELETE: api/Cars/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Car>> DeleteCar(int id)
        {
            var car = await _context.Cars.FindAsync(id);
            if (car == null)
            {
                return NotFound();
            }

            _context.Cars.Remove(car);
            await _context.SaveChangesAsync();

            return car;
        }

        private bool CarExists(Car c)
        {
            return _context.Cars.Any(e => e.PlaceID == c.PlaceID&&e.FloorID==c.FloorID);
        }
    }
}

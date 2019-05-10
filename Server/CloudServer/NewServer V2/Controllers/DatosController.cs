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

        public DatosController(TempDbContext context)
        {
            _context = context;
        }

        // GET: api/Datos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dato>>> GetTemp()
        {
            return await _context.Temp.ToListAsync();
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
            _context.Temp.Add(dato);
            await _context.SaveChangesAsync();

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

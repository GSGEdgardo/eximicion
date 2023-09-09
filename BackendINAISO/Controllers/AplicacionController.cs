using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using backendINAISO.Data; // Asegúrate de ajustar esto según la ubicación real de tu contexto
using backendINAISO.Models;

namespace backendINAISO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AplicacionesController : ControllerBase
    {
        private readonly INAISOContextDB _context;

        public AplicacionesController(INAISOContextDB context)
        {
            _context = context;
        }

        // GET: api/Aplicaciones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Aplicacion>>> GetAplicaciones()
        {
            return await _context.Aplicaciones.ToListAsync();
        }

        // GET: api/Aplicaciones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Aplicacion>> GetAplicacion(int id)
        {
            var aplicacion = await _context.Aplicaciones.FindAsync(id);

            if (aplicacion == null)
            {
                return NotFound();
            }

            return aplicacion;
        }

        // POST: api/Aplicaciones
        [HttpPost]
        public async Task<ActionResult<Aplicacion>> PostAplicacion(Aplicacion aplicacion)
        {
            _context.Aplicaciones.Add(aplicacion);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAplicacion), new { id = aplicacion.Id }, aplicacion);
        }

        // PUT: api/Aplicaciones/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAplicacion(int id, Aplicacion aplicacion)
        {
            if (id != aplicacion.Id)
            {
                return BadRequest();
            }

            _context.Entry(aplicacion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AplicacionExists(id))
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

        // DELETE: api/Aplicaciones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAplicacion(int id)
        {
            var aplicacion = await _context.Aplicaciones.FindAsync(id);
            if (aplicacion == null)
            {
                return NotFound();
            }

            _context.Aplicaciones.Remove(aplicacion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AplicacionExists(int id)
        {
            return _context.Aplicaciones.Any(e => e.Id == id);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using backendINAISO.Data;
using backendINAISO.Models;

namespace backendINAISO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly INAISOContextDB _context;

        public UsuariosController(INAISOContextDB context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioViewModel>>> GetUsuarios()
        {
            var usuarios = await _context.Usuarios
                .Include(u => u.Reservas)
                .Select(u => new UsuarioViewModel
                {
                    Id = u.Id,
                    Nombre = u.Name,
                    Reservas = u.Reservas.Select(r => new ReservaViewModel
                    {
                        Id = r.Id,
                        Aplicacion = r.Aplicacion.Clase, // Supongamos que tienes una propiedad "Nombre" en la clase Aplicacion
                        FechaInicio = r.FechaInicio,
                        FechaFin = r.FechaFin
                    }).ToList()
                })
                .ToListAsync();

            return usuarios;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioViewModel>> GetUsuario(int id)
        {
            var usuario = await _context.Usuarios
                .Include(u => u.Reservas)
                .Where(u => u.Id == id)
                .Select(u => new UsuarioViewModel
                {
                    Id = u.Id,
                    Nombre = u.Name,
                    Reservas = u.Reservas.Select(r => new ReservaViewModel
                    {
                        Id = r.Id,
                        Aplicacion = r.Aplicacion.Clase, // Supongamos que tienes una propiedad "Nombre" en la clase Aplicacion
                        FechaInicio = r.FechaInicio,
                        FechaFin = r.FechaFin
                    }).ToList()
                })
                .FirstOrDefaultAsync();

            if (usuario == null)
            {
                return NotFound();
            }

            return usuario;
        }

        [HttpPost]
        public async Task<ActionResult<Usuario>> PostUsuario(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUsuario), new { id = usuario.Id }, usuario);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuario(int id, Usuario usuario)
        {
            if (id != usuario.Id)
            {
                return BadRequest();
            }

            _context.Entry(usuario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioExists(id))
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }

            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UsuarioExists(int id)
        {
            return _context.Usuarios.Any(e => e.Id == id);
        }
    }
}

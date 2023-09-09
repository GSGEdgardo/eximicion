using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using backendINAISO.Data;
using backendINAISO.Models;

namespace backendINAISO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservasController : ControllerBase
    {
        private readonly INAISOContextDB _context;

        public ReservasController(INAISOContextDB context)
        {
            _context = context;
        }
        [HttpGet("reporteReservasPorUsuario")]
        public IActionResult GetReporteReservasPorUsuario()
        {
            var reporte = _context.Reservas
                .Include(r => r.Usuario)
                .Include(r => r.Aplicacion)
                .GroupBy(r => r.Usuario)
                .Select(group => new
                {
                    UsuarioId = group.Key.Id,
                    UsuarioNombre = group.Key.Name,
                    Reservas = group.Select(r => new
                    {
                        Id = r.Id,
                        UsuarioId = r.UsuarioId,
                        AplicacionId = r.AplicacionId,
                        ClaseAplicacion = r.Aplicacion.Clase,
                        FechaInicio = r.FechaInicio,
                        FechaFin = r.FechaFin
                    })
                })
                .ToList();

            return Ok(reporte);
        }
        [HttpGet("reporteReservasPorAplicacion")]
        public IActionResult GetReporteReservasPorAplicacion()
        {
            var reporte = _context.Reservas
                .Include(r => r.Usuario)
                .Include(r => r.Aplicacion)
                .GroupBy(r => r.Aplicacion)
                .Select(group => new
                {
                    AplicacionId = group.Key.Id,
                    ClaseAplicacion = group.Key.Clase,
                    Reservas = group.Select(r => new
                    {
                        Id = r.Id,
                        UsuarioId = r.UsuarioId,
                        UsuarioNombre = r.Usuario.Name,
                        FechaInicio = r.FechaInicio,
                        FechaFin = r.FechaFin
                    })
                })
                .ToList();

            return Ok(reporte);
        }

    }
}

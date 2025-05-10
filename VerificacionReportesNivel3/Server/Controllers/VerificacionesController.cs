using Microsoft.AspNetCore.Mvc;
using VerificacionReportesNivel3.Server.Data;
using VerificacionReportesNivel3.Server.DTOs;
using VerificacionReportesNivel3.Server.Models;

namespace VerificacionReportesNivel3.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VerificacionesController : Controller
    {
        private readonly AppDbContext _context;

        public VerificacionesController(AppDbContext context)
        {
            _context = context;
        }

        // POST: api/verificaciones/verificar
        [HttpPost("verificar")]
        public async Task<IActionResult> Verificar([FromBody] VerificacionesRequest request)
        {
            bool contieneNombre = request.Texto.Contains(request.Nombre ?? "", StringComparison.OrdinalIgnoreCase);

            var verificacion = new Verificacion
            {
                CedulaCliente = request.CedulaCliente,
                ContieneNombre = contieneNombre
            };

            _context.Verificaciones.Add(verificacion);
            await _context.SaveChangesAsync();

            return Ok(new { contieneNombre });

        }

        // 
        [HttpGet("reporte")]
        public IActionResult GetReporte()
        {
            int totalConNombre = _context.Verificaciones.Count(v => v.ContieneNombre);
            int totalSinNombre = _context.Verificaciones.Count(v => !v.ContieneNombre);

            double relacion = totalConNombre == 0 ? 0 : (double)totalConNombre / totalSinNombre;

            return Ok(new
            {
                cuenta_contieneNombre = totalConNombre,
                cuenta_noContieneNombre = totalSinNombre,
                relacion
            }
            );
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}

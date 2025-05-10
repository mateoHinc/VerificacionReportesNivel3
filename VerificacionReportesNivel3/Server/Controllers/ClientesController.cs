using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VerificacionReportesNivel3.Server.Data;
using VerificacionReportesNivel3.Server.DTOs;

namespace VerificacionReportesNivel3.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientesController : Controller
    {
        private readonly AppDbContext _context;

        public ClientesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("resumen")]
        public async Task<IActionResult> GetResumen()
        {
            var resumen = await _context.Clientes
                .Select(c => new ClienteResumenDto
                {
                    Cedula = c.Cedula,
                    Nombre = c.Nombre,
                    CantidadFacturas = _context.Facturas
                        .Where(f => f.Cliente == c.Cedula)
                        .Select(f => f.NoFactura)
                        .Distinct()
                        .Count(),

                    ValorTotal = _context.Facturas
                        .Where(f => f.Cliente == c.Cedula)
                        .Join(_context.Productos,
                              f => f.Producto,
                              p => p.IdProducto,
                              (f, p) => p.Valor)
                        .Sum()
                }).ToListAsync();

            return Ok(resumen);
        }

        [HttpGet("articulo-mas-caro/{cedula}")]
        public async Task<ActionResult<ArticuloCaroDto>> GetArticuloMasCaro(string cedula)
        {
            var resultado = await _context.ArticuloCaro
                .FromSqlRaw("EXEC ObtenerArticuloMasCaroPorCliente @Cedula = {0}", cedula)
                .ToListAsync();

            if (resultado == null || !resultado.Any())
            {
                return NotFound();
            }

            return Ok(resultado.First());
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PanaderiaAPI.Data;
using PanaderiaAPI.Models;

namespace PanaderiaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly PanaderiaContext _context;

        public ProductosController(PanaderiaContext context)
        {
            _context = context;
        }

        // GET: api/productos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Producto>>> GetProductos()
        {
            // El .Include garantiza que al pedir los panes, también traiga sus ingredientes
            return await _context.Productos
                                 .Include(p => p.Ingredientes)
                                 .ToListAsync();
        }

        // GET: api/productos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Producto>> GetProducto(int id)
        {
            var producto = await _context.Productos
                                         .Include(p => p.Ingredientes)
                                         .FirstOrDefaultAsync(p => p.Id == id);

            if (producto == null)
            {
                return NotFound();
            }

            return producto;
        }

        // POST: api/productos
        [HttpPost]
        public async Task<ActionResult<Producto>> PostProducto(Producto producto)
        {
            _context.Productos.Add(producto);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProducto), new { id = producto.Id }, producto);
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using PiaTienda.Entidades;
using Microsoft.EntityFrameworkCore;

namespace PiaTienda.Controllers
{
    [ApiController]
    [Route("api/ventas")]
    public class VentasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VentasController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("/Listado")]
        public async Task<ActionResult<List<Ventas>>> GetAll()
        {
            return await _context.Ventas.ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Ventas>> GetById(int id)
        {
            return await _context.Ventas.FirstOrDefaultAsync(x => x.Id == id);
        }

        [HttpPost]
        public async Task<ActionResult> Post(Ventas ventas)
        {
            var existe = await _context.Ventas.AnyAsync(x => x.Id == ventas.ClienteId);
            if (existe)
            {
                return BadRequest("El cliente no existe");
            }

            _context.Add(ventas);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, Ventas ventas)
        {
            var existe = await _context.Ventas.AnyAsync(x => x.Id == ventas.ClienteId);

            if (!existe)
            {
                return BadRequest("El cliente no existe");
            }

            if (id != ventas.Id)
            {
                return BadRequest("El id no coincide con lo establecido en la URL");
            }

            _context.Update(ventas);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await _context.Ventas.AnyAsync(x => x.Id == id);

            if (!existe)
            {
                return BadRequest("El cliente no existe");
            }

            _context.Remove(new Ventas() { Id = id });
            await _context.SaveChangesAsync();
            return Ok();
        }
        
    }
}

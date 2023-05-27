using Microsoft.EntityFrameworkCore;
using PiaTienda.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace PiaTienda.Controllers
{
    [ApiController]
    [Route("api/distribuidores")]
    public class DistribuidoresController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DistribuidoresController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Distribuidores>> GetById(int id)
        {
            return await _context.Distribuidores.FirstOrDefaultAsync(x => x.Id == id);
        }

        [HttpGet("/Lista Distribuidores")]
        public async Task<ActionResult<List<Distribuidores>>> GetAll()
        {
            return await _context.Distribuidores.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult> Post(Distribuidores distribuidores)
        {
            var existeDistribuidor = await _context.Distribuidores.AnyAsync(x => x.NombreDistribuidor == distribuidores.NombreDistribuidor);
            if (existeDistribuidor)
            {
                return BadRequest("El distribuidor ya existe");
            }
            
            _context.Add(distribuidores);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, Distribuidores distribuidores)
        {
            if (id != distribuidores.Id)
            {
                return BadRequest("El id no coincide con lo establecido en la URL");
            }

            _context.Update(distribuidores);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
           var existe = await _context.Distribuidores.AnyAsync(x => x.Id == id);
            if (!existe)
            {
                return NotFound("No se encontro en la base de datos");
            }

            _context.Remove(new Distribuidores() { Id = id });
            await _context.SaveChangesAsync();
            return Ok();
        }

    }
}
